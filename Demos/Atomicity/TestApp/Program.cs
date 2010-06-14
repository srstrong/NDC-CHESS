using System;
using Atomicity;
using Utils;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("usage: TestApp iterations");
                return;
            }

            for (var i = 0; i < int.Parse(args[0]); i++)
            {
                var a = new Account();

                Parallel.Invoke(() => a.Credit(100),
                                () => a.Debit(50));

                Console.WriteLine(a.CurrentBalance == 50 ? "Pass {0}" : "Fail {0}", i);

                if (a.CurrentBalance != 50)
                {
                    return;
                }
            }
            Console.WriteLine("Passed having run {0} iterations", args[0]);
        }
    }
}
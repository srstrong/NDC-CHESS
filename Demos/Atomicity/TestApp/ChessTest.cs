using System;
using Atomicity;
using Utils;

namespace TestApp
{
    class ChessTest
    {
        public static bool Run()
        {
            var a = new Account();

            Parallel.Invoke(() => a.Credit(100),
                            () => a.Debit(50));

            Console.WriteLine(a.CurrentBalance == 50 ? "Pass" : "Fail");

            return a.CurrentBalance == 50;
        }
    }
}   
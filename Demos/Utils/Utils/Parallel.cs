using System;
using System.Linq;
using System.Threading;

namespace Utils
{
    public static class Parallel
    {
        public static void Invoke(params Action[] actions)
        {
            var threads = actions.Select(action => new Thread(() => action())).ToList();

            threads.ForAll(thread => thread.Start())
                .ForAll(thread => thread.Join());
        }
    }
}
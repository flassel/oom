using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace Task6
{
    public static class Push_Pull
    {
        public static void Run(Country [] countries)
        {
            var source = new Subject<string>();

            source
                .Sample(TimeSpan.FromSeconds(1.0))
                .Where(x => x == "Austria")
                .Subscribe(x => Console.WriteLine($"received {x}"))
                ;

            var t = new Thread(() =>
            {
                while (true)
                {

                    foreach (var a in countries)
                    {
                        Thread.Sleep(250);
                        source.OnNext(a.Name);
                        Console.WriteLine("sent {0,-40}", a.Name);
                    }

                }
            });
            t.Start();
        }
    }
}

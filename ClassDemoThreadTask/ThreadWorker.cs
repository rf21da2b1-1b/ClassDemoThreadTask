using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClassDemoThreadTask
{
    public class ThreadWorker
    {
        // Static fields are shared between all threads
        private static bool done = false;    


        public ThreadWorker()
        {
        }

        public void Start()
        {
            //StartThreadTest();

            StartTaskTest();
        }


        /*
         *
         * THREADS
         *
         */

        private void StartThreadTest()
        {
            // start thread
            Thread t = new Thread(Go);
            t.Start();

            // normal method call
            Go();

            Thread t2 = new Thread(() => { Console.WriteLine("Hej"); });
            Thread t3 = new Thread(StartThread);

            t2.Start();
            t3.Start();
        }

        private void StartThread()
        {
            Console.WriteLine("Peter");

        }

        private void Go()
        {
            if (!done) {  Console.WriteLine("Done"); done = true; }
        }



        /*
         *
         * TASKS
         *
         */

        private void StartTaskTest()
        {
            Task t = Task.Run(() => DoWork("Number One", ConsoleColor.Red));
            //Task.WaitAll(t);
            Task.Run(() => DoWork("Number Two", ConsoleColor.Green));
        }

        private void DoWork(String name, ConsoleColor colour)
        {
            for (int i = 0; i < 30; i++)
            {
                Console.ForegroundColor = colour;
                Console.WriteLine($"Name {name} no={i}");
            }
        }
    }
}
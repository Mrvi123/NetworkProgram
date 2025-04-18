using System;
using System.Threading;
namespace SamplePool
{
    internal class ThreadPoolSample
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            ThreadPoolSample tps = new ThreadPoolSample();

        }

        public ThreadPoolSample()
        {
            int i;
            ThreadPool.QueueUserWorkItem(new WaitCallback(Counter1));
            ThreadPool.QueueUserWorkItem(new WaitCallback(Counter2));
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine("main: {0}", i);
                Thread.Sleep(100);
            }
            Console.ReadKey();
        }

        void Counter1(object state)
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine("thread 1: {0}", i);
                Thread.Sleep(200);
            } 
        }

        void Counter2(object state) 
        {
            int i;
            for(i = 0; i < 10; i++)
            {
                Console.WriteLine("\nthread 2: {0}", i);
                Thread.Sleep(300);
            }

        }
    }
}



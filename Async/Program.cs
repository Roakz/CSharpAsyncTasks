using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an action delegate to be passed to the Task constructor.
            Action asyncDelayedCountAction = () =>
            {
                Console.WriteLine("Starting to count...");

                //Hello from this Thread
                Console.WriteLine($"Async task thread: {Thread.CurrentThread.ManagedThreadId}");
                for(int i = 0; i < 10; i++)
                    {
                        Console.WriteLine($"{i}");
                        Task.Delay(3000).Wait();
                    }
            };

            //Create a task using the action delegate to assign its functionality.
            Task asyncCountTask = new Task(asyncDelayedCountAction);
            Console.WriteLine("Task created But not started");

            //Start the asynchronous task.
            asyncCountTask.Start();
            Console.WriteLine("I am synchronously coded after the Task has been started!");

            //Hello from the main thread
            Console.WriteLine($" Main thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.Read();
        }
    }
}

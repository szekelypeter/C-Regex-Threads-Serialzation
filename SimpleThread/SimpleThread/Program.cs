using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleThread
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart starter = new ThreadStart(Counting);
            Thread first = new Thread(starter);
            Thread second = new Thread(starter);

            first.Start();
            second.Start();

            first.Join();
            second.Join();

            Console.Read();

    /*        Mutex oneMutex = null;
            const string MutexName = "RUNMEONLYONCE";

            try // Try and open the Mutex
            {
                oneMutex = Mutex.OpenExisting(MutexName);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                // Cannot open the mutex because it doesn't exist
            }

            // Create it if it doesn't exist
            if (oneMutex == null)
            {
                oneMutex = new Mutex(true, MutexName);
            }
            else
            {
                // Close the mutex and exit the application
                // because we can only have one instance
                oneMutex.Close();
                return;
            }

            Console.WriteLine("Our Application");
            Console.Read();*/
        }

        static void Counting()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Count: {0} - Thread: {1}",
                                    i,
                                    Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }
    }
}

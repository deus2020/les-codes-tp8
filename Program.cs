using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Forks
{
    class Program
    {
        static void Main(string[] args)
        {
            //semaphore s = new semaphore();
            //s.semaph();
            Forkss fk = new Forkss();
            fk.Put(1,1);
            //fk.PercentageTakenLeft.ToString();
            //fk.PercentageTakenRight.ToString();
                       
            Console.ReadKey();
        }
    }
}

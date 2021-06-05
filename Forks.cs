using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class Forkss
{
    bool[] fork = new bool[5]; // initially false, i.e. not used
    public double STEPS = 8;
    public  double   PercentageTakenLeft;
    public  double PercentageTakenRight;

    // Try to pick up the forks with the designated numbers
    public void Get(int left, int right)
    {
        lock (this)
        {
            while (fork[left] || fork[right])
            {
                //Monitor.Wait(this);
                ReturnBothSticks();
                Put(1,2);
                fork[left] = true;
                fork[right] = true;
            }
        }
    }

    // Lay down the forks with the designated numbers
    public void Put(int left, int right)
    {
        lock (this)
        {
            fork[left] = false;
            TakeBothSticks();
            fork[right] = false;
            ReturnBothSticks();
            Monitor.PulseAll(this);
        }
    }
   public void TakeBothSticks()
    {
        for (int i = 0; i < STEPS; i++)
        {
            
            PercentageTakenLeft += 1.0 / STEPS;
            PercentageTakenRight += 1.0 / STEPS;
            Thread.Sleep(100);
            Console.WriteLine(PercentageTakenLeft);
            Thread.Sleep(100);
            Console.WriteLine(PercentageTakenRight);

        }
    }

   public void ReturnBothSticks()
    {
        for (int i = 0; i < STEPS; i++)
        {
            Thread.Sleep(100);
            PercentageTakenLeft -= 1.0 / STEPS;
            Thread.Sleep(100);
            PercentageTakenRight -= 1.0 / STEPS;
        }
    }
}
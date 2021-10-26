using System;

namespace Homework1_Entertainment_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator s = new Simulator();
            int FINAL_DAY = 35;
       
            s.test();
            for (int day = 1; day <= FINAL_DAY; day++)
            {
              s.Day();
                //we don't run the final night
                if(day < FINAL_DAY)
                {
                    s.Night();
                }
            }
            Console.WriteLine("");
            s.Report();
        }
    }
}


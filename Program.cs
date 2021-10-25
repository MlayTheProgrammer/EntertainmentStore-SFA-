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
                if(s.night < 35)
                {
                    s.Night();
                }

            }     
            s.Report(); // Im not sure why you removed this but I brought it back up since it was in the requirements 
        }
    }
}


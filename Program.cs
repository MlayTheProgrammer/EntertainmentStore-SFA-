using System;

namespace Homework1_Entertainment_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator s = new Simulator();
            int FINAL_DAY = 35;

            int day = 0;
            while (++day <= FINAL_DAY)
            {
                s.Tick();
            }
            s.Report(); // Im not sure why you removed this but I brought it back up since it was in the requirements 

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Homework1_Entertainment_Store
{
    public class Newbie : ICustomerBehavior
    {
        public int GenNumGamesToRent()
        {
            return new Random().Next(1, 3);
        }
        public int GenNumNightsToRent()
        {
            return new Random().Next(1, 3);
        }
    }
    public class Professional : ICustomerBehavior
    {
        public int GenNumGamesToRent()
        {
            return new Random().Next(1, 4);
        }
        public int GenNumNightsToRent()
        {
            return new Random().Next(3, 6);
        }
    }
    public class Hardcore : ICustomerBehavior
    {
        public int GenNumGamesToRent()
        {
            return 3;
        }
        public int GenNumNightsToRent()
        {
            return 7;
        }
    }
}

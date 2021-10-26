//Coded by Carl
using System;

namespace Homework1_Entertainment_Store
{

        public class Newbie : ICustomerBehavior
        {
            //=======METHODS======
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
            //=======METHODS======
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
            //=======METHODS======
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


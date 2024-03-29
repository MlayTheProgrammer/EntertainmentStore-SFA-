﻿//Coded by Carl
using System;
using System.Collections.Generic;

namespace Homework1_Entertainment_Store
{
    class Simulator
    {
        //=======FIELDS=======
        private List<ICustomer> customers;  // A list of customers that will visit the store.
        private IStore store;               // The video game rental store.
        private int NUM_CUSTOMERS = 10;     // The number of customers that will be generated for the simulaton.
        private int NUM_GAMES = 20;         // The number of games that will be generated for the simulation.
        private int day;                    // The number of days that have been simulated.
        private int night;                  // The number of nights that have been simulated.

        //=======CTORS========
        public Simulator()
        {
            this.day = 1;
            this.night = 1;

            this.store = new Store();
            this.customers = new List<ICustomer>();
            //populate customer list and store stock

            //set prices that the factory will use to produce games
            Dictionary<EGenre, double> prices = new Dictionary<EGenre, double>();
            prices.Add(EGenre.ACTION, 5);
            prices.Add(EGenre.ADVENTURE, 6);
            prices.Add(EGenre.BOARD_GAME, 7);
            prices.Add(EGenre.CASUAL, 4);
            prices.Add(EGenre.NEW_RELEASE, 10);

            //populate store
            GameFactory gf = new GameFactory(prices);
            for (int i = 0; i < NUM_GAMES; i++)
            {
                this.store.AddToStock(gf.CreateGame());
            }

            //populate customers
            CustomerFactory cf = new CustomerFactory();
            for (int i = 0; i < NUM_CUSTOMERS; i++)
            {
                this.customers.Add(cf.CreateCustomer());
            }
        }

        //=======METHODS======
        public void test() 
        {
            // Prints the number of games the store has in stock, and the list of customers that exist.

            Console.WriteLine("All The Games In Stock: \n");
            foreach (IGame g in this.store.GetStock())
            {
                Console.WriteLine(g);
            }
            Console.WriteLine("\nAll The Customers: \n");
            foreach (ICustomer c in this.customers)
            {
                    Console.WriteLine( c); 
            }
            Console.WriteLine("");
        }

        public void Day()
        {
            // Runs one day of the simulation.

            Console.WriteLine("Start of day " + this.day + ":");
            Returns();
            Console.WriteLine("\nEnd of day " + this.day + ".");
            Console.WriteLine("--------------"); 
            day++; 
        }

        public void Night()
        {
            // Runs one night of the simulation.

            Console.WriteLine("Start of night " + this.night + ":");
            Rentals();
            Console.WriteLine("\nEnd of night " + this.night + ".");
            Console.WriteLine("--------------");
            night++;
        }

        public void Report()
        {
            // Prints the store's stock, income, completed rentals, and active rentals.

            Console.WriteLine("GAMES STILL IN STORE:");
            foreach (IGame g in store.GetStock())
            {
                Console.WriteLine(g);
            }
            Console.WriteLine("\nTOTAL STORE INCOME:");
            Console.WriteLine("{0:0.00}", store.GetIncome());
            Console.WriteLine("\nCOMPLETED RENTALS:");
            foreach (IRental r in store.GetCompletedRentals())
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("\nACTIVE RENTALS:");
            foreach (IRental r in store.GetActiveRentals())
            {
                Console.WriteLine(r);
            }
        }

        //=======HELPERS======
        private void Rentals()
        {
            // Procedure for customers renting games from the store.

            if (store.HasGames())
            {
                //put a random selection of customers into a list
                Random rand = new Random();
                Queue<ICustomer> storeQueue = new Queue<ICustomer>();
                int numCustomers = rand.Next(0, this.customers.Count);
                while (storeQueue.Count < numCustomers)
                {
                    int index = rand.Next(0, this.customers.Count);
                    if (!storeQueue.Contains(this.customers[index]))
                    {
                        storeQueue.Enqueue(this.customers[index]);
                    }
                }
                //for each customer, roll their behavior, check if they can go to the store, then go to the store if able
                foreach (ICustomer c in storeQueue)
                {
                    c.RollBehavior();
                    if (c.CanRent(this.store.NumGamesInStock()))
                    {
                        //they enter store, rent some games, and pay
                        IRental r = c.CreateRental(this.day);
                        this.store.PopulateRental(r);

                        Console.WriteLine("\n"+c + " : CREATED RENTAL:");
                        Console.WriteLine(r);
                        store.AcceptPayment(c.PayFor(r));
                    }
                    else
                    {
                        Console.WriteLine("\n"+c + " : DECLINED RENTAL: Games Rented at Maximum Capacity.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nSTORE CLOSED: Currently no games are available, please come again later.");
            }
        }
        private void Returns()
        {
            // Procedure for customers returning games.

            foreach (ICustomer c in this.customers)
            {
                List<IRental> returns = c.ReturnGames(this.day);
                foreach (IRental r in returns)
                {
                    this.store.Restock(r);
                    Console.WriteLine("\n"+c + ": RENTAL RETURN:");
                    Console.WriteLine(r);
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace Homework1_Entertainment_Store
{
    class Simulator
    {
        private List<ICustomer> customers;
        private IStore store;
        private int NUM_CUSTOMERS = 10;
        private int NUM_GAMES = 20;
        private int day;
        private int night;
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
        public void Tick()
        {
            for (int i = 0; i <= 1; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("\nStart of Day " + this.day + ":\n");
                }
                if (i == 1)
                {
                    if (this.night < 35)
                    {
                        Console.WriteLine("\nStart of night " + this.night + ":\n");
                    }
                }
                //return any games at the start of each day
                foreach (ICustomer c in this.customers)
            {
                List<IRental> returns = c.ReturnGames(this.day);
                foreach (IRental r in returns)
                {
                    this.store.Restock(r);
                    Console.WriteLine(c+": RENTAL RETURN:");
                    Console.WriteLine(r+"\n");
                }
            }
            //rent games
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
                        Console.WriteLine(c+" : CREATED RENTAL:");
                        Console.WriteLine(r+"\n");
                        store.AcceptPayment(c.PayFor(r));
                    }
                        else
                        {
                            Console.WriteLine(c + "  Games Rented at Maximum Capacity "); // Reggie Coded this

                        }
                    }
                    if (i == 0)
                    {
                        Console.WriteLine("End of Day " + this.day);
                    }
                    if (i == 1)
                    {
                        if (this.night < 35)
                        {
                            Console.WriteLine("End of night " + this.night);
                        }

                    }
                    Console.WriteLine("----------------");
                }

            }
            day++;
            night++;
        }
        public void Report()
        {
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
    }
}


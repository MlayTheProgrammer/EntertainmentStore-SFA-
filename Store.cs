//Coded by Reggie
using System;
using System.Collections.Generic;

namespace Homework1_Entertainment_Store
{

    public class Store : IStore
    {
        //=======FIELDS=======
        private List<IGame> stock;              // A list of video games currently in stock
        private List<IRental> completedRentals; // A list of rentals that have been returned
        private List<IRental> activeRentals;    // A list of rentals that are currently out of store
        private double income;                  // Total money store has earned from rentals

        //=======CTORS========
        public Store()
        {
            this.stock = new List<IGame>();
            this.completedRentals = new List<IRental>();
            this.activeRentals = new List<IRental>();
            this.income = 0;
        }

        //=======METHODS======

        public bool HasGames()
        {
            // Returns whether the store has any games in stock.

            return this.stock.Count > 0;
        }

        public double GetIncome()
        {
            // Returns the current total income.

            return this.income;
        }

        public List<IGame> GetStock()
        {
            // Returns the current stock of games.

            return this.stock;
        }

        public int NumGamesInStock()
        {
            // Returns the number of games the store has in stock.

            return this.stock.Count;
        }

        public void AddToStock(IGame g)
        {
            // Adds the given game to the stock.
            // 
            this.stock.Add(g);
        }

        public void AcceptPayment(double money)
        {
            // Increments income by the given amount.

            this.income += money;
        }

        public List<IRental> GetActiveRentals()
        {
            // Returns a list of the currently active rentals.

            return this.activeRentals;
        }

        public List<IRental> GetCompletedRentals()
        {
            // Returns a list of the completed rentals.

            return this.completedRentals;
        }

        public void Restock(IRental r)
        {
            // Returns the games in the given rental to stock, then stores the rental in the list completed rentals.

            if (activeRentals.IndexOf(r) == -1)
            {
                throw new Exception("attempting to return a rental that the store never checked out.");
            }
            foreach (IGame g in r.GetGames())
            {
                AddToStock(g);
            }
            activeRentals.Remove(r);
            completedRentals.Add(r);
        }

        public void PopulateRental(IRental r)
        {
            // Adds random games to the given rental until it is filled.

            Random rand = new Random();
            while (!r.Populated())
            {
                int index = rand.Next(0, stock.Count);
                r.AddGame(stock[index]);
                stock.RemoveAt(index);
            }
            activeRentals.Add(r);
        }
    }
}

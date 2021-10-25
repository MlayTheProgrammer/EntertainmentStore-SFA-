using System;
using System.Collections.Generic;

namespace Homework1_Entertainment_Store
{

    public class Store : IStore
    {
        private List<IGame> stock;
        private List<IRental> completedRentals;
        private List<IRental> activeRentals;
        private double income;

        public Store()
        {
            this.stock = new List<IGame>();
            this.completedRentals = new List<IRental>();
            this.activeRentals = new List<IRental>();
            this.income = 0;
        }

        public void AddToStock(IGame g)
        {
            this.stock.Add(g);
        }

        public bool HasGames()
        {
            return this.stock.Count > 0;
        }

        public int NumGamesInStock()
        {
            return this.stock.Count;
        }

        public void Restock(IRental r)
        {
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
            Random rand = new Random();
            while (!r.Populated())
            {
                int index = rand.Next(0, stock.Count);
                r.AddGame(stock[index]);
                stock.RemoveAt(index);
            }
            activeRentals.Add(r);
        }

        public void AcceptPayment(double money)
        {
            this.income += money;
        }

        public List<IGame> GetStock()
        {
            return this.stock;
        }

        public double GetIncome()
        {
            return this.income;
        }

        public List<IRental> GetActiveRentals()
        {
            return this.activeRentals;
        }
        public List<IRental> GetCompletedRentals()
        {
            return this.completedRentals;
        }
    }
}

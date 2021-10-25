using System.Collections.Generic;
using System;

namespace Homework1_Entertainment_Store
{
    public class Customer : ICustomer
    {
        private int MAX_RENTALS = 3;
        private string name;
        private ICustomerBehavior behavior;
        private List<IRental> rentals;
        private int numGamesToRent;
        private int numNightsToRent;

        public Customer(string name, ICustomerBehavior behavior)
        {
            this.name = name;
            this.behavior = behavior;
            this.rentals = new List<IRental>();
            RollBehavior();
            Console.WriteLine("Customer<" + this.name + ", " + this.behavior.GetType().Name + ">"); 
        }
        public string GetName()
        {
            return this.name;
        }
        public void RollBehavior()
        {
            this.numGamesToRent = this.behavior.GenNumGamesToRent();
            this.numNightsToRent = this.behavior.GenNumNightsToRent();
        }
        private int numGamesRented()
        {
            int count = 0;
            foreach (IRental r in this.rentals)
            {
                foreach (IGame g in r.GetGames())
                {
                    count++;
                }
            }
            return count;
        }
        public IRental CreateRental(int day)
        {
            return new Rental(day, this.numGamesToRent, this.numNightsToRent, this.name);
        }
        public double PayFor(IRental r)
        {
            this.rentals.Add(r);
            return r.GetTotalCost();
        }
        public List<IRental> ReturnGames(int day)
        {
            List<IRental> returns = new List<IRental>();
            foreach (IRental r in this.rentals)
            {
                if (r.IsDueOn(day))
                {
                    returns.Add(r);
                }
            }
            foreach (IRental r in returns)
            {
                this.rentals.Remove(r);
            }
            return returns;
        }
        /*public override string ToString()
        {
            string games = "";
            foreach (IRental r in rentals)
            {
                foreach (IGame g in r.GetGames())
                {
                    games += g.GetName() + ", ";
                }
            }
            return name + ": " + games.Substring(0, (games.Length - 2 < 0 ? 0 : games.Length - 2));
        }*/
        public override string ToString()
        {
            return "Customer<" + this.name + ", "+this.behavior.GetType().Name+">";
        }
        public bool CanRent(int storeStock)
        {
            return ((MAX_RENTALS - numGamesRented()) <= storeStock) && (this.numGamesToRent <= storeStock) && ((MAX_RENTALS - numGamesRented()) >= this.numGamesToRent);
        }
    }
}

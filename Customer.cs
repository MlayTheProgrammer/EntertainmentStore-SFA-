using System.Collections.Generic;
using System;

namespace Homework1_Entertainment_Store
{
    public class Customer : ICustomer
    {
        //=======FIELDS=======
        private int MAX_RENTALS = 3;        // maximum number of rentals a customer can have
        private string name;                // customer's first name
        private ICustomerBehavior behavior; // renting startegy of a customer
        private List<IRental> rentals;      // list of rentals tha a customer currently has
        private int numGamesToRent;         // the number of games a customer will rent if given the opportunity.
        private int numNightsToRent;        // the number of nights a customer will rent games for if given the oppotunity.

        //=======CTORS========
        public Customer(string name, ICustomerBehavior behavior)
        {
            this.name = name;
            this.behavior = behavior;
            this.rentals = new List<IRental>();
            RollBehavior();
        }

        //=======METHODS======
        public string GetName()
        {
            // Returns the first name of the customer.

            return this.name;
        }
        public bool CanRent(int storeStock)
        {
            // Returns whether or not the customer is allowed to rent games:
            // The number of games that a customer can rent must be less than or equal to the given number of games a store has in stock.
            // The number of games the customer wants to rent must be less than or equal to the given number of games a store has in stock.
            // The number of games a customer wants to rent must be less than or equal to the number of games a customer can rent.

            return ((MAX_RENTALS - numGamesRented()) <= storeStock) && (this.numGamesToRent <= storeStock) && ((MAX_RENTALS - numGamesRented()) >= this.numGamesToRent);
        }
        public void RollBehavior()
        {
            // Generates the number of games and nights that a customer will rent, and assigns them.

            this.numGamesToRent = this.behavior.GenNumGamesToRent();
            this.numNightsToRent = this.behavior.GenNumNightsToRent();
        }

        public IRental CreateRental(int day)
        {
            // Generates and returns a new rental request for the given day, to be populated with games by a store.

            return new Rental(day, this.numGamesToRent, this.numNightsToRent, this.name);
        }
        public double PayFor(IRental r)
        {
            // Adds the given rental to the list of rentals that the customer has, then returns the cost (paying for it).

            this.rentals.Add(r);
            return r.GetTotalCost();
        }
        public List<IRental> ReturnGames(int day)
        {
            // Iterates through all rentals and removes and adds to a list any that are due on the given day, then returns them.

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

        public override string ToString()
        {
            return "Customer<" + this.name + ", "+this.behavior.GetType().Name+">";
        }

        //=======HELPERS======
        private int numGamesRented()
        {
            // Returns the number of games that the customer currently has rented.

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

    }
}

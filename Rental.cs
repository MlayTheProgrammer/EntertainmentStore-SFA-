//Coded by Reggie
using System.Collections.Generic;


namespace Homework1_Entertainment_Store
{
    public class Rental : IRental
    {
        //=======FIELDS=======
        private int rentedOn;       // The day the rental was created.
        private int numGames;       // The number of games the rental requires.
        private int nightsRented;   // The number of nights the rental will be rented for.
        private string custName;    // The name of the customer that rented the games.
        private List<IGame> games;  // A list of the games rented.

        //=======CTORS========
        public Rental(int rentedOn, int numGames, int nightsRented, string custName)
        {
            this.numGames = numGames;
            this.nightsRented = nightsRented;
            this.custName = custName;
            this.games = new List<IGame>();
            this.rentedOn = rentedOn;
        }

        //=======METHODS======
        public bool IsDueOn(int day)
        {
            // Returns whether the rental is due on the given day.

            return (this.rentedOn + this.nightsRented) == day;
        }

        public bool Populated()
        {
            // Returns whether the rental has been filled with the requested number of games.

            return numGames == games.Count;
        }

        public List<IGame> GetGames()
        {
            // Returns the list of games in the rental.

            return this.games;
        }

        public double GetTotalCost()
        {
            // Returns the total cost of renting the games over the duration of the rental.

            double output = 0;
            foreach (IGame g in games)
            {
                output += g.GetPricePerDay();
            }
            return output *= this.nightsRented;
        }

        public void AddGame(IGame g)
        {
            // Adds a game to the rental.

            this.games.Add(g);
        }

        public override string ToString()
        {
            // Which games were rented by which customer for how many days along with the total amount of that rental.

            string output = this.custName + " rented " + this.numGames + " games on day " + this.rentedOn + " for " + this.nightsRented + " nights.";
            foreach(IGame g in games)
            {
                output += "\n" + g;
            }
            output += "\nTotal Cost of rental is: $" + GetTotalCost();
            return output;
        }
    }
}

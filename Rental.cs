using System.Collections.Generic;


namespace Homework1_Entertainment_Store
{
    public class Rental : IRental
    {
        private int rentedOn;
        private int numGames;
        private int nightsRented;
        private string custName;
        private List<IGame> games;
        public Rental(int rentedOn, int numGames, int nightsRented, string custName)
        {
            this.numGames = numGames;
            this.nightsRented = nightsRented;
            this.custName = custName;
            this.games = new List<IGame>();
            this.rentedOn = rentedOn;
        }
        public bool IsDueOn(int day)
        {
            return (this.rentedOn + this.nightsRented) == day;
        }

        public void AddGame(IGame g)
        {
            this.games.Add(g);
        }
        public List<IGame> GetGames()
        {
            return this.games;
        }
        public bool Populated()
        {
            return numGames == games.Count;
        }
        public double GetTotalCost()
        {
            double output = 0;
            foreach (IGame g in games)
            {
                output += g.GetPricePerDay();
            }
            return output *= this.nightsRented;
        }
        public override string ToString()
        {
            //which games were rented by which customer for how many days along with the total amount of that rental
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

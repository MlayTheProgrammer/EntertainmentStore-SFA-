//Coded by Reggie
using System.Collections.Generic;

namespace Homework1_Entertainment_Store
{
    public interface IRental
    {
        public bool IsDueOn(int day); //returns whether the rental is due on the given day
        public void AddGame(IGame g); //adds a game to the rental
        public double GetTotalCost(); //returns the cost of renting for duration of the rental
        public List<IGame> GetGames(); //returns a list of games in the rental
        public bool Populated(); //returns whether the number of games in the rental equals the number of requested games

    }
}

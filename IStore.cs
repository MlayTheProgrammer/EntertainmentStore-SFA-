using System.Collections.Generic;

namespace Homework1_Entertainment_Store
{
    public interface IStore
    {
        public void AddToStock(IGame g); //adds the given game to the store's stock
        public bool HasGames(); //returns whether or not the store has games
        public int NumGamesInStock(); //returns how many games are in stock
        public void Restock(IRental r); //adds all games back to stock and moves the active rental to completed
        public void PopulateRental(IRental r); //adds games to rental until rental is satisfied.
        public void AcceptPayment(double money); //updates income by the given amount
        public List<IGame> GetStock(); //returns a list of all games in stock
        public double GetIncome(); //returns current income
        public List<IRental> GetCompletedRentals(); //returns a list of all completed rentals
        public List<IRental> GetActiveRentals(); //returns a list of all active rentals

    }
}

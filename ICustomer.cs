//Coded by Reggie
using System.Collections.Generic;

namespace Homework1_Entertainment_Store
{
    public interface ICustomer
    {
        public string GetName(); //returns customer name
        public bool CanRent(int storeStock); //given a stores stock, returns whether or not customer can rent
        public void RollBehavior(); //updates random behavior for renting
        public IRental CreateRental(int day); //creates a rental request with all needed info, to be populated by store
        public double PayFor(IRental r); //adds the given rental to rented games and returns payment
        List<IRental> ReturnGames(int day); //populates a list with rentals that need to be returned on the given day.

    }


}

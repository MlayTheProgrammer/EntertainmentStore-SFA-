//Coded by Reggie
namespace Homework1_Entertainment_Store
{
    public class Game : IGame
    {
        //=======FIELDS=======
        private string Name;    // The name of the game
        private double Price;   // The price per day rented of the game
        private EGenre Genre;   // The genre of the game

        //=======CTORS========
        public Game(string name, double price, EGenre genre)
        {
            this.Name = name;
            this.Price = price;
            this.Genre = genre;
        }

        //=======METHODS======
        public string GetName()
        {
            // Returns the game's name.

            return this.Name;
        }

        public double GetPricePerDay()
        {
            // Returns the price per day of the game.

            return this.Price;
        }

        public override string ToString()
        {
            return "Game<" + this.Name + ", " + "Category<" + this.Genre + ", " + this.Price + ">>";
        }

    }

}

using System;

namespace Homework1_Entertainment_Store
{
    public class Game : IGame
    {

        private string Name;
        private double Price;
        private EGenre Genre;
        public Game(string name, double price, EGenre genre)
        {
            this.Name = name;
            this.Price = price;
            this.Genre = genre;


        }

        public string GetName()
        {
            return this.Name;
        }
        public double GetPricePerDay()
        {
            return this.Price;
        }
        public override string ToString()
        {
            return "Game<" + this.Name + ", " + "Category<" + this.Genre + ", " + this.Price + ">>";
        }

    }

}

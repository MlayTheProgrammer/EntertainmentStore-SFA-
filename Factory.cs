using System;
using System.Collections.Generic;


namespace Homework1_Entertainment_Store
{
    public class CustomerFactory
    {
        //=======FIELDS=======
        private List<string> customerNames; // a list of customer names
        private Random rand;                // a random number generator

        //=======CTORS========
        public CustomerFactory()
        {
            // Reads in a list of names from names.txt and stores them in customer names.
            rand = new Random();
            string[] cNames = null;
            this.customerNames = new List<string>();
            try
            {
                cNames = System.IO.File.ReadAllLines("names.txt");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("names.txt is missing from local folder.");
            }
            if (cNames != null)
            {
                foreach (string name in cNames)
                {
                    this.customerNames.Add(name);
                }
            }
        }

        //=======METHODS======
        public Customer CreateCustomer()
        {
            // Creates a customer object and assigns it a random name and behavior behavior, and returns it.
            switch (this.rand.Next(1, 4))
            {
                
                case 1: return new Customer(RandCustName(), new Newbie());
                case 2: return new Customer(RandCustName(), new Professional());
                default: return new Customer(RandCustName(), new Hardcore());
            }
        }

        //=======HELPERS======
        private string RandCustName()
        {
            // Selects a random name from the stored list of customer names, removes it from the list, and returns it.
            if (this.customerNames.Count == 0)
            {
                throw new Exception("Attempting to generate a customer name when no names remain.");
            }
            int index = rand.Next(0, this.customerNames.Count);
            string output = this.customerNames[index];
            this.customerNames.RemoveAt(index);
            return output;
        }
    }

    public class GameFactory
    {
        //=======FIELDS=======
        private List<string> gameNames;             // a list of game names.
        private Random rand;                        // a random number generator.
        private Dictionary<EGenre, double> prices;  // a dictionary that stores the price of each genre of game.

        //=======CTORS========
        public GameFactory(Dictionary<EGenre, double> prices)
        {
            // Reads in a list of names from game.txt and stores them in game names, and stores the given dictionary of genres and prices.
            rand = new Random();
            this.prices = prices;
            string[] gNames = null;

            this.gameNames = new List<string>();
            try
            {
                gNames = System.IO.File.ReadAllLines("games.txt");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("games.txt is missing from local folder.");
            }
            if (gNames != null)
            {

                foreach (string name in gNames)
                {
                    this.gameNames.Add(name);
                }
            }
        }

        //=======METHODS======
        public Game CreateGame()
        {
            // Creates a game object, assigns it a random name and genre/price, and returns t.
            int temp = this.rand.Next(0, prices.Count);
            return new Game(RandGameName(), prices[(EGenre)temp], (EGenre)temp);
        }

        //=======HELPERS======
        private string RandGameName()
        {
            // Selects a random name from the stored list of games names, removes it from the list, and returns it.
            if (this.gameNames.Count == 0)
            {
                throw new Exception("Attempting to generate a game name when no names remain.");
            }
            int index = rand.Next(0, this.gameNames.Count);
            string output = this.gameNames[index];
            this.gameNames.RemoveAt(index);
            return output;
        }
    }
}

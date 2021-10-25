using System;
using System.Collections.Generic;


namespace Homework1_Entertainment_Store
{
    public class CustomerFactory
    {
        private List<string> customerNames;
        private Random rand;
        public CustomerFactory()
        {
            rand = new Random();
            string[] cNames = null;
            this.customerNames = new List<string>();
            try
            {
                Console.WriteLine("\nHere Are The Customers That Went To The Store: ");

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
        public Customer CreateCustomer()
        {
            switch (this.rand.Next(1, 4))
            {
                case 1: return new Customer(RandCustName(), new Newbie());
                case 2: return new Customer(RandCustName(), new Professional());
                default: return new Customer(RandCustName(), new Hardcore());
            }
        }
        private string RandCustName()
        {
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
        private List<string> gameNames;
        private Random rand;
        private Dictionary<EGenre, double> prices;
        public GameFactory(Dictionary<EGenre, double> prices)
        {
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
                Console.WriteLine("Here Are The Games That Are In The Store: ");
                foreach (string name in gNames)
                {
                    this.gameNames.Add(name);
                }
            }
        }
        public Game CreateGame()
        {
            int temp = this.rand.Next(0, prices.Count);
            return new Game(RandGameName(), prices[(EGenre)temp], (EGenre)temp);
        }
        private string RandGameName()
        {
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Gun17
{
    internal class Program
    {
        public class Memory<T>
        {
            private List<T> list = new List<T>();

            public void Add(T item)
            {
                list.Add(item);
            }

            public List<T> GetAll()
            {
                return list;
            }
        }

        public class Game
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public string Category { get; set; }

            public Game(
                int id,
                string name,
                decimal price,
                int stock,
                string category)
            {
                Id = id;
                Name = name;
                Price = price;
                Stock = stock;
                Category = category;
            }
        }

        static void Main(string[] args)
        {
            Memory<Game> gameMemory = new Memory<Game>();
            gameMemory.Add(new Game(1, "Game 1", 59.99m, 10, "Action"));
            gameMemory.Add(new Game(2, "Game 2", 69.99m, 15, "Action"));
            gameMemory.Add(new Game(3, "Game 3", 79.99m, 20, "Action"));
            gameMemory.Add(new Game(4, "Game 4", 89.99m, 25, "Action"));
            gameMemory.Add(new Game(5, "Game 5", 99.99m, 30, "Action"));

            List<Game> games = gameMemory.GetAll();

            var result = games
             .Where(g => g.Price > 70)
             .ToList();

            foreach (Game game in result)
            {
                Console.WriteLine($"{game.Name} - {game.Price}");
            }


            var result2 = games
                .Select(g => g.Name)
                .ToList();

            foreach (string name in result2)
            {
                Console.WriteLine(name);
            }


            var result3 = games
                .OrderByDescending(g => g.Price)
                .ToList();

            foreach (Game game in result3)
            {
                Console.WriteLine($"{game.Name} - {game.Price}");
            }
            Console.ReadLine();
        }
    }
}
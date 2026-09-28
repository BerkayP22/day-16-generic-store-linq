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
            var result2 = new List<string>();
            Memory<Game> gameMemory = new Memory<Game>();
            try
            {
                gameMemory.Add(new Game(1, "Game 1", 59.99m, 10, "Action"));
                gameMemory.Add(new Game(2, "Game 2", 69.99m, 15, "Drama"));
                gameMemory.Add(new Game(3, "Game 3", 79.99m, 20, "Action"));
                gameMemory.Add(new Game(4, "Game 4", 89.99m, 25, "Drama"));
                gameMemory.Add(new Game(5, "Game 5", 99.99m, 30, "Fear Method"));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error adding game: {e.Message}"); Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("Game loading finished.");
            }
            List<Game> games = gameMemory.GetAll();
            var result = games
             .Where(g => g.Price > 70)
             .ToList();

            foreach (Game game in result)
            {
                Console.WriteLine($"{game.Name} - {game.Price}");
            }

            try
            {
                 result2 = games
                .Select(g => g.Name)
                .ToList();
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error selecting game names: {e.Message}");
            }
            catch(OverflowException e)
            {
                throw new ArgumentException($"This is an argument exception.{e.Message}");
            }
            finally
            {
                Console.WriteLine("Game name query finished.");
            }

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
            
            bool isExist = games.Any(g => g.Name == "Game 1");
            if (isExist)
            {
                Console.WriteLine("Game 1 exists in the list.");

            }
            else
            {
                Console.WriteLine("Game 1 does not exist in the list.");
            }
            bool allGamesInstock = games.All(g => g.Stock > 0);
            if (allGamesInstock)
            {
                Console.WriteLine("All games are in stock.");
            }
            else
            {
                Console.WriteLine("Some games are out of stock.");
            }
            Game gamess=games.FirstOrDefault(g => g.Id == 3);
            if (gamess != null)
            {
                Console.WriteLine($"Game with ID 3: {gamess.Name} - {gamess.Price}");
            }
            else
            {
                Console.WriteLine("Game with ID 3 not found.");
            }
            var groups=games.GroupBy(g => g.Category).Select(g => new { Category = g.Key, Count = g.Count() }).ToList();
            foreach (var group in groups) {Console.WriteLine($"Category: {group.Category}, Count: {group.Count}"); }
            var totalStockforCAT = games.GroupBy(g => g.Category).Select(n => new { Category = n.Key, TotalStock = n.Sum(g => g.Stock) }).ToList();
            foreach (var group in totalStockforCAT) {Console.WriteLine($"Category: {group.Category}, Total Stock: {group.TotalStock}"); }
            var maxPrice = games.GroupBy(g => g.Category).Select(n => new {Category=n.Key,Count=n.Count(),MaxPrice=n.Max(g=>g.Price)}).ToList();
            foreach (var group in maxPrice) {Console.WriteLine($"Category: {group.Category}, Max Price: {group.MaxPrice}");}
            Console.ReadLine();
        }
    }
}

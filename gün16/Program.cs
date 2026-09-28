using System;
using System.Collections.Generic;
using System.Linq;

namespace Gun16
{
    public class InMemoryStore<T>
    {
        private readonly List<T> items = new List<T>();
        public void Add(T item) { items.Add(item); }
        public IReadOnlyList<T> GetAll() { return items.AsReadOnly(); }
    }

    public class Game
    {
        public string Name { get; }
        public string Category { get; }
        public decimal Price { get; }
        public int Stock { get; }
        public Game(string name, string category, decimal price, int stock)
        {
            Name = name; Category = category; Price = price; Stock = stock;
        }
    }

    internal class Program
    {
        static void Main()
        {
            var store = new InMemoryStore<Game>();
            store.Add(new Game("Ada", "Aksiyon", 60m, 10));
            store.Add(new Game("Kare", "Bulmaca", 80m, 5));
            store.Add(new Game("Yol", "Aksiyon", 90m, 3));
            var games = store.GetAll();

            foreach (var name in games.Where(g => g.Price > 70).OrderBy(g => g.Price).Select(g => g.Name))
                Console.WriteLine($"70 TL üzeri: {name}");
            foreach (var group in games.GroupBy(g => g.Category))
                Console.WriteLine($"{group.Key}: {group.Count()} oyun, {group.Sum(g => g.Stock)} stok");
            Console.WriteLine($"Stokta oyun var mı? {games.Any(g => g.Stock > 0)}");
            Console.WriteLine($"Hepsi stokta mı? {games.All(g => g.Stock > 0)}");
            Console.WriteLine($"İlk aksiyon oyunu: {games.FirstOrDefault(g => g.Category == "Aksiyon")?.Name ?? "Yok"}");
        }
    }
}

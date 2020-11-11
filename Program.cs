using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreList
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeList = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var command = input.Split("->");
                string store = command[1];

                if (command[0] == "Add")
                {
                    var items = command[2].Split(",").ToList();

                    if (!storeList.ContainsKey(store))
                    {
                        storeList.Add(store, new List<string>());
                    }

                    foreach (var item in items)
                    {
                        storeList[store].Add(item);
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (storeList.ContainsKey(store))
                    {
                        storeList.Remove(store);
                    }
                }

            }

            Console.WriteLine("Stores list:");

            foreach (var store in storeList.OrderByDescending(s => s.Value.Count)
                .ThenByDescending(s => s.Key))
            {
                Console.WriteLine($"{store.Key}");
                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }

        }
    }
}

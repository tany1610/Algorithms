using System;
using System.Collections.Generic;
using System.Linq;

class Knapsack
{
    static void Main()
    {
        double capacity = double.Parse(Console.ReadLine().Split(':', ' ').Where(a => a.Length > 0).ToArray()[1]);
        int itemsCount = int.Parse(Console.ReadLine().Split(':', ' ').Where(a => a.Length > 0).ToArray()[1]);
        List<Item> items = new List<Item>();
        List<Item> result = new List<Item>();

        for (int i = 0; i < itemsCount; i++)
        {
            int[] itemsInfo = Console.ReadLine()
                .Split(' ', '-', '>')
                .Where(a => a.Length > 0)
                .Select(int.Parse)
                .ToArray();
            int price = itemsInfo[0];
            int weight = itemsInfo[1];

            Item item = new Item(price, weight);
            items.Add(item);
        }

        items.Sort();

        double totalPrice = 0;

        foreach (Item item in items)
        {
            if (item.Weight <= capacity)
            {
                item.Percantage = 100.0;
                capacity -= item.Weight;
                totalPrice += item.Price;
                result.Add(item);
            }
            else
            {
                item.Percantage = (capacity / item.Weight) * 100;
                totalPrice += (item.Price / item.Weight) * (item.Weight * (item.Percantage / 100));
                result.Add(item);
                break;
            }
        }

        foreach (Item item in result)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"Total price: {totalPrice:f2}");
    }
}

class Item : IComparable<Item>
{
    public double Price;

    public double Weight;

    public double Percantage;

    public Item(int price, int weight)
    {
        Price = price;
        Weight = weight;
    }

    public int CompareTo(Item other)
    {
        double otherDiff = other.Price - other.Weight;
        double thisDiff = Price - Weight;

        int c = otherDiff.CompareTo(thisDiff);
        return c;
    }

    public override string ToString()
    {
        if (Percantage == 100.0)
        {
            return $"Take {Percantage}% of item with price {Price:f2} and weight {Weight:f2}";
        }
        return $"Take {Percantage:f2}% of item with price {Price:f2} and weight {Weight:f2}";
    }
}
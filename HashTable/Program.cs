using System.Diagnostics;
using BenchmarkDotNet.Running;

namespace HashTable;

class Program
{
    public static void Main()
    {
#if DEBUG
        TestMyHashTable();
#else
		BenchmarkRunner.Run<Benchmark>();
#endif
    }
    
    private static void TestMyHashTable()
    { 
        MyHashTable<String, float> menu = new MyHashTable<String, float>();
        menu.Add("Pizza", 9.99f);
        menu.Add("Burger", 5.99f);
        menu.Add("Fries", 2.99f);
        menu.Add("Soda", 1.99f);
        menu.Add("Salad", 4.99f);
        menu.Add("Steak", 12.99f);

        Console.WriteLine(menu);
        Console.WriteLine("Count: " + menu.Count);
        Debug.Assert(menu.Count == 6);
        Console.WriteLine("Buckets: " + menu.Buckets);
        Debug.Assert(menu.Buckets >= 16);

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();

        foreach(String key in menu.Keys)
        {
            Console.WriteLine($"Price of {key}: ${menu[key]}");
        }
    }
}
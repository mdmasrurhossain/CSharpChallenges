﻿Pack pack = new Pack(10, 20, 30);

while (true)
{
    Console.WriteLine($"Pack is currently at {pack.CurrentCount}/{pack.MaxCount} items, {pack.CurrentWeight}/{pack.MaxWeight} weight, and {pack.CurrentVolume}/{pack.MaxVolume} volume.");
    Console.WriteLine("What do you want to add?");
    Console.WriteLine("1 - Arrow");
    Console.WriteLine("2 - Bow");
    Console.WriteLine("3 - Rope");
    Console.WriteLine("4 - Water");
    Console.WriteLine("5 - Food");
    Console.WriteLine("6 - Sword");

    int choice = Convert.ToInt32(Console.ReadLine());

    InventoryItem newItem = choice switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new Food(),
        6 => new Sword()
    };

    if (!pack.Add(newItem))
        Console.WriteLine("Could not add this to the pack.");




}
Console.ReadLine();


public class Pack
{
    public int CurrentCount { get; private set; }
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }



    public int MaxCount { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }

    private string[] _items;

    public Pack(int maxCount, float maxWeight, float maxVolume)
    {
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        MaxCount = maxCount;
        _items = new string[maxCount];
    }

    public bool Add(InventoryItem item)
    {
        if (CurrentCount >= MaxCount) return false;
        if (CurrentWeight + item.Weight > MaxWeight) return false;
        if (CurrentVolume + item.Volume > MaxVolume) return false;
        CurrentCount++;
        CurrentWeight += item.Weight;
        CurrentVolume += item.Volume;
        return true;

    }
}



public class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }


    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}


public class Arrow : InventoryItem { public Arrow() : base(0.1f, 0.05f) { } }
public class Bow : InventoryItem { public Bow() : base(1f, 4f) { } }
public class Rope : InventoryItem { public Rope() : base(1f, 1.5f) { } }
public class Water : InventoryItem { public Water() : base(2f, 3f) { } }
public class Food : InventoryItem { public Food() : base(1f, 0.5f) { } }
public class Sword : InventoryItem { public Sword() : base(5f, 3f) { } }

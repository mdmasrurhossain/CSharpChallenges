public interface IItem
{
    string Name { get; }
    void Use(Battle battle, Character user);
}

public class HealthPotion : IItem
{
    public string Name => "HEALTH POTION";

    public void Use(Battle battle, Character user)
    {
        int oldHP = user.HP;
        user.HP += 10;
        int increaseAmount = user.HP - oldHP;
        Console.WriteLine($"{user.Name}'s HP was increased by {increaseAmount}."); // This is not always right. If somebody only recovers 1 HP, it would be cooler if it said "HP was increased by 1." This is another option for a Making It Your Own challenge.
    }
}

public class SimulasSoup : IItem
{
    public string Name => "SIMULA'S SOUP";

    public void Use(Battle battle, Character user)
    {
        user.HP = user.MaxHP;
        Console.WriteLine($"{user.Name}'s HP was increased to Max.");
    }
}
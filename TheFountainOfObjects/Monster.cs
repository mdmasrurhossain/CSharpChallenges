namespace TheFountainOfObjects;

public abstract class Monster
{
    public Location Location { get; set; }
    public bool IsAlive { get; set; } = true;

    public Monster(Location start) => Location = start;

    public abstract void Activate(FountainOfObjectsGame game);   
}

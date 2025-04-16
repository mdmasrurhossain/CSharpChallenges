namespace TheFountainOfObjects;
public class Player
{
    public Location Location { get; set; }
    public bool IsAlive { get; private set; } = true;
    public string CauseOfDeath { get; private set; } = "";

    public int ArrowsRemaining { get; set; } = 5;

    public Player(Location start) => Location = start;

    public void Kill(string cause)
    {
        IsAlive  = false;
        CauseOfDeath = cause;
    }
}

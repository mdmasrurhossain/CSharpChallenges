
namespace TheFountainOfObjects;

public class Amarok : Monster
{
    public Amarok(Location start) : base(start) { }

    public override void Activate(FountainOfObjectsGame game) => game.Player.Kill("You have encountered an amarok and have died.");
}

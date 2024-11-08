namespace TheFountainOfObjects;
public class PitBreezeSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game) => game.Map.HasNeighbourWithRoomType(game.Player.Location, RoomType.Pit);
    public void DisplaySense(FountainOfObjectsGame game) => ConsoleHelper.WriteLine("You feel a draft. There is a pit in nearby room.", ConsoleColor.DarkGray);
}

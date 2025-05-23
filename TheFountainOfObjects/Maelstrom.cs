﻿namespace TheFountainOfObjects;
public class Maelstrom : Monster
{
    public Maelstrom(Location start) : base(start) { }

    public override void Activate(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("You have encountered a maelstrom and have been swept away to another room!", ConsoleColor.Magenta);
        game.Player.Location = Clamp(new Location(game.Player.Location.Row - 1, game.Player.Location.Column + 2), game.Map.Row, game.Map.Column);
        Location = Clamp(new Location(Location.Row + 1, Location.Column - 2), game.Map.Row, game.Map.Column);
    }

    public Location Clamp(Location location, int totalRows, int totalcolumns)
    {
        int row = location.Row;
        if (row < 0) row = 0;
        if (row >= totalRows) row = totalRows - 1;

        int column = location.Column;
        if (column < 0) column = 0;
        if (column >= totalcolumns) column = totalcolumns - 1;
        return new Location(row, column);
    }
}

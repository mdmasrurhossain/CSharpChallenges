Console.WriteLine(new BlockCoordinate(4, 3) + new BlockOffset(2, 0));
Console.WriteLine(new BlockCoordinate(4, 3) + Direction.East);
Console.ReadLine();


public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate start, BlockOffset amount) =>
        new BlockCoordinate(start.Row + amount.RowOffset, start.Column + amount.ColumnOffset);
    public static BlockCoordinate operator +(BlockCoordinate start, Direction direction)
    {
        return start + (direction switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.South => new BlockOffset(1, 0),
            Direction.East => new BlockOffset(0, 1),
            Direction.West => new BlockOffset(0, -1),


        });

    }
}
public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction { North, East, South, West }
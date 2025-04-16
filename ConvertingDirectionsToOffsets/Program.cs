Console.WriteLine(new BlockCoordinate(4, 3) + new BlockOffset(2, 0));
Console.WriteLine(new BlockCoordinate(4, 3) + Direction.East);

BlockCoordinate coordinate = new BlockCoordinate(4, 3);

Console.WriteLine(coordinate[0]);
Console.WriteLine(coordinate[1]);

Direction direction = Direction.South;
Console.WriteLine(direction);
Console.WriteLine((BlockOffset)direction);

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

    public int this[int index] => index switch { 0 => Row, 1 => Column };
}
public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static implicit operator BlockOffset(Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.South => new BlockOffset(+1, 0),
            Direction.East => new BlockOffset(0, +1),
            Direction.West => new BlockOffset(0, -1),
        };
    }
}
public enum Direction { North, East, South, West }
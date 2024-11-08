namespace TheFountainOfObjects;

public record Location(int Row, int Column);
public enum RoomType { Normal, Entrance, Fountain, Pit, OffTheMap }
public class Map
{
    private RoomType[,] _rooms { get; }
    public int Row { get; }
    public int Column { get; }

    public Map(int row, int column)
    {
        Row = row;
        Column = column;
        _rooms = new RoomType[Row, Column];
    }

    public RoomType GetRoomTypeAtLocation(Location location) => IsOnMap(location) ? _rooms[location.Row, location.Column] : RoomType.OffTheMap;

    public bool HasNeighbourWithRoomType(Location location, RoomType roomType)
    {
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column + 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column + 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column + 1)) == roomType) return true;
        return false;
    }

    public void SetRoomTypeAtLocation(Location location, RoomType roomType) => _rooms[location.Row, location.Column] = roomType;

    public bool IsOnMap(Location location) =>
        (location.Row >= 0) &&
        (location.Row < _rooms.GetLength(0)) &&
        (location.Column >= 0) &&
        (location.Column < _rooms.GetLength(1));
    
}



using TheFountainOfObjects;
public class Program
{
    public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            DisplayIntro();
            DateTime start = DateTime.Now;
            FountainOfObjectsGame game = Console.ReadLine() switch
            {
                "small" => CreateSmallGame(),
                "medium" => CreateMediumGame(),
                "large" => CreateLargeGame()
            };

            game.Run();

            DateTime end = DateTime.Now;
            TimeSpan elapsed = end - start;
            Console.WriteLine($"You were in the Caverns for {elapsed.Minutes}m {elapsed.Seconds}s.");

            Console.ReadLine();
        }


    static void DisplayIntro()
    {
        ConsoleHelper.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits, violent maelstorms and dangerours amaroks ", ConsoleColor.White);
        ConsoleHelper.WriteLine("in search of the Fountain of Objects.", ConsoleColor.White);
        ConsoleHelper.WriteLine("Light is visible only in the entrance , and no other light is seen anywhere in the caverns.", ConsoleColor.White);
        ConsoleHelper.WriteLine("You must navigate the Caverns with your other senses.", ConsoleColor.White);
        Console.WriteLine("\n");
        ConsoleHelper.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die", ConsoleColor.Red);
        Console.WriteLine("\n");
        ConsoleHelper.WriteLine("Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns. " +
            "You will be able to hear their growling and groaning in nearby rooms.", ConsoleColor.Red);
        Console.WriteLine("\n");
        ConsoleHelper.WriteLine("Amaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.", ConsoleColor.Red);
        Console.WriteLine("\n");
        ConsoleHelper.WriteLine("You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply.", ConsoleColor.Green);
        Console.WriteLine("\n");
        ConsoleHelper.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.", ConsoleColor.White);
        Console.WriteLine("\n");
        ConsoleHelper.WriteLine("Type help to provide with instructions.", ConsoleColor.Yellow);
        Console.WriteLine("\n");
        ConsoleHelper.Write("Do you want to play a small, medium, or large game? ", ConsoleColor.White);
    }

    private static FountainOfObjectsGame CreateSmallGame()
    {
        Map map = new Map(4, 4);
        Location start = new Location(0, 0);
        map.SetRoomTypeAtLocation(start, RoomType.Entrance);
        map.SetRoomTypeAtLocation(new Location(0, 2), RoomType.Fountain);
        map.SetRoomTypeAtLocation(new Location(3, 2), RoomType.Pit); 

        Monster[] monsters = new Monster[] 
        {
            new Maelstrom(new Location(2, 0)),
            new Amarok(new Location(0, 3))
        };
        return new FountainOfObjectsGame(map, new Player(start), monsters);
    }

    private static FountainOfObjectsGame CreateMediumGame()
    {
        Map map = new Map(6, 6);
        Location start = new Location(5, 0);
        map.SetRoomTypeAtLocation(start, RoomType.Entrance);
        map.SetRoomTypeAtLocation(new Location(2, 4), RoomType.Fountain);
        map.SetRoomTypeAtLocation(new Location(5, 4), RoomType.Pit);
        map.SetRoomTypeAtLocation(new Location(3, 2), RoomType.Pit);

        Monster[] monsters = new Monster[] 
        {
            new Maelstrom(new Location(4, 2)),
            new Amarok(new Location(0, 3)),
            new Amarok(new Location(1, 5))
        };
        return new FountainOfObjectsGame(map, new Player(start), monsters);
    }

    private static FountainOfObjectsGame CreateLargeGame()
        {
            Map map = new Map(8, 8);
            Location start = new Location(3, 7);
            map.SetRoomTypeAtLocation(start, RoomType.Entrance);
            map.SetRoomTypeAtLocation(new Location(4, 2), RoomType.Fountain);
            map.SetRoomTypeAtLocation(new Location(7, 2), RoomType.Pit);
            map.SetRoomTypeAtLocation(new Location(5, 4), RoomType.Pit);
            map.SetRoomTypeAtLocation(new Location(6, 1), RoomType.Pit);
            map.SetRoomTypeAtLocation(new Location(2, 7), RoomType.Pit);

            Monster[] monsters = new Monster[]
            {
            new Maelstrom(new Location(2, 0)),
            new Maelstrom(new Location(6, 3)),
            new Amarok(new Location(0, 3)),
            new Amarok(new Location(1, 5)),
            new Amarok(new Location(4, 7))
            };
            return new FountainOfObjectsGame(map, new Player(start), monsters);
        }
}



namespace TheFountainOfObjects;

public class HelpCommand : ICommand
{
    public void Execute(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("help", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("    Displays this help information.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("enable fountain", ConsoleColor.Yellow);
        ConsoleHelper.WriteLine("    Turns on the Fountain of Objects if you are in the fountain room, or does nothing if you are not.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("move north", ConsoleColor.Yellow);
        ConsoleHelper.WriteLine("    Moves to the room directly north of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("move south", ConsoleColor.Yellow);
        ConsoleHelper.WriteLine("    Moves to the room directly south of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("move east", ConsoleColor.Yellow);
        ConsoleHelper.WriteLine("    Moves to the room directly east of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("move west", ConsoleColor.Yellow);
        ConsoleHelper.WriteLine("    Moves to the room directly west of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("shoot north", ConsoleColor.Yellow);
        ConsoleHelper.WriteLine("    Shoot an arrow to the room directly north of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("shoot south", ConsoleColor.Yellow);
        ConsoleHelper.WriteLine("    Shoot an arrow to the room directly south of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("shoot east", ConsoleColor.Yellow);
        ConsoleHelper.WriteLine("    Shoot an arrow to the room directly east of the current room, as long as there are no walls.", ConsoleColor.Gray);
        ConsoleHelper.WriteLine("shoot west", ConsoleColor.Yellow);
        ConsoleHelper.WriteLine("    Shoot an arrow to the room directly west of the current room, as long as there are no walls.", ConsoleColor.Gray);
    }
}

﻿/// <summary>
/// Represents a single battle in the game.
/// </summary>
public class Battle
{
    /// <summary>
    /// The party of heroes.
    /// </summary>
    public Party Heroes { get; }

    /// <summary>
    /// The party of monsters.
    /// </summary>
    public Party Monsters { get; }

    public static int BattleRound;

    /// <summary>
    /// Creates a new battle with the two parties involved.
    /// </summary>
    public Battle(Party heroes, Party monsters)
    {
        Heroes = heroes;
        Monsters = monsters;
    }

    /// <summary>
    /// Runs the battle to completion.
    /// </summary>
    public void Run()
    {
        // Run rounds until the outcome is known.
        while (!IsOver)
        {
            // For each character in each party...
            foreach (Party party in new[] { Heroes, Monsters })
            {
                foreach (Character character in party.Characters)
                {
                    Console.WriteLine(); // Slight separation gap.

                    BattleRenderer.Render(this, character);

                    // Display who's turn it is.
                    Console.WriteLine($"{character.Name} is taking a turn...");

                    // Have the player in charge of the party pick an action for the character, and then run that action.
                    party.Player.ChooseAction(this, character).Run(this, character);

                    

                    if (IsOver) break; // If the last action ended the battle, there is no need to go on to other characters.
                }
                if (IsOver) break; // If the last action ended the battle, there is no need to go on to other parties.
            }
            BattleRound++;
        }

        if (Heroes.Characters.Count > 0)
        {
            ColoredConsole.WriteLine("The HEROES have defeated the MONSTERS and looted their inventory.", ConsoleColor.Magenta);
            TransferInventory();
            
        }
    }

    private void TransferInventory()
    {
        foreach (IGear gear in Monsters.Gear)
        {
            ColoredConsole.WriteLine($"The HEROES have acquired {gear.Name}.", ConsoleColor.DarkMagenta);
            Heroes.Gear.Add(gear);
        }

        foreach (IItem item in Monsters.Items)
        {
            ColoredConsole.WriteLine($"The HEROES have acquired {item.Name}.", ConsoleColor.DarkMagenta);
            Heroes.Items.Add(item);
        }
    }

    /// <summary>
    /// Indicates whether the game is over or not. This is based on whether a party has no characters left to fight.
    /// </summary>
    public bool IsOver => Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0;

    /// <summary>
    /// Gives you the party that the character is not in. The party that is the enemy of the character in question.
    /// </summary>
    public Party GetEnemyPartyFor(Character character) => Heroes.Characters.Contains(character) ? Monsters : Heroes;

    /// <summary>
    /// Gives you the party that the character is in.
    /// </summary>
    public Party GetPartyFor(Character character) => Heroes.Characters.Contains(character) ? Heroes : Monsters;
}
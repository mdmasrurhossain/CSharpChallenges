Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };
Rank[] ranks = new Rank[] { Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, Rank.Ten, Rank.Dollar, Rank.Percentage, Rank.Carat, Rank.Ampersand };

foreach (Color color in colors)
{
    foreach (Rank rank in ranks)
    {
        Card card = new Card(color, rank);
        Console.WriteLine($"The {color} {rank}");
    }

}

Console.ReadLine();

public class Card
{
    public Color Color { get; }
    public Rank Rank { get; }

    public Card(Color colors, Rank ranks)
    {
        Color = colors;
        Rank = ranks;
    }

    public bool IsSymbol => Rank == Rank.Dollar || Rank == Rank.Percentage || Rank == Rank.Carat || Rank == Rank.Ampersand;
    public bool IsNumber => !IsSymbol;
}



public enum Color { Red, Green, Blue, Yellow }
public enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percentage, Carat, Ampersand }
Random random = new Random();

Console.WriteLine(random.NextDouble(100));
Console.WriteLine(random.NextString("Red", "Green", "Blue"));
Console.WriteLine(random.CoinFlip());
Console.WriteLine(random.CoinFlip(0.25));

Console.ReadLine();


public static class RandomExtensions
{
    public static double NextDouble(this Random random, double maxValue) => random.NextDouble() * maxValue;

    public static string NextString(this Random random, params string[] options ) => options[random.Next(options.Length)];
    public static bool CoinFlip(this Random random, double probabilityOfHeads = 0.5) => random.NextDouble() < probabilityOfHeads;
}
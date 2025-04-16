using static System.Runtime.InteropServices.JavaScript.JSType;

Console.Write("Which filter do you want to use? (1=Even, 2=Positive, 3=MultipleOfTen) ");

int choice = Convert.ToInt32(Console.ReadLine());
Sieve Sieve = choice switch
{
    1 => new Sieve(n => n % 2 == 0),
    2 => new Sieve(n => n >= 0),
    3 => new Sieve(n => n % 10 == 0)
};

while (true)
{
    Console.Write("Enter a number: ");
    int input = Convert.ToInt32(Console.ReadLine());
    string goodOrEvil = Sieve.IsGood(input) ? "Good" : "Evil";
    Console.WriteLine($"The number is {goodOrEvil}");
}

Console.ReadLine();

public class Sieve
{
    private Func<int, bool> _decisionFunction;

    public Sieve(Func<int, bool> decisionFunction) => _decisionFunction = decisionFunction;
    public bool IsGood(int number)
    {
        return _decisionFunction(number);
    }

}
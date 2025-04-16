try
{
    int targetNumber = new Random().Next(10);
    List<int> previousGuesses = new List<int>();

    while (true)
    {
        int number;
        bool previouslyGuessed;
        do
        {
            Console.Write("Pick a number between 0 and 9 (inclusive): ");
            number = Convert.ToInt32(Console.ReadLine());
            previouslyGuessed = previousGuesses.Contains(number);
            if (previouslyGuessed) Console.WriteLine("That number has been guessed before.");
        } while (previouslyGuessed);

        if (number == targetNumber) throw new Exception();

        previousGuesses.Add(number);
    }
}
catch (Exception)
{
    Console.WriteLine("That was the bad number! You lose!");
}
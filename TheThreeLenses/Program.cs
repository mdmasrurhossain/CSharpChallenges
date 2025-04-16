using static System.Runtime.InteropServices.JavaScript.JSType;

int[] input = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };
foreach (int number in ProceduralCode(input))
    Console.Write($"{number} ");
Console.WriteLine();

foreach (int number in KeywordSyntax(input))
    Console.Write($"{number} ");
Console.WriteLine();

foreach (int number in MethodSyntax(input))
    Console.Write($"{number} ");
Console.WriteLine();

Console.ReadLine();

IEnumerable<int> ProceduralCode(int[] input)
{
    List<int> filtered = new List<int>();
    foreach(int number in input)
    {
        if (number % 2 == 0)
            filtered.Add(number);
    }
    int[] results = filtered.ToArray();
    Array.Sort(results);
    for (int index = 0; index < results.Length; index++)
        results[index] *= 2;
    return results;
}

IEnumerable<int> KeywordSyntax(int[] input)
{

    return from number in input
           where number % 2 == 0
           orderby number
           select number * 2;

}

IEnumerable<int> MethodSyntax(int[] input)
{
    return input
        .Where(number => number % 2 == 0)
        .OrderBy(number => number)
        .Select(number => number * 2);

}




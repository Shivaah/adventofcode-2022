using AdventOfCode;
using AdventOfCode.Day1;
using AdventOfCode.Day2;

var solutions = new Dictionary<string, ISolution>()
{
    {  "Day1", new CalorieCounting() },
    {  "Day2", new RockPaperScissors() }
};

foreach (var key in solutions.Keys)
{
    var solution = solutions[key];
    string input = File.ReadAllText($"{key}/input.txt");

    Console.WriteLine($"=== {key} ===");

    Console.WriteLine($"Part 1 : {solution.GetPart1(input)}");
    Console.WriteLine($"Part 2 : {solution.GetPart2(input)}");

    Console.WriteLine("\n");
}

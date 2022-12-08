using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2;

internal enum Choice
{
    Rock = 1,
    Paper = 2,
    Scissors = 3,
}

internal enum Result 
{ 
    Loose = 0,
    Draw = 3,
    Win = 6
}

internal class RockPaperScissors : ISolution
{
    internal Dictionary<Choice, Choice> rules = new Dictionary<Choice, Choice>()
    {
        { Choice.Paper, Choice.Rock },
        { Choice.Rock, Choice.Scissors },
        { Choice.Scissors, Choice.Paper },
    };

    public object GetPart1(string input)
    {
        // Opponent and me
        var points = 0;
        var rounds = GetRounds(input)
            .Select(x => (MapPlayWithChoice(x[0]), MapPlayWithChoice(x[1])))
            .Chunk(3);
          
        foreach ((Choice, Choice)[] round in rounds)
        {
            points += round.Select(play =>
            {
                if (rules[play.Item2] == play.Item1)
                {
                    return (int)play.Item2 + (int)Result.Win;
                }

                if (play.Item2 == play.Item1)
                {
                    return (int)play.Item2 + (int)Result.Draw;
                }

                return (int)play.Item2 + (int)Result.Loose;
            })
            .Sum();
        }

        return points;
    }

    public object GetPart2(string input)
    {
        var points = 0;
        var rounds = GetRounds(input)
            .Select(x => (MapPlayWithChoice(x[0]), MapPlayWithResult(x[1])))
            .Chunk(3);
        
        foreach ((Choice, Result)[] round in rounds)
        {
            points += round.Select(play =>
            {
                if (play.Item2 == Result.Loose)
                {
                    return (int)rules[play.Item1] + (int)Result.Loose;
                }

                if (play.Item2 == Result.Draw)
                {
                    return (int)play.Item1 + (int)Result.Draw;
                }

                return (int)rules.FirstOrDefault(x => x.Value == play.Item1).Key + (int)Result.Win;
            })
            .Sum();
        }

        return points;
    }

    private IEnumerable<string[]> GetRounds(string input)
    {
        return input
            .Split("\n")
            .Select(x => x.Split(" ", StringSplitOptions.TrimEntries));
    }

    private Choice MapPlayWithChoice(string play) =>
         play switch
         {
             "A" or "X" => Choice.Rock,
             "B" or "Y" => Choice.Paper,
             "C" or "Z" => Choice.Scissors,
             _ => Choice.Scissors,
         };

    private Result MapPlayWithResult(string play) =>
        play switch
        {
            "X" => Result.Loose,
            "Y" => Result.Draw,
            "Z" => Result.Win,
            _ => Result.Win,
        };
}


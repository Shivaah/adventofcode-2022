using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day1
{
    internal class CalorieCounting : ISolution
    {
        public object GetPart1(string input)
        {
            return GetCalories(input).Max();
        }

        public object GetPart2(string input)
        {
            return GetCalories(input).Take(3).Sum();
        }

        static internal IEnumerable<int> GetCalories(string input)
        {
            return input
               .Split("\r\n\r\n")
               .Select(x => x.Split('\n').Select(int.Parse).Sum())
               .OrderByDescending(x => x);
        }
    }
}

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace MyCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var d3 = AOC_Days.Day3.AdventOfCodeDay3(@$"{Environment.CurrentDirectory}\SourceData\Day3.txt");
            WriteAnswer("2", d3[0], d3[1]);

            var d2 = AOC_Days.Day2.AdventOfCodeDay2(@$"{Environment.CurrentDirectory}\SourceData\Day2.txt");
            WriteAnswer("2", d2[0], d2[1]);

            var d1 = AOC_Days.Day1.AdventOfCodeDay1(@$"{Environment.CurrentDirectory}\SourceData\Day1.txt");
            WriteAnswer("1", d1[0], d1[1]);
        }
        public static void WriteAnswer(string day, string p1, string p2)
        {
            Console.WriteLine($"AOC day: {day} | Part 1: {p1} | Part 2: {p2}");
        }
    }
}

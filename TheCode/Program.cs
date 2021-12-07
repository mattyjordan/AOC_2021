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
            // var d7 = AOC_Days.Day7.AdventOfCodeDay7(@$"{Environment.CurrentDirectory}\SourceData\Day7.txt");
            // WriteAnswer("7", d7[0], d7[1]);

            // var d6 = AOC_Days.Day6.AdventOfCodeDay6(@$"{Environment.CurrentDirectory}\SourceData\Day6.txt");
            // //WriteAnswer("3", d3[0], d3[1]);

            var d4 = AOC_Days.Day4.AdventOfCodeDay4(@$"{Environment.CurrentDirectory}\SourceData\Day4.txt");
            // WriteAnswer("3", d3[0], d3[1]);


            // var d3 = AOC_Days.Day3.AdventOfCodeDay3(@$"{Environment.CurrentDirectory}\SourceData\Day3.txt");
            // WriteAnswer("3", d3[0], d3[1]);

            // var d2 = AOC_Days.Day2.AdventOfCodeDay2(@$"{Environment.CurrentDirectory}\SourceData\Day2.txt");
            // WriteAnswer("2", d2[0], d2[1]);

            // var d1 = AOC_Days.Day1.AdventOfCodeDay1(@$"{Environment.CurrentDirectory}\SourceData\Day1.txt");
            // WriteAnswer("1", d1[0], d1[1]);
        }
        public static void WriteAnswer(string day, string p1, string p2)
        {
            Console.WriteLine($"AOC day: {day} | Part 1: {p1} | Part 2: {p2}");
        }
    }
}

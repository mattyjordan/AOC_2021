using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace MyCode
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventOfCodeDay1(@$"{Environment.CurrentDirectory}\SourceData\Day1.txt");
            AdventOfCodeDay2(@$"{Environment.CurrentDirectory}\SourceData\Day2.txt");
        }

        #region Day1
        private static void AdventOfCodeDay1(string textFile)
        {
            string[] lines = File.ReadAllLines(textFile);
            int[] ints = Array.ConvertAll(lines, s => int.Parse(s));

            int[] testCase = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

            var d1p1 = AdventOfCodeDay1Part1(ints);
            var d1p2 = AdventOfCodeDay1Part1(AdventOfCodeDay1Part2(ints));

            WriteAnswer("1", d1p1.ToString(), d1p2.ToString());
        }
        public static int AdventOfCodeDay1Part1(int[] arr)
        {
            int counter = 0;
            int sum = 0;
            int previousNum = 0;
            foreach (var num in arr)
            {
                if (counter == 0)
                {
                    previousNum = num;
                    counter++;
                }
                else
                {
                    if (num > previousNum)
                    {
                        sum++;
                    }
                    previousNum = num;
                    counter++;
                }
            }

            return sum;

        }
        public static int[] AdventOfCodeDay1Part2(int[] arr)
        {
            var returnArrAsLList = new List<int>();
            var arrAsList = arr.ToList<int>();
            for (int i = 0; i < arrAsList.Count; i++)
            {
                int sum = 0;


                for (int j = i; j < i + 3; j++)
                {
                    if ((i + 2) < arrAsList.Count)
                    {
                        sum += arr[j];
                        if (j == i + 2)
                        {
                            returnArrAsLList.Add(sum);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return returnArrAsLList.ToArray<int>();

        }

        #endregion
        #region day2
        public static int depth { get; set; }
        public static int horizontal { get; set; }
        public static int aim { get; set; }
        private static void AdventOfCodeDay2(string textFile)
        {
            string[] lines = File.ReadAllLines(textFile);
            string[] testCase = new string[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };

            int p1Answer = AdventOfCodeDay2Part1(lines);
            int p2Answer = AdventOfCodeDay2Part2(lines);

            WriteAnswer("2", p1Answer.ToString(), p2Answer.ToString());
        }

        private static int AdventOfCodeDay2Part2(string[] lines)
        {

            foreach (var line in lines)
            {
                handleMovement(line, true);
            }
            int position = depth * horizontal;
            depth = 0;
            horizontal = 0;
            aim = 0;
            return position;
        }

        private static int AdventOfCodeDay2Part1(string[] lines)
        {

            foreach (var line in lines)
            {
                handleMovement(line, false);
            }
            int position = depth * horizontal;
            depth = 0;
            horizontal = 0;
            aim = 0;
            return position;
        }

        private static void handleMovement(string line, bool calcAim)
        {
            string[] splitLine = line.Split(" ");
            string direction = splitLine[0];
            int move = int.Parse(splitLine[1]);
            switch (calcAim)
            {
                case false:
                    switch (direction)
                    {
                        case "forward":
                            horizontal += move;
                            break;
                        case "backward":
                            horizontal -= move;
                            break;
                        case "up":
                            depth -= move;
                            break;
                        case "down":
                            depth += move;
                            break;

                    }
                    break;
                case true:
                    switch (direction)
                    {
                        case "forward":
                            // It increases your horizontal position by X units.
                            // It increases your depth by your aim multiplied by X.
                            horizontal += move;
                            depth += (aim * move);
                            break;
                        case "backward":
                            break;
                        case "up":
                            aim -= move;
                            break;
                        case "down":
                            aim += move;
                            break;

                    }
                    break;
            }
        }
        #endregion
        private static void WriteAnswer(string day, string p1, string p2)
        {
            Console.WriteLine($"AOC day: {day} | Part 1: {p1} | Part 2: {p2}");
        }
    }
}

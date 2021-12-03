using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC_Days
{
    public class Day2
    {

        #region Day2
        private static int depth { get; set; }
        private static int horizontal { get; set; }
        private static int aim { get; set; }
        public static string[] AdventOfCodeDay2(string textFile)
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

            return new string[] { p1Answer.ToString(), p2Answer.ToString() };
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


    }
}

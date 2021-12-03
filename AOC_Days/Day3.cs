using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace AOC_Days
{
    public class Day3
    {
        public static string[] AdventOfCodeDay3(string textPath)
        {
            string[] lines = File.ReadAllLines(textPath);
            string[] testCase = new string[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

            var d1p1 = AdventOfCodeDay3Part1(lines);
            var d1p2 = AdventOfCodeDay3Part2(lines);

            return new string[] { d1p1.ToString(), d1p2.ToString() };
        }

        private static decimal AdventOfCodeDay3Part2(string[] strings)
        {
            decimal OxygenRating = 0;
            OxygenRating = calcOxygen(ref strings);
            decimal CO2Rating = 0;
            CO2Rating = calcCO2(ref strings);

            return OxygenRating * CO2Rating;
        }

        private static decimal calcCO2(ref string[] strings)
        {
            var localStrings = strings;
            decimal returnValue;
            int ones, zeros;
            for (int i = 0; i < localStrings[0].Length && localStrings.Count() != 1; i++)
            {
                CountOnesAndZeroes(localStrings, i, out ones, out zeros);
                if (ones < zeros && localStrings.Count() > 1)
                {
                    localStrings = localStrings.Where(x => x[i] == '1').ToArray();
                }
                else if (ones > zeros && localStrings.Count() > 1)
                {
                    localStrings = localStrings.Where(x => x[i] == '0').ToArray();
                }
                else
                {
                    localStrings = localStrings.Where(x => x[i] == '0').ToArray();
                }
            }


            returnValue = Convert.ToInt32(localStrings[0], 2);
            return returnValue;
        }

        private static decimal calcOxygen(ref string[] strings)
        {
            var localStrings = strings;
            decimal OxygenRating;
            int ones, zeros;

            for (int i = 0; i < localStrings[0].Length && localStrings.Count() != 1; i++)
            {
                CountOnesAndZeroes(localStrings, i, out ones, out zeros);
                if (ones > zeros && localStrings.Count() > 1)
                {
                    localStrings = localStrings.Where(x => x[i] == '1').ToArray();
                }
                else if (ones < zeros && localStrings.Count() > 1)
                {
                    localStrings = localStrings.Where(x => x[i] == '0').ToArray();
                }
                else
                {
                    localStrings = localStrings.Where(x => x[i] == '1').ToArray();
                }
            }

            OxygenRating = Convert.ToInt32(localStrings[0], 2);
            return OxygenRating;
        }

        private static decimal AdventOfCodeDay3Part1(string[] strings)
        {
            var gammaRate = ""; // Most Common
            var epsilonRate = ""; // Least Common

            for (int i = 0; i < strings[0].Length; i++)
            {
                int ones, zeros;
                CountOnesAndZeroes(strings, i, out ones, out zeros);

                if (ones > zeros)
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
                else
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }

            }

            decimal powerConsumption = Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
            return powerConsumption;

        }

        private static void CountOnesAndZeroes(string[] strings, int i, out int ones, out int zeros)
        {
            zeros = 0;
            ones = 0;
            foreach (var s in strings)
            {
                switch (s[i])
                {
                    case '1':
                        ones++;
                        break;
                    case '0':
                        zeros++;
                        break;
                }
            }
        }
    }
}

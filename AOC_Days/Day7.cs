using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace AOC_Days
{
    public class Day7
    {
        private class allignFuel
        {
            public int allign { get; set; }
            public int fuel { get; set; }
        }
        private static List<allignFuel> fuelList = new List<allignFuel>();

        public static string[] AdventOfCodeDay7(string textPath)
        {
            var testCase = "16,1,2,0,4,2,7,1,2,14".Split(',');
            var testCaseAsIntArr = Array.ConvertAll(testCase, s => int.Parse(s));

            string[] lines = File.ReadAllText(textPath).Split(",");
            int[] input = Array.ConvertAll(lines, s => int.Parse(s));

            var d1p2 = part2(input);
            var d1p1 = part1(input);


            return new string[] { d1p1.ToString(), d1p2.ToString() };
        }

        private static int part2(int[] input)
        {
            for (int i = 0; i < input.Max(); i++)
            {
                calcFuel(input, i, 2);
            }
            var minFuel = fuelList.Min(y => y.fuel);
            int returnVal = fuelList.Where(x => x.fuel == minFuel).Select(y => y.allign).First();

            return minFuel;
        }

        private static void calcFuel(int[] arr, int _allign, int part)
        {
            int _fuel = 0;
            foreach (var item in arr)
            {
                switch (part)
                {
                    case 1:
                        _fuel += Math.Abs(item - _allign);
                        break;
                    case 2:
                        var fuel = Math.Abs(item - _allign);
                        var fuelIncrease = 0;

                        for (int i = 0; i < fuel; i++)
                        {
                            fuelIncrease += i;
                        }
                        _fuel += (fuel + fuelIncrease);
                        break;
                }
            }
            fuelList.Add(new allignFuel() { allign = _allign, fuel = _fuel });
        }

        private static int part1(int[] input)
        {
            for (int i = 0; i < input.Max(); i++)
            {
                calcFuel(input, i, 1);
            }
            var minFuel = fuelList.Min(y => y.fuel);
            int returnVal = fuelList.Where(x => x.fuel == minFuel).Select(y => y.allign).First();

            return minFuel;
        }


    }
}

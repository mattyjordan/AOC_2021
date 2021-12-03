using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC_Days
{
    public class Day1
    {
        #region Day1
        public static string[] AdventOfCodeDay1(string textFile)
        {
            string[] lines = File.ReadAllLines(textFile);
            int[] ints = Array.ConvertAll(lines, s => int.Parse(s));

            int[] testCase = new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

            var d1p1 = AdventOfCodeDay1Part1(ints);
            var d1p2 = AdventOfCodeDay1Part1(AdventOfCodeDay1Part2(ints));

            return new string[] { d1p1.ToString(), d1p2.ToString() };

        }
        private static int AdventOfCodeDay1Part1(int[] arr)
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
        private static int[] AdventOfCodeDay1Part2(int[] arr)
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
    }
}

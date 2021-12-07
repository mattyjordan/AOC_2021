using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace AOC_Days
{
    public class Day6
    {

        public static string[] AdventOfCodeDay6(string textPath)
        {
            var testCase = "3,4,3,1,2".Split(',');
            var testCaseAsIntArr = Array.ConvertAll(testCase, s => long.Parse(s));

            string[] lines = File.ReadAllText(textPath).Split(",");
            long[] input = Array.ConvertAll(lines, s => long.Parse(s));

            var d1p1 = AdventOfCodeDay3Part1(testCaseAsIntArr, 256);

            return null;
        }

        private static long AdventOfCodeDay3Part1(long[] inputArr, int days)
        {
            var listOfLanternFishes = new List<long>();
            foreach (var fish in inputArr)
            {
                listOfLanternFishes.Add(fish);
            }

            return loopThroughLanternFishes(listOfLanternFishes, days);

        }

        private static long loopThroughLanternFishes(List<long> listOfLanternFishes, int days)
        {
            long count = listOfLanternFishes.Count;
            for (int day = 0; day < days; day++)
            {
                Console.WriteLine($"Day {day}");
                long countZeros = listOfLanternFishes.Count(x => x == 0L);
                for (int i = 0; i < listOfLanternFishes.Count; i++)
                {
                    if (listOfLanternFishes[i]-- == 0L) listOfLanternFishes[i] = 6L;
                }


                for (int k = 0; k < countZeros; k++)
                {
                    listOfLanternFishes.Add(8L);
                }


                // each 0 == 6 and new 8.



                //     Console.WriteLine($"Day {i} : {count} Lantern Fish");
                //     foreach (var fish in listOfLanternFishes.ToList())
                //     {
                //         switch (fish.internalTimer)
                //         {
                //             case 0:
                //                 fish.internalTimer = 6;
                //                 // Add new fish to the list.
                //                 listOfLanternFishes.Add(new LanternFish() { internalTimer = 8 });
                //                 count++;
                //                 break;
                //             default:
                //                 fish.internalTimer--;
                //                 break;
                //         }
                //     }
                // }


            }
            return listOfLanternFishes.Sum();
        }
        public class LanternFish
        {
            public long internalTimer { get; set; }
        }
    }
}

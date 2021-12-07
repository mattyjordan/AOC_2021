using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC_Days
{
    public class Day4
    {
        private class board
        {
            public int Id { get; set; }
            public Tuple<int, bool>[] x0 { get; set; }
            public Tuple<int, bool>[] x1 { get; set; }
            public Tuple<int, bool>[] x2 { get; set; }
            public Tuple<int, bool>[] x3 { get; set; }
            public Tuple<int, bool>[] x4 { get; set; }
        }

        private static List<board> boards = new List<board>();

        public static string[] AdventOfCodeDay4(string textPath)
        {
            var testFilePath = @$"{Directory.GetParent(Environment.CurrentDirectory)}\TheCode\SourceData\TestCases\Day4.txt";
            var testCase = File.ReadAllLines(testFilePath);
            var bingoNumber = Array.ConvertAll(testCase[0].Split(','), x => int.Parse(x)).ToArray();
            testCase = createBoards(testCase);

            part1(bingoNumber);


            return null;
        }

        private static string[] createBoards(string[] testCase)
        {
            testCase = testCase.Skip(2).ToArray();
            testCase = testCase.Where(x => x != "").ToArray();

            // build sample data with 1200 Strings
            //string[] items = Enumerable.Range(1, 1200).Select(i => "Item" + i).ToArray();
            // split on groups with each 100 items
            String[][] chunks = testCase
                                .Select((s, i) => new { Value = s, Index = i })
                                .GroupBy(x => x.Index / 5)
                                .Select(grp => grp.Select(x => x.Value).ToArray())
                                .ToArray();

            for (int i = 0; i < chunks.Length; i++)
            {
                var _board = new board() { Id = i };
                foreach (var item in chunks[i])
                {
                    var x = Array.FindIndex(chunks[i], row => row == item);
                    var arr = item.Split(' ').Where(x => x != "").ToArray();
                    switch (x)
                    {
                        case 0:
                            _board.x0 = Array.ConvertAll(arr, y => new Tuple<int, bool>(int.Parse(y), false));
                            break;

                        case 1:
                            _board.x1 = Array.ConvertAll(arr, y => new Tuple<int, bool>(int.Parse(y), false));
                            break;

                        case 2:
                            _board.x2 = Array.ConvertAll(arr, y => new Tuple<int, bool>(int.Parse(y), false));
                            break;

                        case 3:
                            _board.x3 = Array.ConvertAll(arr, y => new Tuple<int, bool>(int.Parse(y), false));
                            break;

                        case 4:
                            _board.x4 = Array.ConvertAll(arr, y => new Tuple<int, bool>(int.Parse(y), false));
                            break;
                    }

                }
                boards.Add(_board);


            }

            return testCase;
        }

        private static void part1(int[] bingoNumber)
        {
            foreach (var num in bingoNumber)
            {
                foreach (var board in boards)
                {
                    foreach (var prop in board.GetType().GetProperties())
                    {
                        Tuple<int, bool> check = new Tuple<int, bool>(num, false);
                        switch (prop.Name)
                        {
                            case "x0":
                                if (board.x0.Contains(check))
                                {
                                    int index = Array.IndexOf(board.x0, check);
                                    board.x0[index] = Tuple.Create(num, true);
                                }
                                break;

                            case "x1":
                                if (board.x1.Contains(check))
                                {
                                    int index = Array.IndexOf(board.x1, check);
                                    board.x1[index] = Tuple.Create(num, true);
                                }
                                break;

                            case "x2":
                                if (board.x2.Contains(check))
                                {
                                    int index = Array.IndexOf(board.x2, check);
                                    board.x2[index] = Tuple.Create(num, true);
                                }
                                break;

                            case "x3":
                                if (board.x3.Contains(check))
                                {
                                    int index = Array.IndexOf(board.x3, check);
                                    board.x3[index] = Tuple.Create(num, true);
                                }
                                break;

                            case "x4":
                                if (board.x4.Contains(check))
                                {
                                    int index = Array.IndexOf(board.x4, check);
                                    board.x4[index] = Tuple.Create(num, true);
                                }
                                break;
                        }
                    }
                }
                CheckForWinner();
            }
        }

        private static void CheckForWinner()
        {
            var winner = false;
            foreach (var board in boards)
            {
                foreach (var prop in board.GetType().GetProperties())
                {
                    

                }
            }
        }
    }
}

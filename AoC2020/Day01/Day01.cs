using System;

/*

--- Day 1: Report Repair ---

After saving Christmas five years in a row, you've decided to take a vacation at a nice resort on a tropical island.
Surely, Christmas will go on without you.

The tropical island has its own currency and is entirely cash-only.
The gold coins used there have a little picture of a starfish; the locals just call them stars.
None of the currency exchanges seem to have heard of them, but somehow, you'll need to find fifty of these coins by the time you arrive so you can pay the deposit on your room.

To save your vacation, you need to get all fifty stars by December 25th.

Collect stars by solving puzzles.
Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first.
ach puzzle grants one star.
Good luck!

Before you leave, the Elves in accounting just need you to fix your expense report (your puzzle input); apparently, something isn't quite adding up.

Specifically, they need you to find the two entries that sum to 2020 and then multiply those two numbers together.

For example, suppose your expense report contained the following:

1721
979
366
299
675
1456

In this list, the two entries that sum to 2020 are 1721 and 299.
Multiplying them together produces 1721 * 299 = 514579, so the correct answer is 514579.

Of course, your expense report is much larger.
Find the two entries that sum to 2020; what do you get if you multiply them together?

*/

namespace Day01
{
    class Program
    {
        static int[] sValues;
        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);
            Parse(lines);

            if (part1)
            {
                var result1 = Program.Part1(sValues);
                Console.WriteLine($"Day01 : Result1 {result1}");
                var expected = 444019;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = -666;
                Console.WriteLine($"Day01 : Result2 {result2}");
                var expected = -123;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        static void Parse(string[] lines)
        {
            var count = lines.Length;
            sValues = new int[count];
            var i = 0;
            foreach (var line in lines)
            {
                sValues[i] = int.Parse(line);
                ++i;
            }
        }

        public static int Part1(int[] values)
        {
            const int targetSum = 2020;
            var count = values.Length;
            Array.Sort(values);
            // values is now lowest to highest
            for (var i = 0; i < count - 1; ++i)
            {
                var iValue = values[i];
                var remainder = targetSum - iValue;
                for (var j = i + 1; i < count; ++j)
                {
                    var jValue = values[j];
                    if (jValue > remainder)
                    {
                        break;
                    }
                    if (jValue == remainder)
                    {
                        var sum = iValue + jValue;
                        if (sum != targetSum)
                        {
                            throw new InvalidProgramException($"Expecting {targetSum} got {sum} {iValue} {jValue}");
                        }
                        var mult = iValue * jValue;
                        return mult;
                    }
                }
            }
            throw new InvalidProgramException($"Sum of {targetSum} not found");
        }

        public static void Run()
        {
            Console.WriteLine("Day01 : Start");
            _ = new Program("Day01/input.txt", true);
            _ = new Program("Day01/input.txt", false);
            Console.WriteLine("Day01 : End");
        }
    }
}

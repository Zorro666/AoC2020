using System;

/*

*/

namespace Day18
{
    class Program
    {
        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = -666;
                Console.WriteLine($"Day18 : Result1 {result1}");
                var expected = -123;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = -666;
                Console.WriteLine($"Day18 : Result2 {result2}");
                var expected = -123;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        public static void Run()
        {
            Console.WriteLine("Day18 : Start");
            _ = new Program("Day18/input.txt", true);
            _ = new Program("Day18/input.txt", false);
            Console.WriteLine("Day18 : End");
        }
    }
}

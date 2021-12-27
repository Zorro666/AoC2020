using System;

/*

--- Day 23: Crab Cups ---

The small crab challenges you to a game!
The crab is going to mix up some cups, and you have to predict where they'll end up.

The cups will be arranged in a circle and labeled clockwise (your puzzle input).
For example, if your labeling were 32415, there would be five cups in the circle; going clockwise around the circle from the first cup, the cups would be labeled 3, 2, 4, 1, 5, and then back to 3 again.

Before the crab starts, it will designate the first cup in your list as the current cup.
The crab is then going to do 100 moves.

Each move, the crab does the following actions:

The crab picks up the three cups that are immediately clockwise of the current cup.
They are removed from the circle; cup spacing is adjusted as necessary to maintain the circle.
The crab selects a destination cup: the cup with a label equal to the current cup's label minus one.
If this would select one of the cups that was just picked up, the crab will keep subtracting one until it finds a cup that wasn't just picked up.
If at any point in this process the value goes below the lowest value on any cup's label, it wraps around to the highest value on any cup's label instead.
The crab places the cups it just picked up so that they are immediately clockwise of the destination cup.
They keep the same order as when they were picked up.
The crab selects a new current cup: the cup which is immediately clockwise of the current cup.

For example, suppose your cup labeling were 389125467.
If the crab were to do merely 10 moves, the following changes would occur:

-- move 1 --
cups: (3) 8  9  1  2  5  4  6  7 
pick up: 8, 9, 1
destination: 2

-- move 2 --
cups:  3 (2) 8  9  1  5  4  6  7 
pick up: 8, 9, 1
destination: 7

-- move 3 --
cups:  3  2 (5) 4  6  7  8  9  1 
pick up: 4, 6, 7
destination: 3

-- move 4 --
cups:  7  2  5 (8) 9  1  3  4  6 
pick up: 9, 1, 3
destination: 7

-- move 5 --
cups:  3  2  5  8 (4) 6  7  9  1 
pick up: 6, 7, 9
destination: 3

-- move 6 --
cups:  9  2  5  8  4 (1) 3  6  7 
pick up: 3, 6, 7
destination: 9

-- move 7 --
cups:  7  2  5  8  4  1 (9) 3  6 
pick up: 3, 6, 7
destination: 8

-- move 8 --
cups:  8  3  6  7  4  1  9 (2) 5 
pick up: 5, 8, 3
destination: 1

-- move 9 --
cups:  7  4  1  5  8  3  9  2 (6)
pick up: 7, 4, 1
destination: 5

-- move 10 --
cups: (5) 7  4  1  8  3  9  2  6 
pick up: 7, 4, 1
destination: 3

-- final --
cups:  5 (8) 3  7  4  1  9  2  6 

In the above example, the cups' values are the labels as they appear moving clockwise around the circle; the current cup is marked with ( ).

After the crab is done, what order will the cups be in?
Starting after the cup labeled 1, collect the other cups' labels clockwise into a single string with no extra characters;
each number except 1 should appear exactly once.
In the above example, after 10 moves, the cups clockwise from 1 are labeled 9, 2, 6, 5, and so on, producing 92658374.
If the crab were to complete all 100 moves, the order after cup 1 would be 67384529.

Using your labeling, simulate 100 moves.

What are the labels on the cups after cup 1?

Your puzzle input is 562893147.
 
Your puzzle answer was 38925764.

--- Part Two ---

Due to what you can only assume is a mistranslation (you're not exactly fluent in Crab), you are quite surprised when the crab starts arranging many cups in a circle on your raft - one million (1000000) in total.

Your labeling is still correct for the first few cups; after that, the remaining cups are just numbered in an increasing fashion starting from the number after the highest number in your list and proceeding one by one until one million is reached.
(For example, if your labeling were 54321, the cups would be numbered 5, 4, 3, 2, 1, and then start counting up from 6 until one million is reached.)
In this way, every number from one through one million is used exactly once.

After discovering where you made the mistake in translating Crab Numbers, you realize the small crab isn't going to do merely 100 moves;
the crab is going to do ten million (10000000) moves!

The crab is going to hide your stars - one each - under the two cups that will end up immediately clockwise of cup 1.
You can have them if you predict what the labels on those cups will be when the crab is finished.

In the above example (389125467), this would be 934001 and then 159792;
multiplying these together produces 149245887792.

Determine which two cups will end up immediately clockwise of cup 1.

What do you get if you multiply their labels together?

*/

namespace Day23
{
    class Program
    {
        const int MAX_NUM_CUPS = 1024 * 1024;
        const int COUNT_CUPS_PART2 = 1000000;
        const int COUNT_MOVES_PART2 = 10000000;
        readonly static int[] sCupsNext = new int[MAX_NUM_CUPS];
        readonly static int[] sCupsPrev = new int[MAX_NUM_CUPS];
        readonly static int[] sCupsValues = new int[MAX_NUM_CUPS];
        readonly static int[] sCupsValuesIndexes = new int[MAX_NUM_CUPS];
        static int sCountCups = 0;
        static int sCurrentCupIndex = 0;
        static int sLowestCupValue = 0;
        static int sHighestCupValue = 0;

        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines, 100);
                Console.WriteLine($"Day23 : Result1 {result1}");
                var expected = 29385746;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day23 : Result2 {result2}");
                var expected = 680435423892L;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        static int Next(int index)
        {
            return sCupsNext[index];
        }

        static int Prev(int index)
        {
            return sCupsPrev[index];
        }

        static int Append(int index, int newNode)
        {
            var oldNext = Next(index);
            // BEFORE
            // node[index] -> next
            // node[index] <- next

            // AFTER
            // node[index] -> NEW NODE
            sCupsNext[index] = newNode;
            // node[index] <- NEW NODE
            sCupsPrev[newNode] = index;

            // NEW NODE -> next
            sCupsNext[newNode] = oldNext;
            // NEW NODE <- next
            sCupsPrev[oldNext] = newNode;

            return newNode;
        }

        static int Remove(int index)
        {
            var oldPrev = Prev(index);
            var oldNext = Next(index);
            // BEFORE
            // node[index] -> next
            // node[index] <- next
            // prev -> node[index]
            // prev <- node[index] <- next

            // AFTER
            // prev -> next
            sCupsNext[oldPrev] = oldNext;
            // prev <- next
            sCupsPrev[oldNext] = oldPrev;

            sCupsNext[index] = -1;
            sCupsPrev[index] = -1;
            var value = sCupsValues[index];
            sCupsValuesIndexes[value] = -1;
            sCupsValues[index] = -1;

            return oldNext;
        }

        private static void Parse(string[] lines)
        {
            var line = lines[0].Trim();
            sCountCups = line.Length;
            var prev = sCountCups - 1;
            var next = 1;
            for (var i = 0; i < sCountCups; ++i)
            {
                var value = line[i] - '0';
                sCupsValues[i] = value;
                sCupsValuesIndexes[value] = i;
                sCupsNext[prev] = i;
                sCupsNext[i] = next;
                sCupsPrev[i] = prev;
                prev = i;
                ++next;
                next %= sCountCups;
            }
        }

        private static void Setup(bool part2)
        {
            sCurrentCupIndex = 0;
            sLowestCupValue = int.MaxValue;
            sHighestCupValue = int.MinValue;
            for (var i = 0; i < sCountCups; ++i)
            {
                sLowestCupValue = Math.Min(sLowestCupValue, sCupsValues[i]);
                sHighestCupValue = Math.Max(sHighestCupValue, sCupsValues[i]);
            }

            if (part2)
            {
                var prev = sCountCups - 1;
                var next = sCountCups + 1;
                var value = sCountCups;
                for (var i = sCountCups; i < COUNT_CUPS_PART2; ++i)
                {
                    ++value;
                    sCupsValues[i] = value;
                    sCupsValuesIndexes[value] = i;
                    sCupsNext[prev] = i;
                    sCupsNext[i] = next;
                    sCupsPrev[i] = prev;
                    prev = i;
                    ++next;
                    next %= COUNT_CUPS_PART2;
                }
                if (value != COUNT_CUPS_PART2)
                {
                    throw new InvalidProgramException($"Unexpected value {value} != {COUNT_CUPS_PART2}");
                }
                sCountCups = COUNT_CUPS_PART2;
                sHighestCupValue = COUNT_CUPS_PART2;
            }
        }

        private static void OutputCups()
        {
            var index = sCurrentCupIndex;
            for (var i = 0; i < sCountCups; ++i)
            {
                Console.Write($"{sCupsValues[index]} -> ");
                index = Next(index);
            }
            Console.WriteLine($"");
        }

        private static long GetResult()
        {
            var index = FindValue(1);
            if (index == -1)
            {
                throw new InvalidProgramException($"Failed to find '1' {index}");
            }
            index = Next(index);

            var result = 0L;
            do
            {
                result *= 10;
                result += sCupsValues[index];
                index = Next(index);
            }
            while (sCupsValues[index] != 1);

            return result;
        }

        private static int FindValue(int value)
        {
            return sCupsValuesIndexes[value];
        }

        private static int FindValueSlow(int value)
        {
            for (var i = 0; i < sCountCups; ++i)
            {
                if (sCupsValues[i] == value)
                {
                    if (i != sCupsValuesIndexes[value])
                    {
                        throw new InvalidProgramException($"FindValue != sCupsValuesIndexes {i} != {sCupsValuesIndexes[value]}");
                    }
                    return i;
                }
            }
            return -1;
        }

        private static void PerformMove()
        {
            // pick up the next three cups and remove them
            var currentIndex = sCurrentCupIndex;
            var currentValue = sCupsValues[currentIndex];
            var nextIndex1 = Next(currentIndex);
            if (nextIndex1 == currentIndex)
            {
                throw new InvalidProgramException($"Unexpected nextIndex1 {nextIndex1} CurrentIndex: {currentIndex}");
            }
            var nextIndex2 = Next(nextIndex1);
            if (nextIndex2 == currentIndex)
            {
                throw new InvalidProgramException($"Unexpected nextIndex2 {nextIndex2} CurrentIndex: {currentIndex}");
            }
            if (nextIndex2 == nextIndex1)
            {
                throw new InvalidProgramException($"Unexpected nextIndex2 {nextIndex2} NextIndex1: {nextIndex1}");
            }
            var nextIndex3 = Next(nextIndex2);
            if (nextIndex3 == currentIndex)
            {
                throw new InvalidProgramException($"Unexpected nextIndex3 {nextIndex3} CurrentIndex: {currentIndex}");
            }
            if (nextIndex3 == nextIndex1)
            {
                throw new InvalidProgramException($"Unexpected nextIndex3 {nextIndex3} NextIndex1: {nextIndex1}");
            }
            if (nextIndex3 == nextIndex2)
            {
                throw new InvalidProgramException($"Unexpected nextIndex3 {nextIndex3} NextIndex2: {nextIndex2}");
            }
            var nextCup1 = sCupsValues[nextIndex1];
            var nextCup2 = sCupsValues[nextIndex2];
            var nextCup3 = sCupsValues[nextIndex3];
            Remove(nextIndex1);
            Remove(nextIndex2);
            Remove(nextIndex3);
            var insertIndex = -1;
            var targetValue = currentValue;

            // selects destination with value equal to the current cup's value minus one.
            // If this would select one of the cups that was just picked up, the crab will keep subtracting one until it finds a cup that wasn't just picked up.
            // If at any point in this process the value goes below the lowest value on any cup's label, it wraps around to the highest value on any cup's label instead.
            while (insertIndex == -1)
            {
                --targetValue;
                if (targetValue < sLowestCupValue)
                {
                    targetValue = sHighestCupValue;
                }
                if ((targetValue == nextCup1) || (targetValue == nextCup2) || (targetValue == nextCup3))
                {
                    continue;
                }
                insertIndex = FindValue(targetValue);
            }

            // The crab places the cups it just picked up so that they are immediately clockwise of the destination cup.
            // They keep the same order as when they were picked up.
            sCupsValues[nextIndex1] = nextCup1;
            sCupsValues[nextIndex2] = nextCup2;
            sCupsValues[nextIndex3] = nextCup3;
            sCupsValuesIndexes[nextCup1] = nextIndex1;
            sCupsValuesIndexes[nextCup2] = nextIndex2;
            sCupsValuesIndexes[nextCup3] = nextIndex3;
            Append(insertIndex, nextIndex1);
            Append(nextIndex1, nextIndex2);
            Append(nextIndex2, nextIndex3);

            // The crab selects a new current cup: the cup which is immediately clockwise of the current cup.
            sCurrentCupIndex = Next(sCurrentCupIndex);
        }

        public static long Part1(string[] lines, int moves)
        {
            Parse(lines);
            Setup(false);

            for (var m = 0; m < moves; ++m)
            {
                PerformMove();
            }

            return GetResult();
        }

        public static long Part2(string[] lines)
        {
            Parse(lines);
            Setup(true);

            for (var m = 0; m < COUNT_MOVES_PART2; ++m)
            {
                PerformMove();
            }

            var index = FindValue(1);
            if (index == -1)
            {
                throw new InvalidProgramException($"Failed to find '1' {index}");
            }
            var next1 = Next(index);
            var next2 = Next(next1);
            long cupNext1 = sCupsValues[next1];
            long cupNext2 = sCupsValues[next2];
            return cupNext1 * cupNext2;
        }

        public static void Run()
        {
            Console.WriteLine("Day23 : Start");
            _ = new Program("Day23/input.txt", true);
            _ = new Program("Day23/input.txt", false);
            Console.WriteLine("Day23 : End");
        }
    }
}

using System;

/*

--- Day 7: Handy Haversacks ---

You land at the regional airport in time for your next flight.
In fact, it looks like you'll even have time to grab some food: all flights are currently delayed due to issues in luggage processing.

Due to recent aviation regulations, many rules (your puzzle input) are being enforced about bags and their contents; bags must be color-coded and must contain specific quantities of other color-coded bags.
Apparently, nobody responsible for these regulations considered how long they would take to enforce!

For example, consider the following rules:

light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.

These rules specify the required contents for 9 bag types.

In this example, every faded blue bag is empty, every vibrant plum bag contains 11 bags (5 faded blue and 6 dotted black), and so on.

You have a shiny gold bag.

If you wanted to carry it in at least one other bag, how many different bag colors would be valid for the outermost bag?
(In other words: how many colors can, eventually, contain at least one shiny gold bag?)

In the above rules, the following options would be available to you:

A bright white bag, which can hold your shiny gold bag directly.
A muted yellow bag, which can hold your shiny gold bag directly, plus some other bags.
A dark orange bag, which can hold bright white and muted yellow bags, either of which could then hold your shiny gold bag.
A light red bag, which can hold bright white and muted yellow bags, either of which could then hold your shiny gold bag.
So, in this example, the number of bag colors that can eventually contain at least one shiny gold bag is 4.

How many bag colors can eventually contain at least one shiny gold bag? (The list of rules is quite long; make sure you get all of it.)

Your puzzle answer was 211.

--- Part Two ---

It's getting pretty expensive to fly these days - not because of ticket prices, but because of the ridiculous number of bags you need to buy!

Consider again your shiny gold bag and the rules from the above example:

faded blue bags contain 0 other bags.
dotted black bags contain 0 other bags.
vibrant plum bags contain 11 other bags: 5 faded blue bags and 6 dotted black bags.
dark olive bags contain 7 other bags: 3 faded blue bags and 4 dotted black bags.
So, a single shiny gold bag must contain 1 dark olive bag (and the 7 bags within it) plus 2 vibrant plum bags (and the 11 bags within each of those): 1 + 1*7 + 2 + 2*11 = 32 bags!

Of course, the actual rules have a small chance of going several levels deeper than this example; be sure to count all of the bags, even if the nesting becomes topologically impractical!

Here's another example:

shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.
In this example, a single shiny gold bag must contain 126 other bags.

How many individual bags are required inside your single shiny gold bag?

*/

namespace Day07
{
    class Program
    {
        const int MAX_COUNT_BAGS = 1024;
        const int MAX_COUNT_SUBBAGS = 8;
        static string[] sBags = new string[MAX_COUNT_BAGS];
        static int[] sSubBagsCount = new int[MAX_COUNT_BAGS];
        static string[,] sSubBags = new string[MAX_COUNT_BAGS, MAX_COUNT_SUBBAGS];
        static int[,] sSubBagAmounts = new int[MAX_COUNT_BAGS, MAX_COUNT_SUBBAGS];
        static int sBagCount = 0;

        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day07 : Result1 {result1}");
                var expected = 289;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day07 : Result2 {result2}");
                var expected = 30055;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        // light red bags contain 1 bright white bag, 2 muted yellow bags.
        // dark orange bags contain 3 bright white bags, 4 muted yellow bags.
        // bright white bags contain 1 shiny gold bag.
        // muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
        // shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
        // dark olive bags contain 3 faded blue bags, 4 dotted black bags.
        // vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
        // faded blue bags contain no other bags.
        // dotted black bags contain no other bags.
        private static void Parse(string[] lines)
        {
            var bag = 0;
            foreach (var line in lines)
            {
                var l = line.Trim();
                var toks = l.Split("bags contain");
                var outerBagColour = toks[0].Trim();
                sBags[bag] = outerBagColour;
                sSubBagsCount[bag] = 0;
                if (toks[1].Trim() != "no other bags.")
                {
                    var innerBags = toks[1].Split(',');
                    var subBag = 0;
                    foreach (var b in innerBags)
                    {
                        var tokens = b.Trim().Split();
                        var innerBag = "";
                        for (var i = 1; i < tokens.Length - 1; ++i)
                        {
                            innerBag += tokens[i];
                            innerBag += " ";
                        }
                        sSubBagAmounts[bag, subBag] = int.Parse(tokens[0]);
                        sSubBags[bag, subBag] = innerBag.Trim();
                        ++subBag;
                    }
                    sSubBagsCount[bag] = subBag;
                }
                ++bag;
            }
            sBagCount = bag;
        }

        public static int Part1(string[] lines)
        {
            Parse(lines);
            var total = 0;
            for (var b = 0; b < sBagCount; ++b)
            {
                var outerBag = sBags[b];
                if (ContainsShinyGold(outerBag))
                {
                    ++total;
                }
            }
            return total;
        }

        private static bool ContainsShinyGold(string bagName)
        {
            for (var b = 0; b < sBagCount; ++b)
            {
                if (sBags[b] == bagName)
                {
                    var childCount = sSubBagsCount[b];
                    for (var child = 0; child < childCount; ++child)
                    {
                        var innerBag = sSubBags[b, child];
                        if (innerBag == "shiny gold")
                        {
                            return true;
                        }
                        else
                        {
                            if (ContainsShinyGold(innerBag))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            throw new InvalidProgramException($"Bag {bagName} not found");
        }

        private static int SubBagCount(string bagName)
        {
            var total = 1;
            for (var b = 0; b < sBagCount; ++b)
            {
                if (sBags[b] == bagName)
                {
                    var childCount = sSubBagsCount[b];
                    for (var child = 0; child < childCount; ++child)
                    {
                        var innerBag = sSubBags[b, child];
                        total += sSubBagAmounts[b, child] * SubBagCount(innerBag);
                    }
                    return total;
                }
            }
            throw new InvalidProgramException($"Bag {bagName} not found");
        }

        public static int Part2(string[] lines)
        {
            Parse(lines);
            var total = 0;
            total += SubBagCount("shiny gold");
            total -= 1;
            return total;
        }

        public static void Run()
        {
            Console.WriteLine("Day07 : Start");
            _ = new Program("Day07/input.txt", true);
            _ = new Program("Day07/input.txt", false);
            Console.WriteLine("Day07 : End");
        }
    }
}

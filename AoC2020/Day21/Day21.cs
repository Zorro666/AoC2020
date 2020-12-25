using System;

/*

--- Day 21: Allergen Assessment ---

You reach the train's last stop and the closest you can get to your vacation island without getting wet.
There aren't even any boats here, but nothing can stop you now: you build a raft.
You just need a few days' worth of food for your journey.

You don't speak the local language, so you can't read any ingredients lists.
However, sometimes, allergens are listed in a language you do understand.
You should be able to use this information to determine which ingredient contains which allergen and work out which foods are safe to take with you on your trip.

You start by compiling a list of foods (your puzzle input), one food per line.
Each line includes that food's ingredients list followed by some or all of the allergens the food contains.

Each allergen is found in exactly one ingredient.
Each ingredient contains zero or one allergen.

Allergens aren't always marked; when they're listed (as in (contains nuts, shellfish) after an ingredients list), the ingredient that contains each listed allergen will be somewhere in the corresponding ingredients list.
However, even if an allergen isn't listed, the ingredient that contains that allergen could still be present: maybe they forgot to label it, or maybe it was labeled in a language you don't know.

For example, consider the following list of foods:

mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)

The first food in the list has four ingredients (written in a language you don't understand): mxmxvkd, kfcds, sqjhc, and nhms.
While the food might contain other allergens, a few allergens the food definitely contains are listed afterward: dairy and fish.

The first step is to determine which ingredients can't possibly contain any of the allergens in any food in your list.
In the above example, none of the ingredients kfcds, nhms, sbzzf, or trh can contain an allergen.

Counting the number of times any of these ingredients appear in any ingredients list produces 5: 
they all appear once each except sbzzf, which appears twice.

Determine which ingredients cannot possibly contain any of the allergens in your list.

How many times do any of those ingredients appear?

*/

namespace Day21
{
    class Program
    {
        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day21 : Result1 {result1}");
                var expected = -123;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day21 : Result2 {result2}");
                var expected = -123;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static void Parse(string[] lines)
        {
            // mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
            // trh fvjkl sbzzf mxmxvkd (contains dairy)
            // sqjhc fvjkl (contains soy)
            // sqjhc mxmxvkd sbzzf (contains fish)
            foreach (var l in lines)
            {
                var line = l.Trim();
                var tokens = line.Split('(');
                var ingrediants = tokens[0].Trim().Split();
                foreach (var ingrediant in ingrediants)
                {
                    Console.WriteLine($"{ingrediant} ");
                }
                var allergens = tokens[1].TrimEnd(')').Split();
                for (var a = 1; a < allergens.Length; ++a)
                {
                    var allergen = allergens[a].Trim().TrimEnd(',');
                    Console.WriteLine($"{allergen} ");
                }
            }
        }

        public static int Part1(string[] lines)
        {
            Parse(lines);
            throw new NotImplementedException();
        }

        public static int Part2(string[] lines)
        {
            Parse(lines);
            throw new NotImplementedException();
        }

        public static void Run()
        {
            Console.WriteLine("Day21 : Start");
            _ = new Program("Day21/input.txt", true);
            _ = new Program("Day21/input.txt", false);
            Console.WriteLine("Day21 : End");
        }
    }
}

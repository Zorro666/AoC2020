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

Your puzzle answer was 2573.

--- Part Two ---

Now that you've isolated the inert ingredients, you should have enough information to figure out which ingredient contains which allergen.

In the above example:

mxmxvkd contains dairy.
sqjhc contains fish.
fvjkl contains soy.

Arrange the ingredients alphabetically by their allergen and separate them by commas to produce your canonical dangerous ingredient list.
(There should not be any spaces in your canonical dangerous ingredient list.)

In the above example, this would be mxmxvkd,sqjhc,fvjkl.

Time to stock your raft with supplies.

What is your canonical dangerous ingredient list?

*/

namespace Day21
{
    class Program
    {
        const int MAX_COUNT_RECIPES = 64;
        const int MAX_COUNT_INGREDIANTS = 256;
        const int MAX_COUNT_ALLERGENS = 8;
        const int MAX_COUNT_INGREDIANTS_PER_RECIPE = 128;
        const int MAX_COUNT_ALLERGENS_PER_RECIPE = 4;
        const int MAX_COUNT_RECIPES_PER_ALLERGEN = 32;

        static readonly string[] sIngrediantNames = new string[MAX_COUNT_INGREDIANTS];
        static readonly string[] sAllergenNames = new string[MAX_COUNT_ALLERGENS];
        static readonly int[,] sRecipesPerAllergen = new int[MAX_COUNT_RECIPES_PER_ALLERGEN, MAX_COUNT_ALLERGENS];
        static readonly int[] sCountRecipesPerAllergen = new int[MAX_COUNT_ALLERGENS];
        static int sCountIngrediants;
        static int sCountAllergens;
        static int sCountRecipes;
        static readonly int[,] sIngrediantsPerRecipe = new int[MAX_COUNT_INGREDIANTS_PER_RECIPE, MAX_COUNT_RECIPES];
        static readonly int[] sCountIngrediantsPerRecipe = new int[MAX_COUNT_RECIPES];
        static readonly int[,] sAllergensPerRecipe = new int[MAX_COUNT_ALLERGENS_PER_RECIPE, MAX_COUNT_RECIPES];
        static readonly int[] sCountAllergensPerRecipe = new int[MAX_COUNT_RECIPES];

        static readonly int[] sResolvedAllergens = new int[MAX_COUNT_ALLERGENS];
        static readonly int[] sIngrediantsToAllergen = new int[MAX_COUNT_INGREDIANTS];
        static readonly int[,] sPotentialIngrediantsPerAllergen = new int[MAX_COUNT_INGREDIANTS_PER_RECIPE, MAX_COUNT_ALLERGENS];
        static readonly int[] sCountPotentialIngrediantsPerAllergen = new int[MAX_COUNT_ALLERGENS];

        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day21 : Result1 {result1}");
                var expected = 2573;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day21 : Result2 {result2}");
                var expected = "bjpkhx,nsnqf,snhph,zmfqpn,qrbnjtj,dbhfd,thn,sthnsg";
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static int FindAllergen(string allergen)
        {
            for (var i = 0; i < sCountAllergens; ++i)
            {
                if (sAllergenNames[i] == allergen)
                {
                    return i;
                }
            }
            var index = sCountAllergens;
            ++sCountAllergens;
            sAllergenNames[index] = allergen;
            return index;
        }

        private static int FindIngrediant(string ingrediant)
        {
            for (var i = 0; i < sCountIngrediants; ++i)
            {
                if (sIngrediantNames[i] == ingrediant)
                {
                    return i;
                }
            }
            var index = sCountIngrediants;
            ++sCountIngrediants;
            sIngrediantNames[index] = ingrediant;
            return index;
        }

        private static void Parse(string[] lines)
        {
            sCountRecipes = 0;
            sCountAllergens = 0;
            sCountIngrediants = 0;
            for (var i = 0; i < MAX_COUNT_RECIPES; ++i)
            {
                sCountIngrediantsPerRecipe[i] = 0;
            }
            for (var a = 0; a < MAX_COUNT_ALLERGENS; ++a)
            {
                sCountRecipesPerAllergen[a] = 0;
            }
            for (var r = 0; r < MAX_COUNT_RECIPES; ++r)
            {
                sCountAllergensPerRecipe[r] = 0;
            }

            // mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
            // trh fvjkl sbzzf mxmxvkd (contains dairy)
            // sqjhc fvjkl (contains soy)
            // sqjhc mxmxvkd sbzzf (contains fish)
            foreach (var l in lines)
            {
                var line = l.Trim();
                var tokens = line.Split('(');
                var ingrediants = tokens[0].Trim().Split();
                for (var i = 0; i < ingrediants.Length; ++i)
                {
                    var ingrediant = ingrediants[i];
                    var index = FindIngrediant(ingrediant);
                    sIngrediantsPerRecipe[i, sCountRecipes] = index;
                    ++sCountIngrediantsPerRecipe[sCountRecipes];
                    sIngrediantsToAllergen[index] = -1;
                }
                var allergens = tokens[1].TrimEnd(')').Split();
                for (var a = 1; a < allergens.Length; ++a)
                {
                    var allergen = allergens[a].Trim().TrimEnd(',');
                    var index = FindAllergen(allergen);
                    sAllergensPerRecipe[a - 1, sCountRecipes] = index;
                    ++sCountAllergensPerRecipe[sCountRecipes];
                    sRecipesPerAllergen[sCountRecipesPerAllergen[index], index] = sCountRecipes;
                    ++sCountRecipesPerAllergen[index];
                    sResolvedAllergens[index] = -1;
                }
                ++sCountRecipes;
            }
            for (var r = 0; r < sCountRecipes; ++r)
            {
                for (var i = 0; i < sCountIngrediantsPerRecipe[r] - 1; ++i)
                {
                    for (var j = i + 1; j < sCountIngrediantsPerRecipe[r]; ++j)
                    {
                        var indexI = sIngrediantsPerRecipe[i, r];
                        var indexJ = sIngrediantsPerRecipe[j, r];
                        if (indexJ < indexI)
                        {
                            sIngrediantsPerRecipe[i, r] = indexJ;
                            sIngrediantsPerRecipe[j, r] = indexI;
                        }
                    }
                }

                for (var i = 0; i < sCountAllergensPerRecipe[r] - 1; ++i)
                {
                    for (var j = i + 1; j < sCountAllergensPerRecipe[r]; ++j)
                    {
                        var indexI = sAllergensPerRecipe[i, r];
                        var indexJ = sAllergensPerRecipe[j, r];
                        if (indexJ < indexI)
                        {
                            sAllergensPerRecipe[i, r] = indexJ;
                            sAllergensPerRecipe[j, r] = indexI;
                        }
                    }
                }
            }
        }

        private static void OutputInput()
        {
            for (var r = 0; r < sCountRecipes; ++r)
            {
                Console.Write($"Ingrediants ");
                for (var i = 0; i < sCountIngrediantsPerRecipe[r]; ++i)
                {
                    var index = sIngrediantsPerRecipe[i, r];
                    Console.Write($"{index} {sIngrediantNames[index]} ");
                }
                Console.Write($"Allergens ");
                for (var i = 0; i < sCountAllergensPerRecipe[r]; ++i)
                {
                    var index = sAllergensPerRecipe[i, r];
                    Console.Write($"{index} {sAllergenNames[index]} ");
                }
                Console.WriteLine($"");
            }
        }

        private static void OutputAllergensInfo()
        {
            Console.WriteLine($"Allergens Info");
            for (var a = 0; a < sCountAllergens; ++a)
            {
                Console.Write($"{sAllergenNames[a]} : ");
                var countPotentialIngrediants = sCountPotentialIngrediantsPerAllergen[a];
                for (var i = 0; i < countPotentialIngrediants; ++i)
                {
                    var index = sPotentialIngrediantsPerAllergen[i, a];
                    Console.Write($"{sIngrediantNames[index]} ");
                }
                Console.WriteLine($"");
            }
        }

        private static void OutputResolvedInfo()
        {
            Console.WriteLine($"Resolved Allergens");
            for (var a = 0; a < sCountAllergens; ++a)
            {
                var i = sResolvedAllergens[a];
                if (i != -1)
                {
                    Console.WriteLine($"{sAllergenNames[a]} : {sIngrediantNames[i]}");
                }
            }
            Console.WriteLine($"Resolved Ingrediants");
            for (var i = 0; i < sCountIngrediants; ++i)
            {
                var a = sIngrediantsToAllergen[i];
                if (a != -1)
                {
                    Console.WriteLine($"{sIngrediantNames[i]} : {sAllergenNames[a]}");
                }
            }
        }

        private static void ResolveRecipes()
        {
            for (var a = 0; a < sCountAllergens; ++a)
            {
                var r = sRecipesPerAllergen[0, a];
                sCountPotentialIngrediantsPerAllergen[a] = sCountIngrediantsPerRecipe[r];
                for (var i = 0; i < sCountIngrediantsPerRecipe[r]; ++i)
                {
                    sPotentialIngrediantsPerAllergen[i, a] = sIngrediantsPerRecipe[i, r];
                }
            }

            bool changed;
            do
            {
                changed = false;
                for (var a = 0; a < sCountAllergens; ++a)
                {
                    if (sResolvedAllergens[a] == -1)
                    {
                        var countRecipes = sCountRecipesPerAllergen[a];
                        for (var ir = 0; ir < countRecipes; ++ir)
                        {
                            var r = sRecipesPerAllergen[ir, a];
                            var countFound = 0;
                            var countPotentialIngrediants = sCountPotentialIngrediantsPerAllergen[a];
                            var newIngrediants = new int[countPotentialIngrediants];
                            for (var j = 0; j < countPotentialIngrediants; ++j)
                            {
                                var found = false;
                                var potentialIngrediant = sPotentialIngrediantsPerAllergen[j, a];
                                if (sIngrediantsToAllergen[potentialIngrediant] != -1)
                                {
                                    continue;
                                }
                                for (var i = 0; i < sCountIngrediantsPerRecipe[r]; ++i)
                                {
                                    var thisIngrediant = sIngrediantsPerRecipe[i, r];
                                    if (potentialIngrediant == thisIngrediant)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                                if (found)
                                {
                                    newIngrediants[countFound] = potentialIngrediant;
                                    ++countFound;
                                }
                            }
                            if (countFound != countPotentialIngrediants)
                            {
                                changed = true;
                                sCountPotentialIngrediantsPerAllergen[a] = countFound;
                                for (var j = 0; j < countFound; ++j)
                                {
                                    sPotentialIngrediantsPerAllergen[j, a] = newIngrediants[j];
                                }
                                if (countFound == 1)
                                {
                                    var ingrediant = newIngrediants[0];
                                    if (sResolvedAllergens[a] != -1)
                                    {
                                        throw new InvalidProgramException($"Allergen {a} already resolved {sResolvedAllergens[a]} new Ingrediant {ingrediant}");
                                    }
                                    sResolvedAllergens[a] = ingrediant;
                                    if (sIngrediantsToAllergen[ingrediant] != -1)
                                    {
                                        throw new InvalidProgramException($"Ingrediant {ingrediant} already resolved {sIngrediantsToAllergen[ingrediant]} new Allergen {a}");

                                    }
                                    sIngrediantsToAllergen[ingrediant] = a;
                                }
                            }
                        }
                    }
                }
            } while (changed);
        }

        public static int Part1(string[] lines)
        {
            Parse(lines);
            ResolveRecipes();

            //OutputAllergensInfo();
            //OutputResolvedInfo();

            var count = 0;
            for (var r = 0; r < sCountRecipes; ++r)
            {
                for (var i = 0; i < sCountIngrediantsPerRecipe[r]; ++i)
                {
                    if (sIngrediantsToAllergen[sIngrediantsPerRecipe[i, r]] == -1)
                    {
                        ++count;
                    }
                }
            }

            return count;
        }

        public static string Part2(string[] lines)
        {
            Parse(lines);
            ResolveRecipes();

            var allergens = new string[MAX_COUNT_ALLERGENS];
            var countAllergens = 0;
            for (var a = 0; a < sCountAllergens; ++a)
            {
                if (sResolvedAllergens[a] != -1)
                {
                    allergens[countAllergens] = sAllergenNames[a];
                    ++countAllergens;
                }
            }

            Array.Sort(allergens, 0, countAllergens);
            var result = "";
            for (var a = 0; a < countAllergens; ++a)
            {
                if (result.Length > 0)
                {
                    result += ",";
                }
                var index = FindAllergen(allergens[a]);
                result += sIngrediantNames[sResolvedAllergens[index]];
            }
            return result;
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

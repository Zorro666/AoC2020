using System;

/*

--- Day 18: Operation Order ---

As you look out the window and notice a heavily-forested continent slowly appear over the horizon, you are interrupted by the child sitting next to you.
They're curious if you could help them with their math homework.

Unfortunately, it seems like this "math" follows different rules than you remember.

The homework (your puzzle input) consists of a series of expressions that consist of addition (+), multiplication (*), and parentheses ((...)).
Just like normal math, parentheses indicate that the expression inside must be evaluated before it can be used by the surrounding expression.
Addition still finds the sum of the numbers on both sides of the operator, and multiplication still finds the product.

However, the rules of operator precedence have changed.
Rather than evaluating multiplication before addition, the operators have the same precedence, and are evaluated left-to-right regardless of the order in which they appear.

For example, the steps to evaluate the expression 1 + 2 * 3 + 4 * 5 + 6 are as follows:

1 + 2 * 3 + 4 * 5 + 6
  3   * 3 + 4 * 5 + 6
      9   + 4 * 5 + 6
         13   * 5 + 6
             65   + 6
                 71
Parentheses can override this order; for example, here is what happens if parentheses are added to form 1 + (2 * 3) + (4 * (5 + 6)):

1 + (2 * 3) + (4 * (5 + 6))
1 +    6    + (4 * (5 + 6))
     7      + (4 * (5 + 6))
     7      + (4 *   11   )
     7      +     44
            51
Here are a few more examples:

2 * 3 + (4 * 5) becomes 26.
5 + (8 * 3 + 9 + 3 * 4 * 3) becomes 437.
5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4)) becomes 12240.
((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2 becomes 13632.

Before you can help with the homework, you need to understand it yourself.

Evaluate the expression on each line of the homework; what is the sum of the resulting values?

Your puzzle answer was 16332191652452.

--- Part Two ---

You manage to answer the child's questions and they finish part 1 of their homework, but get stuck when they reach the next section: advanced math.

Now, addition and multiplication have different precedence levels, but they're not the ones you're familiar with.
Instead, addition is evaluated before multiplication.

For example, the steps to evaluate the expression 1 + 2 * 3 + 4 * 5 + 6 are now as follows:

1 + 2 * 3 + 4 * 5 + 6
  3   * 3 + 4 * 5 + 6
  3   *   7   * 5 + 6
  3   *   7   *  11
     21       *  11
         231
Here are the other examples from above:

1 + (2 * 3) + (4 * (5 + 6)) still becomes 51.
2 * 3 + (4 * 5) becomes 46.
5 + (8 * 3 + 9 + 3 * 4 * 3) becomes 1445.
5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4)) becomes 669060.
((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2 becomes 23340.

What do you get if you add up the results of evaluating the homework problems using these new rules?

*/

namespace Day18
{
    class Program
    {
        const int MAX_COUNT_ITEMS = 32;
        private static readonly long[] sValuesStack = new long[MAX_COUNT_ITEMS];
        private static int sValuesStackCount;
        private static readonly char[] sOperatorsStack = new char[MAX_COUNT_ITEMS];
        private static int sOperatorsStackCount;
        private static bool sPart1 = false;

        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day18 : Result1 {result1}");
                var expected = 14208061823964;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day18 : Result2 {result2}");
                var expected = 320536571743074L;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static long ApplyOperator(long total, long nextValue, char op)
        {
            if (op == '+')
            {
                return total + nextValue;
            }
            else if (op == '*')
            {
                return total * nextValue;
            }
            throw new InvalidProgramException($"Unknown operator '{op}'");
        }

        private static long EvaluatePart1(ref int pos, string line)
        {
            var op = ' ';
            var total = long.MinValue;
            while (pos < line.Length)
            {
                // ((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2
                var c = line[pos];
                ++pos;
                if (c == ' ')
                {
                    continue;
                }
                bool applyOperator = false;
                var value = long.MinValue;
                if (c == '(')
                {
                    value = EvaluatePart1(ref pos, line);
                    applyOperator = true;
                }
                else if (c == ')')
                {
                    return total;
                }
                else if ((c >= '0') && (c <= '9'))
                {
                    value = c - '0';
                    applyOperator = true;
                }
                else if (c == '+')
                {
                    op = '+';
                }
                else if (c == '*')
                {
                    op = '*';
                }
                if (applyOperator)
                {
                    if (op != ' ')
                    {
                        total = ApplyOperator(total, value, op);
                        op = ' ';
                    }
                    else
                    {
                        // 1 + 2 + 3
                        if (total != long.MinValue)
                        {
                            throw new InvalidProgramException($"Bad total '{total}' pos {pos} '{c}'");
                        }
                        total = value;
                    }
                }
            }
            return total;
        }

        private static void PushValue(char c)
        {
            sValuesStack[sValuesStackCount] = c - '0';
            ++sValuesStackCount;
        }

        private static void PushOperator(char op)
        {
            sOperatorsStack[sOperatorsStackCount] = op;
            ++sOperatorsStackCount;
        }

        private static void PopAndApplyOperator()
        {
            if (sValuesStackCount < 2)
            {
                throw new InvalidProgramException($"Bad value stack count need > 2 {sValuesStack} at operator {sOperatorsStackCount} '{sOperatorsStack[sOperatorsStackCount - 1]}'");
            }
            var rhs = sValuesStack[sValuesStackCount - 1];
            var lhs = sValuesStack[sValuesStackCount - 2];
            sValuesStack[sValuesStackCount - 1] = long.MinValue;
            sValuesStack[sValuesStackCount - 2] = long.MinValue;
            sValuesStackCount -= 2;
            var op = sOperatorsStack[sOperatorsStackCount - 1];
            sOperatorsStack[sOperatorsStackCount - 1] = ' ';
            --sOperatorsStackCount;
            var result = ApplyOperator(lhs, rhs, op);
            sValuesStack[sValuesStackCount] = result;
            ++sValuesStackCount;
        }

        private static long Evaluate(string line)
        {
            sValuesStackCount = 0;
            sOperatorsStackCount = 0;
            for (var i = 0; i < MAX_COUNT_ITEMS; ++i)
            {
                sOperatorsStack[i] = ' ';
                sValuesStack[i] = long.MinValue;
            }

            for (var pos = 0; pos < line.Length; ++pos)
            {
                var c = line[pos];
                if (c == ' ')
                {
                    continue;
                }
                if (c == '(')
                {
                    PushOperator(c);
                }
                else if (c == ')')
                {
                    // Pop and apply operator until find '('
                    while (sOperatorsStack[sOperatorsStackCount - 1] != '(')
                    {
                        PopAndApplyOperator();
                    }
                    sOperatorsStack[sOperatorsStackCount] = ' ';
                    --sOperatorsStackCount;
                }
                else if ((c >= '0') && (c <= '9'))
                {
                    PushValue(c);
                }
                else if (c == '+')
                {
                    if (sOperatorsStackCount > 0)
                    {
                        var headOperator = sOperatorsStack[sOperatorsStackCount - 1];
                        if ((headOperator == '+') || (sPart1 && headOperator == '*'))
                        {
                            PopAndApplyOperator();
                        }
                    }
                    PushOperator(c);
                }
                else if (c == '*')
                {
                    if (sOperatorsStackCount > 0)
                    {
                        var headOperator = sOperatorsStack[sOperatorsStackCount - 1];
                        if ((headOperator == '+') || (sPart1 && headOperator == '*'))
                        {
                            PopAndApplyOperator();
                        }
                    }
                    PushOperator(c);
                }
            }
            while (sOperatorsStackCount > 0)
            {
                PopAndApplyOperator();
            }
            if (sValuesStackCount != 1)
            {
                throw new InvalidProgramException($"Bad value stack count {sValuesStackCount}");
            }
            return sValuesStack[0];
        }

        public static long Part1(string[] lines)
        {
            sPart1 = true;
            var total = 0L;
            var total2 = 0L;
            foreach (var l in lines)
            {
                var pos = 0;
                var line = l.Trim();
                total += EvaluatePart1(ref pos, line);
                total2 += Evaluate(line);
                if (total != total2)
                {
                    throw new InvalidProgramException($"Old way not matching new way");
                }
            }

            return total;
        }

        public static long Part2(string[] lines)
        {
            sPart1 = false;
            var total = 0L;
            foreach (var l in lines)
            {
                var line = l.Trim();
                total += Evaluate(line);
            }
            return total;
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

/*

2 * 3 + 4

Values
2
3
4

Operators
*
+

2 + 3 * 4

Operators
+
* : apply the +

*/


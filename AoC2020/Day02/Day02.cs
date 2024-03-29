﻿using System;

/*

--- Day 2: Password Philosophy ---

Your flight departs in a few days from the coastal airport; the easiest way down to the coast from here is via toboggan.

The shopkeeper at the North Pole Toboggan Rental Shop is having a bad day.
"Something's wrong with our computers; we can't log in!" You ask if you can take a look.

Their password database seems to be a little corrupted: some of the passwords wouldn't have been allowed by the Official Toboggan Corporate Policy that was in effect when they were chosen.

To try to debug the problem, they have created a list (your puzzle input) of passwords (according to the corrupted database) and the corporate policy when that password was set.

For example, suppose you have the following list:

1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc

Each line gives the password policy and then the password.
The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid.
For example, 1-3 a means that the password must contain a at least 1 time and at most 3 times.

In the above example, 2 passwords are valid.
The middle password, cdefg, is not; it contains no instances of b, but needs at least 1.
The first and third passwords are valid: they contain one a or nine c, both within the limits of their respective policies.

How many passwords are valid according to their policies?

Your puzzle answer was 569.

--- Part Two ---

While it appears you validated the passwords correctly, they don't seem to be what the Official Toboggan Corporate Authentication System is expecting.

The shopkeeper suddenly realizes that he just accidentally explained the password policy rules from his old job at the sled rental place down the street!
The Official Toboggan Corporate Policy actually works a little differently.

Each policy actually describes two positions in the password, where 1 means the first character, 2 means the second character, and so on.
(Be careful; Toboggan Corporate Policies have no concept of "index zero"!) Exactly one of these positions must contain the given letter.
Other occurrences of the letter are irrelevant for the purposes of policy enforcement.

Given the same example list from above:

1-3 a: abcde is valid: position 1 contains a and position 3 does not.
1-3 b: cdefg is invalid: neither position 1 nor position 3 contains b.
2-9 c: ccccccccc is invalid: both position 2 and position 9 contain c.

How many passwords are valid according to the new interpretation of the policies?

*/

namespace Day02
{
    class Program
    {
        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day02 : Result1 {result1}");
                var expected = 582;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day02 : Result2 {result2}");
                var expected = 729;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static int Part1(string[] rules)
        {
            var count = 0;
            foreach (var rule in rules)
            {
                count += ValidPassword1(rule);
            }
            return count;
        }

        private static int Part2(string[] rules)
        {
            var count = 0;
            foreach (var rule in rules)
            {
                count += ValidPassword2(rule);
            }
            return count;
        }

        public static void ParseRule(string rule, out int min, out int max, out char character, out string password)
        {
            // '1-3 a: abcde'
            var tokens = rule.Split();
            var minMaxTokens = tokens[0].Split('-');
            min = int.Parse(minMaxTokens[0]);
            max = int.Parse(minMaxTokens[1]);
            character = tokens[1].Trim(':')[0];
            password = tokens[2].Trim();
        }

        public static int ValidPassword1(string rule)
        {
            ParseRule(rule, out int min, out int max, out char character, out string password);
            var count = 0;
            foreach (var c in password)
            {
                if (c == character)
                {
                    ++count;
                }
            }
            if (count < min)
            {
                return 0;
            }
            if (count > max)
            {
                return 0;
            }
            return 1;
        }

        public static int ValidPassword2(string rule)
        {
            ParseRule(rule, out int min, out int max, out char character, out string password);
            var foundMin = password[min - 1] == character;
            var foundMax = password[max - 1] == character;
            return foundMin ^ foundMax ? 1 : 0;
        }

        public static void Run()
        {
            Console.WriteLine("Day02 : Start");
            _ = new Program("Day02/input.txt", true);
            _ = new Program("Day02/input.txt", false);
            Console.WriteLine("Day02 : End");
        }
    }
}

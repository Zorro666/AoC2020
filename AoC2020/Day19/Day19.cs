using System;

/*

--- Day 19: Monster Messages ---

You land in an airport surrounded by dense forest.
As you walk to your high-speed train, the Elves at the Mythical Information Bureau contact you again.
They think their satellite has collected an image of a sea monster! Unfortunately, the connection to the satellite is having problems, and many of the messages sent back from the satellite have been corrupted.

They sent you a list of the rules valid messages should obey and a list of received messages they've collected so far (your puzzle input).

The rules for valid messages (the top part of your puzzle input) are numbered and build upon each other.
For example:

0: 1 2
1: "a"
2: 1 3 | 3 1
3: "b"

Some rules, like 3: "b", simply match a single character (in this case, b).

The remaining rules list the sub-rules that must be followed; for example, the rule 0: 1 2 means that to match rule 0, the text being checked must match rule 1, and the text after the part that matched rule 1 must then match rule 2.

Some of the rules have multiple lists of sub-rules separated by a pipe (|).
This means that at least one list of sub-rules must match.
(The ones that match might be different each time the rule is encountered.) For example, the rule 2: 1 3 | 3 1 means that to match rule 2, the text being checked must match rule 1 followed by rule 3 or it must match rule 3 followed by rule 1.

Fortunately, there are no loops in the rules, so the list of possible matches will be finite.
Since rule 1 matches a and rule 3 matches b, rule 2 matches either ab or ba.
Therefore, rule 0 matches aab or aba.

Here's a more interesting example:

0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: "a"
5: "b"

Here, because rule 4 matches a and rule 5 matches b, rule 2 matches two letters that are the same (aa or bb), and rule 3 matches two letters that are different (ab or ba).

Since rule 1 matches rules 2 and 3 once each in either order, it must match two pairs of letters, one pair with matching letters and one pair with different letters.
This leaves eight possibilities: aaab, aaba, bbab, bbba, abaa, abbb, baaa, or babb.

Rule 0, therefore, matches a (rule 4), then any of the eight options from rule 1, then b (rule 5): aaaabb, aaabab, abbabb, abbbab, aabaab, aabbbb, abaaab, or ababbb.

The received messages (the bottom part of your puzzle input) need to be checked against the rules so you can determine which are valid and which are corrupted.
Including the rules and the messages together, this might look like:

0: 4 1 5
1: 2 3 | 3 2
2: 4 4 | 5 5
3: 4 5 | 5 4
4: "a"
5: "b"

ababbb
bababa
abbbab
aaabbb
aaaabbb

Your goal is to determine the number of messages that completely match rule 0.

In the above example, ababbb and abbbab match, but bababa, aaabbb, and aaaabbb do not, producing the answer 2.
The whole message must match all of rule 0; there can't be extra unmatched characters in the message.
(For example, aaaabbb might appear to match rule 0 above, but it has an extra unmatched b on the end.)

How many messages completely match rule 0?

Your puzzle answer was 129.

--- Part Two ---

As you look over the list of messages, you realize your matching rules aren't quite right.

To fix them, completely replace rules 8: 42 and 11: 42 31 with the following:

8: 42 | 42 8
11: 42 31 | 42 11 31

This small change has a big impact: now, the rules do contain loops, and the list of messages they could hypothetically match is infinite.
You'll need to determine how these changes affect which messages are valid.

Fortunately, many of the rules are unaffected by this change; it might help to start by looking at which rules always match the same set of values and how those rules (especially rules 42 and 31) are used by the new versions of rules 8 and 11.

(Remember, you only need to handle the rules you have; building a solution that could handle any hypothetical combination of rules would be significantly more difficult.)

For example:

42: 9 14 | 10 1
9: 14 27 | 1 26
10: 23 14 | 28 1
1: "a"
11: 42 31
5: 1 14 | 15 1
19: 14 1 | 14 14
12: 24 14 | 19 1
16: 15 1 | 14 14
31: 14 17 | 1 13
6: 14 14 | 1 14
2: 1 24 | 14 4
0: 8 11
13: 14 3 | 1 12
15: 1 | 14
17: 14 2 | 1 7
23: 25 1 | 22 14
28: 16 1
4: 1 1
20: 14 14 | 1 15
3: 5 14 | 16 1
27: 1 6 | 14 18
14: "b"
21: 14 1 | 1 14
25: 1 1 | 1 14
22: 14 14
8: 42
26: 14 22 | 1 20
18: 15 15
7: 14 5 | 1 21
24: 14 1

abbbbbabbbaaaababbaabbbbabababbbabbbbbbabaaaa
bbabbbbaabaabba
babbbbaabbbbbabbbbbbaabaaabaaa
aaabbbbbbaaaabaababaabababbabaaabbababababaaa
bbbbbbbaaaabbbbaaabbabaaa
bbbababbbbaaaaaaaabbababaaababaabab
ababaaaaaabaaab
ababaaaaabbbaba
baabbaaaabbaaaababbaababb
abbbbabbbbaaaababbbbbbaaaababb
aaaaabbaabaaaaababaa
aaaabbaaaabbaaa
aaaabbaabbaaaaaaabbbabbbaaabbaabaaa
babaaabbbaaabaababbaabababaaab
aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba

Without updating rules 8 and 11, these rules only match three messages: bbabbbbaabaabba, ababaaaaaabaaab, and ababaaaaabbbaba.

However, after updating rules 8 and 11, a total of 12 messages match:

bbabbbbaabaabba
babbbbaabbbbbabbbbbbaabaaabaaa
aaabbbbbbaaaabaababaabababbabaaabbababababaaa
bbbbbbbaaaabbbbaaabbabaaa
bbbababbbbaaaaaaaabbababaaababaabab
ababaaaaaabaaab
ababaaaaabbbaba
baabbaaaabbaaaababbaababb
abbbbabbbbaaaababbbbbbaaaababb
aaaaabbaabaaaaababaa
aaaabbaabbaaaaaaabbbabbbaaabbaabaaa
aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba

After updating rules 8 and 11, how many messages completely match rule 0?

*/

namespace Day19
{
    class Program
    {
        const int MAX_COUNT_POSITIONS = 1024;
        const int MAX_COUNT_PATTERNS = 512;
        const int MAX_COUNT_RULES = 256;
        const int MAX_COUNT_CHILDREN_PER_RULE = 8;
        static readonly int[,] sRulesChildren = new int[MAX_COUNT_CHILDREN_PER_RULE, MAX_COUNT_RULES];
        static readonly int[] sRulesCountChildren = new int[MAX_COUNT_RULES];
        static readonly bool[] sRulesOr = new bool[MAX_COUNT_RULES];
        static readonly int[] sRulesOrCountLHS = new int[MAX_COUNT_RULES];
        static readonly char[] sRulesMatchChar = new char[MAX_COUNT_RULES];
        static int sRulesCount = 0;
        static int sPatternsCount = 0;
        static readonly string[] sPatterns = new string[MAX_COUNT_PATTERNS];

        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day19 : Result1 {result1}");
                var expected = 129;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day19 : Result2 {result2}");
                var expected = 243;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static void Parse(bool part2, string[] lines)
        {
            sRulesCount = 0;
            for (var i = 0; i < lines.Length; ++i)
            {
                //0: 1 2
                //1: "a"
                //2: 1 3 | 3 1
                //3: "b"
                var line = lines[i].Trim();
                if (line.Length == 0)
                {
                    break;
                }
                var tokens = line.Split(':');
                var ruleID = int.Parse(tokens[0]);
                var rule = tokens[1].Trim();

                if (part2)
                {
                    if (ruleID == 8)
                    {
                        // 8: 42 | 42 8
                        rule = "42 | 42 8";
                        //rule = "42 8 | 42";
                    }
                    else if (ruleID == 11)
                    {
                        // 11: 42 31 | 42 11 31
                        rule = "42 31 | 42 11 31";
                        //rule = "42 11 31 | 42 31";
                    }
                }
                sRulesOr[ruleID] = false;
                sRulesOrCountLHS[ruleID] = 0;
                sRulesCountChildren[ruleID] = 0;
                sRulesMatchChar[ruleID] = ' ';
                if (rule.Contains('|'))
                {
                    sRulesOr[ruleID] = true;
                    var orTokens = rule.Split('|');
                    var countOrTokensSide = orTokens.Length;
                    if (countOrTokensSide % 2 == 1)
                    {
                        throw new InvalidProgramException($"Bad orTokens count {orTokens.Length} expected 2");
                    }
                    var childCount = 0;
                    for (var j = 0; j < countOrTokensSide; ++j)
                    {
                        var orTokensSide = orTokens[j].Trim().Split();
                        if (j == 0)
                        {
                            sRulesOrCountLHS[ruleID] = orTokensSide.Length;
                        }
                        for (var c = 0; c < orTokensSide.Length; ++c)
                        {
                            if (childCount >= MAX_COUNT_CHILDREN_PER_RULE)
                            {
                                throw new InvalidProgramException($"childCount too large {childCount} MAX {MAX_COUNT_CHILDREN_PER_RULE}");
                            }
                            sRulesChildren[childCount, ruleID] = int.Parse(orTokensSide[c]);
                            ++childCount;
                        }
                    }
                    sRulesCountChildren[ruleID] = childCount;
                }
                else if (rule.Contains('"'))
                {
                    sRulesMatchChar[ruleID] = rule.Trim('"').Trim()[0];
                }
                else
                {
                    var childrenTokens = rule.Split();
                    var countChildren = childrenTokens.Length;
                    sRulesCountChildren[ruleID] = countChildren;
                    for (var c = 0; c < countChildren; ++c)
                    {
                        if (c >= MAX_COUNT_CHILDREN_PER_RULE)
                        {
                            throw new InvalidProgramException($"childCount too large {c} MAX {MAX_COUNT_CHILDREN_PER_RULE}");
                        }
                        sRulesChildren[c, ruleID] = int.Parse(childrenTokens[c]);
                    }
                }
                ++sRulesCount;
            }
            sPatternsCount = 0;
            for (var i = sRulesCount + 1; i < lines.Length; ++i)
            {
                var line = lines[i].Trim();
                if (line.Length == 0)
                {
                    throw new InvalidProgramException($"0 length pattern at line {i}");
                }
                sPatterns[sPatternsCount] = line;
                ++sPatternsCount;
            }
        }

        private static bool Matches(int ruleID, int[] positions, ref int countPositions, string pattern)
        {
            var ruleCountChildren = sRulesCountChildren[ruleID];
            var tempCountPositions = 0;
            var tempPositions = new int[MAX_COUNT_POSITIONS];
            if (ruleCountChildren == 0)
            {
                var matchCharacter = sRulesMatchChar[ruleID];
                if (matchCharacter == ' ')
                {
                    throw new InvalidProgramException($"Bad match character {matchCharacter}");
                }
                for (var p = 0; p < countPositions; ++p)
                {
                    var pos = positions[p];
                    if (pos >= pattern.Length)
                    {
                        continue;
                    }
                    if (pattern[pos] != matchCharacter)
                    {
                        continue;
                    }
                    tempPositions[tempCountPositions] = pos + 1;
                    ++tempCountPositions;
                }
                countPositions = tempCountPositions;
                for (var p = 0; p < tempCountPositions; ++p)
                {
                    positions[p] = tempPositions[p];
                }
                return countPositions > 0;
            }
            else
            {
                if (!sRulesOr[ruleID])
                {
                    var localPositions = new int[MAX_COUNT_POSITIONS];
                    var localCountPositions = countPositions;
                    tempCountPositions = 0;
                    for (var p = 0; p < countPositions; ++p)
                    {
                        localPositions[0] = positions[p];
                        localCountPositions = 1;
                        var matches = true;
                        for (var r = 0; r < ruleCountChildren; ++r)
                        {
                            var subRuleID = sRulesChildren[r, ruleID];
                            if (!Matches(subRuleID, localPositions, ref localCountPositions, pattern))
                            {
                                matches = false;
                                break;
                            }
                        }
                        if ((localCountPositions == 0) && matches)
                        {
                            throw new InvalidProgramException($"matches {matches} LocalCount {localCountPositions}");
                        }
                        if ((localCountPositions > 0) && !matches)
                        {
                            throw new InvalidProgramException($"AND matches {matches} LocalCount {localCountPositions}");
                        }
                        if (matches)
                        {
                            for (var i = 0; i < localCountPositions; ++i)
                            {
                                var pos = localPositions[i];
                                tempPositions[tempCountPositions] = pos;
                                ++tempCountPositions;
                            }
                        }
                    }
                    countPositions = tempCountPositions;
                    for (var p = 0; p < tempCountPositions; ++p)
                    {
                        positions[p] = tempPositions[p];
                    }
                    return countPositions > 0;
                }
                else
                {
                    // LHS
                    var lhsCount = sRulesOrCountLHS[ruleID];
                    var localPositions = new int[MAX_COUNT_POSITIONS];
                    var localCountPositions = countPositions;
                    tempCountPositions = 0;
                    for (var p = 0; p < countPositions; ++p)
                    {
                        localPositions[0] = positions[p];
                        localCountPositions = 1;

                        var matches = true;
                        for (var r = 0; r < lhsCount; ++r)
                        {
                            var subRuleID = sRulesChildren[r, ruleID];
                            if (!Matches(subRuleID, localPositions, ref localCountPositions, pattern))
                            {
                                matches = false;
                                break;
                            }
                        }
                        if ((localCountPositions == 0) && matches)
                        {
                            throw new InvalidProgramException($"LHS matches {matches} LocalCount {localCountPositions}");
                        }
                        if ((localCountPositions > 0) && !matches)
                        {
                            throw new InvalidProgramException($"LHS matches {matches} LocalCount {localCountPositions}");
                        }
                        if (matches)
                        {
                            for (var i = 0; i < localCountPositions; ++i)
                            {
                                var pos = localPositions[i];
                                tempPositions[tempCountPositions] = pos;
                                ++tempCountPositions;
                            }
                        }
                    }
                    // RHS
                    for (var p = 0; p < countPositions; ++p)
                    {
                        localPositions[0] = positions[p];
                        localCountPositions = 1;

                        var matches = true;
                        for (var r = lhsCount; r < ruleCountChildren; ++r)
                        {
                            var subRuleID = sRulesChildren[r, ruleID];
                            if (!Matches(subRuleID, localPositions, ref localCountPositions, pattern))
                            {
                                matches = false;
                                break;
                            }
                        }
                        if ((localCountPositions == 0) && matches)
                        {
                            throw new InvalidProgramException($"RHS matches {matches} LocalCount {localCountPositions}");
                        }
                        if ((localCountPositions > 0) && !matches)
                        {
                            throw new InvalidProgramException($"RHS matches {matches} LocalCount {localCountPositions}");
                        }
                        if (matches)
                        {
                            for (var i = 0; i < localCountPositions; ++i)
                            {
                                var pos = localPositions[i];
                                tempPositions[tempCountPositions] = pos;
                                ++tempCountPositions;
                            }
                        }
                    }
                    countPositions = tempCountPositions;
                    for (var p = 0; p < tempCountPositions; ++p)
                    {
                        positions[p] = tempPositions[p];
                    }
                    return countPositions > 0;
                }
            }
        }

        private static bool CountMatches(string pattern)
        {
            var positions = new int[MAX_COUNT_POSITIONS];
            var countPositions = 0;
            positions[countPositions] = 0;
            ++countPositions;
            if (Matches(0, positions, ref countPositions, pattern))
            {
                for (var p = 0; p < countPositions; ++p)
                {
                    var pos = positions[p];
                    if (pos == pattern.Length)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static int Part1(string[] lines)
        {
            Parse(false, lines);

            var countValidPatterns = 0;
            for (var i = 0; i < sPatternsCount; ++i)
            {
                var pattern = sPatterns[i];
                if (CountMatches(pattern))
                {
                    ++countValidPatterns;
                }
            }
            return countValidPatterns;
        }

        public static int Part2(string[] lines)
        {
            Parse(true, lines);

            var countValidPatterns = 0;
            for (var i = 0; i < sPatternsCount; ++i)
            {
                var pattern = sPatterns[i];
                if (CountMatches(pattern))
                {
                    ++countValidPatterns;
                }
            }
            return countValidPatterns;
        }

        public static void Run()
        {
            Console.WriteLine("Day19 : Start");
            _ = new Program("Day19/input.txt", true);
            _ = new Program("Day19/input.txt", false);
            Console.WriteLine("Day19 : End");
        }
    }
}

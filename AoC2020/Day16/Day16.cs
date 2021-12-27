using System;

/*

--- Day 16: Ticket Translation ---

As you're walking to yet another connecting flight, you realize that one of the legs of your re-routed trip coming up is on a high-speed train.
However, the train ticket you were given is in a language you don't understand.
You should probably figure out what it says before you get to the train station after the next flight.

Unfortunately, you can't actually read the words on the ticket.
You can, however, read the numbers, and so you figure out the fields these tickets must have and the valid ranges for values in those fields.

You collect the rules for ticket fields, the numbers on your ticket, and the numbers on other nearby tickets for the same train service (via the airport security cameras) together into a single document you can reference (your puzzle input).

The rules for ticket fields specify a list of fields that exist somewhere on the ticket and the valid ranges of values for each field.
For example, a rule like class: 1-3 or 5-7 means that one of the fields in every ticket is named class and can be any value in the ranges 1-3 or 5-7 (inclusive, such that 3 and 5 are both valid in this field, but 4 is not).

Each ticket is represented by a single line of comma-separated values.
The values are the numbers on the ticket in the order they appear; every ticket has the same format.
For example, consider this ticket:

.--------------------------------------------------------.
| ????: 101    ?????: 102   ??????????: 103     ???: 104 |
|                                                        |
| ??: 301  ??: 302             ???????: 303      ??????? |
| ??: 401  ??: 402           ???? ????: 403    ????????? |
'--------------------------------------------------------'

Here, ? represents text in a language you don't understand.
This ticket might be represented as 101,102,103,104,301,302,303,401,402,403; of course, the actual train tickets you're looking at are much more complicated.
In any case, you've extracted just the numbers in such a way that the first number is always the same specific field, the second number is always a different specific field, and so on - you just don't know what each position actually means!

Start by determining which tickets are completely invalid; these are tickets that contain values which aren't valid for any field.
Ignore your ticket for now.

For example, suppose you have the following notes:

class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12

It doesn't matter which position corresponds to which field; you can identify invalid nearby tickets by considering only whether tickets contain values that are not valid for any field.

In this example, the values on the first nearby ticket are all valid for at least one field.
This is not true of the other three nearby tickets: the values 4, 55, and 12 are are not valid for any field.

Adding together all of the invalid values produces your ticket scanning error rate: 4 + 55 + 12 = 71.

Consider the validity of the nearby tickets you scanned.

What is your ticket scanning error rate?

Your puzzle answer was 19240.

--- Part Two ---

Now that you've identified which tickets contain invalid values, discard those tickets entirely.
Use the remaining valid tickets to determine which field is which.

Using the valid ranges for each field, determine what order the fields appear on the tickets.
The order is consistent between all tickets: if seat is the third field, it is the third field on every ticket, including your ticket.

For example, suppose you have the following notes:

class: 0-1 or 4-19
row: 0-5 or 8-19
seat: 0-13 or 16-19

your ticket:
11,12,13

nearby tickets:
3,9,18
15,1,5
5,14,9

Based on the nearby tickets in the above example, the first position must be row, the second position must be class, and the third position must be seat; you can conclude that in your ticket, class is 12, row is 11, and seat is 13.

Once you work out which field is which, look for the six fields on your ticket that start with the word departure.

What do you get if you multiply those six values together?

*/

namespace Day16
{
    class Program
    {
        const int MAX_COUNT_TICKETS = 256;
        const int MAX_COUNT_PARAMETERS = 32;
        static readonly int[] sMyTicketParams = new int[MAX_COUNT_PARAMETERS];
        static readonly string[] sRangeNames = new string[MAX_COUNT_PARAMETERS];
        static readonly int[] sRangeOneMins = new int[MAX_COUNT_PARAMETERS];
        static readonly int[] sRangeOneMaxs = new int[MAX_COUNT_PARAMETERS];
        static readonly int[] sRangeTwoMins = new int[MAX_COUNT_PARAMETERS];
        static readonly int[] sRangeTwoMaxs = new int[MAX_COUNT_PARAMETERS];
        static readonly int[,] sValidTicketParams = new int[MAX_COUNT_PARAMETERS, MAX_COUNT_TICKETS];
        static int sCountValidTickets = 0;
        static int sCountParameters = 0;

        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day16 : Result1 {result1}");
                var expected = 23954;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day16 : Result2 {result2}");
                var expected = 453459307723;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static int Parse(string[] lines)
        {
            var ranges = true;
            var myTicket = 0;
            var nearbyTickets = 0;
            var invalidTotal = 0;
            sCountParameters = 0;
            sCountValidTickets = 0;
            foreach (var l in lines)
            {
                var line = l.Trim();
                // class: 1-3 or 5-7
                // row: 6-11 or 33-44
                // seat: 13-40 or 45-50
                // 
                if (ranges)
                {
                    if (line.Length == 0)
                    {
                        ranges = false;
                        myTicket = 1;
                        continue;
                    }
                    var nameTokens = line.Split(':');
                    sRangeNames[sCountParameters] = nameTokens[0].Trim();
                    var tokens = nameTokens[1].Trim().Split(' ');
                    if (tokens[1] != "or")
                    {
                        throw new InvalidProgramException($"Unknown token '{tokens[1]}' expected 'or' line '{line}'");
                    }
                    var range1 = tokens[0].Trim();
                    var range1Tokens = range1.Split('-');
                    sRangeOneMins[sCountParameters] = int.Parse(range1Tokens[0]);
                    sRangeOneMaxs[sCountParameters] = int.Parse(range1Tokens[1]);
                    var range2 = tokens[2].Trim();
                    var range2Tokens = range2.Split('-');
                    sRangeTwoMins[sCountParameters] = int.Parse(range2Tokens[0]);
                    sRangeTwoMaxs[sCountParameters] = int.Parse(range2Tokens[1]);
                    ++sCountParameters;
                }
                // your ticket:
                // 7,1,14
                // 
                else if (myTicket == 1)
                {
                    if (line != "your ticket:")
                    {
                        throw new InvalidProgramException($"Expected 'your ticket:' got '{line}'");
                    }
                    myTicket = 2;
                }
                else if (myTicket == 2)
                {
                    if (line.Length == 0)
                    {
                        nearbyTickets = 1;
                        myTicket = 0;
                        continue;
                    }
                    var tokens = line.Split(',');
                    if (tokens.Length != sCountParameters)
                    {
                        throw new InvalidProgramException($"Expected '{sCountParameters}' values got '{tokens.Length}' Line '{line}'");
                    }
                    for (var i = 0; i < tokens.Length; ++i)
                    {
                        var param = int.Parse(tokens[i]);
                        sMyTicketParams[i] = param;
                    }
                }
                // nearby tickets:
                // 7,3,47
                // 40,4,50
                // 55,2,20
                // 38,6,12
                else if (nearbyTickets == 1)
                {
                    if (line != "nearby tickets:")
                    {
                        throw new InvalidProgramException($"Expected 'nearby tickets:' got '{line}'");
                    }
                    nearbyTickets = 2;
                }
                else if (nearbyTickets == 2)
                {
                    var tokens = line.Split(',');
                    if (tokens.Length != sCountParameters)
                    {
                        throw new InvalidProgramException($"Expected '{sCountParameters}' values got '{tokens.Length}' Line '{line}'");
                    }
                    var validTicket = true;
                    for (var p = 0; p < sCountParameters; ++p)
                    {
                        var validParam = false;
                        var value = int.Parse(tokens[p]);
                        for (var j = 0; j < sCountParameters; ++j)
                        {
                            var min = sRangeOneMins[j];
                            var max = sRangeOneMaxs[j];
                            if (IsValid(value, j))
                            {
                                validParam = true;
                                break;
                            }
                        }
                        if (!validParam)
                        {
                            validTicket = false;
                            invalidTotal += value;
                            break;
                        }
                    }
                    if (validTicket)
                    {
                        for (var p = 0; p < sCountParameters; ++p)
                        {
                            var value = int.Parse(tokens[p]);
                            sValidTicketParams[p, sCountValidTickets] = value;
                        }
                        ++sCountValidTickets;
                    }
                }
                else
                {
                    throw new InvalidProgramException($"Unknown state line '{line}'");
                }
            }
            return invalidTotal;
        }

        public static int Part1(string[] lines)
        {
            return Parse(lines);
        }

        private static bool IsValid(int value, int paramIndex)
        {
            var min = sRangeOneMins[paramIndex];
            var max = sRangeOneMaxs[paramIndex];
            if ((value >= min) && (value <= max))
            {
                return true;
            }
            min = sRangeTwoMins[paramIndex];
            max = sRangeTwoMaxs[paramIndex];
            if ((value >= min) && (value <= max))
            {
                return true;
            }
            return false;
        }

        public static long Part2(string[] lines)
        {
            Parse(lines);
            var ticketParamMapping = new int[sCountParameters];
            var paramToTicketMapping = new int[sCountParameters];
            for (var p = 0; p < sCountParameters; ++p)
            {
                ticketParamMapping[p] = -1;
                paramToTicketMapping[p] = -1;
            }

            var countNeeded = 0;
            for (var p = 0; p < sCountParameters; ++p)
            {
                if (sRangeNames[p].StartsWith("departure", StringComparison.Ordinal))
                {
                    ++countNeeded;
                }
            }
            var countFound = 0;
            while (true)
            {
                for (var ticketParamIndex = 0; ticketParamIndex < sCountParameters; ++ticketParamIndex)
                {
                    if (ticketParamMapping[ticketParamIndex] != -1)
                    {
                        continue;
                    }
                    var countMatches = new int[sCountParameters];
                    for (var paramIndex = 0; paramIndex < sCountParameters; ++paramIndex)
                    {
                        if (paramToTicketMapping[paramIndex] != -1)
                        {
                            continue;
                        }
                        var valid = true;
                        if (!IsValid(sMyTicketParams[ticketParamIndex], paramIndex))
                        {
                            break;
                        }
                        for (var ticket = 0; ticket < sCountValidTickets; ++ticket)
                        {
                            var ticketValue = sValidTicketParams[ticketParamIndex, ticket];
                            if (!IsValid(ticketValue, paramIndex))
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (valid)
                        {
                            ++countMatches[paramIndex];
                        }
                    }
                    var mappedParamIndex = -1;
                    var validMatches = 0;
                    for (var paramIndex = 0; paramIndex < sCountParameters; ++paramIndex)
                    {
                        if (countMatches[paramIndex] == 1)
                        {
                            mappedParamIndex = paramIndex;
                            ++validMatches;
                        }
                    }

                    if (validMatches == 1)
                    {
                        ticketParamMapping[ticketParamIndex] = mappedParamIndex;
                        paramToTicketMapping[mappedParamIndex] = ticketParamIndex;
                        var mapping = ticketParamMapping[ticketParamIndex];
                        Console.WriteLine($"Ticket Param[{ticketParamIndex}] maps to {mapping} '{sRangeNames[mapping]}'");
                        if (sRangeNames[mappedParamIndex].StartsWith("departure", StringComparison.Ordinal))
                        {
                            ++countFound;
                        }
                    }
                }
                if (countFound == countNeeded)
                {
                    break;
                }
            }
            var total = 1L;
            for (var p = 0; p < sCountParameters; ++p)
            {
                if (sRangeNames[p].StartsWith("departure", StringComparison.Ordinal))
                {
                    var ticketParam = paramToTicketMapping[p];
                    total *= sMyTicketParams[ticketParam];
                }
            }
            return total;
        }

        public static void Run()
        {
            Console.WriteLine("Day16 : Start");
            _ = new Program("Day16/input.txt", true);
            _ = new Program("Day16/input.txt", false);
            Console.WriteLine("Day16 : End");
        }
    }
}

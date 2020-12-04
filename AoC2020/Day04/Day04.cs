using System;

/*

--- Day 4: Passport Processing ---

You arrive at the airport only to realize that you grabbed your North Pole Credentials instead of your passport.
While these documents are extremely similar, North Pole Credentials aren't issued by a country and therefore aren't actually valid documentation for travel in most of the world.

It seems like you're not the only one having problems, though; a very long line has formed for the automatic passport scanners, and the delay could upset your travel itinerary.

Due to some questionable network security, you realize you might be able to solve both of these problems at the same time.

The automatic passport scanners are slow because they're having trouble detecting which passports have all required fields.
The expected fields are as follows:

byr (Birth Year)
iyr (Issue Year)
eyr (Expiration Year)
hgt (Height)
hcl (Hair Color)
ecl (Eye Color)
pid (Passport ID)
cid (Country ID)
Passport data is validated in batch files (your puzzle input).
Each passport is represented as a sequence of key:value pairs separated by spaces or newlines.
Passports are separated by blank lines.

Here is an example batch file containing four passports:

ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in
The first passport is valid - all eight fields are present.
The second passport is invalid - it is missing hgt (the Height field).

The third passport is interesting; the only missing field is cid, so it looks like data from North Pole Credentials, not a passport at all! Surely, nobody would mind if you made the system temporarily ignore missing cid fields.
Treat this "passport" as valid.

The fourth passport is missing two fields, cid and byr.
Missing cid is fine, but missing any other field is not, so this passport is invalid.

According to the above rules, your improved system would report 2 valid passports.

Count the number of valid passports - those that have all required fields.
Treat cid as optional.
In your batch file, how many passports are valid?

*/

namespace Day04
{
    class Program
    {
        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day04 : Result1 {result1}");
                var expected = 228;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = -666;
                Console.WriteLine($"Day04 : Result2 {result2}");
                var expected = -123;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        public static int Part1(string[] lines)
        {
            // key:value seperated by spaces or newlines
            // Blank line means new passport
            // valid keys: byr iyr eyr hgt hcl ecl pid cid
            // cid does not have to be present
            var count = 0;
            var keyCount = 0;
            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    count += (keyCount == 7) ? 1 : 0;
                    keyCount = 0;
                    continue;
                }
                var tokens = line.Trim().Split();
                foreach (var tok in tokens)
                {
                    var keyValue = tok.Trim().Split(':');
                    var key = keyValue[0];
                    if ((key == "byr") || (key == "iyr") || (key == "eyr") || (key == "hgt") ||
                        (key == "hcl") || (key == "ecl") || (key == "pid"))
                    {
                        ++keyCount;
                    }
                    else if (key != "cid")
                    {
                        throw new InvalidProgramException($"Unknown key {key} found '{line}'");
                    }
                }
            }
            count += (keyCount == 7) ? 1 : 0;
            keyCount = 0;
            return count;
        }

        public static void Run()
        {
            Console.WriteLine("Day04 : Start");
            _ = new Program("Day04/input.txt", true);
            _ = new Program("Day04/input.txt", false);
            Console.WriteLine("Day04 : End");
        }
    }
}

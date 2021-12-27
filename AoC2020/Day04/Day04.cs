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

Your puzzle answer was 228.

--- Part Two ---

The line is moving more quickly now, but you overhear airport security talking about how passports with invalid data are getting through.
Better add some data validation, quick!

You can continue to ignore the cid field, but each other field has strict rules about what values are valid for automatic validation:

byr (Birth Year) - four digits; at least 1920 and at most 2002.
iyr (Issue Year) - four digits; at least 2010 and at most 2020.
eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
hgt (Height) - a number followed by either cm or in:
If cm, the number must be at least 150 and at most 193.
If in, the number must be at least 59 and at most 76.
hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
pid (Passport ID) - a nine-digit number, including leading zeroes.
cid (Country ID) - ignored, missing or not.
Your job is to count the passports where all required fields are both present and valid according to the above rules.
Here are some example values:

byr valid:   2002
byr invalid: 2003

hgt valid:   60in
hgt valid:   190cm
hgt invalid: 190in
hgt invalid: 190

hcl valid:   #123abc
hcl invalid: #123abz
hcl invalid: 123abc

ecl valid:   brn
ecl invalid: wat

pid valid:   000000001
pid invalid: 0123456789
Here are some invalid passports:

eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946

hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007
Here are some valid passports:

pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f

eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719

Count the number of valid passports - those that have all required fields and valid values.
Continue to treat cid as optional.
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
                var expected = 200;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day04 : Result2 {result2}");
                var expected = 116;
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
                var l = line.Trim();
                if (l.Length == 0)
                {
                    count += (keyCount == 7) ? 1 : 0;
                    keyCount = 0;
                    continue;
                }
                var tokens = line.Trim().Split();
                foreach (var tok in tokens)
                {
                    var keyValue = tok.Trim().Split(':');
                    var key = keyValue[0].Trim();
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
            return count;
        }

        public static int Part2(string[] lines)
        {
            // key:value seperated by spaces or newlines
            // Blank line means new passport
            // valid keys: byr iyr eyr hgt hcl ecl pid cid
            // cid does not have to be present
            var count = 0;
            var keyCount = 0;
            foreach (var line in lines)
            {
                var l = line.Trim();
                if (l.Length == 0)
                {
                    count += (keyCount == 7) ? 1 : 0;
                    keyCount = 0;
                    continue;
                }
                var tokens = l.Trim().Split();
                foreach (var tok in tokens)
                {
                    var keyValue = tok.Trim().Split(':');
                    var key = keyValue[0].Trim();
                    var value = keyValue[1].Trim();
                    // byr (Birth Year) - four digits; at least 1920 and at most 2002.
                    if (key == "byr")
                    {
                        if (value.Length == 4)
                        {
                            var byr = int.Parse(value);
                            if ((byr >= 1920) && (byr <= 2002))
                            {
                                ++keyCount;
                            }
                        }
                    }
                    // iyr (Issue Year) - four digits; at least 2010 and at most 2020.
                    else if (key == "iyr")
                    {
                        if (value.Length == 4)
                        {
                            var iyr = int.Parse(value);
                            if ((iyr >= 2010) && (iyr <= 2020))
                            {
                                ++keyCount;
                            }
                        }
                    }
                    // eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
                    else if (key == "eyr")
                    {
                        if (value.Length == 4)
                        {
                            var eyr = int.Parse(value);
                            if ((eyr >= 2020) && (eyr <= 2030))
                            {
                                ++keyCount;
                            }
                        }
                    }
                    // hgt (Height) - a number followed by either cm or in:
                    // If cm, the number must be at least 150 and at most 193.
                    // If in, the number must be at least 59 and at most 76.
                    else if (key == "hgt")
                    {
                        if (value.EndsWith("cm"))
                        {
                            var cmToken = value.Split("cm")[0].Trim();
                            var cm = int.Parse(cmToken);
                            if ((cm >= 150) && (cm <= 193))
                            {
                                ++keyCount;
                            }
                        }
                        else if (value.EndsWith("in"))
                        {
                            var inToken = value.Split("in")[0].Trim();
                            var inch = int.Parse(inToken);
                            if ((inch >= 59) && (inch <= 76))
                            {
                                ++keyCount;
                            }
                        }
                    }
                    // hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                    else if (key == "hcl")
                    {
                        if (value.Length == 7)
                        {
                            if (value[0] == '#')
                            {
                                var validChar = 0;
                                for (var i = 1; i < 7; ++i)
                                {
                                    var c = value[i];
                                    if ((c >= '0') && (c <= '9'))
                                    {
                                        ++validChar;
                                    }
                                    else if ((c >= 'a') && (c <= 'f'))
                                    {
                                        ++validChar;
                                    }
                                }
                                if (validChar == 6)
                                {
                                    ++keyCount;
                                }
                            }
                        }
                    }
                    // ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                    else if (key == "ecl")
                    {
                        if ((value == "amb") || (value == "blu") || (value == "brn") ||
                            (value == "gry") || (value == "grn") || (value == "hzl") ||
                            (value == "oth"))
                        {
                            ++keyCount;
                        }
                    }
                    // pid (Passport ID) - a nine-digit number, including leading zeroes.
                    else if (key == "pid")
                    {
                        if (value.Length == 9)
                        {
                            var validChar = 0;
                            for (var i = 0; i < 9; ++i)
                            {
                                var c = value[i];
                                if ((c >= '0') && (c <= '9'))
                                {
                                    ++validChar;
                                }
                            }
                            if (validChar == 9)
                            {
                                ++keyCount;
                            }
                        }
                    }
                    // cid (Country ID) - ignored, missing or not.
                    else if (key != "cid")
                    {
                        throw new InvalidProgramException($"Unknown key {key} found '{line}'");
                    }
                }
            }
            count += (keyCount == 7) ? 1 : 0;
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

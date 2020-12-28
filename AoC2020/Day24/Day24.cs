using System;

/*

--- Day 24: Lobby Layout ---

Your raft makes it to the tropical island;
it turns out that the small crab was an excellent navigator.
You make your way to the resort.

As you enter the lobby, you discover a small problem: the floor is being renovated.
You can't even reach the check-in desk until they've finished installing the new tile floor.

The tiles are all hexagonal;
they need to be arranged in a hex grid with a very specific color pattern.
Not in the mood to wait, you offer to help figure out the pattern.

The tiles are all white on one side and black on the other.
They start with the white side facing up.
The lobby is large enough to fit whatever pattern might need to appear there.

A member of the renovation crew gives you a list of the tiles that need to be flipped over (your puzzle input).
Each line in the list identifies a single tile that needs to be flipped by giving a series of steps starting from a reference tile in the very center of the room.
(Every line starts from the same reference tile.)

Because the tiles are hexagonal, every tile has six neighbors: east, southeast, southwest, west, northwest, and northeast.
These directions are given in your list, respectively, as e, se, sw, w, nw, and ne.
A tile is identified by a series of these directions with no delimiters; for example, esenee identifies the tile you land on if you start at the reference tile and then move one tile east, one tile southeast, one tile northeast, and one tile east.

Each time a tile is identified, it flips from white to black or from black to white.
Tiles might be flipped more than once.
For example, a line like esew flips a tile immediately adjacent to the reference tile, and a line like nwwswee flips the reference tile itself.

Here is a larger example:

sesenwnenenewseeswwswswwnenewsewsw
neeenesenwnwwswnenewnwwsewnenwseswesw
seswneswswsenwwnwse
nwnwneseeswswnenewneswwnewseswneseene
swweswneswnenwsewnwneneseenw
eesenwseswswnenwswnwnwsewwnwsene
sewnenenenesenwsewnenwwwse
wenwwweseeeweswwwnwwe
wsweesenenewnwwnwsenewsenwwsesesenwne
neeswseenwwswnwswswnw
nenwswwsewswnenenewsenwsenwnesesenew
enewnwewneswsewnwswenweswnenwsenwsw
sweneswneswneneenwnewenewwneswswnese
swwesenesewenwneswnwwneseswwne
enesenwswwswneneswsenwnewswseenwsese
wnwnesenesenenwwnenwsewesewsesesew
nenewswnwewswnenesenwnesewesw
eneswnwswnwsenenwnwnwwseeswneewsenese
neswnwewnwnwseenwseesewsenwsweewe
wseweeenwnesenwwwswnew

In the above example, 10 tiles are flipped once (to black), and 5 more are flipped twice (to black, then back to white).
After all of these instructions have been followed, a total of 10 tiles are black.

Go through the renovation crew's list and determine which tiles they need to flip.
After all of the instructions have been followed, how many tiles are left with the black side up?

  *---*
 / \ / \
*---*---*
 \ / \ /
  *---*


e =>    x += 2  y += 0
se =>   x += 1  y += 1
sw =>   x -= 1  y -= 1
w =>    x -= 2  y += 0
nw =>   x -= 1  y -= 1
ne =>   x -= 1  y -= 1

e/w = x +/-2
se = x

Your puzzle answer was 538.

--- Part Two ---

The tile floor in the lobby is meant to be a living art exhibit.
Every day, the tiles are all flipped according to the following rules:

Any black tile with zero or more than 2 black tiles immediately adjacent to it is flipped to white.
Any white tile with exactly 2 black tiles immediately adjacent to it is flipped to black.
Here, tiles immediately adjacent means the six tiles directly touching the tile in question.

The rules are applied simultaneously to every tile;
put another way, it is first determined which tiles need to be flipped, then they are all flipped at the same time.

In the above example, the number of black tiles that are facing up after the given number of days has passed is as follows:

Day 1: 15
Day 2: 12
Day 3: 25
Day 4: 14
Day 5: 23
Day 6: 28
Day 7: 41
Day 8: 37
Day 9: 49
Day 10: 37

Day 20: 132
Day 30: 259
Day 40: 406
Day 50: 566
Day 60: 788
Day 70: 1106
Day 80: 1373
Day 90: 1844
Day 100: 2208

After executing this process a total of 100 times, there would be 2208 black tiles facing up.

How many tiles will be black after 100 days?

*/

namespace Day24
{
    class Program
    {
        const int MOVE_END = 0;
        const int MOVE_EAST = 1;
        const int MOVE_SOUTH_EAST = 2;
        const int MOVE_SOUTH_WEST = 3;
        const int MOVE_WEST = 4;
        const int MOVE_NORTH_WEST = 5;
        const int MOVE_NORTH_EAST = 6;

        const int MAX_COUNT_COMMANDS = 1024;
        const int MAX_COUNT_MOVES_PER_COMMAND = 32;
        const int MAX_COUNT_GRID = 256;
        const int GRID_ORIGIN = MAX_COUNT_GRID / 2;

        private static readonly int[,] sCommands = new int[MAX_COUNT_COMMANDS, MAX_COUNT_MOVES_PER_COMMAND];
        private static readonly byte[,] sGrid = new byte[MAX_COUNT_GRID, MAX_COUNT_GRID];
        private static readonly byte[,] sNewGrid = new byte[MAX_COUNT_GRID, MAX_COUNT_GRID];
        private static int sCountCommands = 0;

        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day24 : Result1 {result1}");
                var expected = 538;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines, 100);
                Console.WriteLine($"Day24 : Result2 {result2}");
                var expected = 4259;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static void Parse(string[] lines)
        {
            var command = 0;
            foreach (var l in lines)
            {
                var line = l.Trim();
                // e, se, sw, w, nw, and ne.
                var i = 0;
                var move = 0;
                var countChars = line.Length;
                while (i < countChars)
                {
                    var c = line[i];
                    if (c == 'e')
                    {
                        sCommands[command, move] = MOVE_EAST;
                        i += 1;
                    }
                    else if (c == 'w')
                    {
                        sCommands[command, move] = MOVE_WEST;
                        i += 1;
                    }
                    else if (c == 's')
                    {
                        i += 1;
                        c = line[i];
                        if (c == 'e')
                        {
                            sCommands[command, move] = MOVE_SOUTH_EAST;
                            i += 1;
                        }
                        else if (c == 'w')
                        {
                            sCommands[command, move] = MOVE_SOUTH_WEST;
                            i += 1;
                        }
                        else
                        {
                            throw new InvalidProgramException($"Unknown char '{c}' line '{line}'");
                        }
                    }
                    else if (c == 'n')
                    {
                        i += 1;
                        c = line[i];
                        if (c == 'e')
                        {
                            sCommands[command, move] = MOVE_NORTH_EAST;
                            i += 1;
                        }
                        else if (c == 'w')
                        {
                            sCommands[command, move] = MOVE_NORTH_WEST;
                            i += 1;
                        }
                        else
                        {
                            throw new InvalidProgramException($"Unknown char '{c}' line '{line}'");
                        }
                    }
                    else
                    {
                        throw new InvalidProgramException($"Unknown char '{c}' line '{line}'");
                    }
                    ++move;
                }
                sCommands[command, move] = MOVE_END;
                ++command;
            }
            sCountCommands = command;
            for (var y = 0; y < MAX_COUNT_GRID; ++y)
            {
                for (var x = 0; x < MAX_COUNT_GRID; ++x)
                {
                    sGrid[x, y] = 0;
                    sNewGrid[x, y] = 0;
                }
            }
        }

        private static int ApplyCommands()
        {
            var countOnes = 0;
            for (var c = 0; c < sCountCommands; ++c)
            {
                var x = GRID_ORIGIN;
                var y = GRID_ORIGIN;
                var m = 0;
                int move;
                do
                {
                    move = sCommands[c, m];
                    switch (move)
                    {
                        // e =>    x += 2  y += 0
                        // se =>   x += 1  y += 1
                        // sw =>   x -= 1  y += 1
                        // w =>    x -= 2  y += 0
                        // nw =>   x -= 1  y -= 1
                        // ne =>   x += 1  y -= 1
                        case MOVE_EAST:
                            x += 2;
                            break;
                        case MOVE_SOUTH_EAST:
                            x += 1;
                            y += 1;
                            break;
                        case MOVE_SOUTH_WEST:
                            x -= 1;
                            y += 1;
                            break;
                        case MOVE_WEST:
                            x -= 2;
                            break;
                        case MOVE_NORTH_WEST:
                            x -= 1;
                            y -= 1;
                            break;
                        case MOVE_NORTH_EAST:
                            x += 1;
                            y -= 1;
                            break;
                        case MOVE_END:
                            break;
                        default:
                            throw new InvalidProgramException($"Unknown move {move}");
                    }
                    ++m;
                }
                while (move != MOVE_END);
                if (sGrid[x, y] == 0)
                {
                    ++countOnes;
                }
                else if (sGrid[x, y] == 1)
                {
                    --countOnes;
                }
                sGrid[x, y] ^= 1;
            }
            return countOnes;
        }

        private static int CountBlackCells()
        {
            var countBlackCells = 0;
            for (var y = 0; y < MAX_COUNT_GRID; ++y)
            {
                for (var x = 0; x < MAX_COUNT_GRID; ++x)
                {
                    if (sGrid[x, y] == 1)
                    {
                        ++countBlackCells;
                    }
                }
            }
            return countBlackCells;
        }

        private static int CountNeighbours(int x, int y)
        {
            var countNeighbours = 0;
            if (x > 0)
            {
                if (y > 0)
                {
                    countNeighbours += sGrid[x - 1, y - 1];
                }
                if (y < (MAX_COUNT_GRID - 1))
                {
                    countNeighbours += sGrid[x - 1, y + 1];
                }
            }
            if (x < (MAX_COUNT_GRID - 1))
            {
                if (y > 0)
                {
                    countNeighbours += sGrid[x + 1, y - 1];
                }
                if (y < (MAX_COUNT_GRID - 1))
                {
                    countNeighbours += sGrid[x + 1, y + 1];
                }
            }
            if (x > 1)
            {
                countNeighbours += sGrid[x - 2, y + 0];
            }
            if (x < (MAX_COUNT_GRID - 2))
            {
                countNeighbours += sGrid[x + 2, y + 0];
            }
            return countNeighbours;
        }

        private static void SimulateDay()
        {
            for (var y = 0; y < MAX_COUNT_GRID; ++y)
            {
                for (var x = 0; x < MAX_COUNT_GRID; ++x)
                {
                    var countNeighbours = CountNeighbours(x, y);
                    var cell = sGrid[x, y];
                    var newCell = cell;
                    if (cell == 1)
                    {
                        // black tile with zero or more than 2 black tiles neighbours -> white
                        if (countNeighbours == 0)
                        {
                            newCell = 0;
                        }
                        else if (countNeighbours > 2)
                        {
                            newCell = 0;
                        }
                    }
                    else if (cell == 0)
                    {
                        // white tile with exactly 2 black tiles neighbours -> black
                        if (countNeighbours == 2)
                        {
                            newCell = 1;
                        }
                    }
                    else
                    {
                        throw new InvalidProgramException($"Invalid cell value {cell} at {x},{y}");
                    }
                    sNewGrid[x, y] = newCell;
                }
            }
            for (var y = 0; y < MAX_COUNT_GRID; ++y)
            {
                for (var x = 0; x < MAX_COUNT_GRID; ++x)
                {
                    sGrid[x, y] = sNewGrid[x, y];
                }
            }
        }

        public static int Part1(string[] lines)
        {
            Parse(lines);
            var countOnes = ApplyCommands();

            var countBlackCells = CountBlackCells();
            if (countBlackCells != countOnes)
            {
                throw new InvalidProgramException($"countOnes != countBlackCells {countOnes} != {countBlackCells}");
            }
            return countBlackCells;
        }

        public static int Part2(string[] lines, int days)
        {
            Parse(lines);
            ApplyCommands();

            for (var d = 0; d < days; ++d)
            {
                SimulateDay();
            }

            return CountBlackCells();
        }

        public static void Run()
        {
            Console.WriteLine("Day24 : Start");
            _ = new Program("Day24/input.txt", true);
            _ = new Program("Day24/input.txt", false);
            Console.WriteLine("Day24 : End");
        }
    }
}

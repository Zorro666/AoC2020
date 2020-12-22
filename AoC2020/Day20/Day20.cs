using System;

/*

--- Day 20: Jurassic Jigsaw ---

The high-speed train leaves the forest and quickly carries you south.
You can even see a desert in the distance!
Since you have some spare time, you might as well see if there was anything interesting in the image the Mythical Information Bureau satellite captured.

After decoding the satellite messages, you discover that the data actually contains many small images created by the satellite's camera array.
The camera array consists of many cameras; rather than produce a single square image, they produce many smaller square image tiles that need to be reassembled back into a single image.

Each camera in the camera array returns a single monochrome image tile with a random unique ID number.
The tiles (your puzzle input) arrived in a random order.

Worse yet, the camera array appears to be malfunctioning: each image tile has been rotated and flipped to a random orientation.
Your first task is to reassemble the original image by orienting the tiles so they fit together.

To show how the tiles should be reassembled, each tile's image data includes a border that should line up exactly with its adjacent tiles.
All tiles have this border, and the border lines up exactly when the tiles are both oriented correctly.
Tiles at the edge of the image also have this border, but the outermost edges won't line up with any other tiles.

For example, suppose you have the following nine tiles:

Tile 2311:
..##.#..#.
##..#.....
#...##..#.
####.#...#
##.##.###.
##...#.###
.#.#.#..##
..#....#..
###...#.#.
..###..###

Tile 1951:
#.##...##.
#.####...#
.....#..##
#...######
.##.#....#
.###.#####
###.##.##.
.###....#.
..#.#..#.#
#...##.#..

Tile 1171:
####...##.
#..##.#..#
##.#..#.#.
.###.####.
..###.####
.##....##.
.#...####.
#.##.####.
####..#...
.....##...

Tile 1427:
###.##.#..
.#..#.##..
.#.##.#..#
#.#.#.##.#
....#...##
...##..##.
...#.#####
.#.####.#.
..#..###.#
..##.#..#.

Tile 1489:
##.#.#....
..##...#..
.##..##...
..#...#...
#####...#.
#..#.#.#.#
...#.#.#..
##.#...##.
..##.##.##
###.##.#..

Tile 2473:
#....####.
#..#.##...
#.##..#...
######.#.#
.#...#.#.#
.#########
.###.#..#.
########.#
##...##.#.
..###.#.#.

Tile 2971:
..#.#....#
#...###...
#.#.###...
##.##..#..
.#####..##
.#..####.#
#..#.#..#.
..####.###
..#.#.###.
...#.#.#.#

Tile 2729:
...#.#.#.#
####.#....
..#.#.....
....#..#.#
.##..##.#.
.#.####...
####.#.#..
##.####...
##..#.##..
#.##...##.

Tile 3079:
#.#.#####.
.#..######
..#.......
######....
####.#..#.
.#...#.##.
#.#####.##
..#.###...
..#.......
..#.###...

By rotating, flipping, and rearranging them, you can find a square arrangement that causes all adjacent borders to line up:

#...##.#.. ..###..### #.#.#####.
..#.#..#.# ###...#.#. .#..######
.###....#. ..#....#.. ..#.......
###.##.##. .#.#.#..## ######....
.###.##### ##...#.### ####.#..#.
.##.#....# ##.##.###. .#...#.##.
#...###### ####.#...# #.#####.##
.....#..## #...##..#. ..#.###...
#.####...# ##..#..... ..#.......
#.##...##. ..##.#..#. ..#.###...

#.##...##. ..##.#..#. ..#.###...
##..#.##.. ..#..###.# ##.##....#
##.####... .#.####.#. ..#.###..#
####.#.#.. ...#.##### ###.#..###
.#.####... ...##..##. .######.##
.##..##.#. ....#...## #.#.#.#...
....#..#.# #.#.#.##.# #.###.###.
..#.#..... .#.##.#..# #.###.##..
####.#.... .#..#.##.. .######...
...#.#.#.# ###.##.#.. .##...####

...#.#.#.# ###.##.#.. .##...####
..#.#.###. ..##.##.## #..#.##..#
..####.### ##.#...##. .#.#..#.##
#..#.#..#. ...#.#.#.. .####.###.
.#..####.# #..#.#.#.# ####.###..
.#####..## #####...#. .##....##.
##.##..#.. ..#...#... .####...#.
#.#.###... .##..##... .####.##.#
#...###... ..##...#.. ...#..####
..#.#....# ##.#.#.... ...##.....

For reference, the IDs of the above tiles are:

1951    2311    3079
2729    1427    2473
2971    1489    1171

To check that you've assembled the image correctly, multiply the IDs of the four corner tiles together 
If you do this with the assembled tiles from the example above, you get 1951 * 3079 * 2971 * 1171 = 20899048083289.

Assemble the tiles into an image.
What do you get if you multiply together the IDs of the four corner tiles?

Your puzzle answer was 59187348943703.

--- Part Two ---

Now, you're ready to check the image for sea monsters.

The borders of each tile are not part of the actual image; start by removing them.

In the example above, the tiles become:

.#.#..#. ##...#.# #..#####
###....# .#....#. .#......
##.##.## #.#.#..# #####...
###.#### #...#.## ###.#..#
##.#.... #.##.### #...#.##
...##### ###.#... .#####.#
....#..# ...##..# .#.###..
.####... #..#.... .#......

#..#.##. .#..###. #.##....
#.####.. #.####.# .#.###..
###.#.#. ..#.#### ##.#..##
#.####.. ..##..## ######.#
##..##.# ...#...# .#.#.#..
...#..#. .#.#.##. .###.###
.#.#.... #.##.#.. .###.##.
###.#... #..#.##. ######..

.#.#.### .##.##.# ..#.##..
.####.## #.#...## #.#..#.#
..#.#..# ..#.#.#. ####.###
#..####. ..#.#.#. ###.###.
#####..# ####...# ##....##
#.##..#. .#...#.. ####...#
.#.###.. ##..##.. ####.##.
...###.. .##...#. ..#..###

Remove the gaps to form the actual image:

.#.#..#.##...#.##..#####
###....#.#....#..#......
##.##.###.#.#..######...
###.#####...#.#####.#..#
##.#....#.##.####...#.##
...########.#....#####.#
....#..#...##..#.#.###..
.####...#..#.....#......
#..#.##..#..###.#.##....
#.####..#.####.#.#.###..
###.#.#...#.######.#..##
#.####....##..########.#
##..##.#...#...#.#.#.#..
...#..#..#.#.##..###.###
.#.#....#.##.#...###.##.
###.#...#..#.##.######..
.#.#.###.##.##.#..#.##..
.####.###.#...###.#..#.#
..#.#..#..#.#.#.####.###
#..####...#.#.#.###.###.
#####..#####...###....##
#.##..#..#...#..####...#
.#.###..##..##..####.##.
...###...##...#...#..###

Now, you're ready to search for sea monsters! 
Because your image is monochrome, a sea monster will look like this:

                  # 
#    ##    ##    ###
 #  #  #  #  #  #   

When looking for this pattern in the image, the spaces can be anything; only the # need to match.
Also, you might need to rotate or flip your image before it's oriented correctly to find sea monsters.
In the above image, after flipping and rotating it to the appropriate orientation, there are two sea monsters (marked with O):

.####...#####..#...###..
#####..#..#.#.####..#.#.
.#.#...#.###...#.##.O#..
#.O.##.OO#.#.OO.##.OOO##
..#O.#O#.O##O..O.#O##.##
...#.#..##.##...#..#..##
#.##.#..#.#..#..##.#.#..
.###.##.....#...###.#...
#.####.#.#....##.#..#.#.
##...#..#....#..#...####
..#.##...###..#.#####..#
....#.##.#.#####....#...
..##.##.###.....#.##..#.
#...#...###..####....##.
.#.##...#.##.#.#.###...#
#.###.#..####...##..#...
#.###...#.##...#.##O###.
.O##.#OO.###OO##..OOO##.
..O#.O..O..O.#O##O##.###
#.#..##.########..#..##.
#.#####..#.#...##..#....
#....##..#.#########..##
#...#.....#..##...###.##
#..###....##.#...##.##.#

Determine how rough the waters are in the sea monsters' habitat by counting the number of # that are not part of a sea monster.

In the above example, the habitat's water roughness is 273.

How many # are not part of a sea monster?

*/

namespace Day20
{
    class Program
    {
        const int EDGE_TOP = 0;
        const int EDGE_BOTTOM = 1;
        const int EDGE_LEFT = 2;
        const int EDGE_RIGHT = 3;
        const int EDGE_TOP_FLIP = 4;
        const int EDGE_BOTTOM_FLIP = 5;
        const int EDGE_LEFT_FLIP = 6;
        const int EDGE_RIGHT_FLIP = 7;
        const int MAX_DIMENSION = 16;
        const int MAX_COUNT_TILES = 256;
        const int MAX_COUNT_EDGES = 8;
        static readonly byte[,,] sTiles = new byte[MAX_DIMENSION, MAX_DIMENSION, MAX_COUNT_TILES];
        static int sCountTiles;
        static int sTileWidth;
        static int sTileHeight;
        static readonly long[] sTileIDs = new long[MAX_COUNT_TILES];
        static readonly uint[,] sTileEdges = new uint[MAX_COUNT_EDGES, MAX_COUNT_TILES];

        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day20 : Result1 {result1}");
                var expected = 59187348943703;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day20 : Result2 {result2}");
                var expected = -123;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static void Parse(string[] lines)
        {
            var expectID = true;
            var y = 0;
            sCountTiles = 0;
            var tileIndex = -1;
            sTileHeight = int.MinValue;
            sTileWidth = int.MinValue;
            foreach (var l in lines)
            {
                /*
                Tile 2311:
                ..##.#..#.
                ##..#.....
                #...##..#.
                ####.#...#
                ##.##.###.
                ##...#.###
                .#.#.#..##
                ..#....#..
                ###...#.#.
                ..###..###
                */
                var line = l.Trim();
                if (line.Length == 0)
                {
                    sTileHeight = y;
                    expectID = true;
                }
                else if (expectID)
                {
                    if (line.StartsWith("Tile ") && line.EndsWith(":"))
                    {
                        var id = long.Parse(line[5..^1]);
                        sTileIDs[sCountTiles] = id;
                        tileIndex = sCountTiles;
                        ++sCountTiles;
                        y = 0;
                    }
                    else
                    {
                        throw new InvalidProgramException($"Bad line '{line}' Expected 'Tile XXXX:'");
                    }
                    expectID = false;
                }
                else
                {
                    sTileWidth = line.Length;
                    for (var x = 0; x < line.Length; ++x)
                    {
                        var c = line[x];
                        if (c == '#')
                        {
                            sTiles[x, y, tileIndex] = 1;
                        }
                        else if (c == '.')
                        {
                            sTiles[x, y, tileIndex] = 0;
                        }
                        else
                        {
                            throw new InvalidProgramException($"Bad Character '{c}' Line '{line}'");
                        }
                    }
                    ++y;
                }
            }
            if (sTileWidth != sTileHeight)
            {
                throw new InvalidProgramException($"Bad width & height {sTileWidth} != {sTileHeight}");
            }
        }

        private static uint GetRow(int tileIndex, int row)
        {
            var result = 0U;
            for (var x = 0; x < sTileWidth; ++x)
            {
                result <<= 1;
                if (sTiles[x, row, tileIndex] == 1)
                {
                    result |= 1;
                }
            }
            return result;
        }

        private static uint GetColumn(int tileIndex, int column)
        {
            var result = 0U;
            for (var y = 0; y < sTileHeight; ++y)
            {
                result <<= 1;
                if (sTiles[column, y, tileIndex] == 1)
                {
                    result |= 1;
                }
            }
            return result;
        }

        private static uint GetRowFlipped(int tileIndex, int row)
        {
            var result = 0U;
            for (var x = sTileWidth - 1; x >= 0; --x)
            {
                result <<= 1;
                if (sTiles[x, row, tileIndex] == 1)
                {
                    result |= 1;
                }
            }
            return result;
        }

        private static uint GetColumnFlipped(int tileIndex, int column)
        {
            var result = 0U;
            for (var y = sTileHeight - 1; y >= 0; --y)
            {
                result <<= 1;
                if (sTiles[column, y, tileIndex] == 1)
                {
                    result |= 1;
                }
            }
            return result;
        }

        public static long Part1(string[] lines)
        {
            Parse(lines);
            int gridSize = (int)Math.Sqrt((double)sCountTiles);
            if ((gridSize * gridSize) != sCountTiles)
            {
                throw new InvalidProgramException($"Expected square input {sCountTiles} gridSize {gridSize}");
            }
            /*
                Each tile => get 8 edges :
			    top, bottom, left, right, flipTop, flipBottom, flipLeft, flipRight
            */
            for (var t = 0; t < sCountTiles; ++t)
            {
                sTileEdges[EDGE_TOP, t] = GetRow(t, 0);
                sTileEdges[EDGE_BOTTOM, t] = GetRow(t, sTileHeight - 1);
                sTileEdges[EDGE_LEFT, t] = GetColumn(t, 0);
                sTileEdges[EDGE_RIGHT, t] = GetColumn(t, sTileWidth - 1);
                sTileEdges[EDGE_TOP_FLIP, t] = GetRowFlipped(t, 0);
                sTileEdges[EDGE_BOTTOM_FLIP, t] = GetRowFlipped(t, sTileHeight - 1);
                sTileEdges[EDGE_LEFT_FLIP, t] = GetColumnFlipped(t, 0);
                sTileEdges[EDGE_RIGHT_FLIP, t] = GetColumnFlipped(t, sTileWidth - 1);
            }

            // Edge tile only matches: BR, BL, TR, TL
            // 90 rotate
            // T = L flipped
            // B = R flipped
            // L = B 
            // R = T
            // 180 rotate
            // T = B flipped
            // B = T flipped
            // L = R flipped 
            // R = L flipped
            // 270 rotate
            // T = R
            // B = L
            // L = T flipped 
            // R = B flipped
            var result = 1L;
            for (var t = 0; t < sCountTiles; ++t)
            {
                var edgeCounts = new int[MAX_COUNT_EDGES];
                var totalEdges = 0;
                for (var t2 = 0; t2 < sCountTiles; ++t2)
                {
                    if (t2 == t)
                    {
                        continue;
                    }
                    var matched = false;
                    for (var e = 0; e < MAX_COUNT_EDGES; ++e)
                    {
                        var fromEdge = sTileEdges[e, t];
                        for (var e2 = 0; e2 < MAX_COUNT_EDGES; ++e2)
                        {
                            var toEdge = sTileEdges[e2, t2];
                            if (fromEdge == toEdge)
                            {
                                ++edgeCounts[e];
                                ++totalEdges;
                                matched = true;
                                break;
                            }
                        }
                        if (matched)
                        {
                            break;
                        }
                    }
                }
                if (totalEdges < 2)
                {
                    throw new InvalidProgramException($"Not enough edges match {totalEdges} tile {sTileIDs[t]}");
                }
                if (totalEdges == 2)
                {
                    result *= sTileIDs[t];
                    Console.WriteLine($"Found edge tile {sTileIDs[t]}");
                }
            }
            return result;
        }

        public static long Part2(string[] lines)
        {
            Parse(lines);
            throw new NotImplementedException();
        }

        public static void Run()
        {
            Console.WriteLine("Day20 : Start");
            _ = new Program("Day20/input.txt", true);
            _ = new Program("Day20/input.txt", false);
            Console.WriteLine("Day20 : End");
        }
    }
}

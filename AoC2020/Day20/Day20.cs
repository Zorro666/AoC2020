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
        const uint EDGE_TOP = 0;
        const uint EDGE_BOTTOM = 1;
        const uint EDGE_LEFT = 2;
        const uint EDGE_RIGHT = 3;
        const uint EDGE_TOP_REVERSED = 4;
        const uint EDGE_BOTTOM_REVERSED = 5;
        const uint EDGE_LEFT_REVERSED = 6;
        const uint EDGE_RIGHT_REVERSED = 7;

        const uint MAX_DIMENSION = 16;
        const uint MAX_COUNT_GRIDSIZE = 16;
        const uint MAX_COUNT_TILES = MAX_COUNT_GRIDSIZE * MAX_COUNT_GRIDSIZE;
        const uint MAX_COUNT_EDGES = 8;
        const uint MAX_COUNT_LINKS = 4;

        static readonly byte[,,] sTiles = new byte[MAX_DIMENSION, MAX_DIMENSION, MAX_COUNT_TILES];
        static readonly byte[,,] sNewTiles = new byte[MAX_DIMENSION, MAX_DIMENSION, MAX_COUNT_TILES];
        static readonly byte[,] sFinalImage = new byte[MAX_COUNT_TILES, MAX_COUNT_TILES];
        static readonly byte[,] sTestImage = new byte[MAX_COUNT_TILES, MAX_COUNT_TILES];
        static readonly byte[,] sSeaMonster = new byte[20, 3];
        static uint sFinalImageSize;
        static uint sGridSize;
        static uint sCountTiles;
        static uint sTileWidth;
        static uint sTileHeight;
        static readonly long[] sTileIDs = new long[MAX_COUNT_TILES];
        static readonly uint[] sTileXY = new uint[MAX_COUNT_TILES];
        static readonly uint[,] sTileEdges = new uint[MAX_COUNT_EDGES, MAX_COUNT_TILES];
        static readonly uint[,] sTileValidLinks = new uint[MAX_COUNT_LINKS, MAX_COUNT_TILES];
        static readonly uint[,] sTileEdgeLinks = new uint[MAX_COUNT_EDGES, MAX_COUNT_TILES];
        static readonly uint[] sTileCountValidLinks = new uint[MAX_COUNT_TILES];
        static readonly uint[,] sJigsaw = new uint[MAX_COUNT_GRIDSIZE, MAX_COUNT_GRIDSIZE];

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
                var expected = 1565;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static uint GetRow(int tileIndex, uint row)
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

        private static uint GetColumn(int tileIndex, uint column)
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

        private static uint GetRowReversed(int tileIndex, uint row)
        {
            var result = 0U;
            for (var i = 0; i < sTileWidth; ++i)
            {
                var x = sTileWidth - 1 - i;
                result <<= 1;
                if (sTiles[x, row, tileIndex] == 1)
                {
                    result |= 1;
                }
            }
            return result;
        }

        private static uint GetColumnReversed(int tileIndex, uint column)
        {
            var result = 0U;
            for (var i = 0; i < sTileHeight; ++i)
            {
                var y = sTileHeight - 1 - i;
                result <<= 1;
                if (sTiles[column, y, tileIndex] == 1)
                {
                    result |= 1;
                }
            }
            return result;
        }

        private static void Parse(string[] lines)
        {
            var expectID = true;
            var y = 0U;
            sCountTiles = 0;
            var tileIndex = uint.MaxValue;
            sTileHeight = uint.MaxValue;
            sTileWidth = uint.MaxValue;
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
                    sTileWidth = (uint)line.Length;
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

            sGridSize = (uint)Math.Sqrt((double)sCountTiles);
            if ((sGridSize * sGridSize) != sCountTiles)
            {
                throw new InvalidProgramException($"Expected square input {sCountTiles} gridSize {sGridSize}");
            }

            var countCorners = 0;
            var countEdges = 0;
            var countMiddles = 0;
            for (var t = 0; t < sCountTiles; ++t)
            {
                sTileEdges[EDGE_TOP, t] = GetRow(t, 0);
                sTileEdges[EDGE_BOTTOM, t] = GetRow(t, sTileHeight - 1);
                sTileEdges[EDGE_LEFT, t] = GetColumn(t, 0);
                sTileEdges[EDGE_RIGHT, t] = GetColumn(t, sTileWidth - 1);
                sTileEdges[EDGE_TOP_REVERSED, t] = GetRowReversed(t, 0);
                sTileEdges[EDGE_BOTTOM_REVERSED, t] = GetRowReversed(t, sTileHeight - 1);
                sTileEdges[EDGE_LEFT_REVERSED, t] = GetColumnReversed(t, 0);
                sTileEdges[EDGE_RIGHT_REVERSED, t] = GetColumnReversed(t, sTileWidth - 1);
                sTileCountValidLinks[t] = 0;
                for (var e = 0; e < MAX_COUNT_EDGES; ++e)
                {
                    sTileEdgeLinks[e, t] = MAX_COUNT_TILES;
                }
                for (var l = 0; l < MAX_COUNT_LINKS; ++l)
                {
                    sTileValidLinks[l, t] = MAX_COUNT_TILES;
                }
                sTileXY[t] = uint.MaxValue;
            }

            for (uint t = 0; t < sCountTiles; ++t)
            {
                for (uint t2 = 0; t2 < sCountTiles; ++t2)
                {
                    if (t2 == t)
                    {
                        continue;
                    }
                    var matched = false;
                    for (var e = 0; e < MAX_COUNT_EDGES; ++e)
                    {
                        var fromEdge = sTileEdges[e, t];
                        for (uint e2 = 0; e2 < MAX_COUNT_EDGES; ++e2)
                        {
                            var toEdge = sTileEdges[e2, t2];
                            if (fromEdge == toEdge)
                            {
                                sTileValidLinks[sTileCountValidLinks[t], t] = t2;
                                sTileEdgeLinks[e, t] = t2;
                                ++sTileCountValidLinks[t];
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
                // Corner tiles only have 2 links
                if (sTileCountValidLinks[t] == 2)
                {
                    ++countCorners;
                }
                // Edge tiles only have 3 links
                else if (sTileCountValidLinks[t] == 3)
                {
                    ++countEdges;
                }
                // Middle tiles only have 4 links
                else if (sTileCountValidLinks[t] == 4)
                {
                    ++countMiddles;
                }
                else
                {
                    throw new InvalidProgramException($"Invalid number of links {sTileCountValidLinks[t]} tile {sTileIDs[t]}");
                }
            }

            var expected = 4U;
            if (countCorners != expected)
            {
                throw new InvalidProgramException($"Invalid number of Corners {countCorners} expected {expected}");
            }
            expected = (sGridSize - 2) * 4;
            if (countEdges != expected)
            {
                throw new InvalidProgramException($"Invalid number of Edges {countEdges} expected {expected}");
            }
            expected = (sGridSize - 2) * (sGridSize - 2);
            if (countMiddles != expected)
            {
                throw new InvalidProgramException($"Invalid number of Middles {countMiddles} expected {expected}");
            }
            for (y = 0; y < MAX_COUNT_GRIDSIZE; ++y)
            {
                for (var x = 0; x < MAX_COUNT_GRIDSIZE; ++x)
                {
                    sJigsaw[x, y] = MAX_COUNT_TILES;
                }
            }
            // Construct the jigsaw
            // Corner tiles have 2 links
            // Edge tiles have 3 links
            // Middle tiles have 4 links

            /*
            C00-E10-C20
             |   |   |
            E01-M11-E21
             |   |   |
            C02-E12-C22
            */

            for (y = 0; y < sGridSize; ++y)
            {
                for (uint x = 0; x < sGridSize; ++x)
                {
                    var countLinks = 4U;
                    if ((x == 0) && ((y == 0) || (y == sGridSize - 1)))
                    {
                        countLinks = 2;
                    }
                    else if ((x == sGridSize - 1) && ((y == 0) || (y == sGridSize - 1)))
                    {
                        countLinks = 2;
                    }
                    else if ((x == 0) || (y == 0) || (x == sGridSize - 1) || (y == sGridSize - 1))
                    {
                        countLinks = 3;
                    }
                    var tile = FindMatchingTile(x, y, countLinks);
                    sJigsaw[x, y] = tile;
                    sTileXY[tile] = x + y * MAX_COUNT_GRIDSIZE;
                }
            }

            //OutputJigsaw();
        }

        private static uint FindMatchingTile(uint x, uint y, uint countLinks)
        {
            // x-1, y+0
            uint id0 = (x > 0) ? sJigsaw[x - 1, y] : MAX_COUNT_TILES;
            // x+1, y+0
            uint id1 = (x < (sGridSize - 1)) ? sJigsaw[x + 1, y] : MAX_COUNT_TILES;
            // x+0, y-1
            uint id2 = (y > 0) ? sJigsaw[x, y - 1] : MAX_COUNT_TILES;
            // x+0, y+1
            uint id3 = (y < (sGridSize - 1)) ? sJigsaw[x, y + 1] : MAX_COUNT_TILES;
            for (uint t = 0; t < sCountTiles; ++t)
            {
                if (sTileCountValidLinks[t] != countLinks)
                {
                    continue;
                }
                if (sTileXY[t] < uint.MaxValue)
                {
                    continue;
                }
                var foundLinks = new bool[4];
                var countFoundLinks = 0;
                if (id0 >= sCountTiles)
                {
                    foundLinks[0] = true;
                    ++countFoundLinks;
                }
                if (id1 >= sCountTiles)
                {
                    foundLinks[1] = true;
                    ++countFoundLinks;
                }
                if (id2 >= sCountTiles)
                {
                    foundLinks[2] = true;
                    ++countFoundLinks;
                }
                if (id3 >= sCountTiles)
                {
                    foundLinks[3] = true;
                    ++countFoundLinks;
                }
                for (var l = 0; l < sTileCountValidLinks[t]; ++l)
                {
                    var link = sTileValidLinks[l, t];
                    if ((id0 < sCountTiles) && (link == id0))
                    {
                        foundLinks[0] = true;
                        ++countFoundLinks;
                    }
                    else if ((id1 < sCountTiles) && (link == id1))
                    {
                        foundLinks[1] = true;
                        ++countFoundLinks;
                    }
                    else if ((id2 < sCountTiles) && (link == id2))
                    {
                        foundLinks[2] = true;
                        ++countFoundLinks;
                    }
                    else if ((id3 < sCountTiles) && (link == id3))
                    {
                        foundLinks[3] = true;
                        ++countFoundLinks;
                    }
                }
                if (countFoundLinks == 4)
                {
                    return t;
                }
            }
            throw new InvalidProgramException($"Failed to find matching tile");
        }

        private static void OutputJigsaw()
        {
            for (var y = 0; y < sGridSize; ++y)
            {
                for (var x = 0; x < sGridSize; ++x)
                {
                    var tile = sJigsaw[x, y];
                    var tileID = tile < MAX_COUNT_TILES ? sTileIDs[tile] : 0000;
                    Console.Write($"{tileID} ");
                }
                Console.WriteLine($"");
            }
        }

        private static string EdgeName(uint edge)
        {
            return edge switch
            {
                EDGE_TOP => "TOP",
                EDGE_BOTTOM => "BOTTOM",
                EDGE_LEFT => "LEFT",
                EDGE_RIGHT => "RIGHT",
                EDGE_TOP_REVERSED => "TOP_REVERSED",
                EDGE_BOTTOM_REVERSED => "BOTTOM_REVERSED",
                EDGE_LEFT_REVERSED => "LEFT_REVERSED",
                EDGE_RIGHT_REVERSED => "RIGHT_REVERSED",
                _ => "UNKNOWN"
            };
        }

        private static uint FindMatchingEdge(uint fromTile, uint toTile)
        {
            for (uint e = 0; e < MAX_COUNT_EDGES; ++e)
            {
                if (sTileEdgeLinks[e, fromTile] == toTile)
                {
                    return e;
                }
            }
            throw new InvalidProgramException($"No matching edge from {sTileIDs[fromTile]} to {sTileIDs[toTile]}");
        }

        private static uint RemoveFlipped(uint inEdge)
        {
            return inEdge switch
            {
                EDGE_TOP_REVERSED => EDGE_TOP,
                EDGE_BOTTOM_REVERSED => EDGE_BOTTOM,
                EDGE_LEFT_REVERSED => EDGE_LEFT,
                EDGE_RIGHT_REVERSED => EDGE_RIGHT,
                _ => inEdge
            };
        }

        private static void FindOrientation(uint top, uint bottom, uint left, uint right, out bool rotate, out bool flipX, out bool flipY)
        {
            rotate = false;
            flipX = false;
            flipY = false;

            top = RemoveFlipped(top);
            bottom = RemoveFlipped(bottom);
            left = RemoveFlipped(left);
            right = RemoveFlipped(right);

            var matched = 0;
            var matchTop = top < MAX_COUNT_EDGES;
            var matchBottom = bottom < MAX_COUNT_EDGES;
            var matchLeft = left < MAX_COUNT_EDGES;
            var matchRight = right < MAX_COUNT_EDGES;
            uint expectedTop;
            uint expectedBottom;
            uint expectedLeft;
            uint expectedRight;

            // 0 Rotate
            // T = T
            // B = B
            // L = L 
            // R = R
            expectedTop = EDGE_TOP;
            expectedBottom = EDGE_BOTTOM;
            expectedLeft = EDGE_LEFT;
            expectedRight = EDGE_RIGHT;
            if (((matchTop && (top == expectedTop)) || !matchTop) &&
                ((matchBottom && (bottom == expectedBottom)) || !matchBottom) &&
                ((matchLeft && (left == expectedLeft)) || !matchLeft) &&
                ((matchRight && (right == expectedRight)) || !matchRight))
            {
                rotate = false;
                flipX = false;
                flipY = false;
                ++matched;
            }

            // 0 Rotate + FlipX
            // T = T REVERSED
            // B = B REVERSED
            // L = R 
            // R = L
            expectedTop = EDGE_TOP;
            expectedBottom = EDGE_BOTTOM;
            expectedLeft = EDGE_RIGHT;
            expectedRight = EDGE_LEFT;
            if (((matchTop && (top == expectedTop)) || !matchTop) &&
                ((matchBottom && (bottom == expectedBottom)) || !matchBottom) &&
                ((matchLeft && (left == expectedLeft)) || !matchLeft) &&
                ((matchRight && (right == expectedRight)) || !matchRight))
            {
                rotate = false;
                flipX = true;
                flipY = false;
                ++matched;
            }

            // 0 Rotate + FlipY = 180 Rotate + FlipX
            // T = B
            // B = T
            // L = L REVERSED
            // R = R REVERSED
            expectedTop = EDGE_BOTTOM;
            expectedBottom = EDGE_TOP;
            expectedLeft = EDGE_LEFT;
            expectedRight = EDGE_RIGHT;
            if (((matchTop && (top == expectedTop)) || !matchTop) &&
                ((matchBottom && (bottom == expectedBottom)) || !matchBottom) &&
                ((matchLeft && (left == expectedLeft)) || !matchLeft) &&
                ((matchRight && (right == expectedRight)) || !matchRight))
            {
                rotate = false;
                flipX = false;
                flipY = true;
                ++matched;
            }

            // 0 Rotate + FlipX + FlipY = 180 Rotate
            // T = B REVERSED
            // B = T REVERSED
            // L = R REVERSED 
            // R = L REVERSED
            expectedTop = EDGE_BOTTOM;
            expectedBottom = EDGE_TOP;
            expectedLeft = EDGE_RIGHT;
            expectedRight = EDGE_LEFT;
            if (((matchTop && (top == expectedTop)) || !matchTop) &&
                ((matchBottom && (bottom == expectedBottom)) || !matchBottom) &&
                ((matchLeft && (left == expectedLeft)) || !matchLeft) &&
                ((matchRight && (right == expectedRight)) || !matchRight))
            {
                rotate = false;
                flipX = true;
                flipY = true;
                ++matched;
            }

            // 90 Rotate = 270 Rotate + FlipX + FlipY
            // T = L REVERSED
            // B = R REVERSED
            // L = B 
            // R = T
            expectedTop = EDGE_LEFT;
            expectedBottom = EDGE_RIGHT;
            expectedLeft = EDGE_BOTTOM;
            expectedRight = EDGE_TOP;
            if (((matchTop && (top == expectedTop)) || !matchTop) &&
                ((matchBottom && (bottom == expectedBottom)) || !matchBottom) &&
                ((matchLeft && (left == expectedLeft)) || !matchLeft) &&
                ((matchRight && (right == expectedRight)) || !matchRight))
            {
                rotate = true;
                flipX = false;
                flipY = false;
                ++matched;
            }

            // 90 Rotate + FlipX = 270 Rotate + FlipY
            // T = L 
            // B = R 
            // L = T 
            // R = B
            expectedTop = EDGE_LEFT;
            expectedBottom = EDGE_RIGHT;
            expectedLeft = EDGE_TOP;
            expectedRight = EDGE_BOTTOM;
            if (((matchTop && (top == expectedTop)) || !matchTop) &&
                ((matchBottom && (bottom == expectedBottom)) || !matchBottom) &&
                ((matchLeft && (left == expectedLeft)) || !matchLeft) &&
                ((matchRight && (right == expectedRight)) || !matchRight))
            {
                rotate = true;
                flipX = true;
                flipY = false;
                ++matched;
            }

            // 90 Rotate + FlipY = 270 Rotate + FlipX
            // T = R REVERSED 
            // B = L REVERSED
            // L = B REVERSED 
            // R = T REVERSED
            expectedTop = EDGE_RIGHT;
            expectedBottom = EDGE_LEFT;
            expectedLeft = EDGE_BOTTOM;
            expectedRight = EDGE_TOP;
            if (((matchTop && (top == expectedTop)) || !matchTop) &&
                ((matchBottom && (bottom == expectedBottom)) || !matchBottom) &&
                ((matchLeft && (left == expectedLeft)) || !matchLeft) &&
                ((matchRight && (right == expectedRight)) || !matchRight))
            {
                rotate = true;
                flipX = false;
                flipY = true;
                ++matched;
            }

            // 90 Rotate + FlipX + FlipY = 270 Rotate
            // T = R 
            // B = L 
            // L = T REVERSED
            // R = B REVERSED
            expectedTop = EDGE_RIGHT;
            expectedBottom = EDGE_LEFT;
            expectedLeft = EDGE_TOP;
            expectedRight = EDGE_BOTTOM;
            if (((matchTop && (top == expectedTop)) || !matchTop) &&
                ((matchBottom && (bottom == expectedBottom)) || !matchBottom) &&
                ((matchLeft && (left == expectedLeft)) || !matchLeft) &&
                ((matchRight && (right == expectedRight)) || !matchRight))
            {
                rotate = true;
                flipX = true;
                flipY = true;
                ++matched;
            }
            if (matched != 1)
            {
                throw new InvalidProgramException($"Invalid match count {matched}");
            }
        }

        private static void MatchTile(uint x, uint y)
        {
            var tile = sJigsaw[x, y];
            var topEdge = (y > 0) ? FindMatchingEdge(tile, sJigsaw[x, y - 1]) : MAX_COUNT_EDGES;
            var bottomEdge = (y < sGridSize - 1) ? FindMatchingEdge(tile, sJigsaw[x, y + 1]) : MAX_COUNT_EDGES;
            var leftEdge = (x > 0) ? FindMatchingEdge(tile, sJigsaw[x - 1, y]) : MAX_COUNT_EDGES;
            var rightEdge = (x < sGridSize - 1) ? FindMatchingEdge(tile, sJigsaw[x + 1, y]) : MAX_COUNT_EDGES;
            FindOrientation(topEdge, bottomEdge, leftEdge, rightEdge, out bool rotate, out bool flipX, out bool flipY);
            //Console.WriteLine($"{x},{y} Rotate {rotate} FlipX {flipX} FlipY {flipY}");

            /*
            rotate 90
            012    630
            345 => 741
            678    852
            */
            CopyTile(tile, rotate, flipX, flipY);
        }

        private static void CopyTile(uint tile, bool rotate, bool flipX, bool flipY)
        {
            for (var y = 0; y < sTileHeight; ++y)
            {
                for (var x = 0; x < sTileWidth; ++x)
                {
                    //old X, oldY => sGridSize-1-y, x
                    var newX = rotate ? sTileWidth - 1 - y : x;
                    var newY = rotate ? x : y;
                    sNewTiles[newX, newY, tile] = sTiles[x, y, tile];
                }
            }
            if (flipX)
            {
                for (var y = 0; y < sTileHeight; ++y)
                {
                    var row = new byte[sTileHeight];
                    for (var x = 0; x < sTileWidth; ++x)
                    {
                        row[x] = sNewTiles[x, y, tile];
                    }
                    for (var x = 0; x < sTileWidth; ++x)
                    {
                        var newX = sTileWidth - 1 - x;
                        var newY = y;
                        sNewTiles[newX, newY, tile] = row[x];
                    }
                }
            }
            if (flipY)
            {
                for (var x = 0; x < sTileWidth; ++x)
                {
                    var column = new byte[sTileHeight];
                    for (var y = 0; y < sTileHeight; ++y)
                    {
                        column[y] = sNewTiles[x, y, tile];
                    }
                    for (var y = 0; y < sTileHeight; ++y)
                    {
                        var newX = x;
                        var newY = sTileHeight - 1 - y;
                        sNewTiles[newX, newY, tile] = column[y];
                    }
                }
            }
        }

        private static void OutputFinalImage()
        {
            Console.WriteLine($"");
            for (uint y = 0; y < sFinalImageSize; ++y)
            {
                for (uint x = 0; x < sFinalImageSize; ++x)
                {
                    var cell = sFinalImage[x, y] == 1 ? '#' : '.';
                    Console.Write($"{cell}");
                }
                Console.WriteLine($"");
            }
        }

        private static void OutputGrid()
        {
            Console.WriteLine($"");
            for (uint y = 0; y < sGridSize * sTileHeight; ++y)
            {
                var tileY = y / sTileHeight;
                var cellY = y % sTileHeight;
                if (cellY == 0)
                {
                    Console.WriteLine($"");
                }
                for (uint x = 0; x < sGridSize * sTileWidth; ++x)
                {
                    var tileX = x / sTileWidth;
                    var t = sJigsaw[tileX, tileY];
                    var cellX = x % sTileWidth;
                    if (cellX == 0)
                    {
                        Console.Write($" ");
                    }
                    var cell = sNewTiles[cellX, cellY, t] == 1 ? '#' : '.';
                    Console.Write($"{cell}");
                }
                Console.WriteLine($"");
            }
        }

        private static void CheckGridIsValid()
        {
            // Rows must match previous row : tileY*sTileHeight
            for (uint tileY = 1; tileY < sGridSize - 1; ++tileY)
            {
                for (uint x = 0; x < sGridSize * sTileWidth; ++x)
                {
                    var tileX = x / sTileWidth;
                    var thisTile = sJigsaw[tileX, tileY];
                    var cellX = x % sTileWidth;
                    var thisRow = sNewTiles[cellX, 0, thisTile];
                    var previousTile = sJigsaw[tileX, tileY - 1];
                    var previousRow = sNewTiles[cellX, sTileHeight - 1, previousTile];
                    if (previousRow != thisRow)
                    {
                        throw new InvalidProgramException($"Row not match at Cell {cellX} Tile {tileY} Tiles {sTileIDs[thisTile]} {sTileIDs[previousTile]}");
                    }
                }
            }
            // Columns must match previous column : tileX*sTileWidth
            for (uint tileX = 1; tileX < sGridSize - 1; ++tileX)
            {
                for (uint y = 0; y < sGridSize * sTileHeight; ++y)
                {
                    var tileY = y / sTileHeight;
                    var thisTile = sJigsaw[tileX, tileY];
                    var cellY = y % sTileWidth;
                    var thisColumn = sNewTiles[0, cellY, thisTile];
                    var previousTile = sJigsaw[tileX - 1, tileY];
                    var previousColumn = sNewTiles[sTileWidth - 1, cellY, previousTile];
                    if (previousColumn != thisColumn)
                    {
                        throw new InvalidProgramException($"Columns not match at Cell {cellY} Tile {tileX} Tiles {sTileIDs[thisTile]} {sTileIDs[previousTile]}");
                    }
                }
            }
        }

        private static void CopyToFinalImage()
        {
            sFinalImageSize = sGridSize * (sTileHeight - 2);
            var outY = 0;
            for (uint y = 0; y < sGridSize * sTileHeight; ++y)
            {
                var tileY = y / sTileHeight;
                var cellY = y % sTileHeight;
                if (cellY == 0)
                {
                    continue;
                }
                if (cellY == sTileHeight - 1)
                {
                    continue;
                }
                var outX = 0;
                for (uint x = 0; x < sGridSize * sTileWidth; ++x)
                {
                    var tileX = x / sTileWidth;
                    var cellX = x % sTileWidth;
                    if (cellX == 0)
                    {
                        continue;
                    }
                    if (cellX == sTileWidth - 1)
                    {
                        continue;
                    }
                    var t = sJigsaw[tileX, tileY];
                    var cell = sNewTiles[cellX, cellY, t];
                    sFinalImage[outX, outY] = cell;
                    ++outX;
                }
                if (outX != sFinalImageSize)
                {
                    throw new InvalidProgramException($"outX != imageSize {outX} != {sFinalImageSize}");
                }
                ++outY;
            }
            if (outY != sFinalImageSize)
            {
                throw new InvalidProgramException($"outY != imageSize {outY} != {sFinalImageSize}");
            }
        }

        public static long Part1(string[] lines)
        {
            Parse(lines);
            var result = 1L;
            result *= sTileIDs[sJigsaw[0, 0]];
            result *= sTileIDs[sJigsaw[sGridSize - 1, 0]];
            result *= sTileIDs[sJigsaw[0, sGridSize - 1]];
            result *= sTileIDs[sJigsaw[sGridSize - 1, sGridSize - 1]];
            return result;
        }

        private static void CopyToTestImage(bool rotate, bool flipX, bool flipY)
        {
            for (var y = 0; y < sFinalImageSize; ++y)
            {
                for (var x = 0; x < sFinalImageSize; ++x)
                {
                    //old X, oldY => sFinalImageSize-1-y, x
                    var newX = rotate ? sFinalImageSize - 1 - y : x;
                    var newY = rotate ? x : y;
                    sTestImage[newX, newY] = sFinalImage[x, y];
                }
            }
            if (flipX)
            {
                for (var y = 0; y < sFinalImageSize; ++y)
                {
                    var row = new byte[sFinalImageSize];
                    for (var x = 0; x < sFinalImageSize; ++x)
                    {
                        row[x] = sTestImage[x, y];
                    }
                    for (var x = 0; x < sFinalImageSize; ++x)
                    {
                        var newX = sFinalImageSize - 1 - x;
                        var newY = y;
                        sTestImage[newX, newY] = row[x];
                    }
                }
            }
            if (flipY)
            {
                for (var x = 0; x < sFinalImageSize; ++x)
                {
                    var column = new byte[sFinalImageSize];
                    for (var y = 0; y < sFinalImageSize; ++y)
                    {
                        column[y] = sTestImage[x, y];
                    }
                    for (var y = 0; y < sFinalImageSize; ++y)
                    {
                        var newX = x;
                        var newY = sFinalImageSize - 1 - y;
                        sTestImage[newX, newY] = column[y];
                    }
                }
            }
        }

        private static bool MatchSeaMonster(uint x0, uint y0)
        {
            for (uint sy = 0; sy < 3; ++sy)
            {
                var y = y0 + sy;
                if (y >= sFinalImageSize)
                {
                    return false;
                }
                for (uint sx = 0; sx < 20; ++sx)
                {
                    var x = x0 + sx;
                    if (x >= sFinalImageSize)
                    {
                        return false;
                    }
                    if (sSeaMonster[sx, sy] == 1)
                    {
                        if (sTestImage[x, y] == 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static uint CountRoughWater()
        {
            var roughWater = 0U;
            var foundSeaMonsterCount = 0U;
            for (uint y = 0; y < sFinalImageSize; ++y)
            {
                for (uint x = 0; x < sFinalImageSize; ++x)
                {
                    if (MatchSeaMonster(x, y))
                    {
                        //Console.WriteLine($"Found sea monster at {x},{y}");
                        ++foundSeaMonsterCount;
                    }
                    if (sTestImage[x, y] == 1)
                    {
                        ++roughWater;
                    }
                }
            }
            if (foundSeaMonsterCount == 0)
            {
                return 0;
            }
            return roughWater - (foundSeaMonsterCount * 15);
        }

        public static long Part2(string[] lines)
        {
            Parse(lines);
            //The Sea Monster pattern
            //"                  # "
            //"#    ##    ##    ###"
            //" #  #  #  #  #  #   "
            var seaMonster = new string[3] {
"                  # ",
"#    ##    ##    ###",
" #  #  #  #  #  #   "
            };
            for (var y = 0; y < 3; ++y)
            {
                for (var x = 0; x < 20; ++x)
                {
                    sSeaMonster[x, y] = seaMonster[y][x] == '#' ? 1 : 0;
                }
            }

            // Work out the orientation for each tile based on the edge connections
            for (uint y = 0; y < sGridSize; ++y)
            {
                for (uint x = 0; x < sGridSize; ++x)
                {
                    MatchTile(x, y);
                }
            }
            CheckGridIsValid();
            //OutputGrid();

            CopyToFinalImage();
            //OutputFinalImage();

            for (var r = 0; r < 2; ++r)
            {
                var rotate = (r == 1);
                for (var fx = 0; fx < 2; ++fx)
                {
                    var flipX = (fx == 1);
                    for (var fy = 0; fy < 2; ++fy)
                    {
                        var flipY = (fy == 1);
                        CopyToTestImage(rotate, flipX, flipY);
                        var roughWater = CountRoughWater();
                        if (roughWater > 0)
                        {
                            return roughWater;
                        }
                    }
                }
            }

            throw new InvalidProgramException($"Sea Monster not found");
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

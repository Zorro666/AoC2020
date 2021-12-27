using System;

/*
--- Day 17: Conway Cubes ---

As your flight slowly drifts through the sky, the Elves at the Mythical Information Bureau at the North Pole contact you.
They'd like some help debugging a malfunctioning experimental energy source aboard one of their super-secret imaging satellites.

The experimental energy source is based on cutting-edge technology: a set of Conway Cubes contained in a pocket dimension! When you hear it's having problems, you can't help but agree to take a look.

The pocket dimension contains an infinite 3-dimensional grid.
At every integer 3-dimensional coordinate (x,y,z), there exists a single cube which is either active or inactive.

In the initial state of the pocket dimension, almost all cubes start inactive.
The only exception to this is a small flat region of cubes (your puzzle input); the cubes in this region start in the specified active (#) or inactive (.) state.

The energy source then proceeds to boot up by executing six cycles.

Each cube only ever considers its neighbors: any of the 26 other cubes where any of their coordinates differ by at most 1.
For example, given the cube at x=1,y=2,z=3, its neighbors include the cube at x=2,y=2,z=2, the cube at x=0,y=2,z=3, and so on.

During a cycle, all cubes simultaneously change their state according to the following rules:

If a cube is active and exactly 2 or 3 of its neighbors are also active, the cube remains active.
Otherwise, the cube becomes inactive.
If a cube is inactive but exactly 3 of its neighbors are active, the cube becomes active.
Otherwise, the cube remains inactive.
The engineers responsible for this experimental energy source would like you to simulate the pocket dimension and determine what the configuration of cubes should be at the end of the six-cycle boot process.

For example, consider the following initial state:

.#.
..#
###
Even though the pocket dimension is 3-dimensional, this initial state represents a small 2-dimensional slice of it.
(In particular, this initial state defines a 3x3x1 region of the 3-dimensional space.)

Simulating a few cycles from this initial state produces the following configurations, where the result of each cycle is shown layer-by-layer at each given z coordinate:

Before any cycles:

z=0
.#.
..#
###


After 1 cycle:

z=-1
#..
..#
.#.

z=0
#.#
.##
.#.

z=1
#..
..#
.#.


After 2 cycles:

z=-2
.....
.....
..#..
.....
.....

z=-1
..#..
.#..#
....#
.#...
.....

z=0
##...
##...
#....
....#
.###.

z=1
..#..
.#..#
....#
.#...
.....

z=2
.....
.....
..#..
.....
.....


After 3 cycles:

z=-2
.......
.......
..##...
..###..
.......
.......
.......

z=-1
..#....
...#...
#......
.....##
.#...#.
..#.#..
...#...

z=0
...#...
.......
#......
.......
.....##
.##.#..
...#...

z=1
..#....
...#...
#......
.....##
.#...#.
..#.#..
...#...

z=2
.......
.......
..##...
..###..
.......
.......
.......

After the full six-cycle boot process completes, 112 cubes are left in the active state.

Starting with your given initial configuration, simulate six cycles.
How many cubes are left in the active state after the sixth cycle?

Your puzzle answer was 336.

--- Part Two ---

For some reason, your simulated results don't match what the experimental energy source engineers expected.
Apparently, the pocket dimension actually has four spatial dimensions, not three.

The pocket dimension contains an infinite 4-dimensional grid.
At every integer 4-dimensional coordinate (x,y,z,w), there exists a single cube (really, a hypercube) which is still either active or inactive.

Each cube only ever considers its neighbors: any of the 80 other cubes where any of their coordinates differ by at most 1.
For example, given the cube at x=1,y=2,z=3,w=4, its neighbors include the cube at x=2,y=2,z=3,w=3, the cube at x=0,y=2,z=3,w=4, and so on.

The initial state of the pocket dimension still consists of a small flat region of cubes.
Furthermore, the same rules for cycle updating still apply: during each cycle, consider the number of active neighbors of each cube.

For example, consider the same initial state as in the example above.
Even though the pocket dimension is 4-dimensional, this initial state represents a small 2-dimensional slice of it.
(In particular, this initial state defines a 3x3x1x1 region of the 4-dimensional space.)

Simulating a few cycles from this initial state produces the following configurations, where the result of each cycle is shown layer-by-layer at each given z and w coordinate:

Before any cycles:

z=0, w=0
.#.
..#
###


After 1 cycle:

z=-1, w=-1
#..
..#
.#.

z=0, w=-1
#..
..#
.#.

z=1, w=-1
#..
..#
.#.

z=-1, w=0
#..
..#
.#.

z=0, w=0
#.#
.##
.#.

z=1, w=0
#..
..#
.#.

z=-1, w=1
#..
..#
.#.

z=0, w=1
#..
..#
.#.

z=1, w=1
#..
..#
.#.


After 2 cycles:

z=-2, w=-2
.....
.....
..#..
.....
.....

z=-1, w=-2
.....
.....
.....
.....
.....

z=0, w=-2
###..
##.##
#...#
.#..#
.###.

z=1, w=-2
.....
.....
.....
.....
.....

z=2, w=-2
.....
.....
..#..
.....
.....

z=-2, w=-1
.....
.....
.....
.....
.....

z=-1, w=-1
.....
.....
.....
.....
.....

z=0, w=-1
.....
.....
.....
.....
.....

z=1, w=-1
.....
.....
.....
.....
.....

z=2, w=-1
.....
.....
.....
.....
.....

z=-2, w=0
###..
##.##
#...#
.#..#
.###.

z=-1, w=0
.....
.....
.....
.....
.....

z=0, w=0
.....
.....
.....
.....
.....

z=1, w=0
.....
.....
.....
.....
.....

z=2, w=0
###..
##.##
#...#
.#..#
.###.

z=-2, w=1
.....
.....
.....
.....
.....

z=-1, w=1
.....
.....
.....
.....
.....

z=0, w=1
.....
.....
.....
.....
.....

z=1, w=1
.....
.....
.....
.....
.....

z=2, w=1
.....
.....
.....
.....
.....

z=-2, w=2
.....
.....
..#..
.....
.....

z=-1, w=2
.....
.....
.....
.....
.....

z=0, w=2
###..
##.##
#...#
.#..#
.###.

z=1, w=2
.....
.....
.....
.....
.....

z=2, w=2
.....
.....
..#..
.....
.....

After the full six-cycle boot process completes, 848 cubes are left in the active state.

Starting with your given initial configuration, simulate six cycles in a 4-dimensional space.

How many cubes are left in the active state after the sixth cycle?
*/

namespace Day17
{
    class Program
    {
        const int MAX_DIMENSION = 32;
        const int ORIGIN = MAX_DIMENSION / 2;
        static readonly byte[,,,] sCells = new byte[MAX_DIMENSION, MAX_DIMENSION, MAX_DIMENSION, MAX_DIMENSION
            ];
        static readonly byte[,,,] sCopyCells = new byte[MAX_DIMENSION, MAX_DIMENSION, MAX_DIMENSION, MAX_DIMENSION];
        static int sMinX;
        static int sMaxX;
        static int sMinY;
        static int sMaxY;
        static int sMinZ;
        static int sMaxZ;
        static int sMinW;
        static int sMaxW;

        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day17 : Result1 {result1}");
                var expected = 368;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day17 : Result2 {result2}");
                var expected = 2696;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        private static void Zero()
        {
            for (var x = 0; x < MAX_DIMENSION; ++x)
            {
                for (var y = 0; y < MAX_DIMENSION; ++y)
                {
                    for (var z = 0; z < MAX_DIMENSION; ++z)
                    {
                        for (var w = 0; w < MAX_DIMENSION; ++w)
                        {
                            sCells[x, y, z, w] = 0;
                            sCopyCells[x, y, z, w] = 0;
                        }
                    }
                }
            }
        }

        private static void Parse(string[] lines)
        {
            Zero();
            sMinW = ORIGIN;
            sMaxW = ORIGIN;
            sMinZ = ORIGIN;
            sMaxZ = ORIGIN;
            var height = lines.Length;
            sMinY = ORIGIN - height / 2;
            sMaxY = ORIGIN + height / 2;
            var width = lines[0].Trim().Length;
            sMinX = ORIGIN - width / 2;
            sMaxX = ORIGIN + width / 2;

            var w = sMinW;
            var z = sMinZ;
            var y = sMinY;
            foreach (var l in lines)
            {
                var line = l.Trim();
                var x = sMinX;
                for (var c = 0; c < width; ++c)
                {
                    sCells[x, y, z, w] = (byte)((line[c] == '#') ? 1 : 0);
                    ++x;
                }
                ++y;
            }
        }

        private static void CopyCells()
        {
            for (var x = sMinX; x <= sMaxX; ++x)
            {
                for (var y = sMinY; y <= sMaxY; ++y)
                {
                    for (var z = sMinZ; z <= sMaxZ; ++z)
                    {
                        for (var w = sMinW; w <= sMaxW; ++w)
                        {
                            sCopyCells[x, y, z, w] = sCells[x, y, z, w];
                        }
                    }
                }
            }
        }

        private static int UpdateCells()
        {
            var count = 0;
            for (var x = sMinX; x <= sMaxX; ++x)
            {
                for (var y = sMinY; y <= sMaxY; ++y)
                {
                    for (var z = sMinZ; z <= sMaxZ; ++z)
                    {
                        for (var w = sMinW; w <= sMaxW; ++w)
                        {
                            sCells[x, y, z, w] = sCopyCells[x, y, z, w];
                            count += sCells[x, y, z, w];
                        }
                    }
                }
            }
            return count;
        }

        private static int CountNeighbours3D(int x0, int y0, int z0, int w0)
        {
            var count = 0;
            for (var dx = -1; dx <= +1; ++dx)
            {
                for (var dy = -1; dy <= +1; ++dy)
                {
                    for (var dz = -1; dz <= +1; ++dz)
                    {
                        if ((dx != 0) || (dy != 0) || (dz != 0))
                        {
                            count += sCells[x0 + dx, y0 + dy, z0 + dz, w0];
                        }
                    }
                }
            }
            return count;
        }

        private static int CountNeighbours4D(int x0, int y0, int z0, int w0)
        {
            var count = 0;
            for (var dx = -1; dx <= +1; ++dx)
            {
                for (var dy = -1; dy <= +1; ++dy)
                {
                    for (var dz = -1; dz <= +1; ++dz)
                    {
                        for (var dw = -1; dw <= +1; ++dw)
                        {
                            if ((dx != 0) || (dy != 0) || (dz != 0) || (dw != 0))
                            {
                                count += sCells[x0 + dx, y0 + dy, z0 + dz, w0 + dw];
                            }
                        }
                    }
                }
            }
            return count;
        }

        private static void Simulate3D()
        {
            --sMinX;
            ++sMaxX;
            --sMinY;
            ++sMaxY;
            --sMinZ;
            ++sMaxZ;
            for (var x = sMinX; x <= sMaxX; ++x)
            {
                for (var y = sMinY; y <= sMaxY; ++y)
                {
                    for (var z = sMinZ; z <= sMaxZ; ++z)
                    {
                        var w = sMinW;
                        var count = CountNeighbours3D(x, y, z, w);
                        var oldCell = sCells[x, y, z, w];
                        byte newCell;
                        if (oldCell == 1)
                        {
                            if ((count == 2) || (count == 3))
                            {
                                newCell = 1;
                            }
                            else
                            {
                                newCell = 0;
                            }
                        }
                        else if (count == 3)
                        {
                            newCell = 1;
                        }
                        else
                        {
                            newCell = 0;
                        }
                        sCopyCells[x, y, z, w] = newCell;
                    }
                }
            }
        }

        private static void Simulate4D()
        {
            --sMinX;
            ++sMaxX;
            --sMinY;
            ++sMaxY;
            --sMinZ;
            ++sMaxZ;
            --sMinW;
            ++sMaxW;
            for (var x = sMinX; x <= sMaxX; ++x)
            {
                for (var y = sMinY; y <= sMaxY; ++y)
                {
                    for (var z = sMinZ; z <= sMaxZ; ++z)
                    {
                        for (var w = sMinW; w <= sMaxW; ++w)
                        {
                            var count = CountNeighbours4D(x, y, z, w);
                            var oldCell = sCells[x, y, z, w];
                            byte newCell;
                            if (oldCell == 1)
                            {
                                if ((count == 2) || (count == 3))
                                {
                                    newCell = 1;
                                }
                                else
                                {
                                    newCell = 0;
                                }
                            }
                            else if (count == 3)
                            {
                                newCell = 1;
                            }
                            else
                            {
                                newCell = 0;
                            }
                            sCopyCells[x, y, z, w] = newCell;
                        }
                    }
                }
            }
        }

        private static void OutputCells()
        {
            for (var w = sMinW; w <= sMaxW; ++w)
            {
                Console.WriteLine($"w = {w - ORIGIN}");
                for (var z = sMinZ; z <= sMaxZ; ++z)
                {
                    Console.WriteLine($"z = {z - ORIGIN}");
                    for (var y = sMinY; y <= sMaxY; ++y)
                    {
                        var line = "";
                        for (var x = sMinX; x <= sMaxX; ++x)
                        {
                            line += (sCells[x, y, z, w] == 1) ? '#' : '.';
                        }
                        Console.WriteLine(line);
                    }
                }
            }
        }

        public static int Part1(string[] lines)
        {
            Parse(lines);

            var count = 0;
            for (var i = 0; i < 6; ++i)
            {
                CopyCells();
                Simulate3D();
                count = UpdateCells();
            }
            return count;
        }

        public static int Part2(string[] lines)
        {
            Parse(lines);

            var count = 0;
            for (var i = 0; i < 6; ++i)
            {
                CopyCells();
                Simulate4D();
                count = UpdateCells();
            }
            return count;
        }

        public static void Run()
        {
            Console.WriteLine("Day17 : Start");
            _ = new Program("Day17/input.txt", true);
            _ = new Program("Day17/input.txt", false);
            Console.WriteLine("Day17 : End");
        }
    }
}

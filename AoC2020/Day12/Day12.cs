using System;

/*

--- Day 12: Rain Risk ---

Your ferry made decent progress toward the island, but the storm came in faster than anyone expected.
The ferry needs to take evasive actions!

Unfortunately, the ship's navigation computer seems to be malfunctioning; rather than giving a route directly to safety, it produced extremely circuitous instructions.
When the captain uses the PA system to ask if anyone can help, you quickly volunteer.

The navigation instructions (your puzzle input) consists of a sequence of single-character actions paired with integer input values.
After staring at them for a few minutes, you work out what they probably mean:

Action N means to move north by the given value.
Action S means to move south by the given value.
Action E means to move east by the given value.
Action W means to move west by the given value.
Action L means to turn left the given number of degrees.
Action R means to turn right the given number of degrees.
Action F means to move forward by the given value in the direction the ship is currently facing.
The ship starts by facing east.
Only the L and R actions change the direction the ship is facing.
(That is, if the ship is facing east and the next instruction is N10, the ship would move north 10 units, but would still move east if the following action were F.)

For example:

F10
N3
F7
R90
F11
These instructions would be handled as follows:

F10 would move the ship 10 units east (because the ship starts by facing east) to east 10, north 0.
N3 would move the ship 3 units north to east 10, north 3.
F7 would move the ship another 7 units east (because the ship is still facing east) to east 17, north 3.
R90 would cause the ship to turn right by 90 degrees and face south; it remains at east 17, north 3.
F11 would move the ship 11 units south to east 17, south 8.
At the end of these instructions, the ship's Manhattan distance (sum of the absolute values of its east/west position and its north/south position) from its starting position is 17 + 8 = 25.

Figure out where the navigation instructions lead.

What is the Manhattan distance between that location and the ship's starting position?

Your puzzle answer was 319.

--- Part Two ---

Before you can give the destination to the captain, you realize that the actual action meanings were printed on the back of the instructions the whole time.

Almost all of the actions indicate how to move a waypoint which is relative to the ship's position:

Action N means to move the waypoint north by the given value.
Action S means to move the waypoint south by the given value.
Action E means to move the waypoint east by the given value.
Action W means to move the waypoint west by the given value.
Action L means to rotate the waypoint around the ship left (counter-clockwise) the given number of degrees.
Action R means to rotate the waypoint around the ship right (clockwise) the given number of degrees.
Action F means to move forward to the waypoint a number of times equal to the given value.
The waypoint starts 10 units east and 1 unit north relative to the ship.
The waypoint is relative to the ship; that is, if the ship moves, the waypoint moves with it.

For example, using the same instructions as above:

F10 moves the ship to the waypoint 10 times (a total of 100 units east and 10 units north), leaving the ship at east 100, north 10.
The waypoint stays 10 units east and 1 unit north of the ship.
N3 moves the waypoint 3 units north to 10 units east and 4 units north of the ship.
The ship remains at east 100, north 10.
F7 moves the ship to the waypoint 7 times (a total of 70 units east and 28 units north), leaving the ship at east 170, north 38.
The waypoint stays 10 units east and 4 units north of the ship.
R90 rotates the waypoint around the ship clockwise 90 degrees, moving it to 4 units east and 10 units south of the ship.
The ship remains at east 170, north 38.
F11 moves the ship to the waypoint 11 times (a total of 44 units east and 110 units south), leaving the ship at east 214, south 72.
The waypoint stays 4 units east and 10 units south of the ship.

After these operations, the ship's Manhattan distance from its starting position is 214 + 72 = 286.

Figure out where the navigation instructions actually lead.

What is the Manhattan distance between that location and the ship's starting position?

*/

namespace Day12
{
    class Program
    {
        private Program(string inputFile, bool part1)
        {
            var lines = AoC.Program.ReadLines(inputFile);

            if (part1)
            {
                var result1 = Part1(lines);
                Console.WriteLine($"Day12 : Result1 {result1}");
                var expected = 319;
                if (result1 != expected)
                {
                    throw new InvalidProgramException($"Part1 is broken {result1} != {expected}");
                }
            }
            else
            {
                var result2 = Part2(lines);
                Console.WriteLine($"Day12 : Result2 {result2}");
                var expected = 50157;
                if (result2 != expected)
                {
                    throw new InvalidProgramException($"Part2 is broken {result2} != {expected}");
                }
            }
        }

        public static int Part1(string[] lines)
        {
            var x = 0;
            var y = 0;
            var dx = +1;
            var dy = +0;

            foreach (var l in lines)
            {
                var line = l.Trim();
                var move = line[0];
                var distance = int.Parse(line[1..]);
                if (move == 'N')
                {
                    y -= distance;
                }
                else if (move == 'S')
                {
                    y += distance;
                }
                else if (move == 'E')
                {
                    x += distance;
                }
                else if (move == 'W')
                {
                    x -= distance;
                }
                else if (move == 'L')
                {
                    var newDX = dx;
                    var newDY = dy;
                    if (distance == 90)
                    {
                        //+0, -1 => -1, +0
                        //-1, +0 => +0, +1
                        //+0, +1 => +1, +0
                        //+1, +0 => +0, -1
                        newDX = +dy;
                        newDY = -dx;
                    }
                    else if (distance == 180)
                    {
                        //+0, -1 => +0, +1
                        //-1, +0 => +1, +0
                        //+0, +1 => +0, -1
                        //+1, +0 => -1, +0
                        newDX = -dx;
                        newDY = -dy;
                    }
                    else if (distance == 270)
                    {
                        //+0, -1 => +1, +0
                        //-1, +0 => +0, -1
                        //+0, +1 => -1, +0
                        //+1, +0 => +0, +1
                        newDX = -dy;
                        newDY = +dx;
                    }
                    dx = newDX;
                    dy = newDY;
                }
                else if (move == 'R')
                {
                    var newDX = dx;
                    var newDY = dy;
                    if (distance == 90)
                    {
                        //+0, -1 => +1, +0
                        //-1, +0 => +0, -1
                        //+0, +1 => -1, +0
                        //+1, +0 => +0, +1
                        newDX = -dy;
                        newDY = +dx;
                    }
                    else if (distance == 180)
                    {
                        //+0, -1 => +0, +1
                        //-1, +0 => +1, +0
                        //+0, +1 => +0, -1
                        //+1, +0 => -1, +0
                        newDX = -dx;
                        newDY = -dy;
                    }
                    else if (distance == 270)
                    {
                        //+0, -1 => -1, +0
                        //-1, +0 => +0, +1
                        //+0, +1 => +1, +0
                        //+1, +0 => +0, -1
                        newDX = +dy;
                        newDY = -dx;
                    }
                    dx = newDX;
                    dy = newDY;
                }
                else if (move == 'F')
                {
                    x += dx * distance;
                    y += dy * distance;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        public static int Part2(string[] lines)
        {
            var x = 0;
            var y = 0;

            var wayDX = +10;
            var wayDY = -1;

            foreach (var l in lines)
            {
                var line = l.Trim();
                var move = line[0];
                var distance = int.Parse(line[1..]);
                if (move == 'N')
                {
                    wayDY -= distance;
                }
                else if (move == 'S')
                {
                    wayDY += distance;
                }
                else if (move == 'E')
                {
                    wayDX += distance;
                }
                else if (move == 'W')
                {
                    wayDX -= distance;
                }
                else if (move == 'L')
                {
                    var newDX = wayDX;
                    var newDY = wayDY;
                    if (distance == 90)
                    {
                        //+0, -1 => -1, +0
                        //-1, +0 => +0, +1
                        //+0, +1 => +1, +0
                        //+1, +0 => +0, -1
                        newDX = +wayDY;
                        newDY = -wayDX;
                    }
                    else if (distance == 180)
                    {
                        //+0, -1 => +0, +1
                        //-1, +0 => +1, +0
                        //+0, +1 => +0, -1
                        //+1, +0 => -1, +0
                        newDX = -wayDX;
                        newDY = -wayDY;
                    }
                    else if (distance == 270)
                    {
                        //+0, -1 => +1, +0
                        //-1, +0 => +0, -1
                        //+0, +1 => -1, +0
                        //+1, +0 => +0, +1
                        newDX = -wayDY;
                        newDY = +wayDX;
                    }
                    wayDX = newDX;
                    wayDY = newDY;
                }
                else if (move == 'R')
                {
                    var newDX = wayDX;
                    var newDY = wayDY;
                    if (distance == 90)
                    {
                        //+0, -1 => +1, +0
                        //-1, +0 => +0, -1
                        //+0, +1 => -1, +0
                        //+1, +0 => +0, +1
                        newDX = -wayDY;
                        newDY = +wayDX;
                    }
                    else if (distance == 180)
                    {
                        //+0, -1 => +0, +1
                        //-1, +0 => +1, +0
                        //+0, +1 => +0, -1
                        //+1, +0 => -1, +0
                        newDX = -wayDX;
                        newDY = -wayDY;
                    }
                    else if (distance == 270)
                    {
                        //+0, -1 => -1, +0
                        //-1, +0 => +0, +1
                        //+0, +1 => +1, +0
                        //+1, +0 => +0, -1
                        newDX = +wayDY;
                        newDY = -wayDX;
                    }
                    wayDX = newDX;
                    wayDY = newDY;
                }
                else if (move == 'F')
                {
                    x += wayDX * distance;
                    y += wayDY * distance;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        public static void Run()
        {
            Console.WriteLine("Day12 : Start");
            _ = new Program("Day12/input.txt", true);
            _ = new Program("Day12/input.txt", false);
            Console.WriteLine("Day12 : End");
        }
    }
}

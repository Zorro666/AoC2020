﻿using Xunit;
namespace Day03
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"..##.......",
"#...#...#..",
".#....#..#.",
"..#.#...#.#",
".#...##..#.",
"..#.##.....",
".#.#.#....#",
".#........#",
"#.##...#...",
"#...##....#",
".#..#...#.#"
        }, 1, 1, 2)]
        [InlineData(new string[] {
"..##.......",
"#...#...#..",
".#....#..#.",
"..#.#...#.#",
".#...##..#.",
"..#.##.....",
".#.#.#....#",
".#........#",
"#.##...#...",
"#...##....#",
".#..#...#.#"
        }, 3, 1, 7)]
        [InlineData(new string[] {
"..##.......",
"#...#...#..",
".#....#..#.",
"..#.#...#.#",
".#...##..#.",
"..#.##.....",
".#.#.#....#",
".#........#",
"#.##...#...",
"#...##....#",
".#..#...#.#"
        }, 5, 1, 3)]
        [InlineData(new string[] {
"..##.......",
"#...#...#..",
".#....#..#.",
"..#.#...#.#",
".#...##..#.",
"..#.##.....",
".#.#.#....#",
".#........#",
"#.##...#...",
"#...##....#",
".#..#...#.#"
        }, 7, 1, 4)]
        [InlineData(new string[] {
"..##.......",
"#...#...#..",
".#....#..#.",
"..#.#...#.#",
".#...##..#.",
"..#.##.....",
".#.#.#....#",
".#........#",
"#.##...#...",
"#...##....#",
".#..#...#.#"
        }, 1, 2, 2)]
        public void CountTrees(string[] lines, int dx, int dy, int expected)
        {
            Program.Parse(lines);
            Assert.Equal(expected, Program.CountTrees(dx, dy));
        }

        [Theory]
        [InlineData(new string[] {
"..##.......",
"#...#...#..",
".#....#..#.",
"..#.#...#.#",
".#...##..#.",
"..#.##.....",
".#.#.#....#",
".#........#",
"#.##...#...",
"#...##....#",
".#..#...#.#"
        }, 336)]
        public void Part2(string[] lines, int expected)
        {
            Program.Parse(lines);
            Assert.Equal(expected, Program.Part2());
        }
    }
}

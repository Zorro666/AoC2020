using Xunit;
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
        }, 3, 1, 7)]
        public void Part1(string[] lines, int dx, int dy, int expected)
        {
            Program.Parse(lines);
            Assert.Equal(expected, Program.Part1(dx, dy));
        }
    }
}

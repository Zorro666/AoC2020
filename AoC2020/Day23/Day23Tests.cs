using Xunit;
namespace Day23
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
        "389125467"
            }, 10, 92658374L)]
        [InlineData(new string[] {
        "389125467"
            }, 100, 67384529L)]
        public void Part1(string[] lines, int moves, long expected)
        {
            Assert.Equal(expected, Program.Part1(lines, moves));
        }

        [Theory]
        [InlineData(new string[] {
        "389125467"
            }, 100, 67384529L)]
        public void Part2(string[] lines, int moves, long expected)
        {
            Assert.Equal(expected, Program.Part2(lines, moves));
        }
    }
}

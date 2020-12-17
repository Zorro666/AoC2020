using Xunit;
namespace Day17
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
".#.",
"..#",
"###"
        }, 112)]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
".#.",
"..#",
"###"
        }, 848)]
        public void Part2(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

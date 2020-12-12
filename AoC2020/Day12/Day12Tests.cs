using Xunit;
namespace Day12
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"F10",
"N3",
"F7",
"R90",
"F11"
        }, 25)]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
"F10",
"N3",
"F7",
"R90",
"F11"
        }, 286)]
        public void Part2(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

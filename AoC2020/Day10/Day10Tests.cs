using Xunit;
namespace Day10
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"35",
        }, 62)]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
"35",
        }, 62)]
        public void Part2(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

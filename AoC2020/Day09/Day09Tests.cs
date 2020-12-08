using Xunit;
namespace Day09
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"A",
""
        }, 10)]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
"A",
""
        }, 10)]
        public void Part2(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

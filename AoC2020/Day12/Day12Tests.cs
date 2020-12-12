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
    }
}

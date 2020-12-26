using Xunit;
namespace Day22
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"Player 1:",
"9",
"2",
"6",
"3",
"1",
"",
"Player 2:",
"5",
"8",
"4",
"7",
"10"
        }, 306)]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
"Player 1:",
"9",
"2",
"6",
"3",
"1",
"",
"Player 2:",
"5",
"8",
"4",
"7",
"10"
        }, 291)]
        public void Part2(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

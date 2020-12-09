using Xunit;
namespace Day09
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"35",
"20",
"15",
"25",
"47",
"40",
"62",
"55",
"65",
"95",
"102",
"117",
"150",
"182",
"127",
"219",
"299",
"277",
"309",
"576"
        }, 5, 127)]
        public void Part1(string[] lines, int preambleCount, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines, preambleCount));
        }

        [Theory]
        [InlineData(new string[] {
"35",
"20",
"15",
"25",
"47",
"40",
"62",
"55",
"65",
"95",
"102",
"117",
"150",
"182",
"127",
"219",
"299",
"277",
"309",
"576"
        }, 5, 62)]
        public void Part2(string[] lines, int preambleCount, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines, preambleCount));
        }
    }
}

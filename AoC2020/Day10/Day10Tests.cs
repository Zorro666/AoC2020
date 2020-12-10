using Xunit;
namespace Day10
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"16",
"10",
"15",
"5",
"1",
"11",
"7",
"19",
"6",
"12",
"4"
        }, 7 * 5)]
        [InlineData(new string[] {
"28",
"33",
"18",
"42",
"31",
"14",
"46",
"20",
"48",
"47",
"24",
"23",
"49",
"45",
"19",
"38",
"39",
"11",
"1",
"32",
"25",
"35",
"8",
"17",
"7",
"9",
"4",
"2",
"34",
"10",
"3"
        }, 22 * 10)]
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

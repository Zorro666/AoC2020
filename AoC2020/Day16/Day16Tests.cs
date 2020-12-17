using Xunit;

namespace Day16
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"class: 1-3 or 5-7",
"row: 6-11 or 33-44",
"seat: 13-40 or 45-50",
"",
"your ticket:",
"7,1,14",
"",
"nearby tickets:",
"7,3,47",
"40,4,50",
"55,2,20",
"38,6,12"
        }, 71)]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
"departure location: 32-174 or 190-967",
"class: 0-1 or 4-19",
"row: 0-5 or 8-19",
"seat: 0-13 or 16-19",
"",
"your ticket:",
"11,12,13,200",
"",
"nearby tickets:",
"3,9,18,200",
"15,1,5,200",
"5,14,9,200"
        }, 200)]
        public void Part2(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines));

        }
    }
}

using Xunit;

namespace Day18
{
    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"1 + 2 * 3 + 4 * 5 + 6"
        }, 71)]
        [InlineData(new string[] {
"1 + (2 * 3) + (4 * (5 + 6))"
        }, 51)]
        [InlineData(new string[] {
"2 * 3 + (4 * 5)"
        }, 26)]
        [InlineData(new string[] {
"5 + (8 * 3 + 9 + 3 * 4 * 3)"
        }, 437)]
        [InlineData(new string[] {
"5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))"
        }, 12240)]
        [InlineData(new string[] {
"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2"
        }, 13632)]
        [InlineData(new string[] {
"9 * 8 + 2 + (4 * (2 * 2 + 9 * 2) * 9 * 3 * 8) + 8 * 5"
        }, 112730)]
        [InlineData(new string[] {
"5 + (4 * 7 + 2) + (5 + 8 * 5 + (4 * 9) + (3 + 3))"
        }, 142)]
        [InlineData(new string[] {
"8 + (4 * 4 + (7 * 5 * 7 + 2) + (9 * 3)) * (2 * 9 * 9 * (6 + 7 * 8 + 9 + 6 + 3) + 3 * (3 * 9 + 7 + 6 + 5 + 8)) + 5 * (5 + (4 + 2 + 8) + (9 * 7 * 4) + 3) * 8"
        }, (298 * 1047651L + 5) * 274 * 8)]
        [InlineData(new string[] {
"(7 * 5 * 7 + 2)"
        }, 247)]
        [InlineData(new string[] {
"(9 * 3)"
        }, 27)]
        [InlineData(new string[] {
"(4 * 4 + (7 * 5 * 7 + 2) + (9 * 3))"
        }, 290)]
        [InlineData(new string[] {
"(2 * 9 * 9 * (6 + 7 * 8 + 9 + 6 + 3) + 3 * (3 * 9 + 7 + 6 + 5 + 8))"
        }, 1047651)]
        [InlineData(new string[] {
"(6 + 7 * 8 + 9 + 6 + 3)"
        }, 122)]
        [InlineData(new string[] {
"(3 * 9 + 7 + 6 + 5 + 8)"
        }, 53)]
        [InlineData(new string[] {
"(5 + (4 + 2 + 8) + (9 * 7 * 4) + 3)"
        }, 274)]
        public void Part1(string[] lines, long expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
"1 + (2 * 3) + (4 * (5 + 6))"
        }, 51)]
        [InlineData(new string[] {
"2 * 3 + (4 * 5)"
        }, 46)]
        [InlineData(new string[] {
"2 * (3 + (4 * 5))"
        }, 46)]
        [InlineData(new string[] {
"5 + (8 * 3 + 9 + 3 * 4 * 3)"
        }, 1445)]
        [InlineData(new string[] {
"5 + (8 * (3 + 9 + 3) * 4 * 3)"
        }, 1445)]
        [InlineData(new string[] {
"5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))"
        }, 669060)]
        [InlineData(new string[] {
"5 * 9 * (7 * 3 * (3 + 9) * (3 + (8 + 6 * 4)))"
        }, 669060)]
        [InlineData(new string[] {
"((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + (2 + 4) * 2"
        }, 23340)]
        [InlineData(new string[] {
"3 * 3 + 2"
        }, 3 * 5)]
        [InlineData(new string[] {
"3 * (3 + 2)"
        }, 3 * 5)]
        [InlineData(new string[] {
"3 * 3 + 2 + 1"
        }, 3 * 6)]
        [InlineData(new string[] {
"3 * (3 + 2 + 1)"
        }, 3 * 6)]
        [InlineData(new string[] {
"(8 * (3 + 9 + 3))"
        }, 8 * 15)]
        [InlineData(new string[] {
"(8 * 3 + 9 + 3)"
        }, 8 * 15)]
        [InlineData(new string[] {
"(8 * 3 + 9 + 3 * 4)"
        }, 8 * 15 * 4)]
        [InlineData(new string[] {
"3 + 9 + 3 * 4"
        }, 15 * 4)]
        [InlineData(new string[] {
"9 + 3 * 4"
        }, 12 * 4)]
        [InlineData(new string[] {
"2 * 3 + 4"
        }, 14)]
        [InlineData(new string[] {
"2 * (3 + 4)"
        }, 14)]
        [InlineData(new string[] {
"2 * 3 + (3 * 4)"
        }, 30)]
        [InlineData(new string[] {
"8 * (9 + 5 + 5 * 6 + 8 * 3) * 5 * 7 * 4 + 9"
        }, 8 * ((9 + 5 + 5) * (6 + 8) * 3) * 5 * 7 * (4 + 9))]
        public void Part2(string[] lines, long expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

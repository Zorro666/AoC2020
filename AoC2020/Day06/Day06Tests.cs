using Xunit;
namespace Day06
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"abc",
"",
"a",
"b",
"c",
"",
"ab",
"ac",
"",
"a",
"a",
"a",
"a",
"",
"b"}, 11)]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
"abc",
"",
"a",
"b",
"c",
"",
"ab",
"ac",
"",
"a",
"a",
"a",
"a",
"",
"b"}, 6)]
        public void Part2(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

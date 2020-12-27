using Xunit;
namespace Day23
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"389125467"
        }, 1, 54673289L)]
        [InlineData(new string[] {
"389125467"
        }, 2, 32546789L)]
        [InlineData(new string[] {
"389125467"
        }, 3, 34672589L)]
        [InlineData(new string[] {
"389125467"
        }, 4, 32584679L)]
        [InlineData(new string[] {
"389125467"
        }, 5, 36792584L)]
        [InlineData(new string[] {
"389125467"
        }, 6, 93672584L)]
        [InlineData(new string[] {
"389125467"
        }, 7, 92583674L)]
        [InlineData(new string[] {
"389125467"
        }, 8, 58392674L)]
        [InlineData(new string[] {
"389125467"
        }, 9, 83926574L)]
        [InlineData(new string[] {
"389125467"
        }, 10, 92658374L)]
        [InlineData(new string[] {
"389125467"
        }, 100, 67384529L)]
        public void Part1(string[] lines, int moves, long expected)
        {
            Assert.Equal(expected, Program.Part1(lines, moves));
        }

        [Theory]
        [InlineData(new string[] {
"389125467"
        }, 149245887792L)]
        public void Part2(string[] lines, long expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

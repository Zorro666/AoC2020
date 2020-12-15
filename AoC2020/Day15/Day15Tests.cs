using Xunit;
namespace Day15
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"0,3,6"
        }, 436)]
        [InlineData(new string[] {
"1,3,2"
        }, 1)]
        [InlineData(new string[] {
"2,1,3"
        }, 10)]
        [InlineData(new string[] {
"1,2,3"
        }, 27)]
        [InlineData(new string[] {
"2,3,1"
        }, 78)]
        [InlineData(new string[] {
"3,2,1"
        }, 438)]
        [InlineData(new string[] {
"3,1,2"
        }, 1836)]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
"0,3,6"
        }, 175594)]
        [InlineData(new string[] {
"1,3,2"
        }, 2578)]
        [InlineData(new string[] {
"2,1,3"
        }, 3544142)]
        [InlineData(new string[] {
"1,2,3"
        }, 261214)]
        [InlineData(new string[] {
"2,3,1"
        }, 6895259)]
        [InlineData(new string[] {
"3,2,1"
        }, 18)]
        [InlineData(new string[] {
"3,1,2"
        }, 362)]
        public void Part2(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

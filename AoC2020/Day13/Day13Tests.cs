using Xunit;
namespace Day13
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"939",
"7,13,x,x,59,x,31,19"
        }, 295)]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
"939",
"7,13,x,x,59,x,31,19"
        }, 1068781)]
        [InlineData(new string[] {
"939",
"17,x,13,19"
        }, 3417)]
        [InlineData(new string[] {
"939",
"67,7,59,61"
        }, 754018)]
        [InlineData(new string[] {
"939",
"67,x,7,59,61"
        }, 779210)]
        [InlineData(new string[] {
"939",
"67,7,x,59,61"
        }, 1261476)]
        [InlineData(new string[] {
"939",
"1789,37,47,1889"
        }, 1202161486)]
        public void Part2(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

using Xunit;
namespace Day14
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
"mem[8] = 11",
"mem[7] = 101",
"mem[8] = 0"
        }, 165)]
        public void Part1(string[] lines, long expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [InlineData(new string[] {
"mask = 000000000000000000000000000000X1001X",
"mem[42] = 100",
"mask = 00000000000000000000000000000000X0XX",
"mem[26] = 1"
        }, 208)]
        public void Part2(string[] lines, long expected)
        {
            Assert.Equal(expected, Program.Part2(lines));
        }
    }
}

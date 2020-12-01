using Xunit;

namespace Day01
{
    public class Tests
    {
        [Theory]
        [InlineData(new int[]
{
1721,
979,
366,
299,
675,
1456
            }, 514579)]
        public void Day01(int[] values, int expected)
        {
            Assert.Equal(expected, Program.Part1(values));
        }
    }
}

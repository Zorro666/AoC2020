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
        public void SumTwo(int[] values, int expected)
        {
            Assert.Equal(expected, Program.SumTwo(2020, values));
        }

        [Theory]
        [InlineData(new int[]
    {
1721,
979,
366,
299,
675,
1456
            }, 241861950)]
        public void SumThree(int[] values, int expected)
        {
            Assert.Equal(expected, Program.SumThree(2020, values));
        }
    }
}

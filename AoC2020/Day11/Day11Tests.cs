using Xunit;
namespace Day11
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day11(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

using Xunit;
namespace Day20
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day20(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

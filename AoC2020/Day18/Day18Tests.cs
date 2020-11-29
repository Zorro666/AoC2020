using Xunit;
namespace Day18
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day18(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

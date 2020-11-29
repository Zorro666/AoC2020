using Xunit;
namespace Day06
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day06(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

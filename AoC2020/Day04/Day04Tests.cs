using Xunit;
namespace Day04
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day04(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

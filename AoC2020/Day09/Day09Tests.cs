using Xunit;
namespace Day09
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day09(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

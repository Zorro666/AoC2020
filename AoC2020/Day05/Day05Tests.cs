using Xunit;
namespace Day05
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day05(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

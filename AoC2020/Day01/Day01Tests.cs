using Xunit;

namespace Day01
{
    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day01(int expected)
        {
            Assert.NotEqual(expected, expected);
        }
    }
}

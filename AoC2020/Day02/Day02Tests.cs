using Xunit;
namespace Day02
{
    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day02(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

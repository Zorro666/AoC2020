using Xunit;
namespace Day07
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day07(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

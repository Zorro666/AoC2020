using Xunit;
namespace Day19
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day19(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

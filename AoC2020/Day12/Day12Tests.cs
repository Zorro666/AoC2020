using Xunit;
namespace Day12
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day12(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

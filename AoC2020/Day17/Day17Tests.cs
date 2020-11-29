using Xunit;
namespace Day17
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day17(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

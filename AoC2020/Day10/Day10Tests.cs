using Xunit;
namespace Day10
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day10(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

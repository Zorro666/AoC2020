using Xunit;
namespace Day15
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day15(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

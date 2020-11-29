using Xunit;
namespace Day25
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day25(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

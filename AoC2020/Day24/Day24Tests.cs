using Xunit;
namespace Day24
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day24(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

using Xunit;
namespace Day08
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day08(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

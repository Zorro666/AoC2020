using Xunit;
namespace Day03
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day03(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

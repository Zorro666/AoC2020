using Xunit;
namespace Day22
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day22(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

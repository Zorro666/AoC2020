using Xunit;
namespace Day16
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day16(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

using Xunit;
namespace Day23
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day23(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

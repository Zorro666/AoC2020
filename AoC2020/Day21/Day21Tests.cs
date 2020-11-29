using Xunit;
namespace Day21
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day21(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

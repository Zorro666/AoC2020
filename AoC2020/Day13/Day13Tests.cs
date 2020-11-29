using Xunit;
namespace Day13
{

    public class Tests
    {
        [Theory]
        [InlineData(10)]
        public void Day13(int expected)
        {
            Assert.NotEqual(expected, expected);

        }
    }
}

using Xunit;
namespace Day02
{
    public class Tests
    {
        [Theory]
        [InlineData("1-3 a: abcde", 1)]
        [InlineData("1-3 b: cdefg", 0)]
        [InlineData("2-9 c: ccccccccc", 1)]
        public void Day02(string rule, int valid)
        {
            Assert.Equal(valid, Program.ValidPassword(rule));
        }
    }
}

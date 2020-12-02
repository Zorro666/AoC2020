using Xunit;
namespace Day02
{
    public class Tests
    {
        [Theory]
        [InlineData("1-3 a: abcde", 1)]
        [InlineData("1-3 b: cdefg", 0)]
        [InlineData("2-9 c: ccccccccc", 1)]
        public void ValidPassword1(string rule, int valid)
        {
            Assert.Equal(valid, Program.ValidPassword1(rule));
        }
        [Theory]
        [InlineData("1-3 a: abcde", 1)]
        [InlineData("1-3 b: cdefg", 0)]
        [InlineData("2-9 c: ccccccccc", 0)]
        public void ValidPassword2(string rule, int valid)
        {
            Assert.Equal(valid, Program.ValidPassword2(rule));
        }
    }
}

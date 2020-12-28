using Xunit;
namespace Day25
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"5764801",
"17807724"
         }, 14897079L)]
        public void Part1(string[] lines, long expected)
        {
            Assert.Equal(expected, Program.Part1(lines));

        }
    }
}

using Xunit;
namespace Day21
{

    public class Tests
    {
        [Theory]
        [InlineData(new string[] {
"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)",
"trh fvjkl sbzzf mxmxvkd (contains dairy)",
"sqjhc fvjkl (contains soy)",
"sqjhc mxmxvkd sbzzf (contains fish)"
        }, 5)]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));

        }

        [Theory]
        [InlineData(new string[] {
"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)",
"trh fvjkl sbzzf mxmxvkd (contains dairy)",
"sqjhc fvjkl (contains soy)",
"sqjhc mxmxvkd sbzzf (contains fish)"
        }, "mxmxvkd,sqjhc,fvjkl")]
        public void Part2(string[] lines, string expected)
        {
            Assert.Equal(expected, Program.Part2(lines));

        }
    }
}

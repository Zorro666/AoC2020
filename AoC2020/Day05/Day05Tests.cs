using Xunit;
namespace Day05
{

    public class Tests
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        public void DecodePass(string pass, int expectedRow, int expectedColumn, int expectedID)
        {
            var id = Program.DecodePass(pass, out int row, out int column);
            Assert.Equal(expectedRow, row);
            Assert.Equal(expectedColumn, column);
            Assert.Equal(expectedID, id);
        }
    }
}

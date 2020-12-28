using System.Collections.Generic;
using Xunit;
namespace Day24
{

    public class Tests
    {
        static readonly string[] sMoves = new string[] {
"sesenwnenenewseeswwswswwnenewsewsw",
"neeenesenwnwwswnenewnwwsewnenwseswesw",
"seswneswswsenwwnwse",
"nwnwneseeswswnenewneswwnewseswneseene",
"swweswneswnenwsewnwneneseenw",
"eesenwseswswnenwswnwnwsewwnwsene",
"sewnenenenesenwsewnenwwwse",
"wenwwweseeeweswwwnwwe",
"wsweesenenewnwwnwsenewsenwwsesesenwne",
"neeswseenwwswnwswswnw",
"nenwswwsewswnenenewsenwsenwnesesenew",
"enewnwewneswsewnwswenweswnenwsenwsw",
"sweneswneswneneenwnewenewwneswswnese",
"swwesenesewenwneswnwwneseswwne",
"enesenwswwswneneswsenwnewswseenwsese",
"wnwnesenesenenwwnenwsewesewsesesew",
"nenewswnwewswnenesenwnesewesw",
"eneswnwswnwsenenwnwnwwseeswneewsenese",
"neswnwewnwnwseenwseesewsenwsweewe",
"wseweeenwnesenwwwswnew"
        };

        public static IEnumerable<object[]> DataPart1 => new List<object[]>
        {
            new object[] { sMoves, 10 }
        };

        public static IEnumerable<object[]> DataPart2 => new List<object[]>
        {
            new object[] { sMoves, 1, 15 },
            new object[] { sMoves, 2, 12 },
            new object[] { sMoves, 3, 25 },
            new object[] { sMoves, 4, 14 },
            new object[] { sMoves, 5, 23 },
            new object[] { sMoves, 6, 28 },
            new object[] { sMoves, 7, 41 },
            new object[] { sMoves, 8, 37 },
            new object[] { sMoves, 9, 49 },
            new object[] { sMoves, 10, 37 },
            new object[] { sMoves, 20, 132 },
            new object[] { sMoves, 30, 259 },
            new object[] { sMoves, 40, 406 },
            new object[] { sMoves, 50, 566 },
            new object[] { sMoves, 60, 788 },
            new object[] { sMoves, 70, 1106 },
            new object[] { sMoves, 80, 1373 },
            new object[] { sMoves, 90, 1844 },
            new object[] { sMoves, 100, 2208 }
        };

        [Theory]
        [MemberData(nameof(DataPart1))]
        public void Part1(string[] lines, int expected)
        {
            Assert.Equal(expected, Program.Part1(lines));
        }

        [Theory]
        [MemberData(nameof(DataPart2))]
        public void Part2(string[] lines, int days, int expected)
        {
            Assert.Equal(expected, Program.Part2(lines, days));
        }
    }
}

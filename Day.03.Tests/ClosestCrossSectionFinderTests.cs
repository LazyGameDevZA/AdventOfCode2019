using NUnit.Framework;

namespace Day._03.Tests
{
    public class ClosestCrossSectionFinderTests
    {
        [Test]
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", ExpectedResult = 6)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", ExpectedResult = 159)]
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", ExpectedResult = 135)]
        public int TestClosestManhattan(string wire1Input, string wire2Input)
        {
            var wire1 = PathParser.ParsePath(wire1Input);
            var wire2 = PathParser.ParsePath(wire2Input);
            return ClosestCrossSectionFinder.FindClosestManhattanCross(wire1, wire2);
        }

        [Test]
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", ExpectedResult = 30)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", ExpectedResult = 610)]
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", ExpectedResult = 410)]
        public int TestClosestWireFollow(string wire1Input, string wire2Input)
        {
            var wire1 = PathParser.ParsePath(wire1Input);
            var wire2 = PathParser.ParsePath(wire2Input);
            return ClosestCrossSectionFinder.FindClosestViaWireCross(wire1, wire2);
        }
    }
}
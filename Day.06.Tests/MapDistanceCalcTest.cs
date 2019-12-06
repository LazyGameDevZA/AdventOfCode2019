using System.Collections;
using NUnit.Framework;

namespace Day._06.Tests
{
    public class MapDistanceCalcTest
    {
        private Map map;

        [SetUp]
        public void SetUp()
        {
            this.map = Map.Parse(orbits);
        }
        
        [TestCase("D", ExpectedResult = 3)]
        [TestCase("L", ExpectedResult = 7)]
        [TestCase("COM", ExpectedResult = 0)]
        public int TestOrbitCounter(string body)
        {
            return this.map.CalculateOrbitsFor(body);
        }

        [TestCase(ExpectedResult = 42)]
        public int TestChecksumCalculator()
        {
            return this.map.CalculateChecksum();
        }

        private static readonly string[] orbits = { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L" };
    }

    public class MapTransferDistanceCalcTest
    {
        private Map map;

        [SetUp]
        public void SetUp()
        {
            this.map = Map.Parse(orbits);
        }

        [TestCase("YOU", "SAN", ExpectedResult = 4)]
        public int TestOrbitalTransfersCalculator(string from, string to)
        {
            return this.map.CalculateOrbitalTransfersRequired(from, to);
        }
        
        private static readonly string[] orbits = { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN" };
    }
}

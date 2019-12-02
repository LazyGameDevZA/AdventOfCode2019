using NUnit.Framework;

namespace Day._01.Tests
{
    public class FuelCalculatorTests
    {
        [Test]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(14, ExpectedResult = 2)]
        [TestCase(1969, ExpectedResult = 654)]
        [TestCase(100756, ExpectedResult = 33583)]
        public int TestSampleInput(int moduleWeight)
        {
            return FuelCalculator.ForWeight(moduleWeight);
        }

        [Test]
        [TestCase(14, ExpectedResult = 2)]
        [TestCase(1969, ExpectedResult = 966)]
        [TestCase(100756, ExpectedResult = 50346)]
        public int TestSampleInputWithFuelWeight(int moduleWeight)
        {
            return FuelCalculator.ForModuleWeightWithFuelWeight(moduleWeight);
        }
    }
}
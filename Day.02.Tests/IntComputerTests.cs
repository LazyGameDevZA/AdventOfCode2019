using System;
using NUnit.Framework;

namespace Day._02.Tests
{
    public class IntComputerTests
    {
        [Test]
        [TestCase(new[] { 1,9,10,3,2,3,11,0,99,30,40,50 },
            ExpectedResult = new[] { 3500,9,10,70,2,3,11,0,99,30,40,50 })]
        [TestCase(new[] { 1,0,0,0,99 },
            ExpectedResult = new[] { 2,0,0,0,99 })]
        [TestCase(new[] { 2,3,0,3,99 },
            ExpectedResult = new[] { 2,3,0,6,99 })]
        [TestCase(new[] { 2,4,4,5,99,0 },
            ExpectedResult = new[] { 2,4,4,5,99,9801 })]
        [TestCase(new[] { 1,1,1,4,99,5,6,0,99 },
            ExpectedResult = new[] { 30,1,1,4,2,5,6,0,99 })]
        public int[] TestCanRunIntCode(int[] intCode)
        {
            var computer = new IntComputer(intCode);

            computer.Run();

            return intCode;
        }
    }

    public class IntInstructionTests
    {
        [Test]
        [TestCase(new[] {1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50}, 0, 3, ExpectedResult = 70)]
        public int TestAddInstruction(int[] intCode, int startIndex, int resultIndex)
        {
            Instructions.ExecuteAdd(startIndex, intCode);

            return intCode[resultIndex];
        }

        [Test]
        [TestCase(new[] {1, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50}, 4, 0, ExpectedResult = 3500)]
        public int TestMultiplyInstruction(int[] intCode, int startIndex, int resultIndex)
        {
            Instructions.ExecuteMultiply(startIndex, intCode);

            return intCode[resultIndex];
        }
    }
}
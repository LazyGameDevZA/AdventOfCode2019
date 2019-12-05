using System;
using System.Collections;
using NUnit.Framework;

namespace Day._05.Tests
{
    public class IntComputerTests
    {
        [Test]
        [TestCase(new []{ 3,0,4,0,99 }, 50, ExpectedResult = 50)]
        [TestCase(new []{ 3,9,8,9,10,9,4,9,99,-1,8 }, 8, ExpectedResult = 1)]
        [TestCase(new []{ 3,9,8,9,10,9,4,9,99,-1,8 }, 9, ExpectedResult = 0)]
        [TestCase(new []{ 3,3,1108,-1,8,3,4,3,99 }, 8, ExpectedResult = 1)]
        [TestCase(new []{ 3,3,1108,-1,8,3,4,3,99 }, 9, ExpectedResult = 0)]
        [TestCase(new []{ 3,9,7,9,10,9,4,9,99,-1,8 }, 7, ExpectedResult = 1)]
        [TestCase(new []{ 3,9,7,9,10,9,4,9,99,-1,8 }, 8, ExpectedResult = 0)]
        [TestCase(new []{ 3,3,1107,-1,8,3,4,3,99 }, 7, ExpectedResult = 1)]
        [TestCase(new []{ 3,3,1107,-1,8,3,4,3,99 }, 8, ExpectedResult = 0)]
        [TestCase(new []{ 3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9 }, 0, ExpectedResult = 0)]
        [TestCase(new []{ 3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9 }, 1, ExpectedResult = 1)]
        [TestCaseSource(nameof(Large))]
        public int TestIntComputerWithOutput(int[] intCode, int input)
        {
            var computer = new IntComputer(intCode, input);

            return computer.Run();
        }

        [Test]
        [TestCase(new []{ 1002,4,3,4,33 }, ExpectedResult = new []{ 1002,4,3,4,99 })]
        public int[] TestIntComputerMemoryState(int[] intCode)
        {
            var computer = new IntComputer(intCode, 0);
            computer.Run();

            return intCode;
        }

        private static readonly int[] largeExample =
        {
            3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
            1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
            999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99
        };
        
        private static IEnumerable Large
        {
            get
            {
                var data = new int[largeExample.Length];
                
                largeExample.CopyTo(data.AsSpan());
                yield return new TestCaseData(largeExample, 7).Returns(999);
                
                largeExample.CopyTo(data.AsSpan());
                yield return new TestCaseData(largeExample, 8).Returns(1000);
                
                largeExample.CopyTo(data.AsSpan());
                yield return new TestCaseData(largeExample, 9).Returns(1001);
            }
        }
    }
}

using NUnit.Framework;

namespace Day._04.Tests
{
    public class PasswordValidatorTests
    {
        [Test]
        [TestCase(111111, ExpectedResult = false)]
        [TestCase(223450, ExpectedResult = false)]
        [TestCase(123789, ExpectedResult = false)]
        [TestCase(112233, ExpectedResult = true)]
        [TestCase(123444, ExpectedResult = false)]
        [TestCase(111122, ExpectedResult = true)]
        public bool TestValid(int password)
        {
            return PasswordValidator.Validate(password);
        }
    }
}

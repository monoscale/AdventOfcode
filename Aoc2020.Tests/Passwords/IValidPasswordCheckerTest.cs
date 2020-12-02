using Aoc2020.Passwords;
using NUnit.Framework;

namespace Aoc2020.Tests.Passwords {
    [TestFixture]
    public class IValidPasswordCheckerTest {

        private IValidPasswordChecker passwordChecker;

        [Test]
        [TestCase(1, 3, 'a', "abcde", true)]
        [TestCase(1, 3, 'b', "cdefg", false)]
        [TestCase(2, 9, 'c', "ccccccccc", true)]
        public void TestSledRentalPasswordChecker(int f, int l, char r, string p, bool expected) {
            passwordChecker = new SledRentalPasswordChecker();
            Password password = new Password(p, r, f, l);
            Assert.AreEqual(expected, passwordChecker.IsValid(password));

        }

        [Test]
        [TestCase(1, 3, 'a', "abcde", true)]
        [TestCase(1, 3, 'b', "cdefg", false)]
        [TestCase(2, 9, 'c', "ccccccccc", false)]
        public void TestTobogganPasswordChecker(int f, int l, char r, string p, bool expected) {
            passwordChecker = new TobogganPasswordChecker();
            Password password = new Password(p, r, f, l);
            Assert.AreEqual(expected, passwordChecker.IsValid(password));
        }
    }
}

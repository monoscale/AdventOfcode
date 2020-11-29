using Aoc2019.Passwords;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2019.Tests.Passwords {

    [TestFixture]
    public class PasswordTest {

        [Test]
        [TestCase(122345, true)]
        [TestCase(111123, false)]
        [TestCase(111111, false)]
        [TestCase(223450, false)]
        [TestCase(123789, false)]
        [TestCase(112233, true)]
        [TestCase(123444, false)]
        [TestCase(111122, true)]
        public void TestValidPasswords(int digits, bool expected) {
            Password password = new Password(digits);
            Assert.AreEqual(expected, password.IsValid());
        }



    }
}



using Aoc2020.Passports;
using NUnit.Framework;
namespace Aoc2020.Tests.Passports {

    [TestFixture]
    public class IValidPassportCheckerTest {


        [Test]
        public void PassportTestWithoutValidation1() {
            Passport passport = new Passport();
            passport.SetProperty("ecl", "gry");
            passport.SetProperty("pid", "860033327");
            passport.SetProperty("eyr", "2020");
            passport.SetProperty("hcl", "#fffffd");
            passport.SetProperty("byr", "1937");
            passport.SetProperty("iyr", "2017");
            passport.SetProperty("hgt", "183cm");
            passport.SetProperty("cid", "147");
            NoDataValidationPassportChecker passportChecker = new NoDataValidationPassportChecker();
            Assert.AreEqual(true, passportChecker.IsValid(passport));
        }


        [Test]
        public void PassportTestWithoutValidation2() {
            Passport passport = new Passport();
            passport.SetProperty("ecl", "amb");
            passport.SetProperty("pid", "028048884");
            passport.SetProperty("eyr", "2023");
            passport.SetProperty("hcl", "#cfa07d");
            passport.SetProperty("byr", "1929");
            passport.SetProperty("iyr", "2013");
            passport.SetProperty("cid", "350");
            NoDataValidationPassportChecker passportChecker = new NoDataValidationPassportChecker();
            Assert.AreEqual(false, passportChecker.IsValid(passport));
        }

        [Test]
        public void PassportTestWithoutValidation3() {
            Passport passport = new Passport();
            passport.SetProperty("ecl", "brn");
            passport.SetProperty("pid", "760753108");
            passport.SetProperty("eyr", "2024");
            passport.SetProperty("hcl", "#ae17e1");
            passport.SetProperty("byr", "1931");
            passport.SetProperty("iyr", "2013");
            passport.SetProperty("hgt", "179cm");
            NoDataValidationPassportChecker passportChecker = new NoDataValidationPassportChecker();
            Assert.AreEqual(true, passportChecker.IsValid(passport));
        }

        [Test]
        public void PassportTestWithoutValidation4() {
            Passport passport = new Passport();
            passport.SetProperty("ecl", "brn");
            passport.SetProperty("pid", "166559648");
            passport.SetProperty("eyr", "2025");
            passport.SetProperty("hcl", "#cfa07d");
            passport.SetProperty("iyr", "2011");
            passport.SetProperty("hgt", "59in");
            NoDataValidationPassportChecker passportChecker = new NoDataValidationPassportChecker();
            Assert.AreEqual(false, passportChecker.IsValid(passport));
        }

        [Test]
        public void PassportTestWithValidation1() {
            Passport passport = new Passport();
            passport.SetProperty("eyr", "1972");
            passport.SetProperty("cid", "100");
            passport.SetProperty("hcl", "#18171d");
            passport.SetProperty("ecl", "amb");
            passport.SetProperty("hgt", "170");
            passport.SetProperty("pid", "186cm");
            passport.SetProperty("iyr", "2018");
            passport.SetProperty("byr", "1926");
            DataValidationPassportChecker passportChecker = new DataValidationPassportChecker();
            Assert.AreEqual(false, passportChecker.IsValid(passport));
        }

        [Test]
        public void PassportTestWithValidation2() {
            Passport passport = new Passport();
            passport.SetProperty("iyr", "2019");
            passport.SetProperty("hcl", "#602927");
            passport.SetProperty("eyr", "1967");
            passport.SetProperty("hgt", "170cm");
            passport.SetProperty("ecl", "grn");
            passport.SetProperty("pid", "012533040");
            passport.SetProperty("byr", "1946");
            DataValidationPassportChecker passportChecker = new DataValidationPassportChecker();
            Assert.AreEqual(false, passportChecker.IsValid(passport));
        }

        [Test]
        public void PassportTestWithValidation3() {
            Passport passport = new Passport();
            passport.SetProperty("hcl", "dab227");
            passport.SetProperty("iyr", "2012");
            passport.SetProperty("ecl", "brn");
            passport.SetProperty("hgt", "182cm");
            passport.SetProperty("pid", "021572410");
            passport.SetProperty("eyr", "2020");
            passport.SetProperty("byr", "1992");
            passport.SetProperty("cid", "277");
            DataValidationPassportChecker passportChecker = new DataValidationPassportChecker();
            Assert.AreEqual(false, passportChecker.IsValid(passport));
        }


        [Test]
        public void PassportTestWithValidation4() {
            Passport passport = new Passport();
            passport.SetProperty("hgt", "59cm");
            passport.SetProperty("ecl", "zzz");
            passport.SetProperty("eyr", "2038");
            passport.SetProperty("hcl", "74454a");
            passport.SetProperty("iyr", "2023");
            passport.SetProperty("pid", "3556412378");
            passport.SetProperty("byr", "2007");
            DataValidationPassportChecker passportChecker = new DataValidationPassportChecker();
            Assert.AreEqual(false, passportChecker.IsValid(passport));
        }

        [Test]
        public void PassportTestWithValidation5() {
            Passport passport = new Passport();
            passport.SetProperty("pid", "087499704");
            passport.SetProperty("hgt", "74in");
            passport.SetProperty("ecl", "grn");
            passport.SetProperty("iyr", "2012");
            passport.SetProperty("eyr", "2030");
            passport.SetProperty("byr", "1980");
            passport.SetProperty("hcl", "#623a2f");
            DataValidationPassportChecker passportChecker = new DataValidationPassportChecker();
            Assert.AreEqual(true, passportChecker.IsValid(passport));
        }

        [Test]
        public void PassportTestWithValidation6() {
            Passport passport = new Passport();
            passport.SetProperty("eyr", "2029");
            passport.SetProperty("ecl", "blu");
            passport.SetProperty("cid", "129");
            passport.SetProperty("byr", "1989");
            passport.SetProperty("iyr", "2014");
            passport.SetProperty("pid", "896056539");
            passport.SetProperty("hcl", "#a97842");
            passport.SetProperty("hgt", "165cm");
            DataValidationPassportChecker passportChecker = new DataValidationPassportChecker();
            Assert.AreEqual(true, passportChecker.IsValid(passport));
        }

        [Test]
        public void PassportTestWithValidation7() {
            Passport passport = new Passport();
            passport.SetProperty("hcl", "#888785");
            passport.SetProperty("hgt", "164cm");
            passport.SetProperty("byr", "2001");
            passport.SetProperty("iyr", "2015");
            passport.SetProperty("cid", "88");
            passport.SetProperty("pid", "545766238");
            passport.SetProperty("ecl", "hzl");
            passport.SetProperty("eyr", "2022");
            DataValidationPassportChecker passportChecker = new DataValidationPassportChecker();
            Assert.AreEqual(true, passportChecker.IsValid(passport));
        }

        [Test]
        public void PassportTestWithValidation8() {
            Passport passport = new Passport();
            passport.SetProperty("iyr", "2010");
            passport.SetProperty("hgt", "158cm");
            passport.SetProperty("hcl", "#b6652a");
            passport.SetProperty("ecl", "blu");
            passport.SetProperty("byr", "1944");
            passport.SetProperty("eyr", "2021");
            passport.SetProperty("pid", "093154719");
            DataValidationPassportChecker passportChecker = new DataValidationPassportChecker();
            Assert.AreEqual(true, passportChecker.IsValid(passport));
        }
    }
}

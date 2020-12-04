using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc2020.Passports {
    public class DataValidationPassportChecker : IValidPassportChecker {
        public bool IsValid(Passport passport) {
            bool isValid = true;

            NoDataValidationPassportChecker noDataValidationPassportChecker = new NoDataValidationPassportChecker();

            isValid = noDataValidationPassportChecker.IsValid(passport);

            if (isValid) {
                isValid &= CheckBirthYear(passport.BirthYear)
                    && CheckIssueYear(passport.IssueYear)
                    && CheckExpirationYear(passport.ExpirationYear)
                    && CheckHeight(passport.Height)
                    && CheckHairColor(passport.HairColor)
                    && CheckEyeColor(passport.EyeColor)
                    && CheckPassportID(passport.PassportID);
            }
            return isValid;
        }


        private bool CheckBirthYear(string birthYear) {
            int value = int.Parse(birthYear);
            return value >= 1920 && value <= 2002;
        }


        private bool CheckIssueYear(string issueYear) {
            int value = int.Parse(issueYear);
            return value >= 2010 && value <= 2020;
        }

        private bool CheckExpirationYear(string expirationYear) {
            int value = int.Parse(expirationYear);
            return value >= 2020 && value <= 2030;
        }

        private bool CheckHeight(string height) {

            string unitOfLength = height.Where(c => char.IsLetter(c)).Aggregate("", (acc, x) => acc + x);
            int value = int.Parse(height.Take(height.Length - unitOfLength.Length).Aggregate("", (acc, x) => acc + x));
            switch (unitOfLength) {
                case "cm": return value >= 150 && value <= 193;
                case "in": return value >= 59 && value <= 76;
            }
            return false;
        }

        private bool CheckHairColor(string hairColor) {
            Regex regex = new Regex("\\#[0-9a-f]{6}");
            return regex.Match(hairColor).Success;
        }

        private bool CheckEyeColor(string eyeColor) {
            List<string> possibilities = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            return possibilities.Any(p => p.Equals(eyeColor));
        }

        private bool CheckPassportID(string passportID) {
            Regex regex = new Regex("^[0-9]{9}$");
            return regex.Match(passportID).Success;
        }
    }
}

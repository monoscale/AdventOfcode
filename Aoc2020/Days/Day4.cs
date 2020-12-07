using Aoc2020.Airplane;
using Aoc2020.Trees;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc2020.Days {
    public class Day4 : Day<int, int> {
        public override string Title => "Passport Processing";

        private List<Passport> passports;

        protected override void ReadInput(StreamReader input) {
            passports = new List<Passport>();
            Passport currentPassport = new Passport();
            string line;

            while ((line = input.ReadLine()) != null) {
                if (string.IsNullOrWhiteSpace(line)) {
                    passports.Add(currentPassport);
                    currentPassport = new Passport();
                } else {
                    foreach (string property in line.Split(' ')) {
                        string[] keyAndValue = property.Split(':');
                        currentPassport.SetProperty(keyAndValue[0], keyAndValue[1]);
                    }
                }
            }
            passports.Add(currentPassport);

        }

        protected override int SolvePartOne() {
            NoDataValidationPassportChecker passportChecker = new NoDataValidationPassportChecker();
            return passports.Where(p => passportChecker.IsValid(p)).Count();
        }

        protected override int SolvePartTwo() {
            DataValidationPassportChecker passportChecker = new DataValidationPassportChecker();
            return passports.Where(p => passportChecker.IsValid(p)).Count();
        }
    }
}

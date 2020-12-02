using Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Aoc2020.Passwords;

namespace Aoc2020.Days {
    public class Day2 : Day<int, int> {
        public override string Title => "Password Philosophy";

        private List<Password> passwords = new List<Password>();

        protected override void ReadInput(StreamReader input) {
            string regexPattern = @"^(\d*)-(\d*) ([a-z]): ([a-z]*)$";
            Regex regex = new Regex(regexPattern);

            string line;
            while ((line = input.ReadLine()) != null) {

                Match match = regex.Match(line);
                passwords.Add(new Password(
                    match.Groups[4].Value,
                    match.Groups[3].Value[0],
                    int.Parse(match.Groups[1].Value),
                    int.Parse(match.Groups[2].Value)));
            }
        }

        protected override int SolvePartOne() {
            IValidPasswordChecker passwordChecker = new SledRentalPasswordChecker();
            return passwords.Where(p => passwordChecker.IsValid(p)).Count();
        }

        protected override int SolvePartTwo() {
            IValidPasswordChecker passwordChecker = new TobogganPasswordChecker();
            return passwords.Where(p => passwordChecker.IsValid(p)).Count();
        }
    }
}

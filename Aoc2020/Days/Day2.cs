using Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc2020.Days {
    public class Day2 : Day<int, int> {
        public override string Title => "Report Repair";

        private class Password {
            private char requirement;
            private int min, max;
            private string text;
            public Password(string text, char requirement, int min, int max) {
                this.text = text;
                this.requirement = requirement;
                this.min = min;
                this.max = max;
            }

            public bool IsValidV1() {
                int frequency = text.Where(c => c == requirement).Count();
                return frequency >= min && frequency <= max;
            }

            public bool IsValidV2() {
                bool charIsAtFirstPos = text[min - 1] == requirement;
                bool charIsAtSecondPos = text[max - 1] == requirement;
                return charIsAtFirstPos ^ charIsAtSecondPos;
            }
        }

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
            return passwords.Where(p => p.IsValidV1()).Count();
        }

        protected override int SolvePartTwo() {
            return passwords.Where(p => p.IsValidV2()).Count();
        }
    }
}

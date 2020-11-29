using Aoc2019.Passwords;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aoc2019.Days {
    public class Day4 : Day<int, int> {
        public override string Title => "Secure Container";

        private int minimum;
        private int maximum;



        protected override void ReadInput(StreamReader input) {
            string[] parts = input.ReadLine().Split("-");
            minimum = int.Parse(parts[0]);
            maximum = int.Parse(parts[1]);
        }

        protected override int SolvePartOne() {
            int validCount = 0;
            for (int i = minimum; i < maximum; i++) {
                Password password = new Password(i);
                if (password.IsValid()) {
                    validCount++;
                }
            }

            return validCount;
        }

        protected override int SolvePartTwo() {
            return 0;
        }
    }
}

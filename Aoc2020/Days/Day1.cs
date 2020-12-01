using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aoc2020.Days {
    public class Day1 : Day<int, int> {
        public override string Title => "Report Repair";

        private List<int> numbers = new List<int>();

        protected override void ReadInput(StreamReader input) {
            string line;
            while ((line = input.ReadLine()) != null) {
                numbers.Add(int.Parse(line));
            }
        }

        protected override int SolvePartOne() {
            int x = 0, y = 0;
            int i = 0, j = 1;
            while (x + y != 2020) {
                x = numbers[i];
                y = numbers[j % 100];
                j++;
                i = j / 100;
            }
            return x * y;
        }

        protected override int SolvePartTwo() {
            int x = 0, y = 0, z = 0;
            int i = 0, j = 1, k = 2;
            while (x + y + z != 2020) {
                x = numbers[i];
                y = numbers[j % 100];
                z = numbers[k % 100];
                k++;
                j = k / 100;
                i = j / 10000;
            }
            return x * y * z;
        }
    }
}

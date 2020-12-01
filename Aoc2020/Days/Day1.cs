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
            int result = 0;
            for (int i = 0; i < numbers.Count; i++) {
                for (int j = i; j < numbers.Count; j++) {
                    int x = numbers[i];
                    int y = numbers[j];
                    if (x + y == 2020) {
                        Console.WriteLine($"{x} en {y}");
                        result = x * y;

                    }
                }
            }
            return result;
        }

        protected override int SolvePartTwo() {
            int result = 0;
            for (int i = 0; i < numbers.Count; i++) {
                for (int j = i; j < numbers.Count; j++) {
                    for (int k = j; k < numbers.Count; k++) {
                        int x = numbers[i];
                        int y = numbers[j];
                        int z = numbers[k];
                        if (x + y + z == 2020) {
                            Console.WriteLine($"{x} en {y} en {z}");
                            result = x * y * z;

                        }
                    }
                }
            }
            return result;
        }
    }
}

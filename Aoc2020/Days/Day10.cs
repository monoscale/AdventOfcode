using Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc2020.Days {
    public class Day10 : Day<int, int> {
        public override string Title => "Adapter Array";

        IList<int> numbers;
        protected override void ReadInput(StreamReader input) {
            numbers = input.ReadNumbers().OrderBy(i => i).ToList();
        }

        protected override int SolvePartOne() {

            IList<int> copy = new List<int>(numbers);
            int prevNumber = 0;
            for (int i = 0; i < numbers.Count; i++) {
                copy[i] = numbers[i] - prevNumber;
                prevNumber = numbers[i];
            }
            int count1 = copy.Count(x => x == 1);

            return count1 * numbers.Count - count1;
        }

        protected override int SolvePartTwo() {
            return 0;
        }
    }
}

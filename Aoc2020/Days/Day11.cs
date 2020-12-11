using Aoc2020.Ferry;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aoc2020.Days {
    public class Day11 : Day<int, int> {
        public override string Title => "Seating System";

        private Layout layout;

        protected override void ReadInput(StreamReader input) {
            layout = new Layout(input.ReadToEnd().Split("\r\n").ToList().Select(l => new List<char>(l.ToCharArray())).ToList());
        }

        protected override int SolvePartOne() {
            throw new NotImplementedException();
        }

        protected override int SolvePartTwo() {
            throw new NotImplementedException();
        }
    }
}

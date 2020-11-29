using Aoc2019.Intcode;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aoc2019.Days {
    public class Day5 : Day<int, int> {

        private IntcodeProgram intcodeProgram;

        public override string Title => "Sunny with a Chance of Asteroids";

        protected override void ReadInput(StreamReader input) {
            intcodeProgram = new IntcodeProgram(input.ReadLine());
        }

        protected override int SolvePartOne() {
            intcodeProgram.AddToInput(1);
            intcodeProgram.Execute();
            return intcodeProgram.Outputs[intcodeProgram.Outputs.Count - 1];
        }

        protected override int SolvePartTwo() {
            intcodeProgram.Reset();
            intcodeProgram.AddToInput(5);
            intcodeProgram.Execute();
            return intcodeProgram.Outputs[0];
        }
    }
}

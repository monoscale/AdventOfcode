using Aoc2019.Intcode;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aoc2019.Days {
    public class Day2 : Day<int, int> {

        private IntcodeProgram intcodeProgram;
        public override string Title => "1202 Program Alarm";

        protected override void ReadInput(StreamReader input) {
            intcodeProgram = new IntcodeProgram(input.ReadLine());
        }

        protected override int SolvePartOne() {
            intcodeProgram[1] = 12;
            intcodeProgram[2] = 2;
            intcodeProgram.Execute();
            return intcodeProgram[0];
        }

        protected override int SolvePartTwo() {

            int output = 0;
            const int desiredOutput = 19690720;



            int noun = 1;
            int verb = 1;

            while (output != desiredOutput && noun <= 99 && verb <= 99) {
                intcodeProgram.Reset();
                intcodeProgram[1] = noun;
                intcodeProgram[2] = verb;
                intcodeProgram.Execute();
                output = intcodeProgram[0];
                if (output != desiredOutput) {
                    if (verb == 99) {
                        verb = 1;
                        noun++;
                    }
                    verb++;
                }

            }


            return (100 * noun) + verb;
        }
    }
}

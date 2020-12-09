using Aoc2020.Assembly;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aoc2020.Days {
    public class Day8 : Day<int, int> {
        public override string Title => "Handheld Halting";


        private string[] lines;

        protected override void ReadInput(StreamReader input) {
            lines = input.ReadToEnd().Split('\n');

        }

        protected override int SolvePartOne() {
            AssemblyProgram program = new AssemblyProgram(lines);
            InfiniteLoopDetector loopDetector = new InfiniteLoopDetector(program);
            loopDetector.Execute();
            return program.Accumulator;
        }

        protected override int SolvePartTwo() {

            Queue<int> indicesWhichContainJmp = new Queue<int>();
            Queue<int> indicesWhichContainNop = new Queue<int>();

            // find all lines which contain a nop or jmp instruction
            for (int i = 0; i < lines.Length; i++) {
                if (lines[i].StartsWith("nop")) {
                    indicesWhichContainNop.Enqueue(i);
                } else if (lines[i].StartsWith("jmp")) {
                    indicesWhichContainJmp.Enqueue(i);
                }
            }

            InfiniteLoopDetector loopDetector;
            AssemblyProgram program;
            // iterate all lines which contain nop instruction
            do {
                int index = indicesWhichContainNop.Dequeue();
                lines[index] = lines[index].Replace("nop", "jmp");

                program = new AssemblyProgram(lines);
                loopDetector = new InfiniteLoopDetector(program);

                // restore original program
                lines[index] = lines[index].Replace("jmp", "nop");
            } while (loopDetector.Execute() && indicesWhichContainNop.Count > 0);

            int answer;
            if (indicesWhichContainNop.Count > 0) {
                answer = program.Accumulator;
            } else {
                do {
                    int index = indicesWhichContainJmp.Dequeue();
                    lines[index] = lines[index].Replace("jmp", "nop");

                    program = new AssemblyProgram(lines);
                    loopDetector = new InfiniteLoopDetector(program);

                    // restore original program
                    lines[index] = lines[index].Replace("nop", "jmp");
                } while (loopDetector.Execute() && indicesWhichContainJmp.Count > 0);
                answer = program.Accumulator;
            }

            return answer;
        }

    }
}

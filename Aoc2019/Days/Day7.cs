using Aoc2019.Amplifiers;
using Aoc2019.Intcode;
using Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc2019.Days {
    public class Day7 : Day<int, int> {

        private IntcodeProgram intcodeProgram;
        private Amplifier[] amplifiers;
        private IEnumerable<IEnumerable<int>> phaseSettingSequences;


        public override string Title => "Amplification Circuit";

        protected override void ReadInput(StreamReader input) {
            intcodeProgram = new IntcodeProgram(input.ReadLine());

        }

        protected override int SolvePartOne() {
            phaseSettingSequences = GetPermutations(new int[] { 0, 1, 2, 3, 4 }, 5);
            int maxThrusterSignal = 0;
            foreach (IEnumerable<int> phaseSettingSequence in phaseSettingSequences) {
                amplifiers = new Amplifier[5];

                for (int i = 0; i < amplifiers.Length; i++) {
                    amplifiers[i] = new Amplifier(intcodeProgram.Copy());
                    amplifiers[i].SetPhaseSetting(phaseSettingSequence.ElementAt(i));
                }

                int output = 0;
                for (int i = 0; i < amplifiers.Length; i++) {
                    amplifiers[i].SetInput(output);
                    amplifiers[i].Execute();
                    output = amplifiers[i].GetOutput();
                }

                if (output > maxThrusterSignal) {
                    maxThrusterSignal = output;
                }
            }
            return maxThrusterSignal;
        }

        protected override int SolvePartTwo() {
            phaseSettingSequences = GetPermutations(new int[] { 5, 6, 7, 8, 9 }, 5);
            int maxThrusterSignal = 0;
            for (int i = 0; i < amplifiers.Length; i++) {
                amplifiers[i] = new Amplifier(intcodeProgram.Copy());
            }
            foreach (IEnumerable<int> phaseSettingSequence in phaseSettingSequences) {
                for (int i = 0; i < amplifiers.Length; i++) {
                    amplifiers[i].SetPhaseSetting(phaseSettingSequence.ElementAt(i));
                }

                int endOfLoopOutput = -1;
                int output = 0;

                while(endOfLoopOutput != output) {
                    for (int i = 0; i < amplifiers.Length; i++) {
                        amplifiers[i].ClearInputs();
                        amplifiers[i].SetInput(output);
                        amplifiers[i].Execute();
                        output = amplifiers[i].GetOutput();
                    }

                    endOfLoopOutput = output;
                    if (endOfLoopOutput > maxThrusterSignal) {
                        maxThrusterSignal = endOfLoopOutput;
                    }
                }
            }
            return maxThrusterSignal;
        }

        private IEnumerable<IEnumerable<int>> GetPermutations(IEnumerable<int> elements, int length) {
            if (length == 1) {
                return elements.Select(el => new int[] { el });
            }

            return GetPermutations(elements, length - 1)
                .SelectMany(el => elements.Where(i => !el.Contains(i)), (el1, el2) => el1.Concat(new int[] { el2 }));
        }
    }
}

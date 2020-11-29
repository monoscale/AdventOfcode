using Aoc2019.Intcode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2019.Amplifiers {
    public class Amplifier {

        private IntcodeProgram intcodeProgram;

        public Amplifier(IntcodeProgram intcodeProgram) {
            this.intcodeProgram = intcodeProgram;
        }

        public void SetPhaseSetting(int phaseSetting) {
            intcodeProgram.AddToInput(phaseSetting);
        }

        public void SetInput(int input) {
            intcodeProgram.AddToInput(input);
        }

        public void ClearInputs() {
            intcodeProgram.Inputs.Clear();
        }

        public void Execute() {
            intcodeProgram.Execute();
        }

        public int GetOutput() {
            return intcodeProgram.Outputs[0];
        }

        

    }
}

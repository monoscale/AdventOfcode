using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2019.Intcode.Instructions {

    /// <summary>
    /// Outputs the value of its only parameter.
    /// </summary>
    public class OutputInstruction : Instruction {

        private ParameterMode parameterMode;

        public OutputInstruction(ParameterMode parameterMode) {
            this.parameterMode = parameterMode;
        }
        public void Execute(IntcodeProgram program) {
            program.AddToOutput(program.GetValueBasedOnParameterMode(1, parameterMode));
            program.InstructionPointer += 2;
        }
    }
}

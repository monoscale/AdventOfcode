using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2019.Intcode.Instructions {
    /// <summary>
    /// Multiplies together numbers read from two positions and stores the result in a third position.
    /// </summary>
    public class MultiplyInstruction : Instruction {

        private ParameterMode firstParameterMode;
        private ParameterMode secondParameterMode;

        public MultiplyInstruction(ParameterMode firstParameterMode, ParameterMode secondParameterMode) {
            this.firstParameterMode = firstParameterMode;
            this.secondParameterMode = secondParameterMode;
        }
        public void Execute(IntcodeProgram program) {
            int firstParam = program.GetValueBasedOnParameterMode(1, firstParameterMode);
            int secondParam = program.GetValueBasedOnParameterMode(2, secondParameterMode);
            int resultPosition = program[program.InstructionPointer + 3];
            program[resultPosition] = firstParam * secondParam;
            program.InstructionPointer += 4;
        }
    }
}
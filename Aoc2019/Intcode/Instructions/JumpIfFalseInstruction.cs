using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2019.Intcode.Instructions {

    /// <summary>
    /// If the first parameter is zero, it sets the instruction pointer to the value from the second parameter. 
    /// Otherwise, it does nothing.
    /// </summary>
    public class JumpIfFalseInstruction : Instruction {

        private ParameterMode firstParameterMode;
        private ParameterMode secondParameterMode;

        public JumpIfFalseInstruction(ParameterMode firstParameterMode, ParameterMode secondParameterMode) {
            this.firstParameterMode = firstParameterMode;
            this.secondParameterMode = secondParameterMode;
        }

        public void Execute(IntcodeProgram program) {
            int firstVal = program.GetValueBasedOnParameterMode(1, firstParameterMode);
            if (firstVal == 0) {
                int secondVal = program.GetValueBasedOnParameterMode(2, secondParameterMode);
                program.InstructionPointer = secondVal;
            } else {
                program.InstructionPointer += 3;
            }
        }
    }
}

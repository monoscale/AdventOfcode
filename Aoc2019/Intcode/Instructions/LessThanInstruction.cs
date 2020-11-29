using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2019.Intcode.Instructions {

    /// <summary>
    /// If the first parameter is less than the second parameter, it stores 1 in the position given by the third parameter. 
    /// Otherwise, it stores 0.
    /// </summary>
    public class LessThanInstruction : Instruction {

        private ParameterMode firstParameterMode;
        private ParameterMode secondParameterMode;
        private ParameterMode thirdParameterMode;

        public LessThanInstruction(ParameterMode firstParameterMode, ParameterMode secondParameterMode, ParameterMode thirdParameterMode) {
            this.firstParameterMode = firstParameterMode;
            this.secondParameterMode = secondParameterMode;
            this.thirdParameterMode = thirdParameterMode;
        }

        public void Execute(IntcodeProgram program) {
            int firstVal = program.GetValueBasedOnParameterMode(1, firstParameterMode);
            int secondVal = program.GetValueBasedOnParameterMode(2, secondParameterMode);
            int thirdVal = program.GetValueBasedOnParameterMode(3, thirdParameterMode);

            if (firstVal < secondVal) {
                program[program[program.InstructionPointer + 3]] = 1;
            } else {
                program[program[program.InstructionPointer + 3]] = 0;
            }

            program.InstructionPointer += 4;

        }
    }
}

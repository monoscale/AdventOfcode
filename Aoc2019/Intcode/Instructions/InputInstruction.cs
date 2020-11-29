using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2019.Intcode.Instructions {
    /// <summary>
    /// Takes a single integer as input and saves it to the position given by its only parameter.
    /// </summary>
    public class InputInstruction : Instruction {

        private ParameterMode parameterMode;
        private int inputParameter;

        public InputInstruction(int inputParameter, ParameterMode parameterMode) {
            this.parameterMode = parameterMode;
            this.inputParameter = inputParameter;
        }
        public void Execute(IntcodeProgram program) {
            // Due to the nature of the input operation, we cannot use the program.GetValueBasedOnParameterMode method.
            switch (parameterMode) {
                case ParameterMode.PositionMode:
                    program[program[program.InstructionPointer + 1]] = inputParameter;
                    break;
                case ParameterMode.ImmediateMode:
                    program[program.InstructionPointer + 1] = inputParameter;
                    break;
            }
            program.InstructionPointer += 2;
        }
    }
}

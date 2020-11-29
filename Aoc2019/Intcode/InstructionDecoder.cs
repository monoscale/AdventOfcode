using Aoc2019.Intcode.Instructions;

namespace Aoc2019.Intcode {
    public class InstructionDecoder {

        private IntcodeProgram program;
        public InstructionDecoder(IntcodeProgram program) {
            this.program = program;
        }

        public Instruction GiveConcreteInstruction(Opcode instruction) {
            Instruction concreteInstruction = null;
            int opCode = instruction.GetOpCode();
            switch (opCode) {
                case (int)Opcodes.Addition:
                    concreteInstruction = new AdditionInstruction(instruction.GetFirstParameterMode(), instruction.GetSecondParameterMode());
                    break;
                case (int)Opcodes.Multiplication:
                    concreteInstruction = new MultiplyInstruction(instruction.GetFirstParameterMode(), instruction.GetSecondParameterMode());
                    break;
                case (int)Opcodes.Input:
                    concreteInstruction = new InputInstruction(program.Inputs[program.CurrentInputPointer++], instruction.GetFirstParameterMode());
                    break;
                case (int)Opcodes.Output:
                    concreteInstruction = new OutputInstruction(instruction.GetFirstParameterMode());
                    break;
                case (int)Opcodes.JumpIfTrue:
                    concreteInstruction = new JumpIfTrueInstruction(instruction.GetFirstParameterMode(), instruction.GetSecondParameterMode());
                    break;
                case (int)Opcodes.JumpIfFalse:
                    concreteInstruction = new JumpIfFalseInstruction(instruction.GetFirstParameterMode(), instruction.GetSecondParameterMode());
                    break;
                case (int)Opcodes.LessThan:
                    concreteInstruction = new LessThanInstruction(instruction.GetFirstParameterMode(), instruction.GetSecondParameterMode(), instruction.GetThirdParameterMode());
                    break;
                case (int)Opcodes.Equals:
                    concreteInstruction = new EqualsInstruction(instruction.GetFirstParameterMode(), instruction.GetSecondParameterMode(), instruction.GetThirdParameterMode());
                    break;
            }
            return concreteInstruction;
        }
    }
}

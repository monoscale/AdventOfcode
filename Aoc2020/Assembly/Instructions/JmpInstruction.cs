namespace Aoc2020.Assembly.Instructions {
    public class JmpInstruction : Instruction {


        public JmpInstruction(int argument) : base(argument) { }

        public override void Execute(AssemblyProgram program) {
            program.InstructionPointer += Argument;
        }
    }
}

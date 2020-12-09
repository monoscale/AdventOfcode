namespace Aoc2020.Assembly.Instructions {
    public class NopInstruction : Instruction {


        public NopInstruction(int argument) : base(argument) { }

        public override void Execute(AssemblyProgram program) {
            program.InstructionPointer += 1;
        }
    }
}

namespace Aoc2020.Assembly.Instructions {
    public class AccInstruction : Instruction {


        public AccInstruction(int argument) : base(argument) { }

        public override void Execute(AssemblyProgram program) {
            program.Accumulator += Argument;
            program.InstructionPointer += 1;
        }
    }
}

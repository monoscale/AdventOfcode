
namespace Aoc2020.Assembly.Instructions {
    public abstract class Instruction {
        public int Argument { get; private set; }
        public Instruction(int argument) {
            Argument = argument;
        }
        public abstract void Execute(AssemblyProgram program);
    }
}

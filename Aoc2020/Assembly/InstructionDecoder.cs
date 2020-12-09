using Aoc2020.Assembly.Instructions;

namespace Aoc2020.Assembly {
    public class InstructionDecoder {


        public Instruction DecodeInstruction(string line) {
            string name = line.Substring(0, 3);
            int argument = int.Parse(line.Substring(4, line.Length - 4));

            switch (name) {
                case "acc":
                    return new AccInstruction(argument);
                case "jmp":
                    return new JmpInstruction(argument);
                default:
                    return new NopInstruction(argument);
            }
        }
    }
}

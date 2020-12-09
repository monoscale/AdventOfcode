using Aoc2020.Assembly.Instructions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2020.Assembly {
    public class AssemblyProgram {

        public int Accumulator { get; set; }
        public int InstructionPointer { get; set; }

        public int MaxInstructionPointer { get; private set; }

        private IList<Instruction> instructions;

        public AssemblyProgram(string[] lines) {
            instructions = new List<Instruction>();
            InstructionDecoder decoder = new InstructionDecoder();
            foreach (string line in lines) {
                instructions.Add(decoder.DecodeInstruction(line));
            }
            MaxInstructionPointer = instructions.Count;
        }

        public void ExecuteNextInstruction() {
            instructions[InstructionPointer].Execute(this);
        }

        public void ExecuteAll() {
            while (InstructionPointer < instructions.Count) {
                ExecuteNextInstruction();
            }
        }
    }
}

using System.Collections.Generic;

namespace Aoc2020.Assembly {

    /// <summary>
    /// A simple loop detecter that indicates yes when a single instruction is about to be executed twice.
    /// </summary>
    public class InfiniteLoopDetector {

        private AssemblyProgram program;
        public InfiniteLoopDetector(AssemblyProgram program) {
            this.program = program;
        }

        /// <summary>
        /// Returns true if an infinite loop occured; else false when the program terminated.
        /// </summary>
        /// <returns></returns>
        public bool Execute() {
            ISet<int> alreadyExecutedInstructions = new HashSet<int>();
            while (!alreadyExecutedInstructions.Contains(program.InstructionPointer)
                && program.InstructionPointer < program.MaxInstructionPointer) {
                int instructionPointerToUse = program.InstructionPointer;
                program.ExecuteNextInstruction();
                alreadyExecutedInstructions.Add(instructionPointerToUse);
            }

            return alreadyExecutedInstructions.Contains(program.InstructionPointer);

        }


    }
}

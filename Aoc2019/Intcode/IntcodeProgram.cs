using Aoc2019.Intcode.Instructions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Aoc2019.Intcode {
    /// <summary>
    /// Represents an intcode program.
    /// </summary>
    public class IntcodeProgram {

        /// <summary>
        /// Current memory of the program.
        /// </summary>
        private List<int> memory;

        /// <summary>
        /// The memory which was used to initialize the program.
        /// This is neccesary to reset the program.
        /// </summary>
        private ReadOnlyCollection<int> originalMemory;

        /// <summary>
        /// Gets or sets a value in memory.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int this[int position] {
            get { return memory[position]; }
            set { memory[position] = value; }
        }

        /// <summary>
        /// The address of the current instruction. 
        /// It increases by the number of values in the instruction after execution.
        /// </summary>
        private int instructionPointer;
        public int InstructionPointer {
            get { return instructionPointer; }
            set { instructionPointer = value; }
        }

        /// <summary>
        /// The index of the next input to read.
        /// </summary>
        private int currentInputPointer;
        public int CurrentInputPointer {
            get { return currentInputPointer; }
            set { currentInputPointer = value; }
        }
        private List<int> inputs;
        public List<int> Inputs {
            get { return inputs; }
            private set { inputs = value; }
        }
        private List<int> outputs;
        public List<int> Outputs {
            get { return outputs; }
            private set { outputs = value; }
        }

        private InstructionDecoder instructionDecoder;

        private void Initialize(ICollection<int> integers) {
            inputs = new List<int>();
            currentInputPointer = 0;
            outputs = new List<int>();
            instructionPointer = 0;
            memory = new List<int>();
            instructionDecoder = new InstructionDecoder(this);

            foreach (int integer in integers) {
                memory.Add(integer);
            }
            originalMemory = new ReadOnlyCollection<int>(new List<int>(memory));
        }

        public IntcodeProgram(string input) {
            ICollection<int> integers = new Collection<int>();
            foreach (string value in input.Split(',')) {
                int parseResult;
                if (int.TryParse(value, out parseResult)) {
                    integers.Add(parseResult);
                } else {
                    throw new ArgumentException($"Exception at position {memory.Count}: {value} is not an integer.");
                }
            }
            Initialize(integers);
        }

        public IntcodeProgram(ICollection<int> integers) {
            Initialize(integers);
        }


        /// <summary>
        /// Fully executes the intcode program.
        /// </summary>
        public void Execute() {

            Opcode instruction = new Opcode(memory[instructionPointer]);
            int opCode = instruction.GetOpCode();

            while (opCode != (int)Opcodes.Halt) {

                Instruction instructionToExecute = instructionDecoder.GiveConcreteInstruction(instruction);

                if (instructionToExecute == null) {
                    StringBuilder errorMessage = new StringBuilder();
                    errorMessage.AppendLine($"Instruction to execute is null.");
                    throw new InvalidOperationException(errorMessage.ToString());
                }

                instructionToExecute.Execute(this);

                if (instructionPointer < 0 || instructionPointer >= memory.Count) {
                    StringBuilder errorMessage = new StringBuilder();
                    errorMessage.AppendLine($"Instruction pointer points outside of memory range. [current={instructionPointer}, max={memory.Count}]");
                    errorMessage.AppendLine($"Last executed instruction: {instructionToExecute.GetType().Name}.");
                    throw new InvalidOperationException(errorMessage.ToString());
                }

                instruction = new Opcode(memory[instructionPointer]);

                opCode = instruction.GetOpCode();
            }
        }

        /// <summary>
        /// Resets the memory to its original state and sets the instruction pointer at address 0.
        /// </summary>
        public void Reset() {
            memory = new List<int>(originalMemory);
            InstructionPointer = 0;
            Inputs = new List<int>();
            currentInputPointer = 0;
            Outputs = new List<int>();
        }

        public int GetValueBasedOnParameterMode(int instructionPointerOffset, ParameterMode parameterMode) {
            return parameterMode switch {
                ParameterMode.PositionMode => memory[memory[InstructionPointer + instructionPointerOffset]],
                ParameterMode.ImmediateMode => memory[InstructionPointer + instructionPointerOffset],
                _ => memory[memory[InstructionPointer + instructionPointerOffset]],
            };
        }

        public IntcodeProgram Copy() {
            return new IntcodeProgram(originalMemory);
        }

        public void AddToInput(int value) {
            Inputs.Add(value);
        }
        public void AddToOutput(int value) {
            Outputs.Add(value);
        }
    }
}

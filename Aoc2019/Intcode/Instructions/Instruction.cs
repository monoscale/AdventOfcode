using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2019.Intcode.Instructions {
    public interface Instruction {
        void Execute(IntcodeProgram program);
    }
}

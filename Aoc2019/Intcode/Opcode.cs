using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aoc2019.Intcode {
    public class Opcode {


        private int[] digits;

        public Opcode(int code) {
            digits = code.ToString().Select(digit => int.Parse(digit.ToString())).ToArray();
        }

        public int GetOpCode() {
            int opCode = digits[digits.Length - 1];
            if (digits.Length > 1) {
                opCode += digits[digits.Length - 2] * 10;
            }
            return opCode;
        }

        public ParameterMode GetFirstParameterMode() {
            if(digits.Length > 2) {
                return (ParameterMode)digits[digits.Length - 3];
            }
            return ParameterMode.PositionMode;
        }

        public ParameterMode GetSecondParameterMode() {
            if (digits.Length > 3) {
                return (ParameterMode)digits[digits.Length - 4];
            }
            return ParameterMode.PositionMode;
        }

        public ParameterMode GetThirdParameterMode() {
            if (digits.Length > 4) {
                return (ParameterMode)digits[digits.Length - 5];
            }
            return ParameterMode.PositionMode;
        }
    }
}

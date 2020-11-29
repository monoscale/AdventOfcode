using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aoc2019.Passwords {
    public class Password {
        private int[] digits;

        public Password(int number) {
            digits = number.ToString().Select(d => int.Parse(d.ToString())).ToArray();
        }

        public bool IsValid() {

            int adjacentDigitsCount = GetAdjacentDigitsCount();
            int adjacentDigitsWhichArePartOfLargerGroup = GetAdjacentDigitsWhichArePartOfLargerGroup();
            bool adjacentValid = false;
            if (adjacentDigitsCount == 1 && adjacentDigitsWhichArePartOfLargerGroup == 0) {
                adjacentValid = true;
            } else if (adjacentDigitsCount > 1 && adjacentDigitsWhichArePartOfLargerGroup <= 1) {
                adjacentValid = true;
            } else {
                adjacentValid = false;
            }



            return HasSixDigits() &&
                adjacentValid &&
                DigitsNeverDecreaseFromLeftToRight();
        }


        private bool HasSixDigits() {
            return digits.Length == 6;
        }


        private int GetAdjacentDigitsCount() {
            int count = 0;
            int currentDigit = digits[0];

            for (int i = 0; i < 5; i++) {
                if (digits[i] == digits[i + 1]) {
                    count++;
                }
            }

            return count;
        }

        private int GetAdjacentDigitsWhichArePartOfLargerGroup() {
            int count = 0;

            int currentDigit = digits[0];

            for (int i = 1; i < 5; i++) {
                if(digits[i] == currentDigit) {
                    count++;
                    int j = i + 1;
                    while(j < 5 && digits[j] == currentDigit) {
                        j++;
                    }
                    i = j - 1;
                    currentDigit = digits[i];
                }  
            }

            return count;
        }

        private bool DigitsNeverDecreaseFromLeftToRight() {
            return digits[0] <= digits[1]
                && digits[1] <= digits[2]
                && digits[2] <= digits[3]
                && digits[3] <= digits[4]
                && digits[4] <= digits[5];
        }
    }
}

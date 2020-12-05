using System.Linq;

namespace Aoc2020.Airplane {
    public class BinaryBoardingStrategy {

        public Seat GetSeat(string input) {
            int row = GetRow(new string(input.Take(7).ToArray()));
            int column = GetColumn(new string(input.Skip(7).ToArray()));


            return new Seat(row, column);
        }

        private int GetColumn(string input) {
            return BinarySearch(input, 0, 7, 'L', 'R');
        }

        private int GetRow(string input) {
            return BinarySearch(input, 0, 127, 'F', 'B');
        }

        private int BinarySearch(string input, int bottom, int top, char bottomChar, char topChar) {
            int inputIndex = 0;
            while (bottom != top) {
                char currentChar = input[inputIndex];

                if (currentChar.Equals(bottomChar)) {
                    top = top - ((top - bottom) / 2) - 1;
                } else if (currentChar.Equals(topChar)) {
                    bottom = bottom + ((top + 1 - bottom) / 2);
                }
                inputIndex++;
            }

            return bottom; // is equal to top
        }


    }
}

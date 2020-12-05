using System;
using System.Linq;

namespace Aoc2020.Airplane {
    public class BinaryBoardingStrategy {

        public Seat GetSeat(string input) {
            int row = GetRow(new string(input.Take(7).ToArray()));
            int column = GetColumn(new string(input.Skip(7).ToArray()));


            return new Seat(row, column);
        }

        private int GetColumn(string input) {
            return InputToValue(input, 'L', 'R');
        }

        private int GetRow(string input) {
            return InputToValue(input, 'F', 'B');
        }

        private int InputToValue(string input, char bottomChar, char topChar) {
            input = input.Replace(bottomChar, '0').Replace(topChar, '1');
            return Convert.ToInt32(input, 2);
        }


    }
}

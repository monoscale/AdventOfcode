using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aoc2019.Days {
    public class Day1 : Day<int, int> {

        private List<int> moduleMasses = new List<int>();

        public override string Title => "The Tyranny of the Rocket Equation";

        protected override int SolvePartOne() {
            return moduleMasses.Sum(calculateFuel);
        }

        protected override int SolvePartTwo() {
            Queue<int> massesToHandle = new Queue<int>(moduleMasses);
            int sum = 0;
            while(massesToHandle.Count != 0) {
                int fuelRequired = calculateFuel(massesToHandle.Dequeue());
                if (fuelRequired > 0) {
                    sum += fuelRequired;
                    massesToHandle.Enqueue(fuelRequired);
                }
            }
            return sum;
        }

        private int calculateFuel(int mass) {
            return (mass / 3) - 2;
        }

        protected override void ReadInput(StreamReader input) {
            string line;
            while ((line = input.ReadLine()) != null) {
                moduleMasses.Add(int.Parse(line));
            }
        }
    }
}

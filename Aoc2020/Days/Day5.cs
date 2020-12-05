using Aoc2020.Airplane;
using Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc2020.Days {
    public class Day5 : Day<int, int> {
        public override string Title => "Binary Boarding";

        private List<string> boardingPasses;
        private BinaryBoardingStrategy strategy;

        protected override void ReadInput(StreamReader input) {
            strategy = new BinaryBoardingStrategy();
            boardingPasses = new List<string>();

            string line;
            while ((line = input.ReadLine()) != null) {
                boardingPasses.Add(line);
            }
        }

        protected override int SolvePartOne() {
            return boardingPasses.Select(bp => strategy.GetSeat(bp)).Max(bp => bp.SeatId);
        }

        protected override int SolvePartTwo() {
            List<Seat> orderedSeats = boardingPasses.Select(bp => strategy.GetSeat(bp)).OrderBy(bp => bp.SeatId).ToList();
            int nextSeat = orderedSeats[0].SeatId + 1;

            int i = 1;
            while (nextSeat == orderedSeats[i].SeatId) {
                nextSeat = orderedSeats[i].SeatId + 1;
                i++;
            }
            return nextSeat;
        }
    }
}

namespace Aoc2020.Airplane {
    public class Seat {

        public int SeatId => 8 * Row + Column;
        public int Row { get; set; }
        public int Column { get; set; }

        public Seat(int row, int column) {
            Row = row;
            Column = column;
        }
    }
}

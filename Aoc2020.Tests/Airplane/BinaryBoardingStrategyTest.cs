using Aoc2020.Airplane;
using NUnit.Framework;

namespace Aoc2020.Tests.Airplane {

    [TestFixture]
    public class BinaryBoardingStrategyTest {


        private BinaryBoardingStrategy strategy;

        [SetUp]
        public void SetUp() {
            strategy = new BinaryBoardingStrategy();
        }

        [Test]
        [TestCase("FBFBBFFRLR",44, 5, 357)]
        [TestCase("BFFFBBFRRR", 70, 7, 567)]
        [TestCase("FFFBBBFRRR", 14, 7, 119)]
        [TestCase("BBFFBBFRLL", 102, 4, 820)]
        public void TestBinaryBoardingStrategy(string input, int expectedRow, int expectedColumn, int expectedSeatID) {
            Seat seat = strategy.GetSeat(input);
            Assert.AreEqual(expectedRow, seat.Row);
            Assert.AreEqual(expectedColumn, seat.Column);
            Assert.AreEqual(expectedSeatID, seat.SeatId);

        }
    }
}

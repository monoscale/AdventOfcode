using Aoc2020.XMAS;
using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aoc2020.Days {
    public class Day9 : Day<long, long> {
        public override string Title => "Encoding Error";


        private XMASEncryptedMessage message;
        protected override void ReadInput(StreamReader input) {
            IList<long> numbers = new List<long>(input.ReadToEnd().Split('\n').ToList().Select(i => long.Parse(i)));
            message = new XMASEncryptedMessage(numbers, 25);
        }

        protected override long SolvePartOne() {
            XMASExploiter exploiter = new XMASExploiter(message);
            return exploiter.FindFirstNumberWhichIsNotSum();
        }

        protected override long SolvePartTwo() {
            message.Reset();
            XMASExploiter exploiter = new XMASExploiter(message);
            long invalidNumber = exploiter.FindFirstNumberWhichIsNotSum();
            message.Reset();
            return exploiter.FindWeakness(invalidNumber);
        }
    }
}

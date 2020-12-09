using System.Collections.Generic;

namespace Aoc2020.XMAS {
    public class XMASEncryptedMessage {


        public int PreambleLength { get; private set; }

        private IList<long> Numbers { get; set; }
        private int CurrentMessagePointer { get; set; }

        public XMASEncryptedMessage(IList<long> numbers, int preambleLength) {
            PreambleLength = preambleLength;
            Numbers = numbers;
        }

        public long GetNextNumber() {
            return Numbers[CurrentMessagePointer++];
        }

        public void Reset() {
            CurrentMessagePointer = 0;
        }

    }
}

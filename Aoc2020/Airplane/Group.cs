using System;
using System.Collections.Generic;
using System.Text;

namespace Aoc2020.Airplane {
    public class Group {

        public IDictionary<char, int> AnswersPerQuestion { get; private set; }

        public Group() {
            AnswersPerQuestion = new Dictionary<char, int>();
        }

        public int PersonCount { get; private set; }


        public void AddAnswersForPerson(string line) {
            PersonCount += 1;
            foreach (char c in line) {
                if (AnswersPerQuestion.ContainsKey(c)) {
                    AnswersPerQuestion[c] = AnswersPerQuestion[c] + 1;
                } else {
                    AnswersPerQuestion[c] = 1;
                }
            }
        }

    }
}

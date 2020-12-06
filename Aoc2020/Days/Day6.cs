using Aoc2020.Airplane;
using Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc2020.Days {
    public class Day6 : Day<int, int> {
        public override string Title => "Custom Customs";

        private List<Group> groups;

        protected override void ReadInput(StreamReader input) {
            groups = new List<Group>();
            Group currentGroup = new Group();
            string line;
            while ((line = input.ReadLine()) != null) {
                if (string.IsNullOrWhiteSpace(line)) {
                    groups.Add(currentGroup);
                    currentGroup = new Group();
                } else {
                    currentGroup.AddAnswersForPerson(line);
                }
            }
            groups.Add(currentGroup);
        }

        protected override int SolvePartOne() {
            IQuestionAnswerStrategy answerStrategy = new QuestionsWhichAnyoneAnsweredStrategy();
            return groups.Select(group => answerStrategy.GetAnswerCount(group)).Sum();
        }

        protected override int SolvePartTwo() {
            IQuestionAnswerStrategy answerStrategy = new QuestionsWhichEveryoneAnsweredStrategy();
            return groups.Select(group => answerStrategy.GetAnswerCount(group)).Sum();
        }
    }
}

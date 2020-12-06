using Aoc2020.Airplane;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace Aoc2020.Tests.Airplane {

    [TestFixture]
    class IQuestionAnswerStrategyTest {

        private IList<Tuple<Group, int, int>> groupAndExpectedAnswers;

        [SetUp]
        public void SetUp() {
            groupAndExpectedAnswers = new List<Tuple<Group, int, int>>();
            Group group = new Group();
            group.AddAnswersForPerson("abc");
            groupAndExpectedAnswers.Add(new Tuple<Group, int, int>(group, 3, 3));

            group = new Group();
            group.AddAnswersForPerson("a");
            group.AddAnswersForPerson("b");
            group.AddAnswersForPerson("c");
            groupAndExpectedAnswers.Add(new Tuple<Group, int, int>(group, 3, 0));

            group = new Group();
            group.AddAnswersForPerson("ab");
            group.AddAnswersForPerson("ac");
            groupAndExpectedAnswers.Add(new Tuple<Group, int, int>(group, 3, 1));

            group = new Group();
            group.AddAnswersForPerson("a");
            group.AddAnswersForPerson("a");
            group.AddAnswersForPerson("a");
            group.AddAnswersForPerson("a");
            groupAndExpectedAnswers.Add(new Tuple<Group, int, int>(group, 1, 1));


            group = new Group();
            group.AddAnswersForPerson("b");
            groupAndExpectedAnswers.Add(new Tuple<Group, int, int>(group, 1, 1));
        }

        [Test]
        public void AnyoneAnsweredTest() {
            IQuestionAnswerStrategy strategy = new QuestionsWhichAnyoneAnsweredStrategy();
            foreach (Tuple<Group, int, int> tuple in groupAndExpectedAnswers) {
                Assert.AreEqual(tuple.Item2, strategy.GetAnswerCount(tuple.Item1));
            }
        }

        [Test]
        public void EveryoneAnsweredTest() {
            IQuestionAnswerStrategy strategy = new QuestionsWhichEveryoneAnsweredStrategy();
            foreach (Tuple<Group, int, int> tuple in groupAndExpectedAnswers) {
                Assert.AreEqual(tuple.Item3, strategy.GetAnswerCount(tuple.Item1));
            }
        }
    }
}

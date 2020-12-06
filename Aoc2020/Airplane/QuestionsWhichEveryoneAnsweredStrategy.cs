using System.Linq;

namespace Aoc2020.Airplane {
    public class QuestionsWhichEveryoneAnsweredStrategy : IQuestionAnswerStrategy {
        public int GetAnswerCount(Group group) {
            return group.AnswersPerQuestion.Values.Where(f => group.PersonCount == f).Count();
        }
    }
}

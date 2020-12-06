namespace Aoc2020.Airplane {
    public class QuestionsWhichAnyoneAnsweredStrategy : IQuestionAnswerStrategy {
        public int GetAnswerCount(Group group) {
            return group.AnswersPerQuestion.Keys.Count;
        }
    }
}

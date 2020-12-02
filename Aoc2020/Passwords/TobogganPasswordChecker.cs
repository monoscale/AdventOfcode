namespace Aoc2020.Passwords {
    public class TobogganPasswordChecker : IValidPasswordChecker {
        public bool IsValid(Password password) {
            bool charIsAtFirstPos = password.PlainText[password.FirstNumber - 1] == password.Requirement;
            bool charIsAtSecondPos = password.PlainText[password.SecondNumber - 1] == password.Requirement;
            return charIsAtFirstPos ^ charIsAtSecondPos;
        }
    }
}

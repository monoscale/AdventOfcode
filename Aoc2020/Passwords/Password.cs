namespace Aoc2020.Passwords {
    public class Password {
        public char Requirement { get; private set; }
        private int min, max;
        public string PlainText { get; private set; }
        public int FirstNumber { get; private set; }
        public int SecondNumber { get; private set; }
        public Password(string text, char requirement, int min, int max) {
            PlainText = text;
            Requirement = requirement;
            FirstNumber = min;
            SecondNumber = max;
        }
    }
}

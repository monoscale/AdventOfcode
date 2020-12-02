namespace Aoc2020.Passwords {
    public interface IValidPasswordChecker {
        bool IsValid(Password password);
    }
}

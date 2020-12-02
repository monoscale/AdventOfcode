using System.Linq;

namespace Aoc2020.Passwords {
    public class SledRentalPasswordChecker : IValidPasswordChecker {
        public bool IsValid(Password password) {
            int frequency = password.PlainText.Where(c => c == password.Requirement).Count();
            return frequency >= password.FirstNumber && frequency <= password.SecondNumber;
        }
    }
}

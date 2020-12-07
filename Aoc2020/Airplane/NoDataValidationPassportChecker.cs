namespace Aoc2020.Airplane {
    public class NoDataValidationPassportChecker : IValidPassportChecker {
        public bool IsValid(Passport passport) {
            bool allFieldsExceptCIDAreNotNull =
                passport.BirthYear != null &&
                passport.ExpirationYear != null &&
                passport.EyeColor != null &&
                passport.HairColor != null &&
                passport.Height != null &&
                passport.IssueYear != null &&
                passport.PassportID != null;

            return allFieldsExceptCIDAreNotNull;

        }
    }
}

namespace Aoc2020.Passports {
    public class Passport {
        public string BirthYear { get; private set; }
        public string IssueYear { get; private set; }
        public string ExpirationYear { get; private set; }
        public string Height { get; private set; }
        public string HairColor { get; private set; }
        public string EyeColor { get; private set; }
        public string PassportID { get; private set; }
        public string CountryID { get; private set; }

        public void SetProperty(string key, string value) {
            switch (key) {
                case "byr": BirthYear = value; break;
                case "iyr": IssueYear = value; break;
                case "eyr": ExpirationYear = value; break;
                case "hgt": Height = value; break;
                case "hcl": HairColor = value; break;
                case "ecl": EyeColor = value; break;
                case "pid": PassportID = value; break;
                case "cid": CountryID = value; break;
            }
        }
    }
}

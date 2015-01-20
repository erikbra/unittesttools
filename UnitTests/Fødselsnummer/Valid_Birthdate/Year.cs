using UnitTestTools;
using Xunit;

namespace UnitTests.Valid_Birthdate
{
    public class Year
    {
        [Fact]
        public void Is_Between_1900_and_1999_000_499()
        {
            var birthDate = GetFødselsnummer("101220", "000").BirthDate;
            Assert.Equal(1920, birthDate.Year);

            birthDate = GetFødselsnummer("101220", "315").BirthDate;
            Assert.Equal(1920, birthDate.Year);

            birthDate = GetFødselsnummer("101220", "499").BirthDate;
            Assert.Equal(1920, birthDate.Year);
        }

        [Fact]
        public void Is_Before_1899_500_749()
        {
            var birthYear = GetFødselsnummer("101220", "500").BirthDate.Year;
            Assert.Equal(1820, birthYear);
        }

        private static Fødselsnummer GetFødselsnummer(string birthdate, string personnummer)
        {
            return new Fødselsnummer(string.Format("{0}{1}00", birthdate, personnummer));
        }
    }
}

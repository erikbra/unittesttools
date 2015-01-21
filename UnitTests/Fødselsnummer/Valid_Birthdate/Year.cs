using System;
using System.Diagnostics;
using System.Globalization;
using UnitTestTools;
using Xunit;

namespace UnitTests.Valid_Birthdate
{
    public class Year
    {
        [Fact]
        public void Is_Between_1900_and_1999_000_499()
        {
            var birthDate = GetFødselsnummer(new DateTime(1920, 10, 12)).BirthDate;
            Assert.Equal(1920, birthDate.Year);

            birthDate = GetFødselsnummer(new DateTime(1920, 10, 12)).BirthDate;
            Assert.Equal(1920, birthDate.Year);

            birthDate = GetFødselsnummer(new DateTime(1920, 10, 12)).BirthDate;
            Assert.Equal(1920, birthDate.Year);
        }

        [Fact]
        public void Is_Before_1899_500_749()
        {
            var fødselsnummer = GetFødselsnummer(new DateTime(1854, 10, 12));
            var birthYear = fødselsnummer.BirthDate.Year;
            Debug.WriteLine(fødselsnummer);

            Assert.Equal(1854, birthYear);
        }

        [Fact]
        public void Is_After_2000_500_999()
        {
            var birthYear = GetFødselsnummer(new DateTime(2020, 10, 12)).BirthDate.Year;
            Assert.Equal(2020, birthYear);
        }

        [Fact]
        public void Is_Between_1940_1999_999()
        {
            var birthYear = GetFødselsnummer(new DateTime(1940, 10, 12)).BirthDate.Year;
            Assert.Equal(1940, birthYear);
        }

        private static Fødselsnummer GetFødselsnummer(DateTime birthDate)
        {
            return new FødselsnummerGenerator().GenerateRandom(birthDate);
        }
    }
}

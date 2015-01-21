using System;
using UnitTestTools;
using Xunit;

namespace UnitTests.Valid_Birthdate
{
    public class Date
    {
        [Fact]
        public void Is_Between_1_and_31()
        {
            var birthDate = GetFødselsnummer().BirthDate;
            Assert.InRange(birthDate.Day, 1, 31);
        }

        private static Fødselsnummer GetFødselsnummer()
        {
            return new FødselsnummerGenerator().GenerateRandom(new DateTime(1901, 01, 31));
        }
    }
}

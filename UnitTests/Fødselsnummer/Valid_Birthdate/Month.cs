using System;
using UnitTestTools;
using Xunit;

namespace UnitTests.Valid_Birthdate
{
    public class Month
    {
        [Fact]
        public void Is_Between_1_and_12()
        {
            var birthDate = GetFødselsnummer().BirthDate;
            Assert.Equal(12, birthDate.Month);
        }

        private static Fødselsnummer GetFødselsnummer()
        {
            return new FødselsnummerGenerator().GenerateRandom(new DateTime(2014, 12, 31));
        }
    }
}

using System;
using UnitTestTools;
using Xunit;


namespace UnitTests.Valid_Individnummer
{
    public class Between_1900_1940
    {
        [Fact]
        public void Is_Between_000_and_499()
        {
            var gen = new FødselsnummerGenerator();
            var individnummer = gen.GenerateRandom(new DateTime(1901, 12, 10)).Individnummer;
            Assert.InRange(individnummer, 000, 499);
        }
    }
}

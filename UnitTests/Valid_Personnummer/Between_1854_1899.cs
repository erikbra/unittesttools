using System;
using UnitTestTools;
using Xunit;


namespace UnitTests.Valid_Individnummer
{
    public class Between_1854_1899
    {
        [Fact]
        public void Is_Between_500_749()
        {
            var gen = new FødselsnummerGenerator();
            var individnummer = gen.GenerateRandom(new DateTime(1854,10,12)).Individnummer;
            Assert.InRange(individnummer, 500, 749);
        }
    }
}

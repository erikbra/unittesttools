using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestTools;
using Xunit;


namespace UnitTests.Valid_Personnummer
{
    public class After_1900
    {
        [Fact]
        public void Is_Between_000_and_499()
        {
            var gen = new FødselsnummerGenerator();
            var personnummer = gen.GenerateRandom(new DateTime(1901, 12, 10)).Personnummer;
            Assert.InRange(personnummer, 000, 499);
        }
    }
}

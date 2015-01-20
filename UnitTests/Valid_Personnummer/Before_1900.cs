using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestTools;
using Xunit;


namespace UnitTests.Valid_Personnummer
{
    public class Before_1900
    {
        [Fact]
        public void Is_Between_500_749()
        {
            var gen = new FødselsnummerGenerator();
            var personnummer = gen.GenerateRandom().Personnummer;
            Assert.InRange(personnummer, 500, 749);
        }
    }
}

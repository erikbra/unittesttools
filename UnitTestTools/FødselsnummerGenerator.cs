using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestTools
{
    public class FødselsnummerGenerator
    {
        public Fødselsnummer GenerateRandom(DateTime date)
        {
            return new Fødselsnummer(date.ToString("ddMMyy") + "000000");
        }

        public Fødselsnummer GenerateRandom()
        {
            //return new Fødselsnummer("12125650001");
            return GenerateRandom(new DateTime(1904, 12, 16));
        }


    }
}

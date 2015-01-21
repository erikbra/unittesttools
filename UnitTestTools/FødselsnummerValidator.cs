using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTools
{
    public class FødselsnummerValidator
    {
        private readonly KontrollsifferGenerator _kontrollsifferGenerator;

        public FødselsnummerValidator()
        {
            _kontrollsifferGenerator = new KontrollsifferGenerator();
        }

        public void Validate(string fødselsnummer)
        {
            var fnr = fødselsnummer.Substring(0, 9);
            var kontrollSiffer = fødselsnummer.Substring(9, 2);
            if (!kontrollSiffer.Equals(_kontrollsifferGenerator.GenerateKontrollsiffer(fnr)))
            {
                throw new InvalidModuloException("Invalid modulo 11");
            }
        }
    }
}

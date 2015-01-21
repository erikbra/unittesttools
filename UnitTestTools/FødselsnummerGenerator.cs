using System;

namespace UnitTestTools
{
    public class FødselsnummerGenerator
    {
        public Fødselsnummer GenerateRandom(DateTime date)
        {
            var range = GetRange(date.Year);
            var generator = new KontrollsifferGenerator();

            do
            {
                var pnr = GetRandom(range);
                var fnr = date.ToString("ddMMyy") + pnr.ToString("D3");

                string value;
                try
                {
                    value = fnr + generator.GenerateKontrollsiffer(fnr);
                }
                    // Some moduli end up as 10, but those are not used.
                catch (InvalidModuloException)
                {
                    continue;
                }

                return new Fødselsnummer(value);
            } while (true);
        }


        public Fødselsnummer GenerateRandom()
        {
            //return new Fødselsnummer("12125650001");
            return GenerateRandom(new DateTime(1904, 12, 16));
        }
        private int GetRandom(Range range)
        {
            return GetRandom(range.Min, range.Max);
        }

        private static int GetRandom(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }

        private Range GetRange(int birthYear)
        {
            if (birthYear.Between(1854, 1899))
            {
                return new Range(500,749);
            }
            if (birthYear.Between(2000, 2039))
            {
                return new Range(500,999);
            }
            if (birthYear.Between(1940, 1999))
            {
                return OneOf(new Range(000, 499), new Range(900, 999));
            }
            if (birthYear.Between(1900, 1999))
            {
                return new Range(000, 499);
            }

            throw new ArgumentOutOfRangeException("birthYear", "Unknown birthyear: " + birthYear);
        }

        private Range OneOf(Range range, Range range1)
        {
            return (new Random().Next() % 2 == 0) ? range : range1;
        }
    }
}

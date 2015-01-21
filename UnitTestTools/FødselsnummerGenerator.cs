using System;

namespace UnitTestTools
{
    public class FødselsnummerGenerator
    {
        private static readonly Random _random = new Random();

        public Fødselsnummer GenerateRandom(DateTime birthDate)
        {
            var range = GetIndividSifferRange(birthDate.Year);
            var generator = new KontrollsifferGenerator();

            do
            {
                var pnr = GetRandom(range);
                var fnr = birthDate.ToString("ddMMyy") + pnr.ToString("D3");

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
            return GenerateRandom(GetRandomBirthDate());
        }

        private static DateTime GetRandomBirthDate()
        {
            const int minYear = 1854;
            const int maxYear = 2039;

            var randomYear = _random.Next(minYear, maxYear);
            var randomDay = _random.Next(0, 365);

            var date = new DateTime(randomYear, 01, 01);
            date = date.AddDays(randomDay);

            return date;
        }

        private int GetRandom(Range range)
        {
            return GetRandom(range.Min, range.Max);
        }

        private static int GetRandom(int min, int max)
        {
            return _random.Next(min, max);
        }

        private Range GetIndividSifferRange(int birthYear)
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

        private static Range OneOf(Range range, Range range1)
        {
            return (_random.Next() % 2 == 0) ? range : range1;
        }
    }
}

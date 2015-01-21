using System;

namespace UnitTestTools
{
    public class Fødselsnummer
    {
        private readonly string _value;

        public Fødselsnummer(string s)
        {
            var validator = new FødselsnummerValidator();
            validator.Validate(s);
            _value = s;
        }

   
        public DateTime BirthDate
        {
            get
            {
                var date = GetDate();
                var month = GetMonth();
                int year = GetYear();
                int century = GetCentury();

                return new DateTime(century + year, month, date);
            }
        }

        private int GetYear()
        {
            return int.Parse(_value.Substring(4, 2));
        }

        private int GetCentury()
        {
            var pnr = Individnummer;
            var year = GetYear();
            if (pnr.Between(000, 499))
            {
                return 1900;
            }

            if (pnr.Between(500, 749))
            {
                if (year.Between(54, 99))
                {
                    return 1800;
                }
            }
            if (pnr.Between(500, 999))
            {
                if (year.Between(00, 39))
                {
                    return 2000;
                }
            }
            if (pnr.Between(900, 999))
            {
                if (year.Between(40, 99))
                {
                    return 1900;
                }
            }

            throw new Exception("Invalid fødselsnummer: " + _value);
        }

        private int GetMonth()
        {
            return int.Parse(_value.Substring(2, 2));
        }

        private int GetDate()
        {
            return int.Parse(_value.Substring(0, 2));
        }

        public int Individnummer
        {
            get { return int.Parse(_value.Substring(6, 3)); }
        }

        public string Kontrollsiffer
        {
            get { return _value.Substring(9, 2); }
        }

        public override string ToString()
        {
            return _value;
        }
    }

    internal static class IntExtensions
    {
        internal static bool Between(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }
}
using System;
using System.Globalization;

namespace UnitTestTools
{
    public class Fødselsnummer
    {
        private readonly string _value;

        public Fødselsnummer(string s)
        {
            _value = s;
        }

        public DateTime BirthDate
        {
            get
            {
                var date = GetDate();
                var month = GetMonth();
                int year = GetYear();

                return new DateTime(year, month, date);
            }
        }

        private int GetYear()
        {
            int century = GetCentury();
            var year = int.Parse(_value.Substring(4, 2));
            return century + year;
        }

        private int GetCentury()
        {
            return 1900;
        }

        private int GetMonth()
        {
            return int.Parse(_value.Substring(2, 2));
        }

        private int GetDate()
        {
            return int.Parse(_value.Substring(0, 2));
        }

        public int Personnummer
        {
            get { return int.Parse(_value.Substring(6, 3)); }
        }
    }
}
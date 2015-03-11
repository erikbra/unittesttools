using System;

namespace UnitTestTools
{
    class Modulo11
    {
        private readonly int[] _weights;
        private readonly char[] _chars;

        public Modulo11(string text, int[] weights)
        {
            var chars = text.ToCharArray();
            ValidateParameters(chars, weights);

            _chars = chars;
            _weights = weights;
        }

        public int Calculate()
        {
            var sum = 0;
            for (var i = 0; i < _chars.Length; i++)
            {
                int val = _chars[i] - '0';
                sum += (val * _weights[i]);
            }

            var mod = sum % 11;
            var res = 11 - mod;
            if (res == 11) res = 0;

            if (res == 10)
            {
                throw new InvalidModulo11("Got 10 calculating modulo 11. Not used.");
            }

            return res;
        }

        public void Validate(int expected)
        {
            var calculated = Calculate();
            if (calculated != expected)
            {
                throw new InvalidModulo11(expected, calculated, _chars, _weights);
            }
        }

        private void ValidateParameters(char[] chars, int[] weights)
        {
            if (chars.Length != weights.Length)
            {
                var text = new string(chars);
                var weightsList = "[" + string.Join(",", weights) + "]";
                throw new ArgumentException(
                    string.Format(
                        "Length of text ({0} => {1}) must equal number of weights ({2} => {3})",
                        text,
                        chars.Length,
                        weightsList,
                        weights.Length
                    ));
            }
        }
    }
}

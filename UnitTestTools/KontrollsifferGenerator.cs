using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTools
{
    public class KontrollsifferGenerator
    {
        private int[] _weights1 = new[] { 3, 7, 6, 1, 8, 9, 4, 5, 2 };
        private int[] _weights2 = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

        public KontrollsifferGenerator()
        {
        }

        public string GenerateKontrollsiffer(string fnr)
        {
            var mod1 = CalculateMod11(fnr, _weights1);
            var mod2 = CalculateMod11(fnr + mod1, _weights2);

            return "" + mod1 + mod2;
        }

        private int CalculateMod11(string text, int[] weights)
        {
            char[] chars = text.ToCharArray();

            if (chars.Length != weights.Length)
            {
                throw new ArgumentException("Length of text must equal number of weights");
            }

            var sum = 0;

            for (var i = 0; i < chars.Length; i++)
            {
                int val = chars[i] - '0';
                sum += (val * weights[i]);
            }

            var mod = sum % 11;
            var res = 11 - mod;
            if (res == 11) res = 0;

            return res;
        }
    }
}

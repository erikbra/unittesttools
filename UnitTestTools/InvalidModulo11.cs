using System;

namespace UnitTestTools
{
    public class InvalidModulo11 : Exception
    {
        public InvalidModulo11(int expected, int actual, char[] text, int[] weights)
            : base(GetMessage(expected, actual, text, weights))
        {
        }

        public InvalidModulo11(string message) : base(message)
        {
        }

        private static string GetMessage(int expected, int actual, char[] text, int[] weights)
        {
            return "Invalid modulo 11. Expected: " + expected + ", calculated: " + actual +
                "Text: " + text + "weights: " + Format(weights);

        }

        private static string Format(int[] weights)
        {
            return "[" + string.Join(",", weights) + "]";
        }
    }
}
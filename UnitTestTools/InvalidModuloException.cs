using System;

namespace UnitTestTools
{
    public class InvalidModuloException : Exception
    {
        public InvalidModuloException(string message)
            : base(message)
        {
        }
    }
}
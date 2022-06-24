using System;

namespace Planimetry.Exceptions
{
    public class ShapeParameterException : ArgumentException
    {
        public ShapeParameterException(string message, string paramName) : base(message, paramName) { }

        public static void ThrowIfNegative(double value, string paramName)
        {
            if (value < 0)
            {
                throw new ShapeParameterException($"{paramName} can not be negative", paramName);
            }
        }
    }
}
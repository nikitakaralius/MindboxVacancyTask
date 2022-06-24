using System;

namespace Planimetry.Exceptions
{
    public class TriangleInequalityException : Exception
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

        public TriangleInequalityException(double a, double b, double c) => (_a, _b, _c) = (a, b, c);

        public override string Message =>
            $"Triangle with sides {FormatSides()} can not exist due to Triangle Inequality";

        public override string HelpLink => "https://en.wikipedia.org/wiki/Triangle_inequality";

        private string FormatSides() => $"[{_a}, {_b}, {_c}]";
    }
}
using Planimetry.Core;
using Planimetry.Exceptions;
using static System.Math;

namespace Planimetry.Shapes
{
    public class Triangle : IShape
    {
        public Triangle(double a, double b, double c)
        {
            ShapeParameterException.ThrowIfNegative(a, nameof(a));
            ShapeParameterException.ThrowIfNegative(c, nameof(b));
            ShapeParameterException.ThrowIfNegative(c, nameof(c));
            (A, B, C) = (a, b, c);
        }

        public double A { get; }

        public double B { get; }

        public double C { get; }

        public double Area => AreaByHeronsFormula();

        private double AreaByHeronsFormula()
        {
            double semiPerimeter = (A + B + C) / 2;
            return Sqrt(semiPerimeter * (semiPerimeter - A) * (semiPerimeter - B) * (semiPerimeter - C));
        }
    }
}
using System;
using System.Collections.Generic;
using Planimetry.Core;
using Planimetry.Exceptions;
using static System.Math;
using static System.Array;

namespace Planimetry.Shapes
{
    public class Triangle : IShape
    {
        public Triangle(double a, double b, double c)
        {
            ShapeParameterException.ThrowIfNegative(a, nameof(a));
            ShapeParameterException.ThrowIfNegative(b, nameof(b));
            ShapeParameterException.ThrowIfNegative(c, nameof(c));
            if (TriangleExists(a, b, c) == false)
            {
                throw new TriangleInequalityException(a, b, c);
            }
            (A, B, C) = (a, b, c);
        }

        public double A { get; }

        public double B { get; }

        public double C { get; }

        public double Area => AreaByHeronsFormula();

        public bool IsRight
        {
            get
            {
                bool InversePythagoreanTheorem()
                {
                    double[] sides = SidesInAscendingOrder();
                    return Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1E-5;
                }
                return InversePythagoreanTheorem();
            }
        }

        public static Triangle From(IReadOnlyList<double> triplet)
        {
            if (triplet.Count != 3)
            {
                throw new ArgumentException("Triplet must contain exactly 3 elements", nameof(triplet));
            }
            return new Triangle(triplet[0], triplet[1], triplet[2]);
        }

        public double[] SidesInAscendingOrder() => SidesInAscendingOrder(A, B, C);

        private static double[] SidesInAscendingOrder(double a, double b, double c)
        {
            double[] sides = { a, b, c };
            Sort(sides);
            return sides;
        }

        private static bool TriangleExists(double a, double b, double c)
        {
            double[] sides = SidesInAscendingOrder(a, b, c);
            return sides[2] < sides[0] + sides[1];
        }

        private double AreaByHeronsFormula()
        {
            double semiPerimeter = (A + B + C) / 2;
            return Sqrt(semiPerimeter * (semiPerimeter - A) * (semiPerimeter - B) * (semiPerimeter - C));
        }
    }
}
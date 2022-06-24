using Planimetry.Core;
using Planimetry.Exceptions;
using static System.Math;

namespace Planimetry.Shapes
{
    public class Circle : IShape
    {
        public Circle(double radius)
        {
            ShapeParameterException.ThrowIfNegative(radius, nameof(radius));
            Radius = radius;
        }

        public double Radius { get; }

        public double Area => PI * Radius * Radius;
    }
}
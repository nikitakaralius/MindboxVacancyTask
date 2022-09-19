using System;
using Planimetry.Core;
using Planimetry.Exceptions;
using static System.Math;

namespace Planimetry.Shapes
{
    public class Circle : IShape, IEquatable<Circle>
    {
        private Circle(double radius) => Radius = radius;

        public static Circle Create(double radius)
        {
            ShapeParameterException.ThrowIfNegative(radius, nameof(radius));
            return new Circle(radius);
        }

        public double Radius { get; }

        public double Area => PI * Radius * Radius;

        public bool Equals(Circle? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Radius.Equals(other.Radius);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Circle) obj);
        }

        public override int GetHashCode()
        {
            return Radius.GetHashCode();
        }
    }
}

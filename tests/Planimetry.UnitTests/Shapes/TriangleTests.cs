namespace Planimetry.UnitTests.Shapes;

[TestFixture]
public class TriangleTests
{
    #region Tests

    [Test]
    [TestCaseSource(nameof(NaturalPythagoreanTriplets))]
    [TestCaseSource(nameof(DecimalPythagoreanTriplets))]
    public void DeterminesIfTriangleIsRight(double[] triplet) =>
        Triangle.Create(triplet.Shuffled()).IsRight.Should().Be(true);

    [Test]
    [TestCaseSource(nameof(NonPythagoreanTriplets))]
    public void DeterminesIfTriangleIsNotRight(double[] triplet) =>
        Triangle.Create(triplet).IsRight.Should().BeFalse();

    [Test]
    [TestCaseSource(nameof(NaturalPythagoreanTriplets))]
    [TestCaseSource(nameof(DecimalPythagoreanTriplets))]
    public void CalculatesAreaBySidesOnRightTriangles(double[] triplet)
    {
        var triangle = Triangle.Create(triplet);
        var sides = triangle.SidesInAscendingOrder();
        var areaOfRightTriangle = sides[0] * sides[1] / 2.0;
        triangle.Area.Should().BeApproximately(areaOfRightTriangle, 1E-9);
    }

    [Test]
    [TestCaseSource(nameof(TripletsWithNegativeSides))]
    public void ThrowsExceptionIfAnySideIsNegative(double[] triplet)
    {
        Action constructorInitialization = () => Triangle.Create(triplet[0], triplet[1], triplet[2]);
        Action fabricMethodInitialization = () => Triangle.Create(triplet);
        constructorInitialization.Should().Throw<ShapeParameterException>();
        fabricMethodInitialization.Should().Throw<ShapeParameterException>();
    }

    [Test]
    [TestCaseSource(nameof(TripletsThatDoNotFormTriangle))]
    public void ThrowsExceptionIfTriangleDoesNotExist(double[] triplet)
    {
        Action initialization = () => Triangle.Create(triplet);
        initialization.Should().Throw<TriangleInequalityException>();
    }

    #endregion

    #region Sources

    public static readonly double[][] NaturalPythagoreanTriplets =
    {
        new double[] {3, 4, 5},
        new double[] {5, 12, 13},
        new double[] {20, 21, 29},
        new double[] {28, 45, 53},
        new double[] {8, 15, 17},
        new double[] {36, 77, 85},
        new double[] {44, 117, 125},
        new double[] {12, 35, 37},
        new double[] {52, 165, 173}
    };

    public static readonly double[][] DecimalPythagoreanTriplets =
    {
        new[] {3.14, 5.23, 4.1825},
        new[] {2.8, 4.5, 5.3},
        new[] {0.8, 1.5, 1.7},
        new[] {3.6, 7.7, 8.5},
        new[] {0.12, 0.35, 0.37}
    };

    public static readonly double[][] NonPythagoreanTriplets =
    {
        new[] {5.0, 8.0, 5.0},
        new[] {12.4, 14.235, 17.93},
        new[] {100.25, 143.98733, 125.454141}
    };

    public static readonly double[][] TripletsWithNegativeSides =
    {
        new[] {-5.0, 8.0, 5.0},
        new[] {12.4, -14.235, 17.93},
        new[] {100.25, 143.98733, -125.454141},
        new[] {-3.14, -5.23, 4.1825},
        new[] {-2.8, -4.5, -5.3},
        new[] {-0.8, 1.5, -1.7},
    };

    public static readonly double[][] TripletsThatDoNotFormTriangle =
    {
        new[] {5.0, 8.0, 105.0},
        new[] {12.4, 314.235, 17.93},
        new[] {1100.25, 143.98733, 125.454141}
    };

    #endregion
}

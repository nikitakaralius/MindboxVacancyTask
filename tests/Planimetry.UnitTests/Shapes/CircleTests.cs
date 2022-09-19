namespace Planimetry.UnitTests.Shapes;

[TestFixture]
public class CircleTests
{
    [Test]
    public void CalculatesAreaByRadius()
    {
        const double radius = 123.456;
        var circle = Circle.Create(radius);
        circle.Area.Should().Be(PI * radius * radius);
    }

    [Test]
    public void ThrowsExceptionIfRadiusIsNegative()
    {
        Action initialization = () => Circle.Create(-1.12);
        initialization.Should().Throw<ShapeParameterException>();
    }

    [Test]
    public void CirclesWithSameRadiusShouldBeEqual()
    {
        const double radius = 12.345;
        var circle1 = Circle.Create(radius);
        var circle2 = Circle.Create(radius);
        circle1.Equals(circle2).Should().BeTrue();
    }
}

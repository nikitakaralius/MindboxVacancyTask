namespace Planimetry.UnitTests.Shapes;

[TestFixture]
public class CircleTests
{
    [Test]
    public void CalculatesAreaByRadius()
    {
        double radius = 123.456;
        Circle circle = Circle.Create(radius);
        circle.Area.Should().Be(PI * radius * radius);
    }

    [Test]
    public void ThrowsExceptionIfRadiusIsNegative()
    {
        Action initialization = () => Circle.Create(-1.12);
        initialization.Should().Throw<ShapeParameterException>();
    }
}

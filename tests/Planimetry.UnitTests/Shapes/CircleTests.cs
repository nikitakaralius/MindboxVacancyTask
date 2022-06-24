namespace Planimetry.UnitTests.Shapes;

[TestFixture]
public class CircleTests
{
    [Test]
    public void CalculatesAreaByRadius()
    {
        double radius = 123.456;
        Circle circle = new(radius);
        circle.Area.Should().Be(PI * radius * radius);
    }

    [Test]
    public void ThrowsExceptionIfRadiusIsNegative()
    {
        Action initialization = () => new Circle(-1.12);
        initialization.Should().Throw<ShapeParameterException>();
    }
}
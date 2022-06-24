namespace Planimetry.UnitTests.Shapes;

[TestFixture]
public class TriangleTests
{
    public void DeterminesIfTriangleIsRight(double[] triplet)
    {
        var triangle = Triangle.From(triplet.Shuffled());
        triangle.Right.Should().Be(true);
    }
}
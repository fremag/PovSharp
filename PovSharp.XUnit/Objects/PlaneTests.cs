using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class PlaneTests
    {
        [Fact]
        public void TestBasic()
        {
            var Plane = new Plane();
            Check.That(Plane.Type).IsEqualTo("plane");
            Check.That(Plane.Distance).IsEqualTo(0);
            Check.That(Plane.Normal).IsEqualTo(new PovVector(0, 1, 0));
        }
        [Fact]
        public void TestConstructor()
        {
            var plane = new Plane("myPlane") { Distance = 1.234, Normal = new PovVector(1, 2, 3) };
            Check.That(plane.Type).IsEqualTo("plane");
            Check.That(plane.Name).IsEqualTo("myPlane");
            Check.That(plane.Distance).IsEqualTo(1.234);
            Check.That(plane.Normal).IsEqualTo(new PovVector(1, 2, 3));
        }

        [Fact]
        public void TestToPovCode()
        {
            var plane = new Plane("myPlane") { Distance = 1.234, Normal = new PovVector(1, 2, 3) };
            var povCode = plane.ToPovCode();
            Check.That(povCode).IsEqualTo("plane {\n < 1, 2, 3>, 1.234\n}");
        }
        [Fact]
        public void TestToPovCodeWithName()
        {
            var distance = new PovNumber("d",  1.234);
            var normal = new PovVector("normal", 1, 2, 3);
            var Plane = new Plane("myPlane") { Distance = distance, Normal = normal};
            var povCode = Plane.ToPovCode();
            Check.That(povCode).IsEqualTo("plane {\n normal, d\n}");
        }
    }
}
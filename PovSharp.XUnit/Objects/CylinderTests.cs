using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class CylinderTests
    {
        [Fact]
        public void TestBasic()
        {
            var cylinder = new Cylinder();
            Check.That(cylinder.Type).IsEqualTo("cylinder");
            Check.That(cylinder.Open).IsNull();
            Check.That(cylinder.BasePoint).IsEqualTo(new PovVector(0));
            Check.That(cylinder.CapPoint).IsEqualTo(new PovVector(0, 1, 0));
            Check.That(cylinder.Radius).IsEqualTo(1);
        }

        [Fact]
        public void TestConstructor()
        {
            var cylinder = new Cylinder("MyCylinder") { BasePoint = new PovVector(1), CapPoint = new PovVector(2), Radius = 5, Open = Cone.OpenFlag.open };
            Check.That(cylinder.Type).IsEqualTo("cylinder");
            Check.That(cylinder.Name).IsEqualTo("MyCylinder");
            Check.That(cylinder.BasePoint).IsEqualTo(new PovVector(1));
            Check.That(cylinder.CapPoint).IsEqualTo(new PovVector(2));
            Check.That(cylinder.Radius).IsEqualTo(5);
            Check.That(cylinder.Open).IsEqualTo(Cone.OpenFlag.open);
        }

        [Fact]
        public void TestCylinderOpenToPovCode()
        {
            var cylinder = new Cylinder("MyCylinder") { BasePoint = new PovVector(1), CapPoint = new PovVector(2), Radius = 1.234, Open = Cone.OpenFlag.open };
            var povCode = cylinder.ToPovCode();
            Check.That(povCode).IsEqualTo("cylinder {\n < 1, 1, 1>, < 2, 2, 2>, 1.234\n open\n}");
        }
        [Fact]
        public void TestCylinderNotOpenToPovCode()
        {
            var cylinder = new Cylinder();
            var povCode = cylinder.ToPovCode();
            Check.That(povCode).IsEqualTo("cylinder {\n < 0, 0, 0>, < 0, 1, 0>, 1\n}");
        }
    }
}
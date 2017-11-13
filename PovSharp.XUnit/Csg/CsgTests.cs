using NFluent;
using PovSharp.Csg;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Csg
{
    public class CsgTests : PovValueHelpers
    {
        Sphere sphere = new Sphere() { };
        Box box = new Box("MyBox") { };

        [Fact]
        public void CsgUnionTest()
        {
            var csgUnion = new CsgUnion().Add(sphere).Add(box);
            Check.That(csgUnion.Type).IsEqualTo("union");
            var povCode = csgUnion.ToPovCode();
            Check.That(povCode).IsEqualTo("union {\n sphere {\n < 0, 0, 0>, 1\n}\nobject {\n MyBox\n}\n}");
        }
        [Fact]
        public void CsgDifferenceTest()
        {
            var csgDifference = new CsgDifference(sphere).Add(box);
            Check.That(csgDifference.Type).IsEqualTo("difference");
            var povCode = csgDifference.ToPovCode();
            Check.That(povCode).IsEqualTo("difference {\n sphere {\n < 0, 0, 0>, 1\n}\n object {\n MyBox\n}\n}");
        }
        [Fact]
        public void CsgIntersectionTest()
        {
            var csgIntersection = new CsgIntersection().Add(sphere).Add(box);
            Check.That(csgIntersection.Type).IsEqualTo("intersection");
            var povCode = csgIntersection.ToPovCode();
            Check.That(povCode).IsEqualTo("intersection {\n sphere {\n < 0, 0, 0>, 1\n}\nobject {\n MyBox\n}\n}");
        }
        [Fact]
        public void CsgUnionWithLocalsTest()
        {
            var csgUnion = new CsgUnion();
            var radius = csgUnion.Local("radius", _N(1));
            var center = csgUnion.Local("center", _V(0));
            csgUnion.Add(new Sphere {Center = center, Radius = radius}).Add(box);
            var povCode = csgUnion.ToPovCode();
            Check.That(povCode).IsEqualTo("union {\n \n#local radius = 1;\n#local center = < 0, 0, 0>;\nsphere {\n center, radius\n}\nobject {\n MyBox\n}\n}");
        }
    }
}
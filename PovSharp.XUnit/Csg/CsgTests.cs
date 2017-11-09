using NFluent;
using PovSharp.Csg;
using PovSharp.Objects;
using Xunit;

namespace PovSharp.XUnit.Csg
{
    public class CsgTests
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
    }
}
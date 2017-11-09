using NFluent;
using PovSharp.Core;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Core
{
    public class PovSplineTests
    {
        PovNumber n;
        PovVector v;
        PovSpline spline;
        public PovSplineTests()
        {
            n = new PovNumber("n", 0.5);
            v = new PovVector("v", 1, 2, 3);
            spline = new PovSpline("MySpline")
               .Add(0, new PovVector(0))
               .Add(n, v)
               .Add(1, new PovVector(3));
        }

        [Fact]
        public void PovSplineCodeTest()
        {
            var povCode = spline.ToPovCode();
            Check.That(povCode).IsEqualTo("spline {\n 0, < 0, 0, 0>\n\nn, v\n\n1, < 3, 3, 3>\n\n}");
        }

        [Fact]
        public void PovSplineValueTest()
        {
            var value = spline[0.5];
            Check.That(value.Name).IsEqualTo("MySpline(0.5)");

            var sphere = new Sphere() { Center = value };
            var povCode = sphere.ToPovCode();
            Check.That(povCode).IsEqualTo("sphere {\n MySpline(0.5), 1\n}");
        }
    }
}
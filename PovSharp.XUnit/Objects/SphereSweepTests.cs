using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class SphereSweepTests
    {
        [Fact]
        public void SphereSweepConstructorTest()
        {
            var sphereSweep = new SphereSweep();
            Check.That(sphereSweep.Name).IsNull();
            Check.That(sphereSweep.NbSpheres).IsEqualTo(0);
            Check.That(sphereSweep.SplineType).IsNull();
            Check.That(sphereSweep.Tolerance).IsNull();
        }

        [Fact]
        public void SphereSweepToPovCodeTest()
        {
            var n = new PovNumber("myNumber", 0.5);
            var v = new PovVector("myVector", 1, 0, 3);

            var sphereSweep = new SphereSweep() { SplineType = SphereSweep.CubicSpline }
                            .Add(new PovVector(0), 0.5)
                            .Add(new PovVector(-1), 1)
                            .Add(new PovVector(1), 0.25)
                            .Add(v, n)
                            .Add(new PovVector(3, 0, 1), 1);

            var povCode = sphereSweep.ToPovCode();
            Check.That(povCode).IsEqualTo("sphere_sweep {\n cubic_spline\n 5\n < 0, 0, 0>, 0.5\n\n< -1, -1, -1>, 1\n\n< 1, 1, 1>, 0.25\n\nmyVector, myNumber\n\n< 3, 0, 1>, 1\n\n}");
        }
    }
}
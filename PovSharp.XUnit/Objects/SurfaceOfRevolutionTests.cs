using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class SurfaceOfRevolutionTests
    {
        [Fact]
        public void BasicTest()
        {
            var Sor = new SurfaceOfRevolution();
            Check.That(Sor.Name).IsNull();
            Check.That(Sor.Sturm).IsNull();
            Check.That(Sor.NbPoints).IsEqualTo(0);
            Check.That(Sor.Spline).IsNull();
        }

        [Fact]
        public void ConstructorTest()
        {
            var Sor = new SurfaceOfRevolution("MySor")
            {
                Sturm = SurfaceOfRevolution.SturmFlag.sturm,
                Spline =SurfaceOfRevolution.SplineType.bezier_spline
            };

            Check.That(Sor.Name).IsEqualTo("MySor");
            Check.That(Sor.Sturm).IsEqualTo(SurfaceOfRevolution.SturmFlag.sturm);
            Check.That(Sor.Spline).IsEqualTo(SurfaceOfRevolution.SplineType.bezier_spline);
        }
        [Fact]
        public void ToPovCodeTest()
        {
            var sor = new SurfaceOfRevolution("MySor")
            {
                Open = SurfaceOfRevolution.OpenFlag.open,
                Sturm = SurfaceOfRevolution.SturmFlag.sturm,
                Spline = SurfaceOfRevolution.SplineType.bezier_spline
            };
            sor.Add(0, 0).Add(6, 0).Add(6, 8).Add(0, 8).Add(0, 0)  //outer rim
                .Add(1, 1).Add(5, 1).Add(5, 7).Add(1, 7).Add(1, 1);   //inner rim    

            var povCode = sor.ToPovCode();
            Check.That(povCode).IsEqualTo("sor {\n bezier_spline\n 10\n < 0, 0>, < 6, 0>, < 6, 8>, < 0, 8>, < 0, 0>, < 1, 1>, < 5, 1>, < 5, 7>, < 1, 7>, < 1, 1>\n open\n sturm\n}");
        }
    }
}
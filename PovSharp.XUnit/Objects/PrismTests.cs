using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class PrismTests
    {
        [Fact]
        public void BasicTest()
        {
            var prism = new Prism();
            Check.That(prism.Name).IsNull();
            Check.That(prism.Open).IsNull();
            Check.That(prism.Sturm).IsNull();
            Check.That(prism.NbPoints).IsEqualTo(0);
            Check.That(prism.Height1).IsEqualTo(0);
            Check.That(prism.Height2).IsEqualTo(1);
            Check.That(prism.Spline).IsNull();
            Check.That(prism.Sweep).IsNull();
        }

        [Fact]
        public void ConstructorTest()
        {
            var prism = new Prism("MyPrism")
            {
                Height1 = 2,
                Height2 = 3,
                Open = Prism.OpenFlag.open,
                Sturm = Prism.SturmFlag.sturm,
                Sweep = Prism.SweepType.conic_sweep,
                Spline = Prism.ObjectSplineType.bezier_spline
            };

            Check.That(prism.Name).IsEqualTo("MyPrism");
            Check.That(prism.Height1).IsEqualTo(2);
            Check.That(prism.Height2).IsEqualTo(3);
            Check.That(prism.Open).IsEqualTo(Prism.OpenFlag.open);
            Check.That(prism.Sturm).IsEqualTo(Prism.SturmFlag.sturm);
            Check.That(prism.Spline).IsEqualTo(Prism.ObjectSplineType.bezier_spline);
            Check.That(prism.Sweep).IsEqualTo(Prism.SweepType.conic_sweep);
        }
        [Fact]
        public void ToPovCodeTest()
        {
            var prism = new Prism("MyPrism")
            {
                Height1 = 2,
                Height2 = 3,
                Open = Prism.OpenFlag.open,
                Sturm = Prism.SturmFlag.sturm,
                Sweep = Prism.SweepType.conic_sweep,
                Spline = Prism.ObjectSplineType.bezier_spline
            };
            prism.Add(0, 0).Add(6, 0).Add(6, 8).Add(0, 8).Add(0, 0)  //outer rim
                .Add(1, 1).Add(5, 1).Add(5, 7).Add(1, 7).Add(1, 1);   //inner rim    


            var povCode = prism.ToPovCode();
            Check.That(povCode).IsEqualTo("prism {\n conic_sweep\n bezier_spline\n 2, 3, 10\n < 0, 0>, < 6, 0>, < 6, 8>, < 0, 8>, < 0, 0>, < 1, 1>, < 5, 1>, < 5, 7>, < 1, 7>, < 1, 1>\n open\n sturm\n}");
        }
    }
}
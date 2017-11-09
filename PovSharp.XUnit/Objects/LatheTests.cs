using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class LatheTests
    {
        [Fact]
        public void BasicTest()
        {
            var lathe = new Lathe();
            Check.That(lathe.Name).IsNull();
            Check.That(lathe.Sturm).IsNull();
            Check.That(lathe.NbPoints).IsEqualTo(0);
            Check.That(lathe.Spline).IsNull();
        }

        [Fact]
        public void ConstructorTest()
        {
            var lathe = new Lathe("MyLathe")
            {
                Sturm = Lathe.SturmFlag.sturm,
                Spline = Lathe.ObjectSplineType.bezier_spline
            };

            Check.That(lathe.Name).IsEqualTo("MyLathe");
            Check.That(lathe.Sturm).IsEqualTo(Lathe.SturmFlag.sturm);
            Check.That(lathe.Spline).IsEqualTo(Lathe.ObjectSplineType.bezier_spline);
        }
        [Fact]
        public void ToPovCodeTest()
        {
            var lathe = new Lathe("MyLathe")
            {
                Sturm = Lathe.SturmFlag.sturm,
                Spline = Lathe.ObjectSplineType.bezier_spline
            };
            lathe.Add(0, 0).Add(6, 0).Add(6, 8).Add(0, 8).Add(0, 0)  //outer rim
                .Add(1, 1).Add(5, 1).Add(5, 7).Add(1, 7).Add(1, 1);   //inner rim    

            var povCode = lathe.ToPovCode();
            Check.That(povCode).IsEqualTo("lathe {\n bezier_spline\n 10\n < 0, 0>, < 6, 0>, < 6, 8>, < 0, 8>, < 0, 0>, < 1, 1>, < 5, 1>, < 5, 7>, < 1, 7>, < 1, 1>\n sturm\n}");
        }
    }
}
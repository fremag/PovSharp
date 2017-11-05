using NFluent;
using PovSharp.Core;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Core
{
    public class PovListTests
    {
        [Fact]
        public void NumberPovListTest()
        {
            PovList<PovNumber> numbers = new PovList<PovNumber>();
            var n1 = new PovNumber(5);
            var n2 = new PovNumber("MyNumber", 1.234);
            var n3 = 3.14;

            numbers.Add(n1).Add(n2).Add(n3);

            Check.That(numbers.ToPovCode()).IsEqualTo("5, MyNumber, 3.14");
        }
        [Fact]
        public void SpherePovListTest()
        {
            PovList<AbstractPovObject> spheres = new PovList<AbstractPovObject>() { Separator = "\n" };
            var s1 = new Sphere { Center = new PovVector(0), Radius = 1 };
            var s2 = new Sphere("MySphere") { Center = new PovVector(0), Radius = 1 };
            var s3 = new Sphere { Center = new PovVector(2), Radius = 3 };

            spheres.Add(s1).Add(s2).Add(s3);
            var povCode = spheres.ToPovCode();
            Check.That(povCode).IsEqualTo("sphere {\n < 0, 0, 0>, 1\n}\nMySphere\nsphere {\n < 2, 2, 2>, 3\n}");
        }
    }
}
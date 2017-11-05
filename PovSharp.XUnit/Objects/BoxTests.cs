using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class BoxTests
    {
        [Fact]
        public void TestBasic()
        {
            var box = new Box();
            Check.That(box.Type).IsEqualTo("box");
            Check.That(box.Corner1).IsEqualTo(new PovVector(0));
            Check.That(box.Corner2).IsEqualTo(new PovVector(1));
        }
        [Fact]
        public void TestConstructor()
        {
            var box = new Box("myBox") { Corner1 =  new PovVector(1), Corner2= new PovVector(-1) };
            Check.That(box.Type).IsEqualTo("box");
            Check.That(box.Name).IsEqualTo("myBox");
            Check.That(box.Corner1).IsEqualTo(new PovVector(1, 1, 1));
            Check.That(box.Corner2).IsEqualTo(new PovVector(-1, -1, -1));
        }

        [Fact]
        public void TestToPovCode()
        {
            var box = new Box("myBox") { Corner1 =  new PovVector(1), Corner2= new PovVector(-1) };
            var povCode = box.ToPovCode();
            Check.That(povCode).IsEqualTo("box {\n < 1, 1, 1>, < -1, -1, -1>\n}");
        }
        [Fact]
        public void TestToPovCodeWithName()
        {
            var corner1 = new PovVector("c1", 1, 1, 1);
            var corner2 = new PovVector("c2", -1, -1, -1);
            var box = new Box("myBox") { Corner1 = corner1, Corner2 = corner2};
            var povCode = box.ToPovCode();
            Check.That(povCode).IsEqualTo("box {\n c1, c2\n}");
        }
    }
}
using NFluent;
using PovSharp.Core;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Core
{
    public class DeclareElementTests
    {
        [Fact]
        public void TestConstructor()
        {
            var myNum = new PovNumber(5);
            var declElem = new DeclareElement("myVar", myNum, string.Empty);
            Check.That(declElem.Name).IsNull();
            Check.That(myNum.Name).IsEqualTo("myVar");
            Check.That(declElem.PovElement).IsEqualTo(myNum);
            Check.That(declElem.End).IsEqualTo(string.Empty);
        }

        [Fact]
        public void TestConstructor2()
        {
            var myNum = new PovNumber(5);
            var declElem = new DeclareElement("myVar", myNum);
            Check.That(declElem.Name).IsNull();
            Check.That(myNum.Name).IsEqualTo("myVar");
            Check.That(declElem.PovElement).IsEqualTo(myNum);
            Check.That(declElem.End).IsEqualTo(";");
        }

        [Fact]
        public void TestToPovCode1()
        {
            var myNum = new PovNumber("myNum", 5);
            var declElem = new DeclareElement("myVar", myNum);
            Check.That(declElem.ToPovCode()).IsEqualTo("#declare myVar = myNum;");
        }

        [Fact]
        public void TestToPovCode2()
        {
            var myNum = new PovVector("myVect", 5);
            var declElem = new DeclareElement("myVar", myNum);
            Check.That(declElem.ToPovCode()).IsEqualTo("#declare myVar = myVect;");
        }

        [Fact]
        public void TestToPovCode3()
        {
            var myNum = new PovVector(5);
            var declElem = new DeclareElement("myVar", myNum);
            var povCode = declElem.ToPovCode();
            Check.That(povCode).IsEqualTo("#declare myVar = < 5, 5, 5>;");
        }

        [Fact]
        public void TestToPovCode4()
        {
            PovNumber myNum = 1.234;
            var declElem = new DeclareElement("myVar", myNum);
            Check.That(declElem.ToPovCode()).IsEqualTo("#declare myVar = 1.234;");
        }

        [Fact]
        public void TestToPovCode5()
        {
            var myNum = new PovNumber("myNum", 5);
            PovVector myVect = new PovVector { X = myNum, Y = 2, Z = myNum };
            var declElem = new DeclareElement("myVar", myVect);
            Check.That(declElem.ToPovCode()).IsEqualTo("#declare myVar = < myNum, 2, myNum>;");
        }

    }
}
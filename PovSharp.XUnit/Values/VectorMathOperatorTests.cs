using PovSharp.Values;
using Xunit;
using NFluent;

namespace PovSharp.XUnit.Values
{
    public class VectorMathOperatorTests
    {
        PovVector v = new PovVector("v", 1, 2, 3);
        PovVector w = new PovVector(4,5,6);

        PovNumber n = new PovNumber("n", 5);
        PovNumber m = new PovNumber(7);
        
        [Fact]
        public void VectorScalarMultiplicationTest()
        {
            var result = v*3;
            Check.That(result.Name).IsEqualTo("v * 3");
            Check.That(result.X).IsEqualTo(3);
            Check.That(result.Y).IsEqualTo(6);
            Check.That(result.Z).IsEqualTo(9);
        }

        [Fact]
        public void ScalarVectorMultiplicationTest()
        {
            var result = 3*v;
            Check.That(result.Name).IsEqualTo("3 * v");
            Check.That(result.X).IsEqualTo(3);
            Check.That(result.Y).IsEqualTo(6);
            Check.That(result.Z).IsEqualTo(9);
        }

        [Fact]
        public void AnonymousVectorScalarMultiplicationTest()
        {
            var result = w*3;
            Check.That(result.Name).IsEqualTo("< 4, 5, 6> * 3");
            Check.That(result.X).IsEqualTo(12);
            Check.That(result.Y).IsEqualTo(15);
            Check.That(result.Z).IsEqualTo(18);
        }

        [Fact]
        public void ScalarAnonymousVectorMultiplicationTest()
        {
            var result = 3*w;
            Check.That(result.Name).IsEqualTo("3 * < 4, 5, 6>");
            Check.That(result.X).IsEqualTo(12);
            Check.That(result.Y).IsEqualTo(15);
            Check.That(result.Z).IsEqualTo(18);
        }
        [Fact]
        public void VectorNumberMultiplicationTest()
        {
            var result = v*n;
            Check.That(result.Name).IsEqualTo("v * n");
            Check.That(result.X).IsEqualTo(5);
            Check.That(result.Y).IsEqualTo(10);
            Check.That(result.Z).IsEqualTo(15);
        }

        [Fact]
        public void NumberVectorMultiplicationTest()
        {
            var result = n*v;
            Check.That(result.Name).IsEqualTo("n * v");
            Check.That(result.X).IsEqualTo(5);
            Check.That(result.Y).IsEqualTo(10);
            Check.That(result.Z).IsEqualTo(15);
        }

        [Fact]
        public void AnonymousVectorNumberMultiplicationTest()
        {
            var result = w*n;
            Check.That(result.Name).IsEqualTo("< 4, 5, 6> * n");
            Check.That(result.X).IsEqualTo(20);
            Check.That(result.Y).IsEqualTo(25);
            Check.That(result.Z).IsEqualTo(30);
        }

        [Fact]
        public void NumberAnonymousVectorMultiplicationTest()
        {
            var result = n*w;
            Check.That(result.Name).IsEqualTo("n * < 4, 5, 6>");
            Check.That(result.X).IsEqualTo(20);
            Check.That(result.Y).IsEqualTo(25);
            Check.That(result.Z).IsEqualTo(30);
        }
        [Fact]
        public void AnonymousVectorAnonymousNumberMultiplicationTest()
        {
            var result = w*m;
            Check.That(result.Name).IsEqualTo("< 4, 5, 6> * 7");
            Check.That(result.X).IsEqualTo(28);
            Check.That(result.Y).IsEqualTo(35);
            Check.That(result.Z).IsEqualTo(42);
        }

        [Fact]
        public void AnonymousNumberAnonymousVectorMultiplicationTest()
        {
            var result = m*w;
            Check.That(result.Name).IsEqualTo("7 * < 4, 5, 6>");
            Check.That(result.X).IsEqualTo(28);
            Check.That(result.Y).IsEqualTo(35);
            Check.That(result.Z).IsEqualTo(42);
        }

        [Fact]
        public void AnonymousVectorMinusTest()
        {
            var result = -w;
            Check.That(result.Name).IsEqualTo("-< 4, 5, 6>");
            Check.That(result.X).IsEqualTo(-4);
            Check.That(result.Y).IsEqualTo(-5);
            Check.That(result.Z).IsEqualTo(-6);
        }
        [Fact]
        public void VectorMinusTest()
        {
            var result = -v;
            Check.That(result.Name).IsEqualTo("-v");
            Check.That(result.X).IsEqualTo(-1);
            Check.That(result.Y).IsEqualTo(-2);
            Check.That(result.Z).IsEqualTo(-3);
        }
    }
}

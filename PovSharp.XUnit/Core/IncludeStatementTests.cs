using NFluent;
using PovSharp.Core;
using Xunit;

namespace PovSharp.XUnit.Core
{
    public class IncludeStatementTests
    {
        [Fact]
        public void IncludeTest()
        {
            IncludeStatement inc = new IncludeStatement() {IncludeFile = "colors.inc"};
            var povCode = inc.ToPovCode();
            Check.That(povCode).IsEqualTo("#include \"colors.inc\"");
        }
    }
}
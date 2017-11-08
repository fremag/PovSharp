using PovSharp.Core;

namespace PovSharp.Csg
{
    public class CsgUnion : AbstractCsgObject
    {
        public CsgUnion()
        {
        }

        public CsgUnion(string name) : base(name)
        {
        }

        public override string Type => "union";
    }
}
using PovSharp.Core;

namespace PovSharp.Csg
{
    public class CsgIntersection : AbstractCsgObject
    {
        public CsgIntersection()
        {
        }

        public CsgIntersection(string name) : base(name)
        {
        }

        public override string Type => "intersection";
    }
}
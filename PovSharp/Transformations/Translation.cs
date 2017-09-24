using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Transformations
{
    public class Translation : AbstractObjecTransformation
    {
        public Translation(string name) : base(name)
        {
            Vector = new PovVector(0, 0, 0);
        }

        public Translation(PovVector vector) : base(vector) {}

        public override string Type => "translate";
    }
}
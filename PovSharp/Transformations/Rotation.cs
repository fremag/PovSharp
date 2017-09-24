using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Transformations
{
    public class Rotation : AbstractObjecTransformation
    {
        public Rotation(string name) : base(name)
        {
            Vector = new PovVector(0, 0, 0);
        }

        public Rotation(PovVector vector) : base(vector)
        {
        }

        public override string Type => "rotate";
    }
}
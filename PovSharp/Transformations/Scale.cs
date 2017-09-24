using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Transformations
{
    public class Scale : AbstractObjecTransformation
    {

        public Scale(PovVector vector) : base(vector)
        { }

        protected Scale(string name) : base(name)
        {
            Vector = new PovVector(1, 1, 1);
        }

        public override string Type => "scale";
    }
}
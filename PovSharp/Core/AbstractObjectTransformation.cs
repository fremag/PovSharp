using PovSharp.Values;

namespace PovSharp.Core
{
    public abstract class AbstractObjecTransformation : AbstractObjectModifier
    {
        [PovField(0)]
        public PovVector Vector { get; set; }

        public AbstractObjecTransformation(string name) : base(name)
        {
        }

        public AbstractObjecTransformation(string name, PovVector vector) : this(name)
        {
            Vector = vector;
        }

        public AbstractObjecTransformation(PovVector vector) : this(null, vector)
        { }

        public override string ToPovCode()
        {
            string povCode = $"{Type} {this.BuildPovCode()}\n";
            return povCode;
        }
    }
}
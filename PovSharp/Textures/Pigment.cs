using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Textures
{
    public class Pigment : AbstractObjectModifier
    {
        [PovField(0, Before="color ", After="\n")]
       public  PovColor Color {get; set;} = new PovColor(0, 0, 0); // default: black

        public Pigment() : base(null)
        {
        }

        public Pigment(string name) : base(name)
        {
        }

        public Pigment(string name, PovColor color) : base(name)
        {
            Color = color;
        }
        public Pigment(PovColor color) : this(null, color)
        {}

        public override string Type => "pigment";
    }
}
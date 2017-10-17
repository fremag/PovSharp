using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Lights
{
    public class Light : AbstractPovObject
    {
        public Light(string name) : base(name)
        {
        }
        public Light() : this(null)
        {
        }

        [PovField(0, After=",")]
        public PovVector Location {get;set;} = new PovVector(5);

        [PovField(1, After="\n")]
        public PovColor Color {get;set;} = new PovColor(1);

        public override string Type => "light_source";
    }
}
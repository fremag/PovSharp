using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class Plane : AbstractPovObject
    {
        public override string Type => "plane";
        [PovField(0, After=",")]
        public PovVector Normal {get; set;} = new PovVector(0, 1, 0);
        [PovField(1, After="\n")]
        public PovNumber Distance {get; set;} = 0;
        public  Plane(string name) : base(name)
        {
        }
        public  Plane() : base(null)
        {
        }
    }
}
using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class Sphere : AbstractPovObject
    {
        public override string Type => "sphere";
        [PovField(0, After=",")]
        public PovVector Center {get; set;} = new PovVector(0);
        [PovField(1, After="\n")]
        public PovNumber Radius {get; set;} = 1;
        public  Sphere(string name) : base(name)
        {
        }
        public  Sphere() : base(null)
        {
        }
    }
}
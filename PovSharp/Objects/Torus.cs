using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class Torus : AbstractPovObject
    {
        public override string Type => "torus";
        [PovField(0, After = ",")]
        public PovNumber MajorRadius { get; set; } = new PovNumber(1);

        [PovField(1, After = "\n")]
        public PovNumber MinorRadius { get; set; } = new PovNumber(0.5);

        public Torus()
        {
        }

        public Torus(string name) : base(name)
        {
        }
    }
}
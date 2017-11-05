using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class Cone : AbstractPovObject
    {
        public override string Type => "cone";
        [PovField(0, After = ",")]
        public PovVector BasePoint { get; set; } = new PovVector(0);

        [PovField(1, After = "\n")]
        public PovNumber BaseRadius { get; set; } = new PovNumber(1);

        [PovField(2, After = ",")]
        public PovVector CapPoint { get; set; } = new PovVector(0, 1, 0);

        [PovField(3, After = "\n")]
        public PovNumber CapRadius { get; set; } = new PovNumber(0);

        [PovField(4, After = "\n")]
        public OpenFlag? Open { get; set; }

        public Cone()
        {
        }

        public Cone(string name) : base(name)
        {
        }
    }
}
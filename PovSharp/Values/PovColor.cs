using PovSharp.Core;

namespace PovSharp.Values
{
    public class PovColor : AbstractPovElement
    {
        [PovField(0, Before = "rgb <", After=",")]
        public PovNumber Red { get; set; } = 0;
        [PovField(1, After = ",")]
        public PovNumber Green { get; set; } = 0;
        [PovField(2, After = ">")]

        public PovNumber Blue { get; set; } = 0;
        public PovColor(string name, PovNumber red, PovNumber green,  PovNumber blue  ) : base(name)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
        public PovColor(string name) : base(name)
        {
        }
        public PovColor(string name, double red, double green, double blue  ) : this(name, new PovNumber(red), new PovNumber(green), new PovNumber(blue))
        {}

        public PovColor(double red, double green, double blue  ) : this(null, red, green, blue)
        {}
        public PovColor(PovNumber red, PovNumber green, PovNumber blue  ) : this(null, red, green, blue)
        {}
        public PovColor(string name, PovVector rgb) : this(name, rgb.X, rgb.Y, rgb.Z)
        {}

        public PovColor() : base(null)
        {
        }

        public override string ToPovCode()
        {
            return this.BuildPovCode();
        }
    }
}
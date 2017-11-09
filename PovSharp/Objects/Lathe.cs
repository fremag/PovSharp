using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class Lathe : AbstractPovObject
    {
        [PovField(0, After = "\n")]
        public ObjectSplineType? Spline { get; set; } = null;
        

        [PovField(1, After = "\n")]
        public PovNumber NbPoints => Points.Count;

        [PovField(2, After = "\n")]
        private PovList<Point2D> Points { get; set; } = new PovList<Point2D>();

        
        [PovField(3, After = "\n")]
        public SturmFlag? Sturm {get; set;} 

        public Lathe()
        {
        }

        public Lathe(string name) : base(name)
        {
        }

        public Lathe Add(PovNumber x, PovNumber y) {
            Points.Add(new Point2D(x, y));
            return this;
        }
        public override string Type => "lathe";
    }
}
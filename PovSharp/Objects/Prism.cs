using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class Prism : AbstractPovObject
    {
        [PovField(0, After = "\n")]
        public SweepType? Sweep { get; set; } = null;
        [PovField(1, After = "\n")]
        public SplineType? Spline { get; set; } = null;
        
        [PovField(2, After = ",")]
        public PovNumber Height1 { get; set; } = 0;
        
        [PovField(3, After = ",")]
        public PovNumber Height2 { get; set; } = 1;

        [PovField(4, After = "\n")]
        public PovNumber NbPoints => Points.Count;

        [PovField(5, After = "\n")]
        private PovList<Point2D> Points { get; set; } = new PovList<Point2D>();

        [PovField(6, After = "\n")]
        public OpenFlag? Open {get; set;} 
        
        [PovField(7, After = "\n")]
        public SturmFlag? Sturm {get; set;} 

        public Prism()
        {
        }

        public Prism(string name) : base(name)
        {
        }

        public Prism Add(PovNumber x, PovNumber y) {
            Points.Add(new Point2D(x, y));
            return this;
        }
        public override string Type => "prism";
    }
}
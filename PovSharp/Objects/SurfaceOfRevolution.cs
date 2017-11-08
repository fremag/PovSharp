using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class SurfaceOfRevolution : AbstractPovObject
    {
        [PovField(0, After = "\n")]
        public SplineType? Spline { get; set; } = null;
        

        [PovField(1, After = "\n")]
        public PovNumber NbPoints => Points.Count;

        [PovField(2, After = "\n")]
        private PovList<Point2D> Points { get; set; } = new PovList<Point2D>();

        [PovField(3, After = "\n")]
        public OpenFlag? Open {get; set;} 
        
        [PovField(4, After = "\n")]
        public SturmFlag? Sturm {get; set;} 

        public SurfaceOfRevolution() : base()
        {
        }

        public SurfaceOfRevolution(string name) : base(name)
        {
        }

        public SurfaceOfRevolution Add(PovNumber x, PovNumber y) {
            Points.Add(new Point2D(x, y));
            return this;
        }
        public override string Type => "sor";
    }
}
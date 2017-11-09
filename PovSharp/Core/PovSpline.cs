using PovSharp.Values;

namespace PovSharp.Core
{
    public class PovSpline : AbstractPovObject
    {
        public enum SplineFlag { linear_spline, quadratic_spline, cubic_spline, natural_spline }

        [PovField(0, After = "\n")]
        public new SplineFlag? SplineType { get; set; }

        [PovField(1, After = "\n")]
        private PovList<SplineElement> elements = new PovList<SplineElement>("\n");
        // Spline MUST have a name so empty constructor is protected
        public PovSpline()
        {
        }

        public PovSpline(string name) : base(name)
        {
        }

        public PovVector this[PovNumber value]
        {
            get
            {
                return new PovVector($"{Name}({value.ToPovCode()})");
            }
        }

        public void Add(PovNumber value, PovVector vector)
        {

        }
        public override string Type => "spline";

        private class SplineElement : AbstractPovElement
        {
            [PovField(0, After = ",")]
            private PovNumber Value { get; set; }

            [PovField(1, After = "\n")]
            private PovVector Vector { get; set; }

            public SplineElement(PovNumber value, PovVector vector)
            {
                Value = value;
                Vector = vector;
            }

            public override string ToPovCode() => this.BuildPovCode();
        }
    }
}
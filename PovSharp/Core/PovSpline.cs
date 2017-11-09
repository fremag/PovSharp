using PovSharp.Values;

namespace PovSharp.Core
{
    public class PovSpline : AbstractPovObject
    {
        public enum SplineTypeName { linear_spline, quadratic_spline, cubic_spline, natural_spline }

        [PovField(0, After = "\n")]
        public SplineTypeName? SplineType { get; set; }

        [PovField(1, After = "\n")]
        private PovList<SplineElement> Elements { get; set; } = new PovList<SplineElement>("\n");

        // Spline MUST have a name so empty constructor is protected
        protected PovSpline()
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

        public PovSpline Add(PovNumber value, PovVector vector)
        {
            Elements.Add(new SplineElement(value, vector));
            return this;
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
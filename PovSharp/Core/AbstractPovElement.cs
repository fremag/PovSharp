using System;

namespace PovSharp.Core
{
    public abstract class AbstractPovElement : ICloneable
    {
        public enum OpenFlag { open }

        public enum SturmFlag { sturm }

        public enum SplineType { linear_spline, quadratic_spline, cubic_spline, bezier_spline }
        public enum SweepType { linear_sweep, conic_sweep }

        public string Name { get; set; }
        public abstract string ToPovCode();
        public AbstractPovElement()
        {

        }

        protected AbstractPovElement(string name) : this()
        {
            Name = name;
        }

        public virtual object Clone()
        {
            return base.MemberwiseClone();
        }
    }
}

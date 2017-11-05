using System.Collections.Generic;
using System.Linq;

namespace PovSharp.Core
{
    public abstract class AbstractPovObject : AbstractPovElement
    {
        public abstract string Type { get; }
        private List<AbstractObjectModifier> Modifiers { get; } = new List<AbstractObjectModifier>();
        protected AbstractPovObject() : this(null)
        {

        }

        protected AbstractPovObject(string name) : base(name)
        {
        }

        public override string ToPovCode()
        {
            string povCode = $"{Type} {{\n {this.BuildPovCode()}";
            if (Modifiers.Any())
            {
                povCode += "\n";
                povCode += string.Join("\n", Modifiers.Select(mod => mod.ToPovCode()));
            }
            povCode += "}";
            return povCode;
        }

        public AbstractPovObject AddModifiers(AbstractObjectModifier modifier)
        {
            Modifiers.Add(modifier);
            return this;
        }
        public AbstractPovObject AddModifiers(params AbstractObjectModifier[] modifiers)
        {
            foreach (var modifier in modifiers)
            {
                Modifiers.Add(modifier);
            }
            return this;
        }
    }
}
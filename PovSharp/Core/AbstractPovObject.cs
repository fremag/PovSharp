using System.Collections.Generic;
using System.Linq;

namespace PovSharp.Core
{
    public abstract class AbstractPovObject : AbstractPovElement
    {
        public abstract string Type { get; }
        private List<AbstractObjectModifier> Modifiers { get; } = new List<AbstractObjectModifier>();
        protected AbstractPovObject(string name) : base(name)
        {
        }

        public override string ToPovCode() {
            string povCode = $"{Type} {{\n {this.BuildPovCode()}";
            if(Modifiers.Any()) {
                povCode += "\n";
                povCode += string.Join("\n", Modifiers.Select(mod => mod.ToPovCode()));
            }
            povCode += "}";
            return povCode;
        } 

        public AbstractPovObject AddModifiers(AbstractObjectModifier modifiers)
        {
            Modifiers.Add(modifiers);
            return this;
        }
    }
}
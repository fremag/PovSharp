using System.Collections.Generic;
using System.Linq;

namespace PovSharp.Core
{
    public abstract class AbstractPovObject : AbstractPovElement
    {
        public abstract string Type { get; }
        private List<AbstractObjectModifier> Modifiers { get; } = new List<AbstractObjectModifier>();
        private List<LocalElement> Locals { get; set; } = new List<LocalElement>();

        protected AbstractPovObject() : this(null)
        {

        }

        protected AbstractPovObject(string name) : base(name)
        {
        }

        public override string ToPovCode()
        {
            string povCode = $"{Type} {{\n ";
            if (Locals.Any())
            {
                povCode += "\n";
                povCode += string.Join("\n", Locals.Select(mod => mod.ToPovCode()));
                povCode += "\n";
            }
            povCode += this.BuildPovCode();
            if (Modifiers.Any())
            {
                povCode += "\n";
                povCode += string.Join("\n", Modifiers.Select(mod => mod.ToPovCode()));
                povCode += "\n";
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

        public T Local<T>(string name, T element) where T : AbstractPovElement
        {
            Locals.Add(new LocalElement(name, element));
            return element;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Scenes
{
    public class PovScene : PovValueHelpers
    {
        public PovScene()
        {
            Add(new IncludeStatement{IncludeFile ="colors.inc"});
        }

        public string Name {get; set;}
        public string Description {get; set;}
        
        protected List<AbstractPovElement> Elements {get;} = new List<AbstractPovElement>();
        public T Declare<T>(string elementName, T element) where T : AbstractPovElement {
            DeclareElement decl = new DeclareElement(elementName, element);
            Elements.Add(decl);
            element.Name = elementName;
            return element;
        }
        public T Declare<T>(T element) where T : AbstractPovElement {
            var name = element.Name;
            element.Name = null;
            Declare(name, element);
            return element;
        }

        public PovScene Add(AbstractPovElement element) {
            Elements.Add(element);
            return this;
        }

        public IEnumerable<string> ToPovCode() => Elements.Select(element => element.Name ?? element.ToPovCode());
    }
}
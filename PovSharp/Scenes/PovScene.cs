using System.Collections.Generic;
using System.Linq;
using PovSharp.Core;

namespace PovSharp.Scenes
{
    public class PovScene
    {
        protected List<AbstractPovElement> Elements {get;} = new List<AbstractPovElement>();
        public T Declare<T>(string elementName, T element) where T : AbstractPovElement {
            DeclareElement decl = new DeclareElement(elementName, element);
            Elements.Add(decl);
            element.Name = elementName;
            return element;
        }

        public void Add(AbstractPovElement element) {
            Elements.Add(element);
        }

        public IEnumerable<string> ToPovCode() => Elements.Select(element => element.Name ?? element.ToPovCode());
    }
}
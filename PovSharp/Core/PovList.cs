using System.Collections.Generic;
using System.Linq;

namespace PovSharp.Core
{
    public class PovList<T> : AbstractPovElement where T : AbstractPovElement
    {
        public string Separator { get; set; } = ", ";
        private List<AbstractPovElement> InnerList = new List<AbstractPovElement>();

        public PovList(string separator)
        {
            Separator = separator;
        }
        public PovList()
        {
        }

        public PovList<T> Add(T povElement)
        {
            InnerList.Add(povElement);
            return this;
        }

        public override string ToPovCode() => string.Join(Separator, InnerList.Select(povElement => povElement.Name ?? povElement.ToPovCode()));
    }
}
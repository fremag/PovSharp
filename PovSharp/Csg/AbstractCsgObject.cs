using PovSharp.Core;
using PovSharp.Objects;

namespace PovSharp.Csg
{
    public abstract class AbstractCsgObject : AbstractPovObject
    {
        [PovField(2, After = "\n")]
        protected PovList<AbstractPovElement> ObjectList { get; set; } = new PovList<AbstractPovElement>("\n");

        protected AbstractCsgObject()
        {
        }

        protected AbstractCsgObject(string name) : base(name)
        {
        }

        public AbstractCsgObject Add(AbstractPovObject obj)
        {
            if (obj.Name != null)
            {
                ObjectList.Add(new PovObject(obj));
            }
            else
            {
                ObjectList.Add(obj);
            }
            return this;
        }
        public AbstractCsgObject Comment(string text)
        {
            ObjectList.Add(new PovComment{Text=text});
            return this;
        }
        public AbstractCsgObject Add(params AbstractPovObject[] objects)
        {
            foreach (var obj in objects)
            {
                Add(obj);
            }
            return this;
        }
    }
}
using PovSharp.Core;

namespace PovSharp.Csg
{
    public abstract class AbstractCsgObject : AbstractPovObject
    {
        [PovField(1, After="\n")]
        protected PovList<AbstractPovObject> ObjectList {get; set;} = new PovList<AbstractPovObject>("\n");

        protected AbstractCsgObject()
        {
        }

        protected AbstractCsgObject(string name) : base(name)
        {
        }

        public AbstractCsgObject Add(AbstractPovObject obj) {
            ObjectList.Add(obj);
            return this;
        }
    }
}
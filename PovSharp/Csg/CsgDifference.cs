using PovSharp.Core;
using PovSharp.Objects;

namespace PovSharp.Csg
{
    public class CsgDifference : AbstractCsgObject
    {
        [PovField(0, After = "\n")]
        public AbstractPovObject MainObject { get; set; }

        public CsgDifference(AbstractPovObject mainObject)
        {
            if (mainObject.Name != null)
            {
                MainObject = new PovObject(mainObject);
            }
            else
            {
                MainObject = mainObject;
            }
        }

        public CsgDifference(string name) : base(name)
        {
        }

        public override string Type => "difference";
    }
}
using PovSharp.Csg;
using PovSharp.Objects;
using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Demos.Droid
{
    public class DroidHead : CsgUnion
    {
        public DroidHead()
        {
            Add(new Sphere());
        }
    }

}
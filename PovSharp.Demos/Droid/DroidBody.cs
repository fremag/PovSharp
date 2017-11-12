using PovSharp.Csg;
using PovSharp.Objects;

namespace PovSharp.Demos.Droid
{
    public class DroidBody : CsgUnion
    {
        public DroidBody()
        {
            Add(new Sphere());
        }
    }
}
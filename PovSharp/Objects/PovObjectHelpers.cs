using PovSharp.Core;

namespace PovSharp.Objects
{
    public static class PovObjectHelpers
    {
        public static PovObject _Obj(this AbstractPovObject obj) => new PovObject(obj);
    }
}
using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Transformations
{
    public static class TransformationHelpers
    {
        public static AbstractPovObject Translate(this AbstractPovObject povObject, PovVector v) 
        {
            povObject.AddModifiers(new Translation(v));
            return povObject;
        }
        public static AbstractPovObject Translate(this AbstractPovObject povObject, PovNumber x, PovNumber y, PovNumber z ) 
        {
            povObject.AddModifiers(new Translation(x, y, z));
            return povObject;
        }
        public static AbstractPovObject Rotate(this AbstractPovObject povObject, PovVector v) 
        {
            povObject.AddModifiers(new Rotation(v));
            return povObject;
        }
        public static AbstractPovObject Rotate(this AbstractPovObject povObject, PovNumber x, PovNumber y, PovNumber z ) 
        {
            povObject.AddModifiers(new Rotation(x, y, z));
            return povObject;
        }
        public static AbstractPovObject Scale(this AbstractPovObject povObject, PovVector v) 
        {
            povObject.AddModifiers(new Scale(v));
            return povObject;
        }
        public static AbstractPovObject Scale(this AbstractPovObject povObject, PovNumber x, PovNumber y, PovNumber z ) 
        {
            povObject.AddModifiers(new Scale(x, y, z));
            return povObject;
        }
    }
}
using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Transformations
{
    public static class TransformationHelpers
    {
        public static T Translate<T>(this T povObject, PovVector v) where T : AbstractPovObject
        {
            povObject.AddModifiers(new Translation(v));
            return povObject;
        }
        public static T Translate<T>(this T povObject, PovNumber x, PovNumber y, PovNumber z) where T : AbstractPovObject
        {
            povObject.AddModifiers(new Translation(x, y, z));
            return povObject;
        }
        public static T TranslateX<T>(this T povObject, PovNumber deltaX) where T : AbstractPovObject
        => povObject.Translate(deltaX, 0, 0);

        public static T TranslateY<T>(this T povObject, PovNumber deltaY) where T : AbstractPovObject
        => povObject.Translate(0, deltaY, 0);

        public static T TranslateZ<T>(this T povObject, PovNumber deltaZ) where T : AbstractPovObject
        => povObject.Translate(0, 0, deltaZ);

        public static T Rotate<T>(this T povObject, PovVector v) where T : AbstractPovObject
        {
            povObject.AddModifiers(new Rotation(v));
            return povObject;
        }
        public static T Rotate<T>(this T povObject, PovNumber x, PovNumber y, PovNumber z) where T : AbstractPovObject
        {
            povObject.AddModifiers(new Rotation(x, y, z));
            return povObject;
        }

        public static T RotateX<T>(this T povObject, PovNumber angleX) where T : AbstractPovObject
        {
            return povObject.Rotate(angleX, 0, 0);
        }
        public static T RotateY<T>(this T povObject, PovNumber angleY) where T : AbstractPovObject
        => povObject.Rotate(0, angleY, 0);

        public static T RotateZ<T>(this T povObject, PovNumber angleZ) where T : AbstractPovObject
        => povObject.Rotate(0, 0, angleZ);

        public static T Scale<T>(this T povObject, PovVector v) where T : AbstractPovObject
        {
            povObject.AddModifiers(new Scale(v));
            return povObject;
        }
        public static T Scale<T>(this T povObject, PovNumber x, PovNumber y, PovNumber z) where T : AbstractPovObject
        {
            povObject.AddModifiers(new Scale(x, y, z));
            return povObject;
        }
        public static T ScaleX<T>(this T povObject, PovNumber scaleX) where T : AbstractPovObject
        => povObject.Scale(scaleX, 0, 0);
        public static T ScaleY<T>(this T povObject, PovNumber scaleY) where T : AbstractPovObject
        => povObject.Scale(0, scaleY, 0);
        public static T ScaleZ<T>(this T povObject, PovNumber scaleZ) where T : AbstractPovObject
        => povObject.Scale(0, 0, scaleZ);
    }
}
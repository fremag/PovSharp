using PovSharp.Csg;
using PovSharp.Objects;
using PovSharp.Core;
using PovSharp.Values;
using System;
using PovSharp.Transformations;
using PovSharp.Textures;

namespace PovSharp.Demos.Droid
{
    public class DroidHead : CsgUnion
    {
        const double hNeck = 0.13;
        const double hSkull = 0.61;
        const double rSkull = 0.5;
        const double yTopRing = 0.46;
        const double yMiddleRing = 0.38;
        const double hTopRing = 0.08;
        const double hBottomRing = 0.04;
        const double rBigEye = 0.12;
        const double yBigEye = 0.31;
        const double rSmallEye = 0.08;
        const double ySmallEye = 0.21;
        const double aSmallEye = -25;

        public double Heigth => hSkull + hNeck;
        public DroidHead(Pigment mainPigment, Pigment decoPigmentMajor, Pigment decoPigmentMinor)
        {
            double yBottomSkull = 2 * rSkull - hSkull;
            double rBottomSkull = Math.Sqrt(Math.Pow(rSkull, 2) - Math.Pow(hSkull - rSkull, 2));

            #region SkullNeck
            var skull = new CsgDifference(
                new Sphere() { Center = _V(0, rSkull, 0), Radius = rSkull })
                .Add(new Box() { Corner1 = _V(-1), Corner2 = _V(1, yBottomSkull, 1) });
            Local(nameof(skull), skull);

            var neck = new CsgDifference(
                new Cone()
                {
                    BaseRadius = rBottomSkull,
                    BasePoint = _V(0, yBottomSkull, 0),
                    CapPoint = _V(0, yBottomSkull - 0.5, 0)
                })
                .Add(new Box() { Corner1 = _V(-1, yBottomSkull - hNeck, -1), Corner2 = _V(1, -1, 1) })
                ;
            Local(nameof(neck), neck);
            #endregion
            #region Deco
            var smallDecoBox = new Box() { Corner1 = _V(-1, 0, -1), Corner2 = _V(1, 1, 1) };
            Local(nameof(smallDecoBox), smallDecoBox);

            var topRing = smallDecoBox.Obj().ScaleY(hTopRing).TranslateY(yTopRing);
            var bottomRing = smallDecoBox.Obj().ScaleY(hBottomRing);

            var middleRing = new CsgDifference(
                    smallDecoBox.Obj()
                    .ScaleY(hBottomRing)
                    .TranslateY(yMiddleRing))
                .Add(new Cylinder { BasePoint =  yBigEye * _Y, CapPoint = yBigEye * _Y + 2 * _Z, Radius = rBigEye * 1.2 })
                ;

            var minorDecoElements = new CsgUnion()
                .Add(topRing)
                .Add(bottomRing)
                .TranslateY(yBottomSkull)
            ;

            var minorDeco = new CsgIntersection()
                .Add(new Sphere() { Center = rSkull * _Y, Radius = rSkull * 1.0005 })
                .Add(minorDecoElements)
                .AddModifiers(decoPigmentMinor);
            ;

            var miscDeco = new CsgUnion();
            for (int i = 0; i < 10; i++)
            {
                miscDeco.Add(
                    smallDecoBox.Obj().Scale(1, hTopRing, 0.02).RotateY(30 * i+15), 
                    smallDecoBox.Obj().Scale(1, hTopRing, 0.05).RotateY(30 * i));
            }

            miscDeco.TranslateY(hBottomRing);

            var majorDecoElements = new CsgUnion().Add(
                middleRing, 
                miscDeco)
                .TranslateY(yBottomSkull)
            ;
            var majorDeco = new CsgIntersection()
                .Add(new Sphere() { Center = rSkull * _Y, Radius = rSkull * 1.0005 })
                .Add(majorDecoElements)
                .AddModifiers(decoPigmentMajor);
            ;
            #endregion

            double zBigEye = Math.Sqrt(Math.Pow(rSkull, 2) - Math.Pow(yBigEye, 2));
            var bigEye = new Sphere { Center = _V(0, yBigEye + yBottomSkull, zBigEye), Radius = rBigEye }
                .AddModifiers(new Pigment(_Black));
            double zSmallEye = Math.Sqrt(Math.Pow(rSkull, 2) - Math.Pow(ySmallEye, 2));
            var smallEye = new Sphere { Center = _V(0, ySmallEye + yBottomSkull, zSmallEye), Radius = rSmallEye }
                .RotateY(aSmallEye)
                .AddModifiers(new Pigment(_Black));

            Add(bigEye, smallEye, majorDeco, minorDeco, skull, neck);
            AddModifiers(mainPigment);
            this.TranslateY(-yBottomSkull + hNeck);
        }
    }
}
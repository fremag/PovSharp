using PovSharp.Core;
using PovSharp.Csg;
using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Transformations;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Scenes
{
    public class PovEngineTests : AbstractPovEngineTests
    {
        public PovEngineTests()
        {
        }

        public void AddBlueSphere()
        {
            var sphere = new Sphere();
            sphere.AddModifiers(new Pigment() { Color = new PovColor(0, 0, 1) });
            scene.Declare("MySphere", sphere);
            scene.Add(sphere);
        }

        [Fact(Skip = "true")]
        public void BasicSceneTest()
        {
            scene.Name = "TestBlueSphere";
            AddBlueSphere();
            var path = engine.Render(scene, options, false);
        }

        [Fact(Skip = "true")]
        public void DemoObjectsTest()
        {
            scene.Name = "DemoObjects";
            AddBlueSphere();

            var cone = new Cone()
                .AddModifiers(new Pigment() { Color = _Magenta })
                .Translate(2, 0, 0);
            scene.Add(cone);

            var cylinder = new Cylinder()
                .AddModifiers(new Pigment() { Color = _Cyan })
                .Translate(-2, 0, 0);
            scene.Add(cylinder);

            var ovus = new Ovus()
                .AddModifiers(new Pigment() { Color = _Yellow })
                .Translate(0, 0, 2);
            scene.Add(ovus);

            var torus = new Torus()
                .AddModifiers(new Pigment() { Color = _Green })
                .Translate(0, 0, 5);
            scene.Add(torus);

            var box = new Box()
                .AddModifiers(new Pigment() { Color = _Red })
                .Translate(0, 0, -2);
            scene.Add(box);

            var plane = new Plane() { Distance = -1 };
            plane.AddModifiers(new Pigment() { Color = _RGB(1, 0.5, 0.25) });
            scene.Add(plane);

            var lathe = new Lathe()
                .Add(2, 0).Add(3, 0).Add(3, 1).Add(2, 5).Add(2, 0)
                .AddModifiers(new Pigment() { Color = _RGB(1, 1, 0.5) })
                .Scale(0.25, 0.25, 0.25)
                .Translate(2, 0, -2);
            scene.Add(lathe);

            var sor = new SurfaceOfRevolution()
                .Add(2, 0).Add(3, 0).Add(1, 1).Add(2, 5).Add(2, 0)
                .AddModifiers(new Pigment() { Color = _RGB(0.5, 1, 0.5) })
                .Scale(0.25, 0.25, 0.25)
                .Translate(2, 0, 2);
            scene.Add(sor);

            var path = engine.Render(scene, options, false);
        }
        [Fact(Skip = "true")]
        public void CsgDemoTest()
        {
            scene.Name = "TestCsg";

            var cylinderX = scene.Declare("cylinderX", new Cylinder() { BasePoint = new PovVector(-2, 0, 0), CapPoint = new PovVector(2, 0, 0), Radius = 0.5 });
            var cylinderY = scene.Declare("cylinderY", new Cylinder() { BasePoint = new PovVector(0, -2, 0), CapPoint = new PovVector(0, 2, 0), Radius = 0.5 });
            var cylinderZ = scene.Declare("cylinderZ", new Cylinder() { BasePoint = new PovVector(0, 0, -2), CapPoint = new PovVector(0, 0, 2), Radius = 0.5 });

            var csgUnion = new CsgUnion()
                .Add(cylinderX)
                .Add(cylinderY)
                .Add(cylinderZ)
                .AddModifiers(new Pigment(_Red));
            scene.Add(csgUnion);

            var csgIntersection = new CsgIntersection()
                .Add(cylinderX)
                .Add(cylinderY)
                .Add(cylinderZ)
                .AddModifiers(new Pigment(_Green))
                .Translate(0, 0, 3);

            scene.Add(csgIntersection);

            var csgDifference = new CsgDifference(cylinderX)
                .Add(cylinderY)
                .Add(cylinderZ)
                .AddModifiers(new Pigment(_Blue))
                .Translate(3, 0, -3);

            scene.Add(csgDifference);
            var path = engine.Render(scene, options, false);
        }

        [Fact(Skip = "true")]
        public void SplineDemoTest()
        {
            scene.Name = "TestSpline";

            var n = scene.Declare("myNumber", new PovNumber(0.5));
            var v = scene.Declare("myVector", new PovVector(1, 0, 3));

            var spline = new PovSpline("MySpline") { SplineType = PovSpline.SplineTypeName.natural_spline }
                           .Add(0, new PovVector(0))
                           .Add(n, v)
                           .Add(1, new PovVector(3, 0, 1));

            scene.Declare(spline);
            const int N = 50;
            for (int i = 0; i < N; i++)
            {
                var sphere = new Sphere()
                {
                    Center = spline[i * 1.0 / N],
                    Radius = 0.1
                }
                    .AddModifiers(new Pigment(_RGB((i / (double)N + 1) / 2, 0, 0)));
                scene.Add(sphere);
            }
            var path = engine.Render(scene, options, false);
        }

        [Fact(Skip="true")]
        public void SphereSweepDemoTest()
        {
            scene.Name = "TestSphereSweep";

            var n = scene.Declare("myNumber", new PovNumber(0.5));
            var v = scene.Declare("myVector", new PovVector(1, 0, 3));

            var sphereSweep = scene.Declare("MySphereSweep", new SphereSweep() { SplineType = SphereSweep.CubicSpline }
                            .Add(new PovVector(0), 0.5)
                            .Add(new PovVector(-1), 1)
                            .Add(new PovVector(1), 0.25)
                            .Add(v, n)
                            .Add(new PovVector(3, 0, 1), 1)
                            .AddModifiers(new Pigment(_Red)));
            scene.Add(sphereSweep);
            var path = engine.Render(scene, options, false);
        }
    }
}
# PovSharp
[![Build status](https://ci.appveyor.com/api/projects/status/qqe7udujs8745i3e?svg=true)](https://ci.appveyor.com/project/fremag/povsharp)


[![codecov](https://codecov.io/gh/fremag/PovSharp/branch/master/graph/badge.svg)](https://codecov.io/gh/fremag/PovSharp)

Experimental area to test .Net Core and Visual Studio Code.

C# wrapper for [Pov Ray](http://www.povray.org)

Pov-Ray has its own [Scene Description Language](http://www.povray.org/documentation/3.7.0/r3_3.html#r3_3)
Unfortunately, I couldn't find a modern editor to write scenes.

Modern = auto completion, refactoring (rename objects for instance), code navigation, find object references.

I can't write such an editor but I know Visual Code exists for both Windows and Linux.
But there is no extension for PovRay (and I can't write one myself)

So I decided to use Visual Code to edit C# and wrap SDL objects in C#.

For instance, instead of writing: 
```code
camera {
 location <7, 7, 7>
 look_at <0, 0, 0>
}

light_source {
 <5, 5, 5>, rgb <1, 1, 1>
}

#declare MySphere = sphere {
    <0, 0, 0>, 1
    pigment {
        color rgb <1, 1, 1>
    }
};

MySphere
```

I use C#:
```C#
    PovScene scene = new PovScene();
    scene.Add(new Camera() {Location = new PovVector(7), LookAt = new PovVector(0)});
    scene.Add(new Light());

    var sphere = new Sphere();
    sphere.AddModifiers(new Pigment() {Color = new PovColor(1)});
    scene.Declare("MySphere", sphere);
    scene.Add(sphere);
```

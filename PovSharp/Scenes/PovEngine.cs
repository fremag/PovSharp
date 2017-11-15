using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PovSharp.Scenes
{
    public class PovEngine
    {
        private readonly string PovExtension = "pov";

        public PovEngine(string exePath)
        {
            ExePath = exePath;
        }

        public PovEngine(string exePath, string sceneExportPath) : this(exePath)
        {
            SceneExportPath = sceneExportPath;
        }

        string ExePath { get; } = "";
        string SceneExportPath { get; } = Path.GetTempPath();

        public (string, Process) Render(PovScene scene, PovEngineOptions options, bool exitWhenDone = true)
        {
            var sceneFile = Path.ChangeExtension(scene.Name, PovExtension);
            var filePath = Path.Combine(SceneExportPath, sceneFile);

            File.WriteAllLines(filePath, Indent(scene.ToPovCode()));

            var args = new List<string>(options.GetPovArgs());
            args.Add($"Input_File_Name=\"{filePath}\"");
            if (exitWhenDone)
            {
                args.Add("/exit");
            }
            var process = Process.Start(ExePath, string.Join(" ", args));

            return (filePath, process);
        }

        public static IEnumerable<string> Indent(IEnumerable<string> povCodes)
        {
            int idx = 0;
            foreach (var povCode in povCodes)
            {
                string[] lines = povCode.Split("\n");
                foreach (var line in lines)
                {
                    var trimLine = line.TrimStart();
                    if(string.IsNullOrEmpty(trimLine)) 
                    {
                        continue;
                    }
                    idx -= trimLine.Count(f => f == '}');
                    var newLine = string.Concat(Enumerable.Repeat("\t", idx).Append(trimLine));
                    idx += trimLine.Count(f => f == '{');
                    yield return newLine;
                }
            }
        }
    }
}
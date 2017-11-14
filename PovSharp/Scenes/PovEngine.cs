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

        public (string, Process) Render(PovScene scene, PovEngineOptions options, bool exitWhenDone=true)
        {
            var sceneFile = Path.ChangeExtension(scene.Name, PovExtension);
            var filePath =  Path.Combine(SceneExportPath, sceneFile);

            File.WriteAllLines(filePath, scene.ToPovCode());

            var args = new List<string>(options.GetPovArgs());
            args.Add($"Input_File_Name=\"{filePath}\"") ;
            if( exitWhenDone ) 
            {
                args.Add("/exit");
            }
            var process = Process.Start(ExePath, string.Join(" ", args));
            
            return (filePath, process);
        }
    }
}
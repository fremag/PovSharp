using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace PovSharp.Scenes
{
    public class PovEngineOptions
    {
        public PovEngineOptions()
        {
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var d = prop.GetCustomAttribute<DefaultValueAttribute>();
                if (d != null) 
                {
                    prop.SetValue(this, d.Value);
                }
            }
        }

        [DefaultValue(1024)]
        public int Height { get; set; }
        [DefaultValue(1280)]
        public int Width { get; set; }

        [DefaultValue(32)]
        [PovArgumentName("Preview_Start_Size")]
        public int PreviewStartSize { get; set; }
        [DefaultValue(2)]
        [PovArgumentName("Preview_End_Size")]
        public int PreviewEndSize { get; set; }

        public string[] GetPovArgs() 
        {
            List<string> args = new List<string>();
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var d = prop.GetCustomAttribute<DefaultValueAttribute>();
                if (d != null) 
                {
                    var defaultValue  = d.Value;
                    var propValue = prop.GetValue(this);
                    if(! object.Equals(defaultValue, propValue) ) 
                    {
                        string argName = prop.Name;
                        var nameAttr = prop.GetCustomAttribute<PovArgumentNameAttribute>();
                        if( nameAttr != null) {
                            argName = nameAttr.Name; 
                        }
                        args.Add(argName + "=" + propValue);
                    }
                }
            }
            return args.ToArray();
        }
    }

    public class PovArgumentNameAttribute : Attribute
    {   
        public string Name {get;}
        public PovArgumentNameAttribute(string name)
        {
            Name = name;
        }
    }
}
using PluginIface;
using System;
using System.IO;
using System.Reflection;

namespace RSDN_ORG
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("plugins", "*.dll");

            foreach (string item in files)
            {
                Assembly asm = Assembly.LoadFrom(item);

                foreach (Type t in asm.GetExportedTypes())
                {
                    if (typeof(IPlugin).IsAssignableFrom(t))
                    {
                        IPlugin pi = (IPlugin)asm.CreateInstance(t.FullName);
                        Console.WriteLine(pi.GetName());
                    }
                }
            }
            Console.ReadLine();
        }
    }
}

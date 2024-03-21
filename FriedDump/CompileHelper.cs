using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriedDump
{
    public static class CompileHelper
    {
        public static void Compile(bool showConsole,bool run,params string[] sources) 
        {
            CSharpCodeProvider c = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();

            cp.ReferencedAssemblies.Add("system.dll");
            //cp.ReferencedAssemblies.Add("system.collections.generic.dll");
            //cp.ReferencedAssemblies.Add("system.dll");
            //////cp.ReferencedAssemblies.Add("system.xml.dll");
            //////cp.ReferencedAssemblies.Add("system.data.dll");
            cp.ReferencedAssemblies.Add("system.windows.forms.dll");
            cp.ReferencedAssemblies.Add("system.core.dll");
            cp.ReferencedAssemblies.Add("system.linq.dll");
            //cp.ReferencedAssemblies.Add("system.drawing.dll");

            //cp.CompilerOptions = "/t:library";
            if (showConsole)
                cp.CompilerOptions = "/target:exe ";
            else
                cp.CompilerOptions = "/target:winexe ";


            cp.CompilerOptions += $"/win32icon:{Application.StartupPath}\\fried.ico ";

            cp.GenerateInMemory = true;
            cp.GenerateExecutable = true;
            cp.TreatWarningsAsErrors = false;
            cp.WarningLevel = 3;

            string path = /*AppDomain.CurrentDomain.BaseDirectory +*/ "binary";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            cp.OutputAssembly = $"{path}/test.scr";

            //CompilerResults cr = icc.CompileAssemblyFromSource(cp, Code_for_function);
            CompilerResults cr = c.CompileAssemblyFromSource(cp, sources.ToArray());

            if (cr.Errors.Count > 0)
            {
                //MessageBox.Show("ERROR: " + cr.Errors[0].ErrorText,
                //   "Error Generating code", MessageBoxButtons.OK,
                //   MessageBoxIcon.Error);
                foreach (CompilerError error in cr.Errors)
                {
                    if (error.IsWarning)
                    {
                        MessageBox.Show("WARNING: " + error.ErrorText,
                                        "Warning Generating code", MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("ERROR: " + error.ErrorText,
                                        "Error Generating code", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            //System.Reflection.Assembly a = cr.CompiledAssembly;
            //object o = a.CreateInstance("CodeGenarator.CodeGenarator");

            //Type t = o.GetType();
            //MethodInfo mi = t.GetMethod("Main");

            //object s = mi.Invoke(o, null);

            if (run)
            { 
                System.Diagnostics.ProcessStartInfo PSI = new System.Diagnostics.ProcessStartInfo();
                PSI.FileName = $"{Application.StartupPath}\\{path}\\test.scr";
                PSI.WorkingDirectory = Application.StartupPath;
                PSI.Arguments = "lol oop woop";
                System.Diagnostics.Process.Start(PSI);
            }
        }
    }
}

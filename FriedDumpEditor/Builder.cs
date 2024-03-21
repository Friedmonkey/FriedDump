using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FriedDumpEditor
{
    public class Builder
    {
        public static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FriedDump");

        public static (string, string) FileToCsString(string filepath)
        {
            if (!string.IsNullOrWhiteSpace(filepath) && File.Exists(filepath))
            {
                // Read the bytes of the file
                byte[] fileBytes = File.ReadAllBytes(filepath);


                // Convert each byte to its hexadecimal representation
                var hexString = "0x" + BitConverter.ToString(fileBytes).Replace("-", ", 0x");


                var name = Path.GetFileName(filepath);

                return (name, hexString);
            }
            return ("/error/", "0x00");
        }
        public static void Build(string output,List<string> Files)
        {
            //var (_, exeString) = FileToCsString(Assembly.GetExecutingAssembly().Location);

            var (_, exeString) = FileToCsString(Path.Combine(path,"Editor.exe"));
            var (_, iconString) = FileToCsString(Path.Combine(path,"fried.ico"));



            // Complete the C# code with the hexadecimal string
            //string cSharpCode = $"namespace CompiledName {{ public partial class CompiledClass {{ public static readonly byte[] exeBytes = {{ {exeString} }}; }} }}";

            string exeCode = $"namespace CompiledName {{ public partial class CompiledClass {{ public static readonly byte[] exeBytes = {{ {exeString} }}; }} }}";
            string iconCode = $"namespace CompiledName {{ public partial class CompiledClass {{ public static readonly byte[] iconBytes = {{ {iconString} }}; }} }}";


            var fileClass = """"
namespace CompiledName
{
    public class FFile
    {
        public byte[] raw { get; set; }
        public string name { get; set; }
    }
}
"""";

            var files = """"
using System.Collections.Generic;
namespace CompiledName
{
    public partial class CompiledClass
    {
        public static readonly List<FFile> AllFiles = new List<FFile>()
        {
"""";
            foreach (var file in Files)
            {
                var (name, byteString) = FileToCsString(file);
                files += $"new FFile() {{ name = \"{name}\", raw = new byte[]{{ {byteString} }}, }},";
            }
            files += """"
            
        };
    }
}
"""";


            //compiling
            var main = """" 
using System;
using System.IO;
using System.Windows.Forms;
//using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;
namespace CompiledName
{
    public partial class CompiledClass
    {
        public static void Edit(string file, string[] args)
        {
            ProcessStartInfo PSI = new ProcessStartInfo();
            PSI.FileName = path + "\\Editor.exe";
            PSI.WorkingDirectory = Application.StartupPath;
            PSI.Arguments += file;
            PSI.Arguments += " ";
            PSI.Arguments += string.Join(" ",args);
        
            //MessageBox.Show("arguments: "+PSI.Arguments);

            Process.Start(PSI);
        }
        public static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FriedDump");

        public static void Main(string[] args)
        {
            var path2 = path+"\\dumploc.txt";
            if (Directory.Exists(path) && File.Exists(path2))
            {
                var loc = File.ReadAllText(path2);
                //MessageBox.Show("Dumploc found! :"+loc);
                if (Directory.Exists(loc))
                { 
                    foreach (FFile file in AllFiles)
                    {
                        File.WriteAllBytes(Path.Combine(loc,file.name),file.raw);
                    }
                }
                File.Delete(path2);
                Application.Exit();
                return;
            }
            //MessageBox.Show("Hello world!");
            if (!Directory.Exists(path) || !File.Exists(path + "\\Editor.exe"))
            {
                //var res = MessageBox.Show("FriedDumpEditor is not installed, want to Install now?","Install?",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Exclamation);
                //if (res == DialogResult.Yes) 
                {
                    var path3 = path+"\\Editor.exe";
                    var path4 = path+"\\EditorCopy.exe";
                    var path5 = path+"\\fried.icon";
                    Directory.CreateDirectory(path);
                    File.WriteAllBytes(path3,exeBytes);
                    File.WriteAllBytes(path4,exeBytes);
                    File.WriteAllBytes(path5,iconBytes);
                    //MessageBox.Show("FriedDumpEditor has been installed correctly, launching now!");
                }
            }
            if (!Directory.Exists(path) || !File.Exists(path + "\\Editor.exe"))
            {
                MessageBox.Show("No suitable editor for this file found!");
                Application.Exit();
                return;
            }
            Edit(Assembly.GetExecutingAssembly().Location,args);
        }
    }
}
"""";
            CompileHelper.Compile(output,showConsole: false, run: false, fileClass, files, exeCode, iconCode, main);

            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine();
            //Console.WriteLine("Code finished compiling for real ong press key to exit");
            //Console.ReadLine();
        }
    }
}

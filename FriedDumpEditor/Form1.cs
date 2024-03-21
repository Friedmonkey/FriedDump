using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Collections.Specialized;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Security.Cryptography;

namespace FriedDumpEditor
{
    public partial class Form1 : Form
    {
        public static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FriedDump");
        public static string tempPath = "";
        public static string file = "";
        public static string hash = "";
        public static bool ChangesMade = false;
        public Form1(string[] args)
        {
            InitializeComponent();

            if (args.Length < 1)
            {
                MessageBox.Show("Dump not working");
                Application.Exit();
                return;
            }

            tempPath = Path.Combine(Path.GetTempPath(), ".FriedDump", Path.GetFileNameWithoutExtension(args[0]) + "_"+Path.GetRandomFileName());
            Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), ".FriedDump"));
            file = args[0];
            GetData();
            hash = getFolderHash(tempPath);
            tmrPolling.Start();
            this.TopMost = true;
            this.Focus();
            this.TopMost = false;

        }
        //public void dat() 
        //{
        //}
        public string getFolderHash(string folderToLookIn) 
        {
            string input = "empty";
            foreach (var file in Directory.EnumerateFiles(folderToLookIn))
            {
                input += file;
            }
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
        public void GetData() 
        {
            tmrPolling.Stop();
            //MessageBox.Show("getting data");

            flowFolder.Controls.Clear();
            var dumploc = tempPath;
            Directory.CreateDirectory(dumploc);


            var path2 = path + "\\dumploc.txt";

            File.WriteAllText(path2, dumploc);


            ProcessStartInfo PSI = new ProcessStartInfo();
            PSI.FileName = file;
            PSI.WorkingDirectory = Path.GetDirectoryName(file);
            Process proc = Process.Start(PSI);
            if (proc != null)
            {
                // Wait for the process to exit
                proc.WaitForExit();

                // Continue with the rest of your code after the process has exited
                foreach (string file in Directory.EnumerateFiles(dumploc))
                {
                    ItemFile item = new ItemFile()
                    {
                        FileName = file,
                        Icon = GetFileIcon(file),
                        //action = GetData,
                        //temp = tempPath,
                    };
                    flowFolder.Controls.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Dump not working 2");
            }
            tmrPolling.Start();
            //this.TopMost = true;
            //this.Focus();
            //this.TopMost = false;
        }

        private Image GetFileIcon(string filePath)
        {
            Icon icon = Icon.ExtractAssociatedIcon(filePath);
            return icon?.ToBitmap();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ChangesMade)
            {
                //MessageBox.Show("you might have unsaved changes!");
            }
        }

        private void flowFolder_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //MessageBox.Show("data");
                var fileData = e.Data.GetData(DataFormats.FileDrop);
                //MessageBox.Show($"filedata:{fileData}");
                if (fileData is string[] fdat)
                {
                    StringCollection files = new StringCollection();
                    foreach (var f in fdat)
                    {
                        files.Add(f);
                    }
                    //MessageBox.Show($"fdat:{string.Join(" ", fdat)}");
                    //MessageBox.Show($"files:{files}");

                    if (files != null)
                    {
                        //MessageBox.Show("files");
                        foreach (var file in files)
                        {
                            //MessageBox.Show("loop");
                            ChangesMade = true;
                            var path2 = Path.Combine(tempPath, Path.GetFileName(file));
                            //MessageBox.Show($"copying {file} to {path2}");
                            File.Copy(file, path2);
                        }
                        //GetData();
                        return;
                    }
                }
            }
            //label1.Text = e.Data.GetData(DataFormats.StringFormat, true).ToString();
        }

        private void flowFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                grbxFiles.BackColor = Color.DarkGray;
            }
            else
            {
                e.Effect = DragDropEffects.None;
                grbxFiles.BackColor = Color.White;
            }
        }

        private void flowFolder_DragLeave(object sender, EventArgs e)
        {
            grbxFiles.BackColor = Color.White;
        }

        private void bttnSave_Click(object sender, EventArgs e)
        {
            if (ChangesMade)
            {
                Builder.Build(file, Directory.EnumerateFiles(tempPath).ToList());
            }
            else
                MessageBox.Show("you dont have any new changes!");
        }

        private void tmrPolling_Tick(object sender, EventArgs e)
        {
            var hash2 = getFolderHash(tempPath);
            if (hash2 != hash)
            {
                //MessageBox.Show($"{hash} vs {hash2}");
                tmrPolling.Stop();
                Builder.Build(file, Directory.EnumerateFiles(tempPath).ToList());
                GetData();
                hash = getFolderHash(tempPath);
                tmrPolling.Start();
            }
        }
    }
}

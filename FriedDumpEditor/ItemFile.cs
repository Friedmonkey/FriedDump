using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriedDumpEditor
{
    public partial class ItemFile : UserControl
    {
        //public Action action { get; set; }

        private string filename = "";
        public string FileName 
        {
            get 
            {
                return filename;
            }
            set 
            {
                lblFilename.Text = Path.GetFileName(value); 
                filename = value;
            } 
        }

        public Image Icon
        {
            get => picbxIcon.Image;
            set => picbxIcon.Image = value;
        }
        public ItemFile()
        {
            InitializeComponent();

        }

        private void ItemFile_MouseDown(object sender, MouseEventArgs e)
        {
            StringCollection filePath = new() { filename };
            DataObject dataObject = new DataObject();

            dataObject.SetFileDropList(filePath);

            //var watcher = new FileSystemWatcher(Path.GetDirectoryName(filename));
            //watcher.Renamed += Watcher_Renamed;

            //watcher.EnableRaisingEvents = true;

            this.DoDragDrop(dataObject, DragDropEffects.Move);
        }

        //private void Watcher_Renamed(object sender, RenamedEventArgs e)
        //{
        //    MessageBox.Show("watched");

        //    // Check if the change type is Renamed
        //    if (e.ChangeType == WatcherChangeTypes.Renamed)
        //    {
        //        MessageBox.Show("watched success!");

        //        // Handle the file moved event
        //        //Console.WriteLine($"File moved: {e.FullPath} to {e.Name}");
        //        // Call your custom method or perform any other actions
        //        action.Invoke();
        //    }
        //}
    }
}

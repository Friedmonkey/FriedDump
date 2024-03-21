using SharpShell.SharpPropertySheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriedDump.FriedDumpShellExtention
{
    public partial class PropertyPage : SharpPropertyPage
    {
        public PropertyPage()
        {
            InitializeComponent();

            PageTitle = "File Times";
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            //  Store the file path.
            filePath = parent.SelectedItemPaths.First();

            //  Load the file times into the dialog.
            LoadFileTimes();
        }

        protected override void OnPropertySheetApply()
        {
            //  Save the changes.
            SaveFileTimes();
        }

        protected override void OnPropertySheetOK()
        {
            //  Save the changes.
            SaveFileTimes();
        }

        private void LoadFileTimes()
        {
            // ...
        }

        private void SaveFileTimes()
        {
            // ...
        }

        private string filePath;
    }
}

namespace FriedDumpEditor
{
    partial class ItemFile
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picbxIcon = new System.Windows.Forms.PictureBox();
            this.lblFilename = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picbxIcon
            // 
            this.picbxIcon.BackColor = System.Drawing.Color.LightGray;
            this.picbxIcon.Location = new System.Drawing.Point(12, 13);
            this.picbxIcon.Name = "picbxIcon";
            this.picbxIcon.Size = new System.Drawing.Size(123, 104);
            this.picbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbxIcon.TabIndex = 0;
            this.picbxIcon.TabStop = false;
            this.picbxIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ItemFile_MouseDown);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(12, 124);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(63, 13);
            this.lblFilename.TabIndex = 1;
            this.lblFilename.Text = "ExampleFile";
            this.lblFilename.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ItemFile_MouseDown);
            // 
            // ItemFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.picbxIcon);
            this.Name = "ItemFile";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ItemFile_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picbxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picbxIcon;
        private System.Windows.Forms.Label lblFilename;
    }
}

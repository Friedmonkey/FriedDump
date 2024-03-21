namespace FriedDumpEditor
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grbxFiles = new System.Windows.Forms.GroupBox();
            this.flowFolder = new System.Windows.Forms.FlowLayoutPanel();
            this.bttnSave = new System.Windows.Forms.Button();
            this.tmrPolling = new System.Windows.Forms.Timer(this.components);
            this.grbxFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbxFiles
            // 
            this.grbxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbxFiles.Controls.Add(this.flowFolder);
            this.grbxFiles.Location = new System.Drawing.Point(12, 39);
            this.grbxFiles.Name = "grbxFiles";
            this.grbxFiles.Size = new System.Drawing.Size(676, 409);
            this.grbxFiles.TabIndex = 0;
            this.grbxFiles.TabStop = false;
            this.grbxFiles.Text = "Files inside ...";
            // 
            // flowFolder
            // 
            this.flowFolder.AllowDrop = true;
            this.flowFolder.AutoScroll = true;
            this.flowFolder.BackColor = System.Drawing.Color.White;
            this.flowFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowFolder.Location = new System.Drawing.Point(3, 16);
            this.flowFolder.Name = "flowFolder";
            this.flowFolder.Size = new System.Drawing.Size(670, 390);
            this.flowFolder.TabIndex = 0;
            this.flowFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowFolder_DragDrop);
            this.flowFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowFolder_DragEnter);
            this.flowFolder.DragLeave += new System.EventHandler(this.flowFolder_DragLeave);
            // 
            // bttnSave
            // 
            this.bttnSave.Location = new System.Drawing.Point(577, 10);
            this.bttnSave.Name = "bttnSave";
            this.bttnSave.Size = new System.Drawing.Size(111, 23);
            this.bttnSave.TabIndex = 1;
            this.bttnSave.Text = "Save";
            this.bttnSave.UseVisualStyleBackColor = true;
            this.bttnSave.Click += new System.EventHandler(this.bttnSave_Click);
            // 
            // tmrPolling
            // 
            this.tmrPolling.Interval = 500;
            this.tmrPolling.Tick += new System.EventHandler(this.tmrPolling_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 460);
            this.Controls.Add(this.bttnSave);
            this.Controls.Add(this.grbxFiles);
            this.Name = "Form1";
            this.Text = "FriedDumpEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.grbxFiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbxFiles;
        private System.Windows.Forms.FlowLayoutPanel flowFolder;
        private System.Windows.Forms.Button bttnSave;
        private System.Windows.Forms.Timer tmrPolling;
    }
}


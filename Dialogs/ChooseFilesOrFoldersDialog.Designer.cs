﻿namespace Will_ExtRecover.Dialogs
{
    partial class ChooseFilesOrFoldersDialog
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenFilebutton = new System.Windows.Forms.Button();
            this.FolderBrowserbutton = new System.Windows.Forms.Button();
            this.Aboutbutton = new System.Windows.Forms.Button();
            this.Acceptbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox1.Location = new System.Drawing.Point(194, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(493, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "要处理的文件或文件夹:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // OpenFilebutton
            // 
            this.OpenFilebutton.Cursor = System.Windows.Forms.Cursors.Default;
            this.OpenFilebutton.Location = new System.Drawing.Point(477, 63);
            this.OpenFilebutton.Name = "OpenFilebutton";
            this.OpenFilebutton.Size = new System.Drawing.Size(101, 33);
            this.OpenFilebutton.TabIndex = 2;
            this.OpenFilebutton.Text = "打开文件...";
            this.OpenFilebutton.UseVisualStyleBackColor = true;
            this.OpenFilebutton.Click += new System.EventHandler(this.OpenFilebutton_Click);
            // 
            // FolderBrowserbutton
            // 
            this.FolderBrowserbutton.Location = new System.Drawing.Point(584, 63);
            this.FolderBrowserbutton.Name = "FolderBrowserbutton";
            this.FolderBrowserbutton.Size = new System.Drawing.Size(103, 33);
            this.FolderBrowserbutton.TabIndex = 3;
            this.FolderBrowserbutton.Text = "打开文件夹...";
            this.FolderBrowserbutton.UseVisualStyleBackColor = true;
            this.FolderBrowserbutton.Click += new System.EventHandler(this.FolderBrowserbutton_Click);
            // 
            // Aboutbutton
            // 
            this.Aboutbutton.Location = new System.Drawing.Point(12, 268);
            this.Aboutbutton.Name = "Aboutbutton";
            this.Aboutbutton.Size = new System.Drawing.Size(128, 31);
            this.Aboutbutton.TabIndex = 4;
            this.Aboutbutton.Text = "关于...(A)";
            this.Aboutbutton.UseVisualStyleBackColor = true;
            this.Aboutbutton.Click += new System.EventHandler(this.Aboutbutton_Click);
            // 
            // Acceptbutton
            // 
            this.Acceptbutton.Location = new System.Drawing.Point(560, 268);
            this.Acceptbutton.Name = "Acceptbutton";
            this.Acceptbutton.Size = new System.Drawing.Size(128, 31);
            this.Acceptbutton.TabIndex = 5;
            this.Acceptbutton.Text = "确定(O)";
            this.Acceptbutton.UseVisualStyleBackColor = true;
            this.Acceptbutton.Click += new System.EventHandler(this.Acceptbutton_Click);
            // 
            // ChooseFilesOrFoldersDialog
            // 
            this.AcceptButton = this.Acceptbutton;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 311);
            this.Controls.Add(this.Acceptbutton);
            this.Controls.Add(this.Aboutbutton);
            this.Controls.Add(this.FolderBrowserbutton);
            this.Controls.Add(this.OpenFilebutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ChooseFilesOrFoldersDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Will_ExtRecover";
            this.Load += new System.EventHandler(this.ChooseFilesOrFoldersDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OpenFilebutton;
        private System.Windows.Forms.Button Acceptbutton;
        private System.Windows.Forms.Button Aboutbutton;
        private System.Windows.Forms.Button FolderBrowserbutton;
    }
}
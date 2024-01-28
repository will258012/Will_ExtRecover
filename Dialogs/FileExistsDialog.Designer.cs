using System.IO;
namespace Will_ExtRecover.Dialogs
{
    partial class FileExistsDialog
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
            this.Replacebutton = new System.Windows.Forms.Button();
            this.Skipbutton = new System.Windows.Forms.Button();
            this.keepBothButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Replacebutton
            // 
            this.Replacebutton.BackColor = System.Drawing.SystemColors.Window;
            this.Replacebutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Replacebutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.Replacebutton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Replacebutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.Replacebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Replacebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Replacebutton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Replacebutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(28)))), ((int)(((byte)(84)))));
            this.Replacebutton.Image = global::Will_ExtRecover.Properties.Resources.ReplacebuttonIron;
            this.Replacebutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Replacebutton.Location = new System.Drawing.Point(45, 102);
            this.Replacebutton.Name = "Replacebutton";
            this.Replacebutton.Size = new System.Drawing.Size(535, 52);
            this.Replacebutton.TabIndex = 0;
            this.Replacebutton.Text = "替换目标中的文件(&R)";
            this.Replacebutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Replacebutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Replacebutton.UseVisualStyleBackColor = true;
            this.Replacebutton.Click += new System.EventHandler(this.Replacebutton_Click);
            // 
            // Skipbutton
            // 
            this.Skipbutton.BackColor = System.Drawing.SystemColors.Window;
            this.Skipbutton.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.Skipbutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.Skipbutton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Skipbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.Skipbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Skipbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Skipbutton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Skipbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(28)))), ((int)(((byte)(84)))));
            this.Skipbutton.Image = global::Will_ExtRecover.Properties.Resources.SkipbuttonIron;
            this.Skipbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Skipbutton.Location = new System.Drawing.Point(45, 160);
            this.Skipbutton.Name = "Skipbutton";
            this.Skipbutton.Size = new System.Drawing.Size(535, 52);
            this.Skipbutton.TabIndex = 1;
            this.Skipbutton.Text = "跳过此文件(&S)";
            this.Skipbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Skipbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Skipbutton.UseVisualStyleBackColor = true;
            this.Skipbutton.Click += new System.EventHandler(this.Skipbutton_Click);
            // 
            // keepBothButton
            // 
            this.keepBothButton.BackColor = System.Drawing.SystemColors.Window;
            this.keepBothButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.keepBothButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.keepBothButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.keepBothButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.keepBothButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.keepBothButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keepBothButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.keepBothButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(28)))), ((int)(((byte)(84)))));
            this.keepBothButton.Image = global::Will_ExtRecover.Properties.Resources.keepBothbuttonIron;
            this.keepBothButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.keepBothButton.Location = new System.Drawing.Point(45, 218);
            this.keepBothButton.Name = "keepBothButton";
            this.keepBothButton.Size = new System.Drawing.Size(535, 52);
            this.keepBothButton.TabIndex = 2;
            this.keepBothButton.Text = "保留这两个文件(&C)";
            this.keepBothButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.keepBothButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.keepBothButton.UseVisualStyleBackColor = true;
            this.keepBothButton.Click += new System.EventHandler(this.keepBothbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "文件信息";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBox1.Location = new System.Drawing.Point(45, 289);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(151, 26);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "全部执行此操作";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FileExistsDialog
            // 
            this.AcceptButton = this.Replacebutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.keepBothButton;
            this.ClientSize = new System.Drawing.Size(635, 334);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keepBothButton);
            this.Controls.Add(this.Skipbutton);
            this.Controls.Add(this.Replacebutton);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileExistsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件冲突";
            this.Load += new System.EventHandler(this.FileExistsDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Replacebutton;
        private System.Windows.Forms.Button Skipbutton;
        private System.Windows.Forms.Button keepBothButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
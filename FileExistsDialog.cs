using System;
using System.IO;
using System.Windows.Forms;

namespace Will_ExtRecover
{
    public partial class FileExistsDialog : Form
    {
        string FilePath;
        string NewFilePath;
        static bool IsApplyToAll = false;
        static string? AllAction = null;
        public FileExistsDialog(string FilePath, string NewFilePath)
        {
            this.FilePath = FilePath;
            this.NewFilePath = NewFilePath;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            InitializeComponent();
            this.label1.Text = $"准备将“{Path.GetFileName(FilePath)}”文件重命名，\n但 “{Path.GetFileName(NewFilePath)}” 已存在。\n请选择操作：";
        }

        private void Replacebutton_Click(object sender, EventArgs e)
        {
            if (IsApplyToAll && AllAction == null)
            {
                AllAction = "Replace";
            }
            File.Delete(NewFilePath);
            File.Move(FilePath, NewFilePath);
            this.Close();
        }

        private void Skipbutton_Click(object sender, EventArgs e)
        {
            if (IsApplyToAll && AllAction == null)
            {
                AllAction = "Skip";
            }
            this.Close();
        }

        private void keepBothbutton_Click(object sender, EventArgs e)
        {
            if (IsApplyToAll && AllAction == null)
            {
                AllAction = "keepBoth";
            }
            int number = 1;
            string newFilePathChanged() => Path.GetDirectoryName(NewFilePath) + '\\' +
                    Path.GetFileNameWithoutExtension(NewFilePath) +
                    '(' + number.ToString() + ')' +
                    Path.GetExtension(NewFilePath);

            while (File.Exists(newFilePathChanged()))
            {
                number++;
            }

            File.Move(FilePath, newFilePathChanged());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            IsApplyToAll = checkBox1.Checked;
        }

        private void FileExistsDialog_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            if (IsApplyToAll && AllAction != null)
            {
                switch (AllAction)
                {
                    case "Replace":
                        Replacebutton_Click(sender, e); break;
                    case "Skip":
                        Replacebutton_Click(sender, e); break;
                    case "keepBoth":
                        keepBothbutton_Click(sender, e); break;
                }
                this.Close();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.R:
                    Replacebutton.PerformClick();
                    return true;
                case Keys.S:
                    Skipbutton.PerformClick();
                    return true;
                case Keys.C:
                    keepBothButton.PerformClick();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}

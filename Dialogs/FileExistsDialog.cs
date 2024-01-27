using System;
using System.IO;
using System.Windows.Forms;

namespace Will_ExtRecover.Dialogs
{
    public partial class FileExistsDialog : Form
    {
        string FilePath;
        string NewFilePath;
        /// <summary> “全部执行此操作”复选框是否已被勾选。</summary>
        static bool IsApplyToAll = false;
        /// <summary> “全部执行此操作”执行的操作名。</summary>
        static string? AllAction = null;
        /// <summary>
        /// “文件冲突”窗口。
        /// </summary>
        /// <param name="FilePath">需处理文件的路径。</param>
        /// <param name="NewFilePath">重命名后的文件路径。</param>
        /// <param name="args">传入的处理文件名录。</param>
        public FileExistsDialog(string FilePath, string NewFilePath, string[] args)
        {
            this.FilePath = FilePath;
            this.NewFilePath = NewFilePath;
            InitializeComponent();
            this.label1.Text = String.Format("在“{0}”文件夹中：\n“{1}”对应重命名后的文件“{2}”已存在。", 
                Path.GetDirectoryName(FilePath), Path.GetFileName(FilePath), Path.GetFileName(NewFilePath));
            this.checkBox1.Enabled = args.Length > 1;//如果是单文件即不显示“全部执行此操作”复选框
        }
        /// <summary>
        /// 当点击“替换目标中的文件”按钮时执行的操作。
        /// </summary>
        private void Replacebutton_Click(object sender, EventArgs e)
        {
            if (IsApplyToAll && AllAction == null)
            {
                AllAction = "Replace";//替换
            }
            File.Delete(NewFilePath);
            File.Move(FilePath, NewFilePath); 
            this.Close();
        }

        /// <summary>
        /// 当点击“跳过此文件”按钮时执行的操作。
        /// </summary>
        private void Skipbutton_Click(object sender, EventArgs e)
        {
            if (IsApplyToAll && AllAction == null)
            {
                AllAction = "Skip";//跳过
            }
            this.Close();
        }
        /// <summary>
        /// 当点击“保留这两个文件”按钮时执行的操作。
        /// </summary>
        private void keepBothbutton_Click(object sender, EventArgs e)
        {
            if (IsApplyToAll && AllAction == null)
            {
                AllAction = "keepBoth";//保留
            }
            int number = 1;
            string newFilePathChanged() => Path.GetDirectoryName(NewFilePath) + '\\' +
                    Path.GetFileNameWithoutExtension(NewFilePath) +
                    '(' + number.ToString() + ')' +
                    Path.GetExtension(NewFilePath);//生成更改过的重命名文件路径
             // 每次循环，自增number，使文件名不重复
            while (File.Exists(newFilePathChanged()))
            {
                number++;
            }

            File.Move(FilePath, newFilePathChanged());//重命名
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 当点击“全部执行此操作”复选框时执行的操作。
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            IsApplyToAll = checkBox1.Checked;//根据复选框状态，为变量赋值
        }

        private void FileExistsDialog_Load(object sender, EventArgs e)
        {
            //根据IsApplyToAll指定状态，自动执行对应的操作
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
        /// <summary>
        /// 按键操作逻辑。
        /// </summary>
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

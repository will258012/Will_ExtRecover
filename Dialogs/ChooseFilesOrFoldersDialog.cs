using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Will_ExtRecover.Dialogs
{
    public partial class ChooseFilesOrFoldersDialog : Form
    {
        string[] args;
        bool IsAOpenDialog = false;


        public ChooseFilesOrFoldersDialog()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!IsAOpenDialog)
            {
                // 使用正则表达式来匹配引号内的内容
                var matches = Regex.Matches(textBox1.Text, "\"([^\"]*)\"");
                args = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
            }
        }


        private void OpenFilebutton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.ShowDialog();
            if(openFileDialog.FileNames.Length > 0)
            {
                args = openFileDialog.FileNames;
                IsAOpenDialog = true;
                textBox1.Text = null;
                foreach (var path in args)
                {
                    textBox1.Text = '"' + path + '"';
                }
                IsAOpenDialog = false;
            }
            
        }
        private void FolderBrowserbutton_Click(object sender,EventArgs e)
        {
#if NET48           

            using var folderBrowser = new FolderBrowserDialog();
#endif
#if NET8_0_OR_GREATER
            var folderBrowser = new OpenFolderDialog(); //OpenFolderDialog 方法在.NET 8.0之后可用 
            folderBrowser.Multiselect = true;
#endif
            folderBrowser.ShowDialog();
#if NET48
            if(folderBrowser.SelectedPath != string.Empty) { 
            args = new string[1];
            args[0] = folderBrowser.SelectedPath;
            IsAOpenDialog = true;
            textBox1.Text = '"' + folderBrowser.SelectedPath + '"';
            IsAOpenDialog = false;
            }
#endif
#if NET8_0_OR_GREATER
            if (folderBrowser.FolderNames.Length > 0){
            args = folderBrowser.FolderNames;
            textBox1.Text = null;
            IsAOpenDialog = true;
            foreach (var path in args)
            {
                textBox1.Text += '"' + path + '"';
            }
            IsAOpenDialog = false;
        }
#endif
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Acceptbutton_Click(object sender, EventArgs e)
        {
            // 检查 args 是否已正确填充
            if (args == null)
            {
                MessageBox.Show("没有选择文件或文件夹！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Entry.args = args;
            foreach (var path in args)
            {
                Program.ProcessFileOrFolder(path, args.Length > 1);
            }
            if (args.Length > 1)
            {
                MessageBox.Show("处理完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
          //  this.Close();    
        }
        private void ChooseFilesOrFoldersDialog_Load(object sender, EventArgs e)
        {

        }

        private void Aboutbutton_Click(object sender, EventArgs e)
        {
            using var about = new About();
            about.ShowDialog();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}

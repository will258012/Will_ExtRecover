using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Will_ExtRecover.Dialogs
{
    public partial class ChooseFilesOrFoldersDialog : Form
    {
        /// <summary>
        /// 需要处理的文件或目录的名录。
        /// </summary>
        private string[]? args;
        /// <summary>
        /// 用户是否正在文本框中键入。
        /// </summary>
        private bool IsTypeing = false;

        /// <summary>
        /// “选择文件或文件夹”窗口。
        /// </summary>
        public ChooseFilesOrFoldersDialog()
        {
            InitializeComponent();
            textBox1.GotFocus += new EventHandler(textBox1_FocusChanged);
            textBox1.LostFocus += new EventHandler(textBox1_FocusChanged);
        }
        /// <summary>
        /// 当文本框文字改变时执行的内容。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (IsTypeing) //如果是手动输入的路径
            {
                // 检查格式是否正确
                if (!IsInputFormatCorrect(textBox1.Text))
                {
                    // 显示提示
                    toolTip1.Show("输入格式错误，请确保路径用引号包围。", textBox1,3000);
                }
                else
                {
                    toolTip1.Hide(textBox1);
                    // 使用正则表达式来匹配引号内的内容
                    var matches = Regex.Matches(textBox1.Text, "\"([^\"]*)\"");
                    args = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();//存储变量
                    
                }
            }
        }
        /// <summary>
        /// 检查是否每个路径都被引号包围
        /// </summary>
        /// <param name="input"></param>
        /// <returns>true 表示格式正确，返回 false 表示格式错误</returns>
        private bool IsInputFormatCorrect(string input)
        {
            return Regex.IsMatch(input, "^\"([^\"]*)\"( \"([^\"]*)\")*$");
        }
        private void textBox1_FocusChanged(object sender, EventArgs e) 
        {
            IsTypeing = textBox1.Focused; //设定为textBox1的聚焦情况
        }
        /// <summary>
        /// 点击“打开文件”时执行的内容。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFilebutton_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new System.Windows.Forms.OpenFileDialog();//选择文件对话框
            openFileDialog.Multiselect = true; //多选
            openFileDialog.ShowDialog();
            if (openFileDialog.FileNames.Length > 0) //如果选择了文件
            {
                args = openFileDialog.FileNames; //赋值给args
                textBox1.Text = null;
                foreach (var path in args)
                {
                    textBox1.Text += '"' + path + '"' + " ";// 添加路径到文本框
                }
            }

        }
        /// <summary>
        /// 点击“打开文件夹”按钮时执行的内容。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderBrowserbutton_Click(object sender, EventArgs e)
        {
#if NET48           

            using var folderBrowser = new FolderBrowserDialog();
#endif
#if NET8_0_OR_GREATER
            var folderBrowser = new OpenFolderDialog(); //OpenFolderDialog 方法在.NET 8.0之后可用 
            folderBrowser.Multiselect = true; //多选
#endif
            folderBrowser.ShowDialog();
#if NET48
            if (folderBrowser.SelectedPath != string.Empty)
            {
                args = new string[1];
                args[0] = folderBrowser.SelectedPath; //FolderBrowserDialog 只能选取一个文件夹
                textBox1.Text = '"' + folderBrowser.SelectedPath + '"'; // 添加路径到文本框
            }
#endif
#if NET8_0_OR_GREATER
            if (folderBrowser.FolderNames.Length > 0)
            {
                args = folderBrowser.FolderNames;
                textBox1.Text = null;
                foreach (var path in args)
                {
                    textBox1.Text += '"' + path + '"' + " "; // 添加路径到文本框
                }
            }
#endif
        }
        /// <summary>
        /// 点击“确定”按钮时执行的内容。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Acceptbutton_Click(object sender, EventArgs e)
        {
            // 检查 args 是否已正确填充
            if (args == null)
            {
                //MessageBox.Show("没有选择文件或文件夹！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, 
                //  MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                // 显示提示
                toolTip1.Show("未输入/选择文件或文件夹！", textBox1, 3000);
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
        }

        /// <summary>
        /// 点击“关于”按钮时执行的内容。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Aboutbutton_Click(object sender, EventArgs e)
        {
            using var about = new About();
            about.ShowDialog();
        }

        /// <summary>
        /// 拖入时执行的内容。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseFilesOrFoldersDialog_DragDrop(object sender, DragEventArgs e)
        {
            // 检查是否有东西拖入
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 获取拖入的文件或文件夹路径
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

                // 将路径写入 args 数组
                args = paths;
                // 清空文本框并添加新路径
                textBox1.Text = null;
                foreach (var path in paths)
                {
                    textBox1.Text += '"' + path + '"' + " "; // 添加路径到文本框
                }
            }
        }
        private void ChooseFilesOrFoldersDialog_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void ChooseFilesOrFoldersDialog_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void toolTip1_Popup(object sender, PopupEventArgs e) { }
    }
}
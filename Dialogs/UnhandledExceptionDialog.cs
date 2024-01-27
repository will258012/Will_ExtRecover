using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Will_ExtRecover.Dialogs
{
    public partial class UnhandledExceptionDialog : Form
    {
        /// <summary>
        /// 当（不幸地）发生了未处理错误时显示的窗口。
        /// </summary>
        /// <param name="ex"></param>
        public UnhandledExceptionDialog(Exception ex)
        {
            InitializeComponent();
            textBox1.Text = String.Format("异常类型：{0}\r\n异常消息：{1}\r\n 堆栈跟踪：\r\n {2} \r\n",
                    ex.GetType().FullName, ex.Message, ex.StackTrace);//生成错误报告
            About aboutInstance = new About();
            label2.Text = aboutInstance.AssemblyTitle + " " + aboutInstance.AssemblyVersion;//获取版本号
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.OpenFile("https://github.com/will258012/Will_ExtRecover/issues/new");
        }

        private void UnhandledExceptionDialog_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
/// <summary>
/// 文件或目录的输入
/// </summary>
namespace Will_ExtRecover
{
    class Entry
    {
        [STAThread]
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionTrapper);
            Application.EnableVisualStyles();
            FileOrFolderEntry(args);
        }

        private static void FileOrFolderEntry(string[] args)
        {
            if (args.Length > 0)
            {
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
            else
            {
                var openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog().GetValueOrDefault())
                {
                    if (openFileDialog.FileNames.Length > 1)
                    {
                        foreach (var path in openFileDialog.FileNames)
                        {
                            Program.ProcessFileOrFolder(path, true);
                        }
                        MessageBox.Show("处理完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        Program.ProcessFileOrFolder(openFileDialog.FileName);
                    }
                }
            }
        }
        public static List<string> Extensions
        {
            get
            {
                string fileName = "Will_ExtRecover.ini";
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                try
                {
                    string FullPath = Path.GetFullPath(filePath);
                    if (!File.Exists(filePath))
                    {
                        throw new FileNotFoundException("配置文件不存在: " + FullPath);
                    }

                    var builder = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddIniFile(fileName, optional: false, reloadOnChange: true);

                    IConfigurationRoot configuration = builder.Build();

                    var extensions = new List<string>();
                    IConfigurationSection extensionsSection = configuration.GetSection("Extensions");

                    if (!extensionsSection.GetChildren().Any())
                    {
                        throw new Exception("配置文件中不存在扩展名部分!\n请在配置文件中添加 [Extensions] 部分。" + FullPath);
                    }

                    // 将扩展名添加到列表中
                    foreach (var item in extensionsSection.GetChildren())
                    {
                        var extension = item.Value?.Trim();
                        if (!string.IsNullOrEmpty(extension))
                        {
                            extensions.Add(extension ?? throw new NullReferenceException());
                        }
                    }

                    // 检查扩展名列表是否为空
                    if (extensions.Count == 0)
                    {
                        throw new Exception("配置文件中的扩展名列表为空!" + FullPath);
                    }
                    return extensions;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("无法读取配置文件: \n" + e.Message);
                    MessageBox.Show(e.Message, "无法读取配置文件", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                    // 如果配置文件不存在，则创建一个新的
                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath).Close();
                    }
                    Program.OpenFile(filePath);
                    Environment.Exit(0);
                }
                return new List<string>();
            }
        }
        public static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Console.Error.WriteLine("异常类型: " + ex.GetType().FullName);
            Console.Error.WriteLine("异常消息: " + ex.Message);
            Console.Error.WriteLine("堆栈跟踪:");
            Console.Error.WriteLine(ex.StackTrace);
            using var UnhandledExceptionDialog = new UnhandledExceptionDialog(ex);
            UnhandledExceptionDialog.ShowDialog();
            Environment.Exit(1);
        }
    }

    /// <summary>
    /// 主要部分
    /// </summary>
    class Program
    {
        /// <summary>
        /// 对文件或目录进行初步处理。
        /// </summary>
        /// <param name="path">文件或目录的路径。</param>
        internal static void ProcessFileOrFolder(string path, bool IsMultiFiles = false)
        {
            try
            {
                if (File.Exists(path))
                {
                    ProcessFile(path, false, IsMultiFiles);
                }
                else if (Directory.Exists(path))
                {
                    if (Directory.GetFiles(path).Length >= 0 || Directory.GetDirectories(path).Length >= 0)
                    {
                        ProcessDirectory(path);
                    }
                    else
                    {
                        throw new Exception("目录为空：" + path);
                    }
                }
                else
                {
                    throw new FileNotFoundException("目录或文件不存在：" + path);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("处理文件时出错: \n" + e.Message);
                MessageBox.Show(e.Message, "处理文件时出错", MessageBoxButtons.OK, MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        /// <summary>
        /// 对目录进行遍历，处理每个文件。
        /// </summary>
        /// <param name="path">目录的路径。</param>
        /// <param name="dep">递归的深度。</param>
        private static void ProcessDirectory(string path, int dep = 0)
        {
            // 处理当前目录中的所有文件
            foreach (var file in Directory.GetFiles(path))
            {
                ProcessFile(file, true);
            }

            // 递归处理所有子目录
            foreach (var directory in Directory.GetDirectories(path))
            {
                ProcessDirectory(directory, dep + 1);
            }
            /*         MessageBox.Show("所有文件均已处理完毕！","提示", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly); */
            //打开目录
            if (dep == 0) OpenFile(path);
        }

        /// <summary>
        /// 处理文件。
        /// </summary>
        /// <param name="filePath">文件的路径。</param>
        /// <param name="IsFolder">是否是目录处理模式。缺省值为false。</param>
        /// <param name="IsMultiFiles">是否是多文件处理模式。缺省值为false。</param>
        private static void ProcessFile(string filePath, bool IsFolder = false, bool IsMultiFiles = false)
        {
            try
            {
                // 如果文件已经处理过了，或者不需要被处理，则直接打开它
                if (Path.HasExtension(filePath) &&
                (IsExtensionRegistered(Path.GetExtension(filePath).ToLower()) || Entry.Extensions.Contains(Path.GetExtension(filePath).ToLower())))
                {
                    if (!IsFolder && !IsMultiFiles)//目录或多文件处理模式中？
                    {
                        OpenFile(filePath);
                    }
                    else
                    {
                        Console.WriteLine("跳过文件：" + filePath);
                    }
                }
                else//否则，尝试重命名文件
                {
                    // 获取文件名并转换为小写
                    string fileName = Path.GetFileName(filePath).ToLower();

                    // 尝试获取匹配的扩展名（去掉点），如果没有找到，则返回 null
                    string? matchedExtension = Entry.Extensions
                        .FirstOrDefault(ext => fileName.EndsWith(ext.Substring(1)))
                        ?.Substring(1);

                    if (!string.IsNullOrEmpty(matchedExtension))
                    {
                        // 打开重命名后的文件
                        if (!IsFolder && !IsMultiFiles)//目录或多文件处理模式中？
                        {
                            OpenFile(RenameFilewithNewFilePath(filePath, matchedExtension));
                        }
                        else
                        {
                            RenameFile(filePath, matchedExtension);
                            Console.WriteLine("处理文件：" + filePath);
                        }
                    }
                    else
                    {
                        if (!IsFolder && !IsMultiFiles)//目录或多文件处理模式中？
                        {
                            throw new Exception("文件名中似乎有不受支持的扩展名: " + Path.GetFullPath(filePath) + "\n" +
                            "如果需要处理它，请将其添加到配置文件中。");
                        }
                        else
                        {
                            Console.Error.WriteLine("跳过不支持的文件：" + filePath);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("处理文件时出错: \n" + e.Message);
                MessageBox.Show(e.Message, "处理文件时出错", MessageBoxButtons.OK, MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        /// <summary>
        /// 重命名文件，并返回新的文件路径。
        /// </summary>
        /// <param name="filePath">文件的路径。</param>
        /// <param name="newExtension">新的扩展名。不需要带点</param>
        private static string RenameFilewithNewFilePath(string filePath, string newExtension)
        {
            try
            {
                string newFilePath = Path.Combine(Path.GetDirectoryName(filePath),
                    Path.GetFileName(filePath).Remove(Path.GetFileName(filePath).Length - newExtension.Length) + '.'
                    + newExtension);
                if (File.Exists(newFilePath))
                {
                    using var FileExistsDialog = new FileExistsDialog(filePath, newFilePath);
                    FileExistsDialog.ShowDialog();
                }
                else
                {
                    File.Move(filePath, newFilePath);
                }
                return newFilePath;
            }
            catch (Exception e)
            {
                throw new Exception("文件重命名失败：" + e.Message);
            }
        }

        /// <summary>
        /// 重命名文件。
        /// </summary>
        /// <param name="filePath">文件的路径。</param>
        /// <param name="newExtension">新的扩展名。不需要带点</param>
        private static void RenameFile(string filePath, string newExtension)
        {
            try
            {
                string newFilePath = Path.Combine(Path.GetDirectoryName(filePath),
                    Path.GetFileName(filePath).Remove(Path.GetFileName(filePath).Length - newExtension.Length) + '.'
                    + newExtension);
                if (File.Exists(newFilePath))
                {
                    using var FileExistsDialog = new FileExistsDialog(filePath, newFilePath);
                    FileExistsDialog.ShowDialog();
                }
                else
                {
                    File.Move(filePath, newFilePath);
                }
            }
            catch (Exception e)
            {
                throw new Exception("文件重命名失败：" + e.Message);
            }
        }

        /// <summary>
        /// 打开一个文件或目录。
        /// </summary>
        /// <param name="filePath">文件或目录的路径。</param>
        public static void OpenFile(string filePath)
        {
            Process.Start("explorer.exe", filePath);
        }

        /// <summary>
        /// 检查扩展名是否已注册。
        /// </summary>
        /// <param name="extension">扩展名。</param>
        /// <returns>如果扩展名已注册，则为 true；否则为 false。</returns>
        private static bool IsExtensionRegistered(string extension)
        {
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(extension))
            {
                return key != null;
            }
        }
    }
}
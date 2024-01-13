using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Win32;
using System.Linq;
using System.Drawing;
/// <summary>
/// 文件或文件夹的输入
/// </summary>
class Entry
{
    [STAThread]
    private static void Main(string[] args)
    {
        FileOrFolderEntry(args);
    }

    private static void FileOrFolderEntry(string[] args)
    {
        if (args.Length > 0)
        {
            foreach (var path in args)
            {
                Program.ProcessFileOrFolder(path);
            }
        }
        else
        {
            using var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Program.ProcessFileOrFolder(openFileDialog.FileName);
            }
        }
    }
    internal static readonly List<string> Extensions = LoadExtensions("Will_ExtRecover.ini");

    private static List<string> LoadExtensions(string fileName)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        try
        {
            if (File.Exists(filePath))
            {
                var extensions = new List<string>();
                var lines = File.ReadAllLines(filePath);
                if (lines.Length == 0)
                {
                    throw new Exception("配置文件为空!" + Path.GetFullPath(filePath));
                }

                foreach (var line in lines)
                {
                    // 可以添加更多的错误检查，例如确保扩展名格式正确
                    extensions.Add(line.Trim());
                }
                return extensions;
            }
            else throw new FileNotFoundException("配置文件不存在: " + Path.GetFullPath(filePath));
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("无法读取配置文件: " + e.Message);
            MessageBox.Show(e.Message, "无法读取配置文件", MessageBoxButtons.OK, MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            File.Create(filePath).Close();
            Process.Start("explorer.exe", filePath);
            Environment.Exit(1);
            return new List<string>();
        }
    }
}

/// <summary>
/// 主要部分
/// </summary>
class Program
{
    /// <summary>
    /// 对文件或文件夹进行初步处理。
    /// </summary>
    /// <param name="path">文件或文件夹的路径。</param>
    internal static void ProcessFileOrFolder(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                ProcessFile(path);
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
            Console.Error.WriteLine("处理文件时出错: " + e.Message);
            MessageBox.Show(e.Message, "处理文件时出错", MessageBoxButtons.OK, MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
    }
    private static void ProcessDirectory(string path)
    {
        // 处理当前目录中的所有文件
        foreach (var file in Directory.GetFiles(path))
        {
            ProcessFile(file,true);
        }

        // 递归处理所有子目录
        foreach (var directory in Directory.GetDirectories(path))
        {
            ProcessDirectory(directory);
        }
        MessageBox.Show("所有文件均已处理完毕！","提示", MessageBoxButtons.OK, MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
    }

    /// <summary>
    /// 处理文件。
    /// </summary>
    /// <param name="filePath">文件的路径。</param>
    /// <param name="IsFolder">是否是文件夹读取模式。缺省值为false。</param>
    private static void ProcessFile(string filePath, bool IsFolder = false)
    {
        try
        {
            // 如果文件已经处理过了，或者不需要被处理，则直接打开它
            if (Path.HasExtension(filePath) &&
            (IsExtensionRegistered(Path.GetExtension(filePath).ToLower()) || Entry.Extensions.Contains(Path.GetExtension(filePath).ToLower())))
            {
                if (!IsFolder)//文件夹处理模式中？
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
                    ?.Substring(1); // 使用 '?' 来安全地访问 Substring 方法

                if (!string.IsNullOrEmpty(matchedExtension))
                {
                    // 打开重命名后的文件
                    if (!IsFolder)//文件夹处理模式中？
                    {
                        OpenFile(RenameFilewithNewFilePath(filePath, '.' + matchedExtension));
                    }
                    else
                    {
                        RenameFile(filePath, '.' + matchedExtension);
                        Console.WriteLine("处理文件：" + filePath);
                    }
                }
                else
                {
                    if (!IsFolder)
                    {
                        throw new Exception("不受支持的文件扩展名: " + Path.GetFullPath(filePath) + "\n" +
                        "如果需要处理它，请将其添加到配置文件中。");
                    }
                    else{
                    Console.Error.WriteLine("跳过不支持的文件：" + filePath);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("处理文件时出错: " + e.Message);
            MessageBox.Show(e.Message, "处理文件时出错", MessageBoxButtons.OK, MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
    }

    /// <summary>
    /// 重命名文件，并返回新的文件路径。
    /// </summary>
    /// <param name="filePath">文件的路径。</param>
    /// <param name="newExtension">新的扩展名。</param>
    private static string RenameFilewithNewFilePath(string filePath, string newExtension)
    {
        string newFilePath = Path.Combine(Path.GetDirectoryName(filePath),
         Path.GetFileName(filePath) + newExtension);
        File.Move(filePath, newFilePath);
        return newFilePath;
    }

    /// <summary>
    /// 重命名文件。
    /// </summary>
    /// <param name="filePath">文件的路径。</param>
    /// <param name="newExtension">新的扩展名。</param>
    private static void RenameFile(string filePath, string newExtension)
    {
        string newFilePath = Path.Combine(Path.GetDirectoryName(filePath),
         Path.GetFileName(filePath) + newExtension);
        File.Move(filePath, newFilePath);
    }
    /// <summary>
    /// 打开文件。
    /// </summary>
    /// <param name="filePath">文件的路径。</param>
    private static void OpenFile(string filePath)
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
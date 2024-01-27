# Will_ExtRecover
本程序旨在将乱码的文件扩展名还原，省去了恼人的重命名过程。

程序会将形如`1�?ppt`的文件名，识别并修复它具有的扩展名，最后重命名为形如`1�?.ppt`的文件名。

# 安装

本程序提供 Windows 7 (.NETFramework 4.8)版本和 Windows 8及以上 (.NET 8.0)版本。

### 其中前者需安装[.NETFramework 4.8 运行时](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net48-web-installer)；

### 后者需安装[.NET 8.0 桌面运行时](https://dotnet.microsoft.com/download/dotnet/thank-you/runtime-desktop-8.0.1-windows-x64-installer)。 

# 使用
只需把文件或文件夹使用该程序打开（拖到可执行文件上），文件的扩展名会自动恢复。

如果是单文件，还会在重命名后自动打开。

# 配置

`Will_ExtRecover.ini`预置了一些需识别的扩展名。在实际使用时，还可以根据需求增加。

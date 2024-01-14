# Will_ExtRecover
本程序旨在将乱码的文件扩展名还原，省去了恼人的重命名过程。

程序会将形如`1�?ppt`的文件名，识别它具有的扩展名，然后在原文件后加上缺失的扩展名。最后重命名为形如`1�?ppt.ppt`。

# 安装

本程序提供 Windows 7 (.NETFramework 4.8)版本和 Windows 8及以上 (.NET 7.0)版本。

### 其中前者需安装[.NETFramework 4.8运行时](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net48-web-installer)，后者开箱即用。 

# 使用
只需把文件或文件夹拖入到程序内，文件的扩展名会自动恢复。

如果是单文件，还会在重命名后自动打开。

# 配置

`Will_ExtRecover.ini`预置了一些需识别的扩展名。在实际使用时，还可以根据需求增加。

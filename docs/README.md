# Reverse Engineering Case Study: HipPOS Hidden API

## Background

Client need to find hidden API from HipPOS .desktop app to be used for their own web app.

## Tools

- [de4dot](https://github.com/de4dot/de4dot): .NET de-obfucastor and unpacker
- [ILSpy](https://github.com/icsharpcode/ILSpy): .NET decompiler
- [Visual Studio Code](https://code.visualstudio.com)
- [Visual Studio](https://visualstudio.microsoft.com)

## Step 1: Deobfuscate the binaries

First thing to do is to detect if the binaries are protected by some kind of obfuscator.

![](img/step-01-de4dot-deobfuscate.gif)

We use de4dot for that.

```shell
$  de4dot.exe -d -r .\HipPOS\

de4dot v3.1.41592.3405

Detected .NET Reactor (C:\HipPOS\CorePOS.Business.dll)
Detected .NET Reactor (C:\HipPOS\CorePOS.Data.dll)
Detected .NET Reactor (C:\HipPOS\Hippos-Sync.exe)
Detected .NET Reactor (C:\HipPOS\HipPOS-Updater.exe)
Detected .NET Reactor (C:\HipPOS\HipPOS.exe)
```

As we can see, it's protected by .NET Reactor.

Now let's clean it first.

```shell
$ de4dot.exe -r .\HipPOS\ -ru -ro .\HipPOS-clean\

de4dot v3.1.41592.3405

Detected .NET Reactor (C:\HipPOS\CorePOS.Business.dll)
Detected .NET Reactor (C:\HipPOS\CorePOS.Data.dll)
Detected .NET Reactor (C:\HipPOS\Hippos-Sync.exe)
Detected .NET Reactor (C:\HipPOS\HipPOS-Updater.exe)
Detected .NET Reactor (C:\HipPOS\HipPOS.exe)
Cleaning C:\HipPOS\CorePOS.Business.dll
Cleaning C:\HipPOS\CorePOS.Data.dll
Cleaning C:\HipPOS\Hippos-Sync.exe
Cleaning C:\HipPOS\HipPOS-Updater.exe
Cleaning C:\HipPOS\HipPOS.exe
Renaming all obfuscated symbols
Saving C:\HipPOS-clean\CorePOS.Business.dll
Saving C:\HipPOS-clean\CorePOS.Data.dll
Saving C:\HipPOS-clean\Hippos-Sync.exe
Saving C:\HipPOS-clean\HipPOS-Updater.exe
Saving C:\HipPOS-clean\HipPOS.exe
```

## Step 2: Decompile the binaries and retrieve the C# source code

Before we decompile the app, we need to copy all `dll` libraries from `C:\HipPOS\` to `C:\HipPOS-clean\`.
Make sure NOT to replace the deobfuscated binaries with the original ones from Step 1.

![](img/step-02-1-copy-dependencies.gif)

Open `ILSpy`, Click **File** - **Open**, and select following files:

- CorePOS.Business.dll
- CorePOS.Data.dll
- Hippos-Sync.exe
- HipPOS-Updater.exe
- HipPOS.exe

![](img/step-02-2-ilspy-select-files.gif)

Under **Assemblies**, for each binary above, Righ click and select **Save Code**.

![](img/step-02-3-ilspy-save-source-code.gif)

Select the directory to save the code, in this case I choose `C:\HipPOS-src\`.

## Step 3: Find Hidden REST API

This part is pretty easy.

I open the project files by using Visual Studio Code and search for `hipposhq.com` and found the Class and Function that utilize HttpWebRequest.

## Step 4: Build a simple WinForms App to test HipPOS REST API

In this step, we build a simple desktop app for Proof of concept wether we use the correct function or not.

It's basically just a simple GUI with function copied from the decompiled code from Step 2) and 3).

## Step 5: Write Python Script for Web app integration with HipPOS REST API

Once the REST API is verified working correctly from Step 4, 


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

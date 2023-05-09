using System;
using System.Diagnostics;
using System.IO;

namespace CorePOS.Business.Methods;

public class DebugMethods
{
	public static void ShowExceptionTextFile(Exception ex)
	{
		string text = AppDomain.CurrentDomain.BaseDirectory + "\\DebugMode.txt";
		if (File.Exists(text))
		{
			string text2 = "[Source] " + ex.Source + Environment.NewLine;
			text2 = text2 + "[StackTrace] " + ex.StackTrace + Environment.NewLine;
			text2 = text2 + "[Message] " + ex.Message;
			File.WriteAllText(text, text2);
			Process.Start(text);
		}
	}

	public static void ShowErrorTextFile(string error)
	{
		string text = AppDomain.CurrentDomain.BaseDirectory + "\\DebugMode.txt";
		if (File.Exists(text))
		{
			string contents = "[ERROR] " + error;
			File.WriteAllText(text, contents);
			Process.Start(text);
		}
	}

	public DebugMethods()
	{
		Class2.oOsq41PzvTVMr();
		// base._002Ector();
	}
}

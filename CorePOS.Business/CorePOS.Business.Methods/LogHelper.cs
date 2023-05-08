using System;
using System.IO;
using System.Linq;
using System.Threading;
using CorePOS.Business.Objects;

namespace CorePOS.Business.Methods;

public static class LogHelper
{
	public static void WriteLog(string message, string logname)
	{
		_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0();
		_003C_003Ec__DisplayClass0_.logname = logname;
		_003C_003Ec__DisplayClass0_.message = message;
		new Thread((ThreadStart)delegate
		{
			try
			{
				string text = _003C_003Ec__DisplayClass0_.logname.ToLower();
				string text2 = AppDomain.CurrentDomain.BaseDirectory + "logs\\";
				if (text == LogTypes.print_log)
				{
					text2 = AppDomain.CurrentDomain.BaseDirectory + "logs\\printlogs\\";
				}
				else if (text == LogTypes.call_log)
				{
					text2 = AppDomain.CurrentDomain.BaseDirectory + "logs\\calllogs\\";
				}
				else if (text == LogTypes.error_log)
				{
					text2 = AppDomain.CurrentDomain.BaseDirectory + "logs\\errorlogs\\";
				}
				else if (text == LogTypes.sync_log)
				{
					text2 = AppDomain.CurrentDomain.BaseDirectory + "logs\\synclogs\\";
				}
				else if (text == LogTypes.tcp_log)
				{
					text2 = AppDomain.CurrentDomain.BaseDirectory + "logs\\tcplogs\\";
				}
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				_003C_003Ec__DisplayClass0_.message = "[" + DateTime.Now.ToLongTimeString() + "] " + _003C_003Ec__DisplayClass0_.message;
				string path = text2 + _003C_003Ec__DisplayClass0_.logname + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
				if (!File.Exists(path))
				{
					using (StreamWriter streamWriter = File.CreateText(path))
					{
						streamWriter.WriteLine(_003C_003Ec__DisplayClass0_.message);
						streamWriter.Close();
						return;
					}
				}
				using StreamWriter streamWriter2 = File.AppendText(path);
				streamWriter2.WriteLine(_003C_003Ec__DisplayClass0_.message);
				streamWriter2.Close();
			}
			catch (Exception)
			{
			}
		}).Start();
	}

	public static void CleanAllLogs()
	{
		CleanSpecificFolderLogs(LogTypes.print_log);
		CleanSpecificFolderLogs(LogTypes.call_log);
		CleanSpecificFolderLogs(LogTypes.error_log);
		CleanSpecificFolderLogs(LogTypes.sync_log);
		CleanSpecificFolderLogs(LogTypes.tcp_log);
	}

	public static void CleanSpecificFolderLogs(string logType)
	{
		string path = AppDomain.CurrentDomain.BaseDirectory + "logs\\";
		if (logType == LogTypes.print_log)
		{
			path = AppDomain.CurrentDomain.BaseDirectory + "logs\\printlogs\\";
		}
		else if (logType == LogTypes.call_log)
		{
			path = AppDomain.CurrentDomain.BaseDirectory + "logs\\calllogs\\";
		}
		else if (logType == LogTypes.error_log)
		{
			path = AppDomain.CurrentDomain.BaseDirectory + "logs\\errorlogs\\";
		}
		else if (logType == LogTypes.sync_log)
		{
			path = AppDomain.CurrentDomain.BaseDirectory + "logs\\synclogs\\";
		}
		else if (logType == LogTypes.tcp_log)
		{
			path = AppDomain.CurrentDomain.BaseDirectory + "logs\\tcplogs\\";
		}
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		foreach (FileInfo item in from a in new DirectoryInfo(path).GetFiles()
			where a.CreationTime < DateTime.Now.AddMonths(-2)
			select a)
		{
			item.Delete();
		}
	}
}

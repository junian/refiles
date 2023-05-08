using System;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using CorePOS.Data.Properties;

namespace CorePOS.Data;

public class Helper
{
	public static string GetEncryptedConnectionString()
	{
		string path = AppDomain.CurrentDomain.BaseDirectory + "\\connectionstring.txt";
		string result = "";
		if (File.Exists(path))
		{
			using (StreamReader streamReader = new StreamReader(path))
			{
				while (streamReader.Peek() >= 0)
				{
					result = streamReader.ReadLine();
				}
				return result;
			}
		}
		return result;
	}

	public static void SetConnectionString(string connectionString)
	{
		connectionString = connectionString.Replace("{%APPLICATION_PATH%}\\", AppDomain.CurrentDomain.BaseDirectory);
		connectionString = ((!Convert.ToBoolean(Settings.Default["isCurrentlyTrainingMode"])) ? connectionString.Replace("{%MODE%}", string.Empty) : connectionString.Replace("{%MODE%}", "-Training"));
		Settings.Default["ConnectionString"] = connectionString;
	}

	public static string GetConnectionString()
	{
		return (string)Settings.Default["ConnectionString"];
	}

	public static void SubmitChangesWithCatch(GClass6 context)
	{
		int num = 3;
		bool flag = false;
		while (num > 0 && !flag)
		{
			try
			{
				context.SubmitChanges(ConflictMode.ContinueOnConflict);
				flag = true;
			}
			catch (ChangeConflictException)
			{
				foreach (ObjectChangeConflict changeConflict in context.ChangeConflicts)
				{
					changeConflict.Resolve(RefreshMode.KeepChanges);
				}
				try
				{
					context.Refresh(RefreshMode.KeepChanges);
					context.SubmitChanges(ConflictMode.ContinueOnConflict);
					flag = true;
				}
				catch (ChangeConflictException)
				{
					foreach (ObjectChangeConflict changeConflict2 in context.ChangeConflicts)
					{
						changeConflict2.Resolve(RefreshMode.OverwriteCurrentValues);
					}
					flag = true;
				}
			}
			catch (SqlException ex3)
			{
				if (ex3.Number != 1205)
				{
					throw;
				}
				Thread.Sleep(1000);
				num--;
				if (num == 0)
				{
					throw;
				}
			}
		}
	}

	public Helper()
	{
		Class5.qrSRKAOzgGGAb();
		base._002Ector();
	}
}

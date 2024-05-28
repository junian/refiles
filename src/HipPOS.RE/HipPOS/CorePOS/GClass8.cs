using System;
using System.Drawing.Printing;
using System.Management;
using System.Runtime.InteropServices;

namespace CorePOS;

public class GClass8
{
	[StructLayout(LayoutKind.Sequential)]
	public class DOCINFOA
	{
		[MarshalAs(UnmanagedType.LPStr)]
		public string pDocName;

		[MarshalAs(UnmanagedType.LPStr)]
		public string pOutputFile;

		[MarshalAs(UnmanagedType.LPStr)]
		public string pDataType;

		public DOCINFOA()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern bool OpenPrinterA([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

	[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
	public static extern bool ClosePrinter(IntPtr hPrinter);

	[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern bool StartDocPrinterA(IntPtr hPrinter, int level, [In][MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

	[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
	public static extern bool EndDocPrinter(IntPtr hPrinter);

	[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
	public static extern bool StartPagePrinter(IntPtr hPrinter);

	[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
	public static extern bool EndPagePrinter(IntPtr hPrinter);

	[DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
	public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

	public static bool SendBytesToPrinter(string sPrinterName, IntPtr pBytes, int dwCount)
	{
		if (string.IsNullOrEmpty(sPrinterName))
		{
			sPrinterName = new PrinterSettings().PrinterName;
		}
		int dwWritten = 0;
		IntPtr hPrinter = new IntPtr(0);
		DOCINFOA dOCINFOA = new DOCINFOA();
		bool flag = false;
		dOCINFOA.pDocName = "Hippos Document";
		dOCINFOA.pDataType = "RAW";
		if (OpenPrinterA(sPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
		{
			if (StartDocPrinterA(hPrinter, 1, dOCINFOA))
			{
				if (StartPagePrinter(hPrinter))
				{
					flag = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
					EndPagePrinter(hPrinter);
				}
				EndDocPrinter(hPrinter);
			}
			ClosePrinter(hPrinter);
		}
		if (!flag)
		{
			Marshal.GetLastWin32Error();
		}
		return flag;
	}

	private static bool smethod_0(string string_0, string string_1)
	{
		int dwCount = (string_1.Length + 1) * Marshal.SystemMaxDBCSCharSize;
		IntPtr intPtr = Marshal.StringToCoTaskMemAnsi(string_1);
		SendBytesToPrinter(string_0, intPtr, dwCount);
		Marshal.FreeCoTaskMem(intPtr);
		return true;
	}

	public static void OpenCashDrawer(string PrinterName = "")
	{
		if (PrinterName == "")
		{
			PrinterName = new PrinterSettings().PrinterName;
		}
		string text = string.Empty;
		if (PrinterName.ToUpper().Contains("STAR"))
		{
			text = "STAR";
		}
		else if (!PrinterName.ToUpper().Contains("KITCHEN") && !PrinterName.ToUpper().Contains("SALES"))
		{
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher($"SELECT * from Win32_Printer WHERE Name = '{PrinterName}'");
			using ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			try
			{
				foreach (ManagementObject item in managementObjectCollection)
				{
					foreach (PropertyData property in item.Properties)
					{
						if (property.Name == "DriverName")
						{
							text = property.Value.ToString();
						}
					}
				}
			}
			catch (ManagementException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		else
		{
			text = PrinterName;
		}
		if (text.ToUpper().Contains("STAR"))
		{
			smethod_0(PrinterName, "\u001b@\u001b\a\u0014\u0014\a");
			return;
		}
		smethod_0(PrinterName, Convert.ToChar(27) + "@" + Convert.ToChar(27) + "p" + Convert.ToChar(0) + ".}");
	}

	public GClass8()
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
	}
}

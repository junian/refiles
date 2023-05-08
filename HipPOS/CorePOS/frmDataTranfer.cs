using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmDataTranfer : frmMasterForm
{
	private string string_0;

	private string string_1;

	private bool bool_0;

	private IContainer icontainer_1;

	private RadProgressBar progressBar1;

	private Label label1;

	private System.Windows.Forms.Timer timer_0;

	public frmDataTranfer()
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = string.Empty;
		string_1 = string.Empty;
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmDataTranfer_Load(object sender, EventArgs e)
	{
		timer_0.Enabled = true;
		timer_0.Start();
		timer_0.Interval = 100;
		progressBar1.Maximum = 100;
		timer_0.Tick += timer_0_Tick;
		new Thread(method_3).Start();
	}

	private void method_3()
	{
		string connectionString = Helper.GetConnectionString();
		if (!string.IsNullOrEmpty(connectionString))
		{
			int num = connectionString.IndexOf("Initial Catalog=");
			if (num != -1)
			{
				string text = connectionString.Substring(num + 16, connectionString.Length - (num + 16));
				num = text.IndexOf(";");
				if (num != -1)
				{
					text = (string_0 = text.Substring(0, num));
				}
			}
			else
			{
				num = connectionString.IndexOf("(LocalDB)\\MSSQLLocalDB;AttachDbFilename");
				if (num != -1)
				{
					string[] array = connectionString.Substring(num, connectionString.Length - num).Split('=');
					if (array.Length > 1)
					{
						num = array[1].IndexOf(";");
						if (num != -1)
						{
							string_0 = array[1].Substring(0, num);
						}
						else
						{
							string_0 = array[1];
						}
						string_1 = ".mdf";
						string_0 = string_0.Replace(string_1, string.Empty);
					}
				}
			}
		}
		if (string.IsNullOrEmpty(string_0))
		{
			string_0 = BrandingTerms.DatabaseName;
		}
		CopyDataToTrainingDB();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (progressBar1.Value1 == 100)
		{
			timer_0.Stop();
			Close();
		}
	}

	private void method_4(string string_2)
	{
		SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
		sqlConnection.Open();
		new SqlCommand(string_2, sqlConnection).ExecuteNonQuery();
		sqlConnection.Close();
	}

	private string method_5(List<string> list_2)
	{
		string text = "";
		foreach (string item in list_2)
		{
			text = text + "alter table[" + string_0 + "-Training" + string_1 + "].[dbo].[" + item + "] nocheck constraint all;";
		}
		return text;
	}

	private string method_6(List<string> list_2)
	{
		string text = "";
		foreach (string item in list_2)
		{
			text = text + "alter table[" + string_0 + "-Training" + string_1 + "].[dbo].[" + item + "] check constraint all;";
		}
		return text;
	}

	private string method_7(string string_2, bool bool_1)
	{
		string text = string.Empty;
		if (bool_1)
		{
			text = text + "SET IDENTITY_INSERT [" + string_0 + "-Training" + string_1 + "].[dbo].[" + string_2 + "] ON;";
		}
		text = text + "delete from [" + string_0 + "-Training" + string_1 + "].[dbo].[" + string_2 + "];";
		string text2 = "insert into [" + string_0 + "-Training" + string_1 + "].[dbo].[" + string_2 + "] (";
		string text3 = "select ";
		using (SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString()))
		{
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand("USE [" + string_0 + string_1 + "];SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + string_2 + "' order by Ordinal_position", sqlConnection);
			using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
			{
				while (sqlDataReader.Read())
				{
					text2 = text2 + "[" + sqlDataReader["COLUMN_NAME"].ToString() + "],";
					text3 = text3 + "[" + sqlDataReader["COLUMN_NAME"].ToString() + "],";
				}
				text2 = text2.Remove(text2.Length - 1);
				text3 = text3.Remove(text3.Length - 1);
				text2 += ")";
			}
			sqlConnection.Close();
		}
		text = text + text2 + " " + text3 + " from[" + string_0 + string_1 + "].[dbo].[" + string_2 + "]; ";
		if (bool_1)
		{
			text = text + "SET IDENTITY_INSERT [" + string_0 + "-Training" + string_1 + "].[dbo].[" + string_2 + "] OFF;";
		}
		return text;
	}

	private bool trtBspiTpp(string string_2)
	{
		using (SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString()))
		{
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand("select 1 from sys.columns c where c.object_id = object_id('" + string_2 + "') and c.is_identity = 1;", sqlConnection))
			{
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.Read())
				{
					sqlConnection.Close();
					return true;
				}
			}
			sqlConnection.Close();
		}
		return false;
	}

	public void CopyDataToTrainingDB()
	{
		string text = "";
		List<string> list = new List<string>();
		try
		{
			using (SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString()))
			{
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand("USE [" + string_0 + string_1 + "];SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = '" + string_0 + string_1 + "'", sqlConnection);
				using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
				{
					while (sqlDataReader.Read())
					{
						if (sqlDataReader["TABLE_NAME"].ToString() != "sysdiagrams")
						{
							list.Add(sqlDataReader["TABLE_NAME"].ToString());
						}
					}
				}
				sqlConnection.Close();
			}
			progressBar1.Value1 = 5;
			if (list.Count == 0)
			{
				progressBar1.Value1 = 100;
				return;
			}
			method_4(method_5(list));
			progressBar1.Value1 = 10;
			double num = 80.0 / (double)list.Count;
			foreach (string item in list.Where((string a) => a != "Orders"))
			{
				Thread.Sleep(100);
				text = item;
				string empty = string.Empty;
				empty = ((!trtBspiTpp(item)) ? method_7(item, bool_1: false) : method_7(item, bool_1: true));
				method_4(empty);
				progressBar1.Value1 = ((Convert.ToInt16((double)progressBar1.Value1 + num) > 100) ? 100 : Convert.ToInt16((double)progressBar1.Value1 + num));
			}
			method_4(method_6(list));
			progressBar1.Value1 = 100;
		}
		catch (Exception ex)
		{
			new frmMessageBox(Resources.Error_of_copying_data_from_pro + text + ") : " + ex.Message).ShowDialog();
			progressBar1.Value1 = 100;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		icontainer_1 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmDataTranfer));
		progressBar1 = new RadProgressBar();
		label1 = new Label();
		timer_0 = new System.Windows.Forms.Timer(icontainer_1);
		((ISupportInitialize)progressBar1).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(progressBar1, "progressBar1");
		progressBar1.ForeColor = Color.White;
		progressBar1.Name = "progressBar1";
		((RadProgressBarElement)progressBar1.GetChildAt(0)).Text = componentResourceManager.GetString("resource.Text");
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderColor = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderColor2 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderColor3 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderColor4 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderInnerColor = Color.FromArgb(21, 23, 33);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BackColor2 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BackColor3 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BackColor4 = Color.FromArgb(35, 39, 56);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BorderBottomColor = Color.FromArgb(0, 0, 0);
		((RadProgressBarElement)progressBar1.GetChildAt(0)).BackColor = Color.FromArgb(35, 39, 56);
		((ProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(0)).BackColor2 = Color.FromArgb(247, 192, 82);
		((ProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(0)).BackColor3 = Color.FromArgb(242, 182, 51);
		((ProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(0)).BackColor4 = Color.FromArgb(242, 182, 51);
		((ProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(0)).BackColor = Color.FromArgb(247, 192, 82);
		((ProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(0)).Visibility = ElementVisibility.Collapsed;
		((UpperProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(1)).BackColor2 = Color.FromArgb(247, 192, 82);
		((UpperProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(1)).BackColor3 = Color.FromArgb(242, 182, 51);
		((UpperProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(1)).BackColor4 = Color.FromArgb(242, 182, 51);
		((UpperProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(1)).BackColor = Color.FromArgb(247, 192, 82);
		((UpperProgressIndicatorElement)progressBar1.GetChildAt(0).GetChildAt(1)).Visibility = ElementVisibility.Collapsed;
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(label1);
		base.Controls.Add(progressBar1);
		base.Name = "frmDataTranfer";
		base.Opacity = 1.0;
		base.Load += frmDataTranfer_Load;
		((ISupportInitialize)progressBar1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}

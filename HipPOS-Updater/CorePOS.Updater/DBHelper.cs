using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace CorePOS.Updater;

public class DBHelper
{
	private string string_0;

	public string getConnectionString(bool isTraining)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + "\\connectionstring.txt";
			string text = string.Empty;
			if (File.Exists(path))
			{
				using (StreamReader streamReader = new StreamReader(path))
				{
					while (streamReader.Peek() >= 0)
					{
						text = streamReader.ReadLine();
					}
				}
				text = StringCipher.Decrypt(text, "DigitalCraftHipPOS");
				text = text.Replace("{%APPLICATION_PATH%}\\", AppDomain.CurrentDomain.BaseDirectory);
			}
			text = (string_0 = ((!isTraining) ? text.Replace("{%MODE%}", string.Empty) : text.Replace("{%MODE%}", "-Training")));
		}
		return string_0;
	}

	public void EncryptConnectionString()
	{
		string path = AppDomain.CurrentDomain.BaseDirectory + "\\connectionstring.txt";
		string text = string.Empty;
		if (File.Exists(path))
		{
			using StreamReader streamReader = new StreamReader(path);
			while (streamReader.Peek() >= 0)
			{
				text = streamReader.ReadLine();
			}
		}
		if (text.IndexOf("Data Source=") == 0)
		{
			File.WriteAllText(path, StringCipher.Encrypt(text, "DigitalCraftHipPOS"));
		}
	}

	private bool method_0(string string_1, bool bool_0)
	{
		SqlConnection sqlConnection = new SqlConnection(getConnectionString(bool_0));
		string cmdText = "IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES \r\n                       WHERE TABLE_NAME='" + string_1 + "') SELECT 1 ELSE SELECT 0";
		try
		{
			sqlConnection.Open();
		}
		catch
		{
			MessageBox.Show("Unable to connect to " + (bool_0 ? "training" : string.Empty) + " database.", "Database Error", MessageBoxButtons.OK);
			return false;
		}
		int num = Convert.ToInt32(new SqlCommand(cmdText, sqlConnection).ExecuteScalar());
		sqlConnection.Close();
		if (num == 0)
		{
			return false;
		}
		return true;
	}

	private bool method_1(string string_1, string string_2, bool bool_0)
	{
		SqlConnection sqlConnection = new SqlConnection(getConnectionString(bool_0));
		string cmdText = "IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'" + string_1 + "' AND Object_ID = Object_ID(N'" + string_2 + "')) SELECT 1 ELSE SELECT 0";
		try
		{
			sqlConnection.Open();
		}
		catch
		{
			MessageBox.Show("Unable to connect to " + (bool_0 ? "training" : string.Empty) + " database.", "Database Error", MessageBoxButtons.OK);
			Application.Exit();
		}
		int num = Convert.ToInt32(new SqlCommand(cmdText, sqlConnection).ExecuteScalar());
		sqlConnection.Close();
		if (num == 0)
		{
			return false;
		}
		return true;
	}

	private void method_2(string string_1, bool bool_0)
	{
		SqlConnection sqlConnection = new SqlConnection(getConnectionString(bool_0));
		try
		{
			sqlConnection.Open();
		}
		catch
		{
			MessageBox.Show("Unable to connect to " + (bool_0 ? "training" : string.Empty) + " database.", "Database Error", MessageBoxButtons.OK);
			return;
		}
		new SqlCommand(string_1, sqlConnection).ExecuteNonQuery();
		sqlConnection.Close();
	}

	private string method_3(string string_1, bool bool_0)
	{
		string empty = string.Empty;
		using SqlConnection sqlConnection = new SqlConnection(getConnectionString(bool_0));
		SqlCommand sqlCommand = new SqlCommand(string_1, sqlConnection);
		try
		{
			sqlConnection.Open();
		}
		catch
		{
			return "error-connection";
		}
		try
		{
			empty = (string)sqlCommand.ExecuteScalar();
		}
		catch
		{
			return "error";
		}
		sqlConnection.Close();
		return empty;
	}

	private bool twouihSvv(string string_1, bool bool_0)
	{
		bool flag = false;
		using SqlConnection sqlConnection = new SqlConnection(getConnectionString(bool_0));
		SqlCommand sqlCommand = new SqlCommand(string_1, sqlConnection);
		try
		{
			sqlConnection.Open();
		}
		catch
		{
			MessageBox.Show("Unable to connect to " + (bool_0 ? "training" : string.Empty) + " database.", "Database Error", MessageBoxButtons.OK);
			return false;
		}
		flag = (bool)sqlCommand.ExecuteScalar();
		sqlConnection.Close();
		return flag;
	}

	public string GetMachineProductKey()
	{
		return method_3("SELECT ProductKey FROM [dbo].[Terminals] WHERE SystemName = '" + Environment.MachineName + "'", bool_0: false);
	}

	public void upgrading_from_old_db(bool isTraining)
	{
		string empty = string.Empty;
		if (!method_1("FirstName", "Employees", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Employees] ADD [FirstName]  NVARCHAR (100) NULL;";
			method_2(empty, isTraining);
			if (!method_1("LastName", "Employees", isTraining))
			{
				empty = "ALTER TABLE [dbo].[Employees] ADD [LastName]  NVARCHAR (100) NULL;";
				method_2(empty, isTraining);
			}
			empty = "UPDATE [dbo].[Employees] SET [FirstName]=SUBSTRING([EmployeeName], 0, CHARINDEX(' ', [EmployeeName], 0)), [LastName]=SUBSTRING([EmployeeName], CHARINDEX(' ', [EmployeeName], 0), LEN([EmployeeName]) - CHARINDEX(' ', [EmployeeName], 0))";
			method_2(empty, isTraining);
		}
		if (!method_1("isActive", "Employees", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Employees] ADD [isActive] BIT CONSTRAINT [DF_Employees_isActive] DEFAULT ((-1)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "Groups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Groups] ADD[Synced] BIT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Active", "Groups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Groups] ADD [Active] BIT DEFAULT -1 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("ParentGroupID", "Groups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Groups] ADD [ParentGroupID] SMALLINT CONSTRAINT [DF_Groups_ParentGroupID] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("ParentGroupID", "Groups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Groups] ADD [ParentGroupID] SMALLINT CONSTRAINT [DF_Groups_ParentGroupID] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("ItemCost", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [ItemCost] DECIMAL (18, 4) CONSTRAINT [DF_Items_ItemCost] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Description", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [Description] NVARCHAR (MAX) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("ItemSalePrice", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [ItemSalePrice] DECIMAL(18, 2) CONSTRAINT[DF_Items_ItemPrice1] DEFAULT((0)) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("OnSale", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [OnSale] BIT CONSTRAINT [DF_Items_Taxable1] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Active", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [Active] BIT CONSTRAINT [DF_Items_Active] DEFAULT ((-1)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Barcode", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [Barcode] NVARCHAR (50)   NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("AllowProRated", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [AllowProRated] BIT CONSTRAINT [DF_Items_AllowProRated] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("InventoryCount", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [InventoryCount] DECIMAL (18, 4) CONSTRAINT [DF_Items_InventoryCount] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [Synced] BIT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("TrackInventory", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [TrackInventory] BIT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Temp", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [Temp] NVARCHAR (128) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "ItemsInGroups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsInGroups] ADD[Synced] BIT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Quantity", "ItemsInItem", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsInItem] ADD[Quantity] DECIMAL DEFAULT((0)) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "ItemsInItem", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsInItem] ADD[Synced] BIT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("StartDateOnSale", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [StartDateOnSale] DATETIME DEFAULT (NULL) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("EndDateOnSale", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [EndDateOnSale] DATETIME DEFAULT (NULL) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("DisableSoldOutItems", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [DisableSoldOutItems] BIT DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("CustomerID", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [CustomerID] INT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("TaxDesc", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [TaxDesc] NVARCHAR (50) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("GroupName", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [GroupName] NVARCHAR (100) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Qty", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [Qty] DECIMAL (16, 4) CONSTRAINT [DF_Orders_ItemPrice1] DEFAULT ((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("ItemCost", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [ItemCost] DECIMAL (8, 4) CONSTRAINT [DF_Orders_ItemCost] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("ItemPrice", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [ItemPrice] DECIMAL (6, 2) CONSTRAINT [DF_Orders_ItemPrice] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("ItemSellPrice", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [ItemSellPrice] DECIMAL (6, 2) CONSTRAINT [DF_Orders_ItemPrice1_1] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("DateRefunded", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [DateRefunded] DATETIME NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("VoidBy", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [VoidBy] NVARCHAR (100) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Options", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [Options] NVARCHAR (255) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("ComboID", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [ComboID] SMALLINT DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [Synced] BIT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("LastSynced", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [LastSynced]     DATETIME         NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("HasCashDrawer", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [HasCashDrawer] BIT CONSTRAINT [DF_Stations_HasCashDrawer] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("IPAddress", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [IPAddress]     NVARCHAR (15) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("ComputerName", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [ComputerName]  NVARCHAR (50) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Description", "Tax", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Tax] ADD [Description] NVARCHAR (MAX) NULL; ";
			method_2(empty, isTraining);
		}
		string text = "CREATE TABLE [dbo].[Appointments] (    [AppointmentID] INT            IDENTITY (1, 1) NOT NULL,    [EmployeeID]    INT            NOT NULL,    [NumOfPeople]    INT           DEFAULT ((0)),    [CustomerName]  NVARCHAR (50)  NOT NULL,    [CustomerCell]  NVARCHAR (10)  NULL,    [CustomerHome]  NVARCHAR (10)  NULL,    [CustomerEmail] NVARCHAR (MAX) NULL,    [Comments]      NVARCHAR (MAX) NULL,    [StartDateTime] DATETIME       NOT NULL,    [EndDateTime]   DATETIME       NOT NULL,    [DateCreated]   DATETIME       CONSTRAINT [DF_Appointments_DateCreated] DEFAULT (getdate()) NOT NULL,    [SMSSent]       BIT            CONSTRAINT [DF_Appointments_SMSSent] DEFAULT ((0)) NOT NULL,    [EmailSent]     BIT            CONSTRAINT [DF_Appointments_EmailSent] DEFAULT ((0)) NOT NULL,    [isCancelled]   BIT            CONSTRAINT [DF_Appointments_isCancelled] DEFAULT ((0)) NOT NULL,    [isNoShow]      BIT            CONSTRAINT [DF_Appointments_isNoShow] DEFAULT ((0)) NOT NULL,    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([AppointmentID] ASC),    CONSTRAINT [FK_Appointments_Employees] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employees] ([EmployeeID]));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Appointments') BEGIN " + text + " END";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[Customers] (    [CustomerID]    INT            IDENTITY (1, 1) NOT NULL,    [EmployeeID]    INT            NOT NULL,    [MemberNumber]  NVARCHAR (50)  NULL,    [CustomerName]  NVARCHAR (50)  NOT NULL,    [CustomerCell]  NVARCHAR (10)  NULL,    [CustomerHome]  NVARCHAR (10)  NULL,    [CustomerEmail] NVARCHAR (MAX) NULL,    [Comments]      NVARCHAR (MAX) NULL,    [DateCreated]   DATETIME       CONSTRAINT [DF_Customers_DateCreated] DEFAULT (getdate()) NOT NULL,    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC),    CONSTRAINT [FK_Customers_Employees] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employees] ([EmployeeID]));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Customers') BEGIN " + text + " END";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[CustomFields] (    [CustomFieldId] SMALLINT      IDENTITY (1, 1) NOT NULL,    [Value]         NVARCHAR (50) NOT NULL,    [Sycned]        BIT           DEFAULT ((0)) NOT NULL,    CONSTRAINT [aaaaaCustomFields_PK] PRIMARY KEY NONCLUSTERED ([CustomFieldId] ASC));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'CustomFields') BEGIN " + text + " END";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[InventoryAudits] (    [InventoryAuditId]      INT             IDENTITY (1, 1) NOT NULL,    [ItemID]                INT             NOT NULL,    [QtyStart]              DECIMAL (18, 4) DEFAULT ((0)) NOT NULL,    [QtyChange]             DECIMAL (18, 4) DEFAULT ((0)) NOT NULL,    [QtyNew]                DECIMAL (18, 4) DEFAULT ((0)) NOT NULL,    [Owner]                 NVARCHAR (50)   NULL,    [Comment]               NVARCHAR (MAX)  NULL,    [DateCreated]           DATETIME        DEFAULT (getdate()) NOT NULL,     [Synced]                BIT             DEFAULT ((0)) NOT NULL,     [CloudInventoryAuditID] BIGINT          DEFAULT ((0)) NOT NULL,     PRIMARY KEY CLUSTERED ([InventoryAuditId] ASC)); ";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'InventoryAudits') BEGIN " + text + " END";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[ItemCustomFieldValue] (    [Id]            INT           IDENTITY (1, 1) NOT NULL,    [ItemId]        INT           NOT NULL,    [CustomFieldId] SMALLINT      NOT NULL,    [Value]         NVARCHAR (50) NULL,    [Synced]        BIT           DEFAULT ((0)) NOT NULL,    CONSTRAINT [aaaaaItemCustomFieldValue_PK] PRIMARY KEY NONCLUSTERED ([Id] ASC),    CONSTRAINT [FK_ItemCustomFieldValue_Groups] FOREIGN KEY ([CustomFieldId]) REFERENCES [dbo].[CustomFields] ([CustomFieldId]),    CONSTRAINT [FK_ItemCustomFieldValue_Items] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([ItemID]));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'ItemCustomFieldValue') BEGIN " + text + " END";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[ItemTypes] (    [ItemTypeID]   INT           IDENTITY (1, 1) NOT NULL,    [ItemTypeName] NVARCHAR (50) NOT NULL,    PRIMARY KEY CLUSTERED ([ItemTypeID] ASC));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'ItemTypes') BEGIN " + text + " END";
		method_2(empty, isTraining);
		empty = "SET IDENTITY_INSERT [dbo].[ItemTypes] ON IF NOT EXISTS (SELECT * FROM [dbo].[ItemTypes] WHERE [ItemTypeID] = 1) BEGIN INSERT [dbo].[ItemTypes] ([ItemTypeID], [ItemTypeName]) VALUES (1, N'Other Goods & Services') END;IF NOT EXISTS (SELECT * FROM [dbo].[ItemTypes] WHERE [ItemTypeID] = 2) BEGIN INSERT [dbo].[ItemTypes] ([ItemTypeID], [ItemTypeName]) VALUES (2, N'Prepared Food & Beverages') END;IF NOT EXISTS (SELECT * FROM [dbo].[ItemTypes] WHERE [ItemTypeID] = 3) BEGIN INSERT [dbo].[ItemTypes] ([ItemTypeID], [ItemTypeName]) VALUES (3, N'Snack & Beverages') END;SET IDENTITY_INSERT [dbo].[ItemTypes] OFF";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[Refunds] (    [RefundID]       UNIQUEIDENTIFIER CONSTRAINT [DF_Refunds_RefundID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,    [RefundNumber]   NVARCHAR (10)    NOT NULL,    [DateCreated]    DATETIME         CONSTRAINT [DF_Refunds_DateCreated] DEFAULT (getdate()) NOT NULL,    [OrderId]        UNIQUEIDENTIFIER NOT NULL,    [Qty]            DECIMAL (16, 4)  CONSTRAINT [DF_Refunds_Qty] DEFAULT ((1)) NOT NULL,    [AmountRefunded] DECIMAL (10, 2)  DEFAULT ((0)) NOT NULL,    [EmployeeID]     INT              NULL,    CONSTRAINT [PK_Refunds] PRIMARY KEY CLUSTERED ([RefundID] ASC),    CONSTRAINT [FK_Refunds_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([OrderId]),    CONSTRAINT [FK_Refunds_Employees] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employees] ([EmployeeID]));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Refunds') BEGIN " + text + " END";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[Settings] (    [SettingID]      INT            IDENTITY (1, 1) NOT NULL,    [Key]            NVARCHAR (50)  NOT NULL,    [Value]          NVARCHAR (160) NOT NULL,    [ToolTip]        NVARCHAR (MAX) NULL,    [ShowInSettings] BIT            CONSTRAINT [DF_Settings_ShowInSettings] DEFAULT ((0)) NOT NULL,    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([SettingID] ASC));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Settings') BEGIN " + text + " END";
		method_2(empty, isTraining);
		empty = "SET IDENTITY_INSERT [dbo].[Settings] ON IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'smtp_server') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (1, N'smtp_server', N'', N'Your e-mail SMTP Server IP or Domain.', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'smtp_port') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (2, N'smtp_port', N'25', N'Your e-mail SMTP Server port.', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'smtp_username') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (4, N'smtp_username', N'', N'Your e-mail SMTP login username.', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'smtp_password') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (5, N'smtp_password', N'', N'Your e-mail SMTP Server login password.', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'smtp_use_ssl') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (6, N'smtp_use_ssl', N'False', N'Does your SMTP server use SSL encryption?', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'sms_token') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (7, N'sms_token', N'', NULL, 0) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'sms_country_code') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (8, N'sms_country_code', N'', NULL, 0) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'sms_message') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (9, N'sms_message', N'', NULL, 0) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'sms_server') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (10, N'sms_server', N'', NULL, 0) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'UserNotes') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (11, N'UserNotes', N'', NULL, 0) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'cloudsync_api_key') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (13, N'cloudsync_api_key', N'', N'CloudSync API key.  If you do not one, please visit https://www.hipposhq.com to sign up.', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'cloudsync_station') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (16, N'cloudsync_station', N'', N'The name of the computer that will handle the task of sending orders to the cloud.', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'printer_default') BEGIN INSERT [dbo].[Settings] ([SettingID], [Key], [Value], [ToolTip], [ShowInSettings]) VALUES (17, N'printer_default', N'Select A Printer', N'Select a default receipt printer', 1) END;SET IDENTITY_INSERT [dbo].[Settings] OFF";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[TaxRules] (    [TaxRuleId] INT           IDENTITY (1, 1) NOT NULL,    [RuleName]  NVARCHAR (50) NOT NULL,    [Active]    BIT           DEFAULT ((-1)) NOT NULL,    PRIMARY KEY CLUSTERED ([TaxRuleId] ASC));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'TaxRules') BEGIN " + text + " END";
		method_2(empty, isTraining);
		empty = "SET IDENTITY_INSERT [dbo].[TaxRules] ON; IF NOT EXISTS (SELECT * FROM [dbo].[TaxRules] WHERE [RuleName] = 'Prepared Foods & Beverages') BEGIN INSERT [dbo].[TaxRules] ([TaxRuleId], [RuleName], [Active]) VALUES (8, N'Prepared Foods & Beverages', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRules] WHERE [RuleName] = '* Default') BEGIN INSERT [dbo].[TaxRules] ([TaxRuleId], [RuleName], [Active]) VALUES (9, N'* Default', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRules] WHERE [RuleName] = 'Snack Foods') BEGIN INSERT [dbo].[TaxRules] ([TaxRuleId], [RuleName], [Active]) VALUES (10, N'Snack Foods', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRules] WHERE [RuleName] = 'Zero Rated HST') BEGIN INSERT [dbo].[TaxRules] ([TaxRuleId], [RuleName], [Active]) VALUES (12, N'Zero Rated HST', 1) END;SET IDENTITY_INSERT [dbo].[TaxRules] OFF";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[TaxRuleRequirements] (    [TaxRuleRequirementId] UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,    [RequirementDesc]      NVARCHAR (255)   NOT NULL,    PRIMARY KEY CLUSTERED ([TaxRuleRequirementId] ASC));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'TaxRuleRequirements') BEGIN " + text + " END";
		method_2(empty, isTraining);
		empty = "IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleRequirements] WHERE [TaxRuleRequirementId] = '58ff6ce4-00e9-47b4-97ba-3fe1179464d3') BEGIN INSERT [dbo].[TaxRuleRequirements] ([TaxRuleRequirementId], [RequirementDesc]) VALUES (N'58ff6ce4-00e9-47b4-97ba-3fe1179464d3', N'If item price is') END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleRequirements] WHERE [TaxRuleRequirementId] = '25116f4f-8273-4b5c-a6b4-555eef41a1e0') BEGIN INSERT [dbo].[TaxRuleRequirements] ([TaxRuleRequirementId], [RequirementDesc]) VALUES (N'25116f4f-8273-4b5c-a6b4-555eef41a1e0', N'If order contains Prepared Foods and subtotal of all Prepared and Snack foods are') END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleRequirements] WHERE [TaxRuleRequirementId] = '2e3a1fe0-843b-40b1-9946-de876214e1bc') BEGIN INSERT [dbo].[TaxRuleRequirements] ([TaxRuleRequirementId], [RequirementDesc]) VALUES (N'2e3a1fe0-843b-40b1-9946-de876214e1bc', N'If subtotal of all Prepared and Snack foods are') END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleRequirements] WHERE [TaxRuleRequirementId] = 'dc08ec92-50aa-4966-84b4-fc87917765f4') BEGIN INSERT [dbo].[TaxRuleRequirements] ([TaxRuleRequirementId], [RequirementDesc]) VALUES (N'dc08ec92-50aa-4966-84b4-fc87917765f4', N'If order does not contain Prepared Foods') END;";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[TaxRuleOperations] (    [TaxRuleOperatorId]    INT              IDENTITY (1, 1) NOT NULL,    [TaxRuleId]            INT              NOT NULL,    [TaxRuleRequirementID] UNIQUEIDENTIFIER DEFAULT ('58ff6ce4-00e9-47b4-97ba-3fe1179464d3') NOT NULL,    [Operator]             NVARCHAR (2)     NOT NULL,    [Condition]            DECIMAL (18, 2)  DEFAULT ((0)) NOT NULL,    [TaxID]                INT              NOT NULL,    PRIMARY KEY CLUSTERED ([TaxRuleOperatorId] ASC),    CONSTRAINT [FK_TaxRuleOperations_ToTaxRule] FOREIGN KEY ([TaxRuleId]) REFERENCES [dbo].[TaxRules] ([TaxRuleId]),    CONSTRAINT [FK_TaxRuleOperations_ToTax] FOREIGN KEY ([TaxID]) REFERENCES [dbo].[Tax] ([TaxID]),    CONSTRAINT [FK_TaxRuleOperations_ToTaxRuleRequirement] FOREIGN KEY ([TaxRuleRequirementID]) REFERENCES [dbo].[TaxRuleRequirements] ([TaxRuleRequirementId]));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'TaxRuleOperations') BEGIN " + text + " END";
		method_2(empty, isTraining);
		empty = "SET IDENTITY_INSERT [dbo].[TaxRuleOperations] ON IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleOperations] WHERE [TaxRuleOperatorId] = 5) BEGIN INSERT [dbo].[TaxRuleOperations] ([TaxRuleOperatorId], [TaxRuleId], [TaxRuleRequirementID], [Operator], [Condition], [TaxID]) VALUES (5, 8, N'2e3a1fe0-843b-40b1-9946-de876214e1bc', N'<=', CAST(4.00 AS Decimal(18, 2)), 3) END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleOperations] WHERE [TaxRuleOperatorId] = 6) BEGIN INSERT [dbo].[TaxRuleOperations] ([TaxRuleOperatorId], [TaxRuleId], [TaxRuleRequirementID], [Operator], [Condition], [TaxID]) VALUES (6, 8, N'2e3a1fe0-843b-40b1-9946-de876214e1bc', N'>', CAST(4.00 AS Decimal(18, 2)), 2) END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleOperations] WHERE [TaxRuleOperatorId] = 7) BEGIN INSERT [dbo].[TaxRuleOperations] ([TaxRuleOperatorId], [TaxRuleId], [TaxRuleRequirementID], [Operator], [Condition], [TaxID]) VALUES (7, 9, N'58ff6ce4-00e9-47b4-97ba-3fe1179464d3', N'>', CAST(0.00 AS Decimal(18, 2)), 2) END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleOperations] WHERE [TaxRuleOperatorId] = 9) BEGIN INSERT [dbo].[TaxRuleOperations] ([TaxRuleOperatorId], [TaxRuleId], [TaxRuleRequirementID], [Operator], [Condition], [TaxID]) VALUES (9, 10, N'25116f4f-8273-4b5c-a6b4-555eef41a1e0', N'<=', CAST(4.00 AS Decimal(18, 2)), 3) END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleOperations] WHERE [TaxRuleOperatorId] = 10) BEGIN INSERT [dbo].[TaxRuleOperations] ([TaxRuleOperatorId], [TaxRuleId], [TaxRuleRequirementID], [Operator], [Condition], [TaxID]) VALUES (10, 10, N'25116f4f-8273-4b5c-a6b4-555eef41a1e0', N'>', CAST(4.00 AS Decimal(18, 2)), 2) END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleOperations] WHERE [TaxRuleOperatorId] = 11) BEGIN INSERT [dbo].[TaxRuleOperations] ([TaxRuleOperatorId], [TaxRuleId], [TaxRuleRequirementID], [Operator], [Condition], [TaxID]) VALUES (11, 10, N'dc08ec92-50aa-4966-84b4-fc87917765f4', N'>', CAST(0.00 AS Decimal(18, 2)), 2) END;IF NOT EXISTS (SELECT * FROM [dbo].[TaxRuleOperations] WHERE [TaxRuleOperatorId] = 13) BEGIN INSERT [dbo].[TaxRuleOperations] ([TaxRuleOperatorId], [TaxRuleId], [TaxRuleRequirementID], [Operator], [Condition], [TaxID]) VALUES (13, 12, N'58ff6ce4-00e9-47b4-97ba-3fe1179464d3', N'>', CAST(0.00 AS Decimal(18, 2)), 4) END;SET IDENTITY_INSERT [dbo].[TaxRuleOperations] OFF";
		method_2(empty, isTraining);
		text = "CREATE TABLE [dbo].[UOMs] (    [UOMID]        SMALLINT      IDENTITY (1, 1) NOT NULL,    [Name]         NVARCHAR (50) NOT NULL,    [isFractional] BIT           DEFAULT ((0)) NOT NULL,    CONSTRAINT [PK_UOMs] PRIMARY KEY CLUSTERED ([UOMID] ASC));";
		empty = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'UOMs') BEGIN " + text + " END";
		method_2(empty, isTraining);
		empty = "SET IDENTITY_INSERT [dbo].[UOMs] ON IF NOT EXISTS (SELECT * FROM [dbo].[UOMs] WHERE [UOMID] = 1) BEGIN INSERT [dbo].[UOMs] ([UOMID], [Name], [isFractional]) VALUES (1, N'Each', 0) END;IF NOT EXISTS (SELECT * FROM [dbo].[UOMs] WHERE [UOMID] = 2) BEGIN INSERT [dbo].[UOMs] ([UOMID], [Name], [isFractional]) VALUES (2, N'LB', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[UOMs] WHERE [UOMID] = 3) BEGIN INSERT [dbo].[UOMs] ([UOMID], [Name], [isFractional]) VALUES (3, N'KG', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[UOMs] WHERE [UOMID] = 4) BEGIN INSERT [dbo].[UOMs] ([UOMID], [Name], [isFractional]) VALUES (4, N'Gram', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[UOMs] WHERE [UOMID] = 5) BEGIN INSERT [dbo].[UOMs] ([UOMID], [Name], [isFractional]) VALUES (5, N'Box', 0) END;IF NOT EXISTS (SELECT * FROM [dbo].[UOMs] WHERE [UOMID] = 6) BEGIN INSERT [dbo].[UOMs] ([UOMID], [Name], [isFractional]) VALUES (6, N'Pack', 0) END;SET IDENTITY_INSERT [dbo].[UOMs] OFF";
		method_2(empty, isTraining);
		if (!method_1("TaxRuleID", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [TaxRuleID] INT DEFAULT ((8)) NOT NULL;";
			method_2(empty, isTraining);
			empty = "UPDATE [dbo].[Items] SET TaxRuleID=8 WHERE TaxRuleID=0;";
			method_2(empty, isTraining);
			empty = "ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_TaxRule] FOREIGN KEY([TaxRuleID]) REFERENCES[dbo].[TaxRules]([TaxRuleId]);";
			method_2(empty, isTraining);
			empty = "ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_TaxRule];";
			method_2(empty, isTraining);
		}
		else
		{
			empty = "UPDATE [dbo].[Items] SET TaxRuleID=8 WHERE TaxRuleID=0;";
			method_2(empty, isTraining);
		}
		empty = "UPDATE [dbo].Items SET ItemColor = '150,166,166' WHERE ItemColor NOT LIKE '%,%' OR ItemColor IS NULL";
		method_2(empty, isTraining);
		if (method_1("GroupColor", "Groups", isTraining))
		{
			empty = "UPDATE [dbo].Groups SET GroupColor = '150,166,166' WHERE GroupColor NOT LIKE '%,%' OR GroupColor IS NULL";
			method_2(empty, isTraining);
		}
		empty = "UPDATE [dbo].[Roles] SET RoleName='Admin' WHERE RoleID=1";
		method_2(empty, isTraining);
		empty = "UPDATE [dbo].[Roles] SET RoleName='Manager' WHERE RoleID=2";
		method_2(empty, isTraining);
		empty = "UPDATE [dbo].[Roles] SET RoleName='Staff' WHERE RoleID=3";
		method_2(empty, isTraining);
		if (!method_1("ItemTypeID", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [ItemTypeID] INT DEFAULT ((1)) NOT NULL; ";
			method_2(empty, isTraining);
			empty = "ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_ItemType] FOREIGN KEY([ItemTypeID]) REFERENCES[dbo].[ItemTypes]([ItemTypeID])";
			method_2(empty, isTraining);
			empty = "ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_ItemType];";
			method_2(empty, isTraining);
		}
		if (!method_1("UOMID", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [UOMID] SMALLINT CONSTRAINT [DF_Items_UOMID] DEFAULT ((1)) NOT NULL; ";
			method_2(empty, isTraining);
			empty = "ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_UOMs] FOREIGN KEY([UOMID]) REFERENCES[dbo].[UOMs]([UOMID]);";
			method_2(empty, isTraining);
			empty = "ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_UOMs]";
			method_2(empty, isTraining);
		}
		if (!method_1("NumOfPeople", "Appointments", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Appointments] ADD [NumOfPeople] INT DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("NextNotifyDateTime", "Appointments", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Appointments] ADD [NextNotifyDateTime] DATETIME NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("ReminderDismissed", "Appointments", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Appointments] ADD [ReminderDismissed] BIT DEFAULT ((0)) NOT NULL; ; ";
			method_2(empty, isTraining);
		}
	}

	public string checkCorrectSoftwareType(bool isTraining)
	{
		string text = method_3("SELECT [StoreType] FROM [dbo].[CompanySetup]", isTraining);
		if (text == "error-connection")
		{
			return text;
		}
		if (!method_1("StoreType", "CompanySetup", isTraining))
		{
			if (!method_1("Capacity", "CompanySetup", bool_0: false))
			{
				string string_ = "ALTER TABLE [dbo].[CompanySetup] ADD [StoreType] nvarchar(20) NULL; ";
				method_2(string_, isTraining);
				string_ = "UPDATE [dbo].[CompanySetup] SET [StoreType]='retail'";
				method_2(string_, isTraining);
			}
			else
			{
				string string_ = "ALTER TABLE [dbo].[CompanySetup] ADD [StoreType] nvarchar(20) NULL; ";
				method_2(string_, isTraining);
				string_ = "UPDATE [dbo].[CompanySetup] SET [StoreType]='restaurant'";
				method_2(string_, isTraining);
			}
		}
		return method_3("SELECT [StoreType] FROM [dbo].[CompanySetup]", isTraining);
	}

	public void updateversion(bool isTraining, string appVersion)
	{
		string string_ = "UPDATE settings SET value = '" + appVersion + "' WHERE [key] = 'db_version';";
		method_2(string_, isTraining);
	}

	public void one_zeroone_to_one_zerotwo(bool isTraining)
	{
		string empty = string.Empty;
		if (!method_1("CloudItemID", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD[CloudItemID] BIGINT NOT NULL DEFAULT 0; ";
			method_2(empty, isTraining);
		}
		if (!method_1("StartTimeOnSale", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [StartTimeOnSale] DATETIME DEFAULT (NULL) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("EndTimeOnSale", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [EndTimeOnSale] DATETIME DEFAULT (NULL) NULL; ";
			method_2(empty, isTraining);
		}
		string empty2 = string.Empty;
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'cloudsync_time_range') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('cloudsync_time_range', 'OFF', 'Set the Time range where your Pos Syncs to Cloud', 1)  END";
		method_2(empty2, isTraining);
		if (!method_1("Section", "Layout", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Layout] ADD [Section] NVARCHAR (100) DEFAULT (N'') NOT NULL; ";
			method_2(empty, isTraining);
		}
		empty = "ALTER TABLE [dbo].[Options] ALTER COLUMN [SpecialPrice]  DECIMAL (18, 2) NULL;";
		method_2(empty, isTraining);
		if (!method_1("LatestOpeningTime", "CompanySetup", isTraining))
		{
			empty = "ALTER TABLE [dbo].[CompanySetup] ADD [LatestOpeningTime] NVARCHAR (20)  CONSTRAINT [DF_CompanySetup_LatestOpeningTime] DEFAULT (N'8:00:00 AM') NOT NULL; ";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'receipt_footer_message') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('receipt_footer_message', '', 'Receipt Footer Message that is to be printed at the bottom of the receipt', 1)  END";
		method_2(empty2, isTraining);
		empty = "ALTER TABLE [dbo].[Settings] ALTER COLUMN Value NVARCHAR (MAX) NOT NULL;";
		method_2(empty, isTraining);
	}

	public void one_zerofour_to_one_zerofive(bool isTraining)
	{
		string empty = string.Empty;
		if (!method_1("CustomerInfo", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [CustomerInfo] NVARCHAR (1024) NULL; ";
			method_2(empty, isTraining);
		}
	}

	public void one_zerosix_to_one_zeroseven(bool isTraining)
	{
		string empty = string.Empty;
		empty = "UPDATE [dbo].[Settings] SET [ToolTip]='CloudSync API key. If you do not have one please visit https://www.hipposhq.com to sign up.' WHERE [Key]='cloudsync_api_key';";
		empty += "UPDATE [dbo].[Settings] SET [ToolTip]='The name of the computer that will handle the task of sending orders to the Cloud.' WHERE [Key]='cloudsync_station';";
		empty += "UPDATE [dbo].[Settings] SET [ToolTip]='Set the time range when your POS syncs to Cloud.' WHERE [Key]='cloudsync_time_range';";
		empty += "UPDATE [dbo].[Settings] SET [ToolTip]='Select a default receipt printer.' WHERE [Key]='printer_default';";
		empty += "UPDATE [dbo].[Settings] SET [ToolTip]='The footer message that will be displayed at the bottom of each receipt.' WHERE [Key]='receipt_footer_message';";
		empty += "UPDATE [dbo].[Settings] SET [ToolTip]='Activate the second screen functionality built into the Order Entry screen.' WHERE [Key]='second_screen';";
		method_2(empty, isTraining);
	}

	public void one_zeroeight_to_one_zeronine(bool isTraining, string version)
	{
		string empty = string.Empty;
		if (!method_1("DiscountReason", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [DiscountReason] NVARCHAR (100) NULL";
			method_2(empty, isTraining);
		}
		if (method_0("OrderDiscountReasons", isTraining))
		{
			empty = "UPDATE Orders SET Orders.DiscountReason = OrderDiscountReasons.DiscountReason FROM Orders JOIN OrderDiscountReasons ON Orders.OrderNumber = OrderDiscountReasons.OrderNumber ";
			method_2(empty, isTraining);
			empty = "DROP TABLE OrderDiscountReasons;";
			method_2(empty, isTraining);
		}
		if (version == "1.09.0" && method_1("DiscountReason", "Orders", isTraining))
		{
			empty = "UPDATE Orders SET Synced = 0 WHERE DiscountReason IS NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("ItemClassification", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [ItemClassification] NVARCHAR(128) NOT NULL DEFAULT 'product';";
			method_2(empty, isTraining);
		}
		if (!method_0("MaterialsInItem", isTraining))
		{
			empty = "CREATE TABLE[dbo].[MaterialsInItem] ([ID] INT IDENTITY(1, 1) NOT NULL,[ItemID] INT NOT NULL,[ItemMaterialID] INT NOT NULL,[Quantity] DECIMAL(18, 2) NULL,[UOMID] SMALLINT DEFAULT ((1)) NOT NULL,CONSTRAINT [FK_MaterialsInItem_UOMs] FOREIGN KEY ([UOMID]) REFERENCES [dbo].[UOMs] ([UOMID]),CONSTRAINT[aaaaaMaterialsInItem_PK] PRIMARY KEY NONCLUSTERED([Id] ASC));";
			method_2(empty, isTraining);
		}
		if (!method_1("InventoryType", "InventoryAudits", isTraining))
		{
			empty = "ALTER TABLE [dbo].[InventoryAudits] ADD [InventoryType] NVARCHAR(128) NOT NULL DEFAULT 'product';";
			method_2(empty, isTraining);
		}
		if (!method_1("GroupClassification", "Groups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Groups] ADD [GroupClassification] NVARCHAR(128) NOT NULL DEFAULT 'product';";
			method_2(empty, isTraining);
		}
		if (!method_1("DaysSaleList", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [DaysSaleList] NVARCHAR (512) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "TaxRules", isTraining))
		{
			empty = "ALTER TABLE [dbo].[TaxRules] ADD [Synced] BIT NOT NULL DEFAULT '0';";
			method_2(empty, isTraining);
		}
		if (version == "1.09.0")
		{
			empty = "UPDATE [dbo].[Items] Set [Synced] = 0;";
			empty += "IF EXISTS (SELECT 1 FROM sys.default_constraints WHERE object_id = OBJECT_ID('[dbo].[DF_Orders_ItemPrice1]') AND parent_object_id = OBJECT_ID('[dbo].[Orders]')) BEGIN ALTER TABLE[dbo].[Orders] DROP CONSTRAINT [DF_Orders_ItemPrice1] END;";
			empty += "ALTER TABLE [dbo].[Orders] ALTER COLUMN Qty INT;";
			empty += "ALTER TABLE [dbo].[Orders] ALTER COLUMN ItemCost decimal(10,4);";
			empty += "ALTER TABLE [dbo].[Orders] ALTER COLUMN ItemPrice decimal(10,4);";
			empty += "ALTER TABLE [dbo].[Orders] ALTER COLUMN ItemSellPrice decimal(10,4);";
			empty += "ALTER TABLE [dbo].[Orders] ALTER COLUMN Discount decimal(10,4);";
			empty += "ALTER TABLE [dbo].[Orders] ALTER COLUMN SubTotal decimal(10,4);";
			method_2(empty, isTraining);
		}
		if (!method_1("PaymentMethod", "Refunds", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Refunds] ADD [PaymentMethod]  NVARCHAR(50)    DEFAULT('CASH') NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("RefundReason", "Refunds", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Refunds] ADD[RefundReason] NVARCHAR (100)   NULL; ";
			method_2(empty, isTraining);
		}
		if (method_0("DiscountReasons", isTraining))
		{
			if (!method_0("Reasons", isTraining))
			{
				if (method_1("Reason", "DiscountReasons", isTraining))
				{
					empty = "exec sp_rename 'DiscountReasons.Reason', 'Value', 'COLUMN';";
					method_2(empty, isTraining);
				}
				empty = "exec sp_rename '[dbo].[DiscountReasons]','Reasons';";
				method_2(empty, isTraining);
				empty = "exec sp_rename 'DiscountReason_PK', 'Reason_PK', 'object'; ";
				method_2(empty, isTraining);
			}
		}
		else if (!method_0("Reasons", isTraining))
		{
			empty = "CREATE TABLE [dbo].[Reasons] ( [Id]            INT IDENTITY (1, 1) NOT NULL,[Value]        NVARCHAR (255) NULL,CONSTRAINT [Reason_PK] PRIMARY KEY NONCLUSTERED ([Id] ASC));";
			method_2(empty, isTraining);
		}
		if (!method_1("ReasonType", "Reasons", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Reasons] ADD[ReasonType] NVARCHAR (50) DEFAULT ('discount') NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (method_1("Reason", "Reasons", isTraining))
		{
			empty = "exec sp_rename 'Reasons.Reason', 'Value', 'COLUMN';";
			method_2(empty, isTraining);
		}
		if (method_1("DiscountReason", "Reasons", isTraining))
		{
			empty = "exec sp_rename 'Reasons.DiscountReason', 'Value', 'COLUMN';";
			method_2(empty, isTraining);
		}
		string empty2 = string.Empty;
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ItemTypes] WHERE [ItemTypeName] = 'Ticket, Fare, or Admission') BEGIN INSERT INTO [dbo].[ItemTypes] ([ItemTypeName]) VALUES ('Ticket, Fare, or Admission')  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Reasons] WHERE [Value] = 'Purchased Wrong Item') BEGIN INSERT INTO [dbo].[Reasons] ([Value], [ReasonType]) VALUES ('Purchased Wrong Item','refund')  END; ";
		empty2 += "IF NOT EXISTS ( SELECT * FROM [dbo].[Reasons] WHERE [Value] = 'Missing Parts') BEGIN INSERT INTO [dbo].[Reasons] ([Value], [ReasonType]) VALUES ('Missing Parts','refund')  END; ";
		empty2 += "IF NOT EXISTS ( SELECT * FROM [dbo].[Reasons] WHERE [Value] = 'Item Damaged') BEGIN INSERT INTO [dbo].[Reasons] ([Value], [ReasonType]) VALUES ('Item Damaged','refund')  END; ";
		empty2 += "IF NOT EXISTS ( SELECT * FROM [dbo].[Reasons] WHERE [Value] = 'Purchased Too Many') BEGIN INSERT INTO [dbo].[Reasons] ([Value], [ReasonType]) VALUES ('Purchased Too Many','refund')  END; ";
		method_2(empty2, isTraining);
	}

	public void one_zeronine_zero_to_one_zeronine_one(bool isTraining)
	{
		string empty = string.Empty;
		empty = "IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'printer_kitchen') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES (N'printer_kitchen', N'Select The Kitchen Printer', N'Select the kitchen receipt printer.', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_to_kitchen') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES (N'print_to_kitchen', N'OFF', N'Enable print to kitchen feature.', 1) END;";
		method_2(empty, isTraining);
	}

	public void one_zeronine_two_to_one_zeronine_three(bool isTraining, string version)
	{
		string empty = string.Empty;
		if (!method_1("Synced", "ItemTypes", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemTypes] ADD[Synced] BIT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("TenderAmount", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [TenderAmount] DECIMAL (10, 2) DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("TenderChange", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [TenderChange] DECIMAL (10, 2) DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_0("ItemAuditLogs", isTraining))
		{
			empty = "CREATE TABLE [dbo].[ItemAuditLogs] ( [Id] INT IDENTITY (1, 1) NOT NULL, [ItemID] INT NOT NULL,[Changelog] NVARCHAR(MAX)   NULL,[DateCreated] DATETIME DEFAULT (getdate()) NOT NULL,[Synced]  BIT  DEFAULT((0)) NOT NULL,CONSTRAINT[aaaaaItemAuditLogs_PK] PRIMARY KEY NONCLUSTERED([Id] ASC),CONSTRAINT[FK_ItemAuditLogs_Items] FOREIGN KEY([ItemID]) REFERENCES[dbo].[Items] ([ItemID]));";
			method_2(empty, isTraining);
		}
		empty = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME='aaaaaUsers_PK' ) BEGIN ALTER TABLE Users DROP CONSTRAINT aaaaaUsers_PK; ALTER TABLE Users ADD CONSTRAINT aUsers_PK PRIMARY KEY (UserID) END; ";
		method_2(empty, isTraining);
		if (version == "1.09.3")
		{
			empty = "UPDATE [dbo].[Items] Set [Synced] = 0;";
			method_2(empty, isTraining);
		}
	}

	public void one_zeronine_three_to_one_zeronine_four(bool isTraining, string version)
	{
		string empty = string.Empty;
		if (!method_1("TipAmount", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [TipAmount] DECIMAL (10, 2) DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("TipRecorded", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [TipRecorded] BIT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("DateCleared", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [DateCleared] DATETIME DEFAULT (NULL) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Price", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [Price] DECIMAL (6, 2) DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
			empty = "UPDATE dbo.ItemsWithOptions SET dbo.ItemsWithOptions.Price = (SELECT dbo.Options.SpecialPrice FROM dbo.Options WHERE dbo.Options.OptionID = dbo.ItemsWithOptions.OptionID);";
			method_2(empty, isTraining);
		}
		if (!method_1("AllowAdditional", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [AllowAdditional] BIT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
			empty = "UPDATE dbo.ItemsWithOptions SET dbo.ItemsWithOptions.AllowAdditional = (SELECT dbo.Options.AllowAdditional FROM dbo.Options WHERE dbo.Options.OptionID = dbo.ItemsWithOptions.OptionID);";
			method_2(empty, isTraining);
		}
	}

	public void one_zeronine_four_to_one_zeronine_five(bool isTraining, string version)
	{
		if (version == "1.09.5")
		{
			string string_ = "UPDATE [dbo].[Orders] SET DateCleared = DatePaid WHERE DateCleared IS NULL ";
			method_2(string_, isTraining);
		}
	}

	public void one_zeronine_six_to_one_zeronine_seven(bool isTraining, string version)
	{
		string empty = string.Empty;
		empty = "IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'db_version') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES (N'db_version', N'1.09.7', N'Version of Database', 0) END;";
		method_2(empty, isTraining);
		empty = "ALTER TABLE [dbo].[ItemsInItem] ALTER COLUMN Quantity decimal(18, 2);";
		method_2(empty, isTraining);
	}

	public void one_zeronine_seven_to_one_ten_zero(bool isTraining, string version)
	{
		string empty = string.Empty;
		if (!method_0("ItemImages", isTraining))
		{
			empty = "CREATE TABLE [dbo].[ItemImages] ([Id]                INT IDENTITY (1, 1) NOT NULL,[ItemID]            INT NOT NULL,[BlobName]          NVARCHAR(256) NOT NULL,[BlobThumbnailName] NVARCHAR(256) NOT NULL,[ImageAsText]       NVARCHAR (MAX) NULL,[isNewImage]        BIT DEFAULT((1)) NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC),CONSTRAINT[FK_ItemImages_Item] FOREIGN KEY([ItemID]) REFERENCES[dbo].[Items] ([ItemID]));";
			method_2(empty, isTraining);
		}
		if (!method_1("Comments", "MaterialsInItem", isTraining))
		{
			empty = "ALTER TABLE [dbo].[MaterialsInItem] ADD [Comments] NVARCHAR(256) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Active", "Customers", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Customers] ADD [Active] BIT DEFAULT ((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_0("BusinessHours", isTraining))
		{
			empty = "CREATE TABLE[dbo].[BusinessHours] ([Id] INT IDENTITY(1, 1) NOT NULL,[DayOfTheWeek] NVARCHAR(50) NOT NULL,[LatestOpeningTime] NVARCHAR(20) CONSTRAINT[DF_BusinessHours_LatestOpeningTime] DEFAULT(N'3:00:00 AM') NOT NULL,[LatestClosingTime] NVARCHAR(20) CONSTRAINT[DF_BusinessHours_LatestClosingTime] DEFAULT(N'3:00:00 AM') NOT NULL,CONSTRAINT[aaaaaBusinessHours_PK] PRIMARY KEY NONCLUSTERED([Id] ASC));";
			method_2(empty, isTraining);
		}
		string text = method_3("SELECT LatestOpeningTime FROM [dbo].[CompanySetup]", isTraining);
		string text2 = method_3("SELECT LatestClosingTime FROM [dbo].[CompanySetup]", isTraining);
		text = (string.IsNullOrEmpty(text) ? "10:00:00" : text);
		text2 = (string.IsNullOrEmpty(text2) ? "22:00:00" : text2);
		string empty2 = string.Empty;
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[BusinessHours] WHERE [DayOfTheWeek] = 'monday') BEGIN INSERT INTO [dbo].[BusinessHours] ([DayOfTheWeek], [LatestOpeningTime], [LatestClosingTime]) VALUES ('monday', '" + text + "', '" + text2 + "')  END;";
		empty2 = empty2 + "IF NOT EXISTS ( SELECT * FROM [dbo].[BusinessHours] WHERE [DayOfTheWeek] = 'tuesday') BEGIN INSERT INTO [dbo].[BusinessHours] ([DayOfTheWeek], [LatestOpeningTime], [LatestClosingTime]) VALUES ('tuesday', '" + text + "', '" + text2 + "')  END;";
		empty2 = empty2 + "IF NOT EXISTS ( SELECT * FROM [dbo].[BusinessHours] WHERE [DayOfTheWeek] = 'wednesday') BEGIN INSERT INTO [dbo].[BusinessHours] ([DayOfTheWeek], [LatestOpeningTime], [LatestClosingTime]) VALUES ('wednesday', '" + text + "', '" + text2 + "')  END;";
		empty2 = empty2 + "IF NOT EXISTS ( SELECT * FROM [dbo].[BusinessHours] WHERE [DayOfTheWeek] = 'thursday') BEGIN INSERT INTO [dbo].[BusinessHours] ([DayOfTheWeek], [LatestOpeningTime], [LatestClosingTime]) VALUES ('thursday', '" + text + "', '" + text2 + "')  END;";
		empty2 = empty2 + "IF NOT EXISTS ( SELECT * FROM [dbo].[BusinessHours] WHERE [DayOfTheWeek] = 'friday') BEGIN INSERT INTO [dbo].[BusinessHours] ([DayOfTheWeek], [LatestOpeningTime], [LatestClosingTime]) VALUES ('friday', '" + text + "', '" + text2 + "')  END;";
		empty2 = empty2 + "IF NOT EXISTS ( SELECT * FROM [dbo].[BusinessHours] WHERE [DayOfTheWeek] = 'saturday') BEGIN INSERT INTO [dbo].[BusinessHours] ([DayOfTheWeek], [LatestOpeningTime], [LatestClosingTime]) VALUES ('saturday', '" + text + "', '" + text2 + "')  END;";
		empty2 = empty2 + "IF NOT EXISTS ( SELECT * FROM [dbo].[BusinessHours] WHERE [DayOfTheWeek] = 'sunday') BEGIN INSERT INTO [dbo].[BusinessHours] ([DayOfTheWeek], [LatestOpeningTime], [LatestClosingTime]) VALUES ('sunday', '" + text + "', '" + text2 + "')  END;";
		method_2(empty2, isTraining);
		if (!method_1("Capacity", "CompanySetup", isTraining))
		{
			empty = "ALTER TABLE [dbo].[CompanySetup] ADD [Capacity] INT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty = "IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'useful_tip') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES (N'useful_tip', N'ON', N'Enable Useful Tips to pop-up when the program loads.', 1) END;";
		method_2(empty, isTraining);
		if (!method_1("Round", "Layout", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Layout] Add [Round] bit CONSTRAINT [DF_Layout_Round] DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("CurrentGuests", "Layout", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Layout] Add [CurrentGuests] INT DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("AppointmentID", "Layout", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Layout] Add [AppointmentID] INT NULL, FOREIGN KEY([AppointmentID]) REFERENCES [Appointments]([AppointmentID]);";
			method_2(empty, isTraining);
		}
		if (!method_1("CustomerInfoName", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] Add [CustomerInfoName] NVARCHAR (64) CONSTRAINT [DF_Layout_CustomerInfoName] DEFAULT (('')) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "Appointments", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Appointments] Add [Synced] BIT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("CloudsyncReservationID", "Appointments", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Appointments] Add [CloudsyncReservationID] BIGINT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Archived", "Groups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Groups] Add [Archived] bit DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("GuestCount", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] Add [GuestCount] INT DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("ItemMadeNotified", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] Add [ItemMadeNotified] BIT DEFAULT ((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
	}

	public void one_ten_zero_to_one_ten_one(bool isTraining, string version)
	{
		string empty = string.Empty;
		if (!method_1("Synced", "Options", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Options] Add [Synced] BIT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] Add [Synced] BIT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("isDeleted", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] Add [isDeleted] BIT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "SpecialInstructions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[SpecialInstructions] Add [Synced] BIT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_0("Maintenance", isTraining))
		{
			empty = "CREATE TABLE [dbo].[Maintenance]([Id][int] IDENTITY(1, 1) NOT NULL,[Question] [nvarchar](512) NOT NULL,[AnswerType] [int] NOT NULL,CONSTRAINT[PK_Maintenance] PRIMARY KEY CLUSTERED([Id] ASC));";
			method_2(empty, isTraining);
		}
		string string_ = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'restaurant_mode') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('restaurant_mode', 'Dine In', 'value [dine in,quick service] is used to configure the retaurant appearance', 0)  END";
		method_2(string_, isTraining);
		if (!method_0("Terminals", isTraining))
		{
			empty = "CREATE TABLE [dbo].[Terminals]([TerminalID][int] IDENTITY(1, 1) NOT NULL,[SystemName] [nvarchar](128) NOT NULL,[LastCheckedIn] [datetime] NOT NULL,[DefaultLayoutSectionName] [nvarchar](50) default('') NOT NULL,CONSTRAINT[PK_Terminals] PRIMARY KEY CLUSTERED([TerminalID] ASC));";
			method_2(empty, isTraining);
		}
		if (!method_1("AngleOfRotation", "Layout", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Layout] Add [AngleOfRotation] INT DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (version == "1.10.1")
		{
			empty = "UPDATE Layout SET AngleOfRotation = 90, Rotation = 'A' WHERE Rotation = 'B'; ";
			empty += "UPDATE Layout SET AngleOfRotation = 90, Rotation = 'H' WHERE Rotation = 'V'; ";
			method_2(empty, isTraining);
		}
		string_ = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_gratuity_info') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('print_gratuity_info', 'ON', 'Allow to print the gratuity information on the receipt.', 1)  END";
		method_2(string_, isTraining);
		string_ = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_kitchen_made') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('print_kitchen_made', 'ON', 'Enable to print a receipt when order/item is made on kitchen.', 1)  END";
		method_2(string_, isTraining);
		string_ = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_bar_made') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('print_bar_made', 'ON', 'Enable to print a receipt when order/item is made on bar.', 1)  END";
		method_2(string_, isTraining);
		if (!method_1("IsDiscount", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] Add [IsDiscount] BIT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("CloudSyncId", "Groups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Groups] ADD [CloudSyncId] INT DEFAULT -1 NOT NULL";
			method_2(empty, isTraining);
		}
	}

	public void one_ten_one_to_one_ten_two(bool isTraining, string version)
	{
		string text = "";
		if (!method_1("Synced", "Tax", isTraining))
		{
			text = "ALTER TABLE [dbo].[Tax] ADD [Synced] BIT NOT NULL DEFAULT '0';";
			method_2(text, isTraining);
		}
		if (!method_1("Synced", "TaxRuleOperations", isTraining))
		{
			text = "ALTER TABLE [dbo].[TaxRuleOperations] ADD [Synced] BIT NOT NULL DEFAULT '0';";
			method_2(text, isTraining);
		}
		if (!method_1("isEcommerce", "Groups", isTraining))
		{
			text = "ALTER TABLE [dbo].[Groups] ADD [isEcommerce] BIT NOT NULL DEFAULT ((0));";
			method_2(text, isTraining);
		}
		if (!method_1("CloudSyncId", "Groups", isTraining))
		{
			text = "ALTER TABLE [dbo].[Groups] ADD [CloudSyncId] INT NOT NULL DEFAULT ((0));";
			method_2(text, isTraining);
		}
	}

	public void one_ten_two_to_one_ten_three(bool isTraining, string version)
	{
		string text = "";
		string string_ = "IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'second_screen') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES (N'second_screen', N'OFF', N'Activate the second screen functionality built into the Order Entry screen.', 1) END;";
		method_2(string_, isTraining);
		if (!method_1("Notes", "Items", isTraining))
		{
			text = "ALTER TABLE [dbo].[Items] ADD [Notes] NVARCHAR (256) NULL;";
			method_2(text, isTraining);
		}
		string_ = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'font_size_kitchen') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('font_size_kitchen', '13', 'Setup the font size showing on kitchen.', 1)  END;";
		method_2(string_, isTraining);
		string_ = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'font_size_bar') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('font_size_bar', '13', 'Setup the font size showing on bar.', 1)  END;";
		method_2(string_, isTraining);
		if (!method_1("SeatNum", "Orders", isTraining))
		{
			text = "ALTER TABLE [dbo].[Orders] ADD [SeatNum] NVARCHAR (3) NOT NULL DEFAULT '1';";
			method_2(text, isTraining);
		}
		if (!method_1("ShareItemID", "Orders", isTraining))
		{
			text = "ALTER TABLE [dbo].[Orders] ADD [ShareItemID] UNIQUEIDENTIFIER NULL;";
			method_2(text, isTraining);
		}
		text = "IF EXISTS (SELECT 1 FROM SYS.DEFAULT_CONSTRAINTS WHERE PARENT_OBJECT_ID = OBJECT_ID('Users') AND PARENT_COLUMN_ID = (SELECT column_id FROM sys.columns WHERE NAME = N'PIN' AND object_id = OBJECT_ID(N'Users')) AND name = 'DF__Users__PIN__2D27B809') BEGIN ALTER TABLE Users DROP CONSTRAINT DF__Users__PIN__2D27B809; ALTER TABLE [dbo].[Users] ALTER COLUMN [PIN] int NOT NULL; END;";
		method_2(text, isTraining);
		if (!method_1("ItemCourse", "Items", isTraining))
		{
			text = "ALTER TABLE [dbo].[Items] ADD [ItemCourse] NVARCHAR (48) NOT NULL DEFAULT ('Uncategorized');";
			method_2(text, isTraining);
		}
		if (!method_1("isSynced", "CompanySetup", isTraining))
		{
			text = "ALTER TABLE [dbo].[CompanySetup] ADD [isSynced] BIT DEFAULT ((0)) NOT NULL;";
			method_2(text, isTraining);
		}
		if (!method_1("Address1", "CompanySetup", isTraining))
		{
			text = "sp_rename 'CompanySetup.Address','Address1','column'; ";
			method_2(text, isTraining);
		}
		string_ = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'restaurant_capacity') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('restaurant_capacity', 'ON', 'Turn notification on or off when reaching the restaurant capacity', 1)  END;";
		method_2(string_, isTraining);
		if (method_1("PIN", "Users", isTraining))
		{
			text = "alter table [dbo].[Users] alter column PIN nvarchar(16) not null;";
			method_2(text, isTraining);
		}
		if (!method_1("HipposTimeEmployeeID", "Users", isTraining))
		{
			text = "alter table [dbo].[Users] ADD [HipposTimeEmployeeID] UNIQUEIDENTIFIER NULL;";
			method_2(text, isTraining);
		}
		if (!method_1("TaxChangeReason", "Orders", isTraining))
		{
			text = "ALTER TABLE [dbo].[Orders] ADD [TaxChangeReason] NVARCHAR (128) NULL;";
			method_2(text, isTraining);
		}
		if (!method_0("UOMUnitsConversion", isTraining))
		{
			text = "CREATE TABLE [dbo].[UOMUnitsConversion] ([Id] INT IDENTITY (1, 1) NOT NULL, [BaseUnitId] SMALLINT NOT NULL, [ToUnitId] SMALLINT NOT NULL ,[Operator] NVARCHAR(3)    NOT NULL, [Factor] DECIMAL(16, 8) NOT NULL, CONSTRAINT[aaaaaUOMUnitsConversion_PK] PRIMARY KEY NONCLUSTERED([Id] ASC));";
			method_2(text, isTraining);
		}
		if (!method_1("Synced", "Refunds", isTraining))
		{
			text = "ALTER TABLE [dbo].[Refunds] ADD [Synced] BIT DEFAULT 0 NOT NULL; ";
			method_2(text, isTraining);
		}
		string_ = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'hippos_time') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('hippos_time', 'Disabled', 'Enable/Disable Hippos Time & Attendance Add-On', 0)  END";
		method_2(string_, isTraining);
		if (!method_1("ItemID", "UOMUnitsConversion", isTraining))
		{
			text = "ALTER TABLE [dbo].[UOMUnitsConversion] ADD [ItemID] INT NULL; ";
			method_2(text, isTraining);
			text = "ALTER TABLE [dbo].[UOMUnitsConversion] ADD CONSTRAINT [FK_UOMUnitsConversion_UOMs] FOREIGN KEY ([BaseUnitId]) REFERENCES [dbo].[UOMs] ([UOMID]); ";
			method_2(text, isTraining);
			text = "ALTER TABLE [dbo].[UOMUnitsConversion] ADD CONSTRAINT [FK_UOMUnitsConversion_UOMsToUnit] FOREIGN KEY ([ToUnitId]) REFERENCES [dbo].[UOMs] ([UOMID]); ";
			method_2(text, isTraining);
			text = "ALTER TABLE [dbo].[UOMUnitsConversion] ADD CONSTRAINT [FK_UOMUnitsConversion_Items] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items] ([ItemID]); ";
			method_2(text, isTraining);
		}
		text = "UPDATE [UOMs] SET Name = 'Kilogram' Where Name = 'KG'";
		method_2(text, isTraining);
		text = "UPDATE [UOMs] SET Name = 'Pound' Where Name = 'LB'";
		method_2(text, isTraining);
		string_ = "IF NOT EXISTS ( SELECT * FROM [dbo].[UOMs] WHERE [Name] = 'Ounce') BEGIN INSERT INTO [dbo].[UOMs] ( [Name], [isFractional]) VALUES ('Ounce', 1)  END";
		method_2(string_, isTraining);
		if (!method_0("ImageScreen", isTraining))
		{
			text = "CREATE TABLE [dbo].[ImageScreen] ([Id]          INT IDENTITY (1, 1) NOT NULL,[ImageType]   NVARCHAR(128) NULL,[ImageName]   NVARCHAR(128) NULL,[ImageAsText] NVARCHAR(MAX) NULL,PRIMARY KEY CLUSTERED([Id] ASC)); ";
			method_2(text, isTraining);
		}
		if (version == "1.10.3" || version == "1.10.4")
		{
			text = "UPDATE [dbo].[Employees] SET [isActive]=-1 WHERE [FirstName]='Admin' AND [isActive]=0 AND [EmployeeName]='Admin';";
			method_2(text, isTraining);
		}
		text = "IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'printer_bar') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES (N'printer_bar', N'Bar Printer Name', N'Select the bar receipt printer.', 1) END;IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_to_bar') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES (N'print_to_bar', N'OFF', N'Enable print to bar feature.', 1) END;";
		method_2(text, isTraining);
	}

	public void one_ten_four_to_one_ten_five(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!method_0("ModulesAndFeatures", isTraining))
		{
			empty = "CREATE TABLE [dbo].[ModulesAndFeatures] ( [Id] INT IDENTITY (1, 1) NOT NULL, [ModuleName] NVARCHAR(256) NOT NULL, [ControlName] NVARCHAR(256) NULL, [Description] NVARCHAR(512) NULL, CONSTRAINT[aaaaaModulesAndFeatures_PK] PRIMARY KEY NONCLUSTERED([Id] ASC) ) ";
			method_2(empty, isTraining);
		}
		empty = "ALTER TABLE [dbo].[ModulesAndFeatures] ALTER COLUMN ControlName NVARCHAR(256) NULL;";
		method_2(empty, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName] = 'frmLayout') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName],  [Description]) VALUES(N'frmLayout', N'Layout Form') END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName] = 'frmQuickService') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [Description]) VALUES(N'frmQuickService', N'Quick Service') END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName] = 'frmRefund') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [Description]) VALUES(N'frmRefund', N'Refund') END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName] = 'frmDayEndClosing') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [Description]) VALUES(N'frmDayEndClosing', N'Day End Closing') END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName] = 'frmAdminReports') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName],  [Description]) VALUES(N'frmAdminReports', N'Reports') END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName] = 'frmAdmin') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [Description]) VALUES(N'frmAdmin', N'Admin') END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName] = 'frmEditLayout') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName],  [Description]) VALUES(N'frmEditLayout', N'Edit Layout') END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName] = 'frmAdminViewOrders') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [Description]) VALUES(N'frmAdminViewOrders', N'Order History') END";
		method_2(empty2, isTraining);
		empty = "UPDATE [dbo].[ModulesAndFeatures] SET [Description]='Admin' WHERE [ModuleName]='frmAdmin' AND [ControlName] IS NULL;";
		method_2(empty, isTraining);
		empty = "UPDATE [dbo].[ModulesAndFeatures] SET [Description]='Edit Layout' WHERE [ModuleName]='frmEditLayout' AND [ControlName] IS NULL;";
		method_2(empty, isTraining);
		empty = string.Empty;
		if (!method_0("SecurityMatrix", isTraining))
		{
			empty = "CREATE TABLE [dbo].[SecurityMatrix] ( [Id]       INT IDENTITY (1, 1) NOT NULL, [ModuleID] INT NOT NULL, [RoleID] SMALLINT NOT NULL, [IsAllow] BIT DEFAULT((1)) NOT NULL, CONSTRAINT[aaaaaSecurityMatrix_PK] PRIMARY KEY NONCLUSTERED([Id] ASC), CONSTRAINT[FK_SecurityMatrix_Module] FOREIGN KEY([ModuleID]) REFERENCES[dbo].[ModulesAndFeatures] ([Id]), CONSTRAINT[FK_SecurityMatrix_Role] FOREIGN KEY([RoleID]) REFERENCES[dbo].[Roles] ([RoleID]) );";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[CompanySetup] WHERE [Name] LIKE '%Vinh%') BEGIN TRUNCATE TABLE [dbo].[ConfigDetails] END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'items_paging') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('items_paging', 'ON', 'Enable/Disable Paging for Items in Order Entry screen.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'groups_paging') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('groups_paging', 'ON', 'Enable/Disable Paging for Groups in Order Entry screen.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'items_number_of_columns') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('items_number_of_columns', '0', 'Specify number of Item buttons per row in the Order Entry screen.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'items_number_of_rows') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('items_number_of_rows', '0', 'Specify number of rows of Item buttons in the Order Entry screen.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'groups_number_of_columns') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('groups_number_of_columns', '0', 'Specify number of Item buttons per row in the Order Entry screen.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'groups_number_of_rows') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('groups_number_of_rows', '0', 'Specify number of rows of Item buttons in the Order Entry screen.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'item_images') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('item_images', 'ON', 'Show item/product images on Order Entry screen as image buttons.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'show_placeholder_buttons') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('show_placeholder_buttons', 'OFF', 'Add blank placeholder buttons in the Order Entry screen instead of just showing blank spaces.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'use_payment_processor') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('use_payment_processor', 'OFF', 'Enable/disable and setup use of payment chip && pin terminal.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'primary_language') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('primary_language', 'en-US', 'Select the primary preferred language.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'secondary_language') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('secondary_language', 'en-US', 'Select the secondary preferred language.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'quickservice_screen') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('quickservice_screen', 'ON', 'Show the Quick Service screen.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'payfinish_screen') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('payfinish_screen', 'ON', 'Show the Pay Finish screen.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'send_orders_kitchen') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('send_orders_kitchen', 'ON', 'Enables sending of Orders to Kitchen.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'send_orders_bar') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('send_orders_bar', 'ON', 'Enables sending of Orders to Bar.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'sms') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('sms', 'Disabled', 'Enable/Disable SMS notifications.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'auto_print_receipt') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('auto_print_receipt', 'OFF', 'Enable/Disable auto printing of receipts on cash out.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'receipt_language') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('receipt_language', 'en-US', 'Select a preferred receipt language.', 0)  END";
		method_2(empty2, isTraining);
		if (!method_1("SortOrder", "ItemsInGroups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsInGroups] ADD [SortOrder] SMALLINT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Color", "ItemsInGroups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsInGroups] ADD [Color] nvarchar(50) NOT NULL DEFAULT ('150,166,166');";
			method_2(empty, isTraining);
		}
		if (!method_1("SortOrder", "Groups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Groups] ADD [SortOrder] SMALLINT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("PaymentProviderName", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [PaymentProviderName] NVARCHAR (128) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("PaymentMerchantID", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [PaymentMerchantID] NVARCHAR (128) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("PaymentTerminalModel", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [PaymentTerminalModel] NVARCHAR (50) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("PaymentTerminalAddress", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [PaymentTerminalAddress] NVARCHAR (15) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("PaymentTerminalPort", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [PaymentTerminalPort] SMALLINT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("TransactionApprovalCode", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [TransactionApprovalCode] NVARCHAR (128) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_0("TransactionReceipts", isTraining))
		{
			empty = "CREATE TABLE dbo.TransactionReceipts ( TransactionReceiptID int NOT NULL IDENTITY(1, 1), OrderNumber nvarchar(10)  NULL, RefundNumber nvarchar(10)  NULL, CustomerReceipt nvarchar(MAX) NOT NULL, MerchantReceipt nvarchar(MAX) NOT NULL, DateCreated datetime NOT NULL CONSTRAINT DF_TransactionReceipts_DateCreated DEFAULT getdate() CONSTRAINT[PK_TransactionReceipts] PRIMARY KEY CLUSTERED([TransactionReceiptID] ASC));";
			method_2(empty, isTraining);
		}
		if (!method_1("SortOrder", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [SortOrder] SMALLINT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		empty = "ALTER TABLE Items ALTER COLUMN ItemName nvarchar(256) NOT NULL;";
		method_2(empty, isTraining);
		empty = "ALTER TABLE Tax ALTER COLUMN Percentage decimal(5, 5) NOT NULL;";
		method_2(empty, isTraining);
		if (!method_0("PaymentTerminalTransactionLogs", isTraining))
		{
			empty = "CREATE TABLE dbo.PaymentTerminalTransactionLogs (PaymentTerminalTransactionLogID bigint NOT NULL IDENTITY (1, 1), Type nvarchar(20) NOT NULL, ProcessorName nvarchar(50) NOT NULL, DeviceModel nvarchar(50) NOT NULL, IP nvarchar(15) NOT NULL, Data nvarchar(MAX), DateCreated datetime NOT NULL CONSTRAINT DF_PaymentTerminalTransactionLogs_DateCreated DEFAULT getdate() CONSTRAINT[PK_PaymentTerminalTransactionLogs] PRIMARY KEY CLUSTERED([PaymentTerminalTransactionLogID] ASC));";
			method_2(empty, isTraining);
		}
		if (!method_1("PrintedInKitchen", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [PrintedInKitchen] BIT DEFAULT ((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
	}

	public void one_ten_five_to_one_ten_six(bool isTraining, string version)
	{
		string empty = string.Empty;
		empty += "ALTER TABLE [dbo].[Orders] ALTER COLUMN TaxTotal decimal(10,4);";
		empty += "ALTER TABLE [dbo].[Orders] ALTER COLUMN Total decimal(10,4);";
		method_2(empty, isTraining);
	}

	public void one_ten_six_to_one_ten_seven(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!method_1("OperatingMode", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [OperatingMode] nvarchar(20) NOT NULL DEFAULT ('Normal'); ";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'lock_table_staff') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('lock_table_staff', 'ON', 'Enable/Disable which Locks the table for the Employee/User that opened it.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'auto_lock_layout') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('auto_lock_layout', 'ON', 'Turning on this setting will auto lock the layout screen after 60 seconds of inactivity.', 0)  END";
		method_2(empty2, isTraining);
		if (!method_1("EmployeeID", "Layout", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Layout] ADD [EmployeeID] INT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("AllowCtrlOverride", "ModulesAndFeatures", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ModulesAndFeatures] ADD [AllowCtrlOverride] BIT NOT NULL DEFAULT 0;";
			method_2(empty, isTraining);
		}
		if (!method_1("AllowAdminEdit", "ModulesAndFeatures", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ModulesAndFeatures] ADD [AllowAdminEdit] BIT NOT NULL DEFAULT 1;";
			method_2(empty, isTraining);
		}
		if (!method_1("ProcessorName", "PaymentTerminalTransactionLogs", isTraining))
		{
			empty = "ALTER TABLE [dbo].[PaymentTerminalTransactionLogs] ADD [ProcessorName]  nvarchar(50) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("DeviceModel", "PaymentTerminalTransactionLogs", isTraining))
		{
			empty = "ALTER TABLE [dbo].[PaymentTerminalTransactionLogs] ADD [DeviceModel]  nvarchar(50) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("IP", "PaymentTerminalTransactionLogs", isTraining))
		{
			empty = "ALTER TABLE [dbo].[PaymentTerminalTransactionLogs] ADD [IP]  nvarchar(15) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("OrderNumber", "PaymentTerminalTransactionLogs", isTraining))
		{
			empty = "ALTER TABLE [dbo].[PaymentTerminalTransactionLogs] ADD [OrderNumber]  nvarchar(20) NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Roles] WHERE [RoleName] = 'Patron') BEGIN INSERT INTO [dbo].[Roles] ([RoleName]) VALUES ('Patron')  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Roles] WHERE [RoleName] = 'Kiosk') BEGIN INSERT INTO [dbo].[Roles] ([RoleName]) VALUES ('Kiosk')  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnChangePrice') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description]) VALUES ('frmOrderEntry', 'btnChangePrice', 'Order Entry -> Override Price') END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnOrderDiscount') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description]) VALUES ('frmOrderEntry', 'btnOrderDiscount', 'Order Entry -> Discounts') END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnClear') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description]) VALUES ('frmOrderEntry', 'btnClear', 'Order Entry -> Void Order') END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnClose') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmOrderEntry', 'btnClose', 'Order Entry -> Close', 1) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnChangeQty') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmOrderEntry', 'btnChangeQty', 'Order Entry -> Change Qty', 0) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnItemSub') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmOrderEntry', 'btnItemSub', 'Order Entry -> Item Substitution', 0) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnChangeTable') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmOrderEntry', 'btnChangeTable', 'Order Entry -> Change Table', 0) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnSplitMergeBill') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmOrderEntry', 'btnSplitMergeBill', 'Order Entry -> Split/Merge Bill', 0) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnPrintBill') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmOrderEntry', 'btnPrintBill', 'Order Entry -> Print Bill', 0) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnCustomerInfo') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmOrderEntry', 'btnCustomerInfo', 'Order Entry -> Customer Info', 0) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnChangeGuests') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmOrderEntry', 'btnChangeGuests', 'Order Entry -> Change Guest Counts', 0) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnPay') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmOrderEntry', 'btnPay', 'Order Entry -> Cash Out', 0) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmOrderEntry' AND [ControlName]='btnSaveClose') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmOrderEntry', 'btnSaveClose', 'Save and Close', 0) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'now_serving_screen') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES (N'now_serving_screen', N'ON', N'Enables Now Serving Screen in Kitchen', 1) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS (SELECT * FROM [dbo].[Settings] WHERE [Key] = 'upc_scanning') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES (N'upc_scanning', N'OFF', N'Enables upc scanning for item barcodes.', 1) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmQuickService' AND [ControlName]='btnOpenRegister') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride], [AllowAdminEdit]) VALUES ('frmQuickService', 'btnOpenRegister', 'Quick Service -> Open Til', 1, 1) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmLayout' AND [ControlName]='btnOpenRegister') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride], [AllowAdminEdit]) VALUES ('frmLayout', 'btnOpenRegister', 'Layout -> Open Til', 1, 1) END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmSplash' AND [ControlName]='btnClose') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmSplash', 'btnClose', 'SplashScreen->Quit', 0) END";
		method_2(empty2, isTraining);
	}

	public void one_ten_seven_to_one_ten_eight(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!method_1("TerminalID", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [TerminalID] INT NULL;";
			method_2(empty, isTraining);
			empty = "ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_Orders_ToTerminals] FOREIGN KEY ([TerminalID]) REFERENCES [dbo].[Terminals] ([TerminalID]); ";
			method_2(empty, isTraining);
		}
		empty = "ALTER TABLE [dbo].[Orders] ALTER COLUMN [PaymentMethods] NVARCHAR(2056) NULL;";
		method_2(empty, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'display_option') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('display_option', 'OFF', 'Enables displaying of options for an item in a receipt', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'display_instruction') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('display_instruction', 'OFF', 'Enables displaying of instructions for an item in a receipt', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'auto_clear_table') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('auto_clear_table', 'OFF', 'Turning on this setting will auto clear table that is already been paid.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'tip_tracking') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('tip_tracking', 'OFF', 'Turning on this setting to prompt users to enter a tip in a table.', 0)  END";
		method_2(empty2, isTraining);
		if (!method_0("GroupsInItems", isTraining))
		{
			empty = "CREATE TABLE [dbo].[GroupsInItems] ([Id]        INT IDENTITY(1, 1) NOT NULL,[ItemID]    INT DEFAULT((0)) NOT NULL,[GroupID]   SMALLINT DEFAULT((0)) NOT NULL,[Quantity]  DECIMAL(18, 2) DEFAULT((1)) NOT NULL,[SortOrder] SMALLINT DEFAULT((0)) NOT NULL,[Synced]    BIT DEFAULT((0)) NOT NULL,CONSTRAINT[aaaaaGroupsInItems_PK] PRIMARY KEY NONCLUSTERED([Id] ASC),CONSTRAINT[FK_GroupsInItems_Groups] FOREIGN KEY([GroupID]) REFERENCES[dbo].[Groups]([GroupID]),CONSTRAINT[FK_GroupsInItems_Items] FOREIGN KEY([ItemID]) REFERENCES[dbo].[Items]([ItemID])); ";
			method_2(empty, isTraining);
		}
		if (!method_1("StationID", "SpecialInstructions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[SpecialInstructions] ADD [StationID] INT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'auto_gratuity') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('auto_gratuity', 'OFF', 'Turning on this setting will add a auto gratuity on bills/receipts.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'auto_gratuity_percentage') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('auto_gratuity_percentage', '0', 'Percentage for auto gratuity.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'auto_gratuity_count') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('auto_gratuity_count', '0', 'Number of guests for auto gratuity.', 0)  END";
		method_2(empty2, isTraining);
		if (!method_1("GroupID", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [GroupID] SMALLINT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("Qty", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [Qty]  decimal(4,1) NOT NULL DEFAULT (1); ";
			method_2(empty, isTraining);
		}
		if (!method_1("ToBeDeleted", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [ToBeDeleted]  BIT NOT NULL DEFAULT (0);";
			method_2(empty, isTraining);
		}
		empty2 = "UPDATE [dbo].[Reasons] SET [ReasonType]='option tab' WHERE [ReasonType]='option tag';";
		method_2(empty2, isTraining);
		empty2 = "IF (SELECT COUNT(*) FROM [dbo].[Reasons] WHERE [ReasonType] = 'option tab') = 0 BEGIN INSERT INTO [dbo].[Reasons] ([Value], [ReasonType]) VALUES ('options', 'option tab')  END";
		method_2(empty2, isTraining);
		if (!method_1("AppointmentType", "Appointments", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Appointments] ADD [AppointmentType] NVARCHAR(40) DEFAULT('reservation') NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("IsCleared", "Appointments", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Appointments] ADD [IsCleared] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("isDefault", "Reasons", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Reasons] ADD [isDefault] BIT NOT NULL DEFAULT 0;";
			method_2(empty, isTraining);
		}
		if (!method_1("DateUpdated", "Appointments", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Appointments] ADD [DateUpdated] DATETIME NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("MaxFreeOptions", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [MaxFreeOptions] INT NOT NULL DEFAULT (0);";
			method_2(empty, isTraining);
		}
		if (method_1("Tag", "ItemsWithOptions", isTraining))
		{
			empty = "exec sp_rename 'ItemsWithOptions.Tag', 'Tab', 'column';";
			method_2(empty, isTraining);
		}
		else if (!method_1("Tab", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [Tab]  nvarchar(50) NOT NULL DEFAULT ('options'); ";
			method_2(empty, isTraining);
		}
		empty2 = "UPDATE [dbo].[SpecialInstructions] SET [StationID]=0 WHERE [StationID] IS NULL;";
		method_2(empty2, isTraining);
	}

	public void one_ten_eight_to_one_ten_nine(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!method_1("Synced", "Reasons", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Reasons] ADD [Synced] BIT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (version == "1.10.9")
		{
			empty = "UPDATE Groups SET Synced = 0;";
			method_2(empty, isTraining);
			empty = "UPDATE Items SET Synced = 0;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'kitchen_station_view') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('kitchen_station_view', 'list', 'Kitchen View Preference.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'bar_station_view') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('bar_station_view', 'list', 'Kitchen View Preference.', 0)  END";
		method_2(empty2, isTraining);
	}

	public void one_ten_nine_to_one_eleven_zero(bool isTraining, string version)
	{
		string empty = string.Empty;
		if (version == "1.11.0")
		{
			empty = "UPDATE Appointments SET Synced = 0 WHERE AppointmentType = 'waiting_list';";
			method_2(empty, isTraining);
			empty = "UPDATE CompanySetup SET isSynced = 0;";
			method_2(empty, isTraining);
		}
	}

	public void one_eleven_zero_to_one_eleven_one(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!method_1("AppRestartRequired", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [AppRestartRequired] BIT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='frmLayout' AND [ControlName]='btnAssignEmployee') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES ('frmLayout', 'btnAssignEmployee', 'Layout -> Assign Employee', 0) END";
		method_2(empty2, isTraining);
	}

	public void one_eleven_one_to_one_eleven_two(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!method_1("TrackExpiryDate", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [TrackExpiryDate] BIT  DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("InventoryBatchId", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [InventoryBatchId] INT   NULL;";
			method_2(empty, isTraining);
		}
		if (!method_0("InventoryBatches", isTraining))
		{
			empty = "CREATE TABLE [dbo].[InventoryBatches] ([Id]           INT             IDENTITY (1, 1) NOT NULL,[BatchNumber]  NVARCHAR (20)   NOT NULL,[ReceivedDate] DATETIME        NOT NULL,[ExpiryDate]   DATETIME        NOT NULL,[QTYReceived]  DECIMAL (18, 2) NOT NULL,[QTYRemaining] DECIMAL (18, 2) NOT NULL,[ItemID]       INT             NOT NULL,[Synced]       BIT DEFAULT ((0)) NOT NULL,CONSTRAINT [aaaaaInventoryBatche_PK] PRIMARY KEY NONCLUSTERED ([Id] ASC),CONSTRAINT [FK_InventoryBatches_Items] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items] ([ItemID]));";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'stack_options') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('stack_options', 'OFF', 'Stacks additional options in the order entry.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'font_size_chit') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES (N'font_size_chit', N'9', N'Setup the font size for the kitchen or bar chits that get printed.', 0) END;";
		method_2(empty2, isTraining);
		if (!method_1("Status", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [Status] NVARCHAR (50) DEFAULT ('active') NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("SortOrder", "Reasons", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Reasons] ADD [SortOrder] SMALLINT DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
	}

	public void one_eleven_two_to_one_eleven_three(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'encrypted_subs') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('encrypted_subs', '', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'encrypted_prodkey_sub') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('encrypted_prodkey_sub', '', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_1("DiscountReasonItem", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [DiscountReasonItem] NVARCHAR (100) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("DiscountOnSaleItem", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [DiscountOnSaleItem] DECIMAL (10, 4)  DEFAULT ((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
	}

	public void one_eleven_three_to_one_eleven_four(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!method_1("MaxGroupOptions", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [MaxGroupOptions] SMALLINT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("OrderEntryShow", "Groups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Groups] ADD [OrderEntryShow] BIT DEFAULT ((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'receipt_size') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('receipt_size', '80', '', 0) END;";
		method_2(empty2, isTraining);
		empty = "ALTER TABLE Orders ALTER COLUMN ItemName NVARCHAR(256); ";
		method_2(empty, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_kitchen_copy') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('print_kitchen_copy', '1', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_bar_copy') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('print_bar_copy', '1', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'prompt_option_child_item') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('prompt_option_child_item', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'add_solo_option_main') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('add_solo_option_main', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'receipt_display_child_items') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('receipt_display_child_items', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
	}

	public void one_eleven_four_to_one_eleven_five(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName] = 'frmPatron' AND [ControlName]='btnClose') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description], [AllowCtrlOverride]) VALUES(N'frmPatron', 'btnClose', N'Patron Ordering -> Close', -1) END";
		method_2(empty2, isTraining);
		if (!method_1("ImageAsTextHighRes", "ItemImages", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemImages] ADD [ImageAsTextHighRes] NVARCHAR (MAX) NULL;";
			method_2(empty, isTraining);
		}
		if (version == "1.11.5")
		{
			empty = "UPDATE [dbo].[ItemImages] SET isNewImage = 1;";
			method_2(empty, isTraining);
		}
		if (!method_1("ShowInPatronKiosk", "Groups", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Groups] ADD [ShowInPatronKiosk] BIT DEFAULT 1 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("MinFreeOptions", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [MinFreeOptions] INT NOT NULL DEFAULT (0);";
			method_2(empty, isTraining);
		}
		if (!method_1("MinGroupOptions", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [MinGroupOptions] SMALLINT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'chit_print_server') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('chit_print_server', '', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_0("ChitPrintQueues", isTraining))
		{
			empty = "CREATE TABLE [dbo].[ChitPrintQueues] ([Id]           INT             IDENTITY (1, 1) NOT NULL,[TextString]  NVARCHAR (MAX)   NOT NULL,[FontSize]       INT DEFAULT ((10)) NOT NULL,[StationID]       INT DEFAULT ((1)) NOT NULL,[DateCreated] DATETIME        NOT NULL, CONSTRAINT [ChitPrintQueue_PK] PRIMARY KEY NONCLUSTERED ([Id] ASC),);";
			method_2(empty, isTraining);
		}
		empty = "ALTER TABLE Layout ALTER COLUMN TableName NVARCHAR(40) NOT NULL; ";
		method_2(empty, isTraining);
	}

	public void one_eleven_five_to_one_eleven_six(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!method_1("Color", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [Color] NVARCHAR (50) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Color", "SpecialInstructions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[SpecialInstructions] ADD [Color] NVARCHAR (50) NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'font_size_item_groups_oe') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('font_size_item_groups_oe', '7', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_1("ItemsInGroupsRefreshRequired", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [ItemsInGroupsRefreshRequired] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("OrderOnHoldTime", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [OrderOnHoldTime] INT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty = "ALTER TABLE [Orders] ALTER COLUMN [DiscountDesc] nvarchar(512) NULL;";
		method_2(empty, isTraining);
		if (!method_1("LayoutZoomValue", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [LayoutZoomValue] INT DEFAULT ((5)) NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("IsModified", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [IsModified] BIT DEFAULT ((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("LastDateModified", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [LastDateModified] DATETIME NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("DateVoided", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [DateVoided] DATETIME NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'delivery_charge') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('delivery_charge', '0', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'card_transaction_fee') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('card_transaction_fee', '0', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_1("Interval", "ImageScreen", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ImageScreen] ADD [Interval] INT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("SortOrder", "ImageScreen", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ImageScreen] ADD [SortOrder] INT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("OptionComboId", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [OptionComboId] SMALLINT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Flag", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [Flag] NVARCHAR(128) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Preselect", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [Preselect] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_chit_change_cancel') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('print_chit_change_cancel', 'ON', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'tip_kitchen') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('tip_kitchen', '0', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'tip_breakage') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('tip_breakage', '0', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'auto_tip_cash_back') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('auto_tip_cash_back', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_1("TipShareDesc", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [TipShareDesc] NVARCHAR(256) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Printed", "ChitPrintQueues", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ChitPrintQueues] ADD [Printed] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
	}

	public void one_eleven_six_to_one_eleven_seven(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'prompt_void_orders_reason') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('prompt_void_orders_reason', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_1("VoidReason", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [VoidReason]  NVARCHAR (128)   NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("ApplySaleComboOption", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [ApplySaleComboOption] BIT NOT NULL DEFAULT (0);";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'gift_card_payment') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('gift_card_payment', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'gift_card_json') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('gift_card_json', '[]', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_0("GiftCardTransactionLogs", isTraining))
		{
			empty = "CREATE TABLE [dbo].[GiftCardTransactionLogs] ([Id]            BIGINT IDENTITY(1, 1) NOT NULL,[Type]          NVARCHAR(20)  NOT NULL,[ProcessorName] NVARCHAR(50)  NOT NULL,[Data]          NVARCHAR(MAX) NULL,[DateCreated] DATETIME NOT NULL,[OrderNumber] NVARCHAR(20)  NULL,CONSTRAINT[PK_GiftCardTransactionLogs] PRIMARY KEY CLUSTERED([Id] ASC));";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'patt_server') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('patt_server', 'DISABLED', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_1("Address", "Customers", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Customers] ADD [Address] NVARCHAR(MAX) DEFAULT('') NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("LoyaltyCardNo", "Customers", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Customers] ADD [LoyaltyCardNo] NVARCHAR(50) DEFAULT('') NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'item_button_price') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('item_button_price', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'delivery_fee_km') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('delivery_fee_km', '0', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_0("UsefulTips", isTraining))
		{
			empty = "CREATE TABLE[dbo].[UsefulTips] ([Id] INT NOT NULL PRIMARY KEY,[Description] NVARCHAR(MAX) NOT NULL )";
			method_2(empty, isTraining);
		}
		if (!method_1("UserCashout", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [UserCashout] SMALLINT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'loyalty_card_payment') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('loyalty_card_payment', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'loyalty_card_json') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('loyalty_card_json', '[]', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_0("Suppliers", isTraining))
		{
			empty = "CREATE TABLE [dbo].[Suppliers] ([Id]   INT IDENTITY (1, 1) NOT NULL,[Name] NVARCHAR(512) NOT NULL,CONSTRAINT[Suppliers_PK] PRIMARY KEY NONCLUSTERED([Id] ASC)); ";
			method_2(empty, isTraining);
		}
		if (!method_0("ItemsSupplier", isTraining))
		{
			empty = "CREATE TABLE [dbo].[ItemsSupplier] ([ItemId]     INT NOT NULL,[SupplierId] INT NOT NULL,CONSTRAINT[PK_dbo.ItemsSupplier] PRIMARY KEY CLUSTERED([ItemId] ASC, [SupplierId] ASC),CONSTRAINT[FK_dbo.ItemsSupplier_dbo.Items_ItemId] FOREIGN KEY([ItemId]) REFERENCES[dbo].[Items] ([ItemID]) ON DELETE CASCADE,CONSTRAINT[FK_dbo.ItemsSupplier_dbo.Suppliers_SupplierId] FOREIGN KEY([SupplierId]) REFERENCES[dbo].[Suppliers] ([Id]) ON DELETE CASCADE ); ";
			method_2(empty, isTraining);
		}
		if (!method_1("SupplierId", "InventoryAudits", isTraining))
		{
			empty = "ALTER TABLE [dbo].[InventoryAudits] ADD [SupplierId] INT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("SettingsRefreshedRequired", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [SettingsRefreshedRequired] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'member_assign') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('member_assign', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		empty = "ALTER TABLE [dbo].[Items] ALTER COLUMN [ItemPrice] DECIMAL (18, 4) NULL;";
		method_2(empty, isTraining);
		empty = "ALTER TABLE [dbo].[Items] ALTER COLUMN [ItemSalePrice] DECIMAL (18, 4) NULL;";
		method_2(empty, isTraining);
		if (!method_1("EncryptedCardNumber", "GiftCardTransactionLogs", isTraining))
		{
			empty = "ALTER TABLE [dbo].[GiftCardTransactionLogs] ADD [EncryptedCardNumber] NVARCHAR(MAX) NULL;";
			method_2(empty, isTraining);
		}
	}

	public void one_eleven_seven_to_one_eleven_eight(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'workflow_prompt_cashout_pin') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('workflow_prompt_cashout_pin', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_0("DiscountCodes", isTraining))
		{
			empty = "CREATE TABLE [dbo].[DiscountCodes] ([Id]                BIGINT          IDENTITY (1, 1) NOT NULL,[CloudsyncId]       BIGINT          DEFAULT ((0)) NOT NULL,[Code]              NVARCHAR (128)  NOT NULL,[Description]       NVARCHAR (MAX)  NOT NULL,[DiscountAmount]    DECIMAL (12, 4) NOT NULL,[DiscountUOM]       NVARCHAR (20)   NOT NULL,[StartDate]         DATETIME        NOT NULL,[EndDate]           DATETIME        NOT NULL,[AvailableOnline]   BIT             NOT NULL,[AvailableInStore]  BIT             NOT NULL,[OneTimeUse]        BIT             DEFAULT ((0)) NOT NULL,[DiscountCodeCount] INT             DEFAULT ((-1)) NOT NULL,[UsedCount]         INT             DEFAULT ((0)) NOT NULL,[Synced]            BIT             DEFAULT ((0)) NOT NULL,PRIMARY KEY CLUSTERED ([Id] ASC));";
			method_2(empty, isTraining);
		}
		if (!method_1("EnablePrint", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [EnablePrint] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("PrintCopies", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [PrintCopies] INT DEFAULT((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("ItemIdentifier", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [ItemIdentifier] NVARCHAR(256) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("AutoPrint", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [AutoPrint] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "Customers", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Customers] ADD [Synced] BIT DEFAULT 0 NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("SendToStation", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [SendToStation] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Synced", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [Synced] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_chit_cashout') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('print_chit_cashout', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'confirm_online_orders') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('confirm_online_orders', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
		if (!method_1("CloudsyncGUID", "Customers", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Customers] ADD [CloudsyncGUID] UNIQUEIDENTIFIER NULL";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'station_settings_changed') BEGIN INSERT [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('station_settings_changed', 'OFF', '', 0) END;";
		method_2(empty2, isTraining);
	}

	public void DbUpdateTo_1_11_9(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!method_1("PaymentTerminalSerial", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [PaymentTerminalSerial] NVARCHAR(50) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("ChitFormat", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [ChitFormat] SMALLINT DEFAULT((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'font_size_second_screen') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('font_size_second_screen', '11', '', 1)  END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_tax_no') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('print_tax_no', 'ON', '', 1)  END;";
		method_2(empty2, isTraining);
		if (!method_1("LastDateUpdated", "GenKeys", isTraining))
		{
			empty = "ALTER TABLE [dbo].[GenKeys] ADD [LastDateUpdated] DATETIME NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[GenKeys] WHERE [KeyName] = 'OrderTicket') BEGIN INSERT INTO [dbo].[GenKeys] ([KeyName], [Prefix], [LastKey]) VALUES ('OrderTicket', '', '0')  END;";
		method_2(empty2, isTraining);
		if (!method_1("OrderTicketNumber", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [OrderTicketNumber] NVARCHAR(50) NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'use_order_ticket') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('use_order_ticket', 'OFF', '', 1)  END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'enable_http_listener') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('enable_http_listener', 'OFF', '', 1)  END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'course_selection') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('course_selection', 'OFF', '', 1)  END;";
		method_2(empty2, isTraining);
		if (!method_1("ItemCourse", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [ItemCourse] NVARCHAR(20) NOT NULL DEFAULT 'Uncategorized';";
			method_2(empty, isTraining);
		}
		if (!method_1("DefaultStation1", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [DefaultStation1] INT NOT NULL DEFAULT 1;";
			method_2(empty, isTraining);
		}
		if (!method_1("DefaultStation2", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [DefaultStation2] INT NOT NULL DEFAULT 2;";
			method_2(empty, isTraining);
		}
		if (!method_1("UseChildItemPriceAndTax", "ItemsInItem", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsInItem] ADD [UseChildItemPriceAndTax] BIT NOT NULL DEFAULT 0;";
			method_2(empty, isTraining);
		}
	}

	public void DbUpdatedTo_1_12_0(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!method_1("IsDefault", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [IsDefault] BIT DEFAULT((0)) NOT NULL";
			method_2(empty, isTraining);
		}
		if (!method_1("DefaultButtonName", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [DefaultButtonName] NVARCHAR(50) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("LastDateSettlement", "CompanySetup", isTraining))
		{
			empty = "ALTER TABLE [dbo].[CompanySetup] ADD [LastDateSettlement] DATETIME NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("AutoResetQty", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [AutoResetQty] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("ResetQty", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [ResetQty] Decimal(18, 4) DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("SortOrder", "SpecialInstructions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[SpecialInstructions] ADD [SortOrder] SMALLINT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'auto_logout_cashout') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('auto_logout_cashout', 'OFF', '', 1)  END;";
		method_2(empty2, isTraining);
		if (!method_0("CustomTipSharing", isTraining))
		{
			empty = "CREATE TABLE [dbo].[CustomTipSharing]([Id]               INT IDENTITY(1, 1) NOT NULL,[TipName] NVARCHAR(128) NULL,[Percentage] DECIMAL(10,2) DEFAULT((0)) NOT NULL,CONSTRAINT[aaaaaCustomTips_PK] PRIMARY KEY NONCLUSTERED([Id] ASC))";
			method_2(empty, isTraining);
		}
		empty = "UPDATE Orders SET OrderType = 'Pick-Up' WHERE OrderType = 'Take-Out';";
		method_2(empty, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'show_instruction_oe') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('show_instruction_oe', 'OFF', '', 1)  END;";
		method_2(empty2, isTraining);
		empty2 = "UPDATE [dbo].[ModulesAndFeatures] SET [Description] = 'Order Entry -> Discounts' WHERE [ModuleName]='frmOrderEntry' AND [ControlName] = 'btnOrderDiscount'; ";
		method_2(empty2, isTraining);
		empty2 = "UPDATE [dbo].[Orders] SET [OrderType] = 'Pick-Up-Online', Synced=0 WHERE [OrderType]='Take-Out-Online';";
		method_2(empty2, isTraining);
		empty2 = "UPDATE [dbo].[Orders] SET [OrderType] = 'Pick-Up', Synced=0 WHERE [OrderType]='Take-Out';";
		method_2(empty2, isTraining);
		if (!method_1("UserServed", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [UserServed] SMALLINT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("SystemDefinedID", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [SystemDefinedID] INT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("PaperSize", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [PaperSize] nchar(4) NOT NULL CONSTRAINT DF_Stations_PaperSize DEFAULT N'80mm'; ";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'online_order_sync') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('online_order_sync', '[]', '', 1)  END;";
		method_2(empty2, isTraining);
		if (!method_0("OnlineOrderSyncQueues", isTraining))
		{
			empty = "CREATE TABLE [dbo].[OnlineOrderSyncQueues]([Id]               INT IDENTITY(1, 1) NOT NULL,[Provider] NVARCHAR(128) NOT NULL,[RawData] NVARCHAR(MAX) NOT NULL,[DateCreated] DATETIME NOT NULL,[DateProcessed] DATETIME NULL,CONSTRAINT[aaaaaOnlineOrderSyncQueuesID_PK] PRIMARY KEY NONCLUSTERED([Id] ASC))";
			method_2(empty, isTraining);
		}
		if (!method_1("FulfillmentAt", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [FulfillmentAt] DATETIME NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("Source", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [Source] NVARCHAR(50) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("ChitFontSize", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [ChitFontSize] INT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("DisplayFontSize", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [DisplayFontSize] INT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("OrderTypes", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [OrderTypes] NVARCHAR(128) NOT NULL DEFAULT N'Dine In,To-Go,Pick-Up,Delivery,Pick-Up-Online,Delivery-Online';";
			method_2(empty, isTraining);
		}
		if (!method_1("OrderNumber", "ChitPrintQueues", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ChitPrintQueues] ADD [OrderNumber] NVARCHAR(50) NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("GroupOrderTypes", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [GroupOrderTypes] NVARCHAR(128) NOT NULL DEFAULT N'Dine In,To-Go,Pick-Up,Delivery,Pick-Up-Online,Delivery-Online';";
			method_2(empty, isTraining);
		}
		empty = "ALTER TABLE [dbo].[Orders] ALTER COLUMN [Instructions] NVARCHAR(MAX) NULL;";
		method_2(empty, isTraining);
		if (!method_1("PromptItemOptions", "GroupsInItems", isTraining))
		{
			empty = "ALTER TABLE [dbo].[GroupsInItems] ADD [PromptItemOptions] BIT DEFAULT((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
	}

	public void DbUpdatedTo_1_12_1(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'options_number_of_columns') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('options_number_of_columns', '7', 'Specify number of Item buttons per row in the Order Entry Options screen.', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'options_number_of_rows') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('options_number_of_rows', '4', 'Specify number of rows of Item buttons in the Order Entry Options screen.', 0)  END";
		method_2(empty2, isTraining);
		if (!method_0("PaymentTypes", isTraining))
		{
			empty = "CREATE TABLE [dbo].[PaymentTypes]([Id]               INT IDENTITY(1, 1) NOT NULL,[Name] NVARCHAR(20) NULL,[SortOrder] INT DEFAULT((0)) NOT NULL,[OpenCashDrawer] BIT DEFAULT((0)) NOT NULL,[UsePaymentTerminal] BIT DEFAULT((0)) NOT NULL,[SystemDefault] BIT DEFAULT((0)) NOT NULL,CONSTRAINT[aaaaaPaymentTypes_PK] PRIMARY KEY NONCLUSTERED([Id] ASC))";
			method_2(empty, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'CASH') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('CASH', 0, 1, 0, 1)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'OTHER') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('OTHER', 1, 1, 0, 0)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'DEBIT') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('DEBIT', 2, 1, 1, 0)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'AMEX') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('AMEX', 3, 1, 1, 0)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'VISA') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('VISA', 4, 1, 1, 0)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'MASTERCARD') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('MASTERCARD', 5, 1, 1, 0)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'GIFT CARD') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('GIFT CARD', 6, 1, 0, 1)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'DISCOVER') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('DISCOVER', 7, 1, 1, 0)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'DINERS CLUB') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('DINERS CLUB', 8, 1, 1, 0)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'JCB') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('JCB', 9, 1, 1, 0)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'SKIP THE DISHES') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('SKIP THE DISHES', 10, 1, 0, 0)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'UBER EATS') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('UBER EATS', 11, 1, 0, 0)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'LOYALTY CARD') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('LOYALTY CARD', 12, 1, 0, 1)  END";
			method_2(empty2, isTraining);
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[PaymentTypes] WHERE [Name] = 'CHECK') BEGIN INSERT INTO [dbo].[PaymentTypes] ([Name], [SortOrder], [OpenCashDrawer], [UsePaymentTerminal], [SystemDefault]) VALUES ('CHECK', 13, 1, 0, 0)  END";
			method_2(empty2, isTraining);
		}
		empty2 = "IF EXISTS (SELECT * FROM sys.default_constraints WHERE name = 'DF__Items__StationID__1920BF5C' ) BEGIN ALTER TABLE [dbo].[Items] DROP CONSTRAINT [DF__Items__StationID__1920BF5C] END;ALTER TABLE[dbo].[Items] ALTER COLUMN[StationID] NVARCHAR(256) NULL;";
		method_2(empty2, isTraining);
		empty2 = "IF EXISTS (SELECT * FROM sys.default_constraints WHERE name = 'DF_Orders_StationID' ) BEGIN ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [DF_Orders_StationID] END;ALTER TABLE[dbo].[Orders] ALTER COLUMN[StationID] NVARCHAR(256) NULL;";
		method_2(empty2, isTraining);
		if (!method_1("PrintEachQty", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [PrintEachQty] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'payfinish_screen_ifchange') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('payfinish_screen_ifchange', 'OFF', '', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Roles] WHERE [RoleName] = 'Supervisor') BEGIN INSERT INTO [dbo].[Roles] ([RoleName]) VALUES ('Supervisor')  END";
		method_2(empty2, isTraining);
		foreach (ModuleAndFeaturesData item in new List<ModuleAndFeaturesData>
		{
			new ModuleAndFeaturesData("frmAdmin", "btnAddEditItem", "Admin -> Add/Edit Items"),
			new ModuleAndFeaturesData("frmAdmin", "btnAddEditGroup", "Admin -> Add/Edit Groups"),
			new ModuleAndFeaturesData("frmAdmin", "btnAddItemInGroup", "Admin -> Add/Move Items to Group"),
			new ModuleAndFeaturesData("frmAdmin", "btnViewGroupItems", "Admin -> Manage Groups & Items"),
			new ModuleAndFeaturesData("frmAdmin", "btnOptions", "Admin -> Add/Edit Options"),
			new ModuleAndFeaturesData("frmAdmin", "btnInstructions", "Admin -> Add/Edit Instructions"),
			new ModuleAndFeaturesData("frmAdmin", "btnAddEditIngredients", "Admin -> Add/Edit Ingredients"),
			new ModuleAndFeaturesData("frmAdmin", "btnEditLayout", "Admin -> Edit Layout"),
			new ModuleAndFeaturesData("frmAdmin", "btnEmployees", "Admin -> Employees"),
			new ModuleAndFeaturesData("frmAdmin", "btnTaxSettings", "Admin -> Setup Tax"),
			new ModuleAndFeaturesData("frmAdmin", "btnSetMode", "Admin -> Training Mode"),
			new ModuleAndFeaturesData("frmAdmin", "btnSettings", "Admin -> Tools & Settings")
		})
		{
			empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='" + item.ModuleName + "' AND [ControlName]='" + item.ControlName + "') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description]) VALUES ('" + item.ModuleName + "', '" + item.ControlName + "', '" + item.Description + "') END";
			method_2(empty2, isTraining);
		}
		if (!method_1("RoleLevel", "Roles", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Roles] ADD [RoleLevel] SMALLINT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("PrintItemQtyGreater", "Stations", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Stations] ADD [PrintItemQtyGreater] SMALLINT DEFAULT((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("DefaultOrderTypes", "Terminals", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Terminals] ADD [DefaultOrderTypes] NVARCHAR (256) DEFAULT N'Dine In,To-Go,Pick-Up,Delivery' NOT NULL;";
			method_2(empty, isTraining);
		}
		empty = "UPDATE [dbo].[Terminals] SET [DefaultOrderTypes] = 'Dine In,To-Go,Pick-Up,Delivery' WHERE [DefaultOrderTypes] IS NULL;ALTER TABLE [dbo].[Terminals] ALTER COLUMN [DefaultOrderTypes] NVARCHAR(256) NOT NULL;IF (select COLUMN_DEFAULT from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Terminals' and COLUMN_NAME = 'DefaultOrderTypes') IS NULL BEGIN ALTER TABLE [dbo].[Terminals] ADD CONSTRAINT DF_DefaultOrderType DEFAULT N'Dine In,To-Go,Pick-Up,Delivery' FOR [DefaultOrderTypes] END";
		method_2(empty, isTraining);
		if (!method_1("StationMade", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [StationMade] NVARCHAR (256) NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_clock_out') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('print_clock_out', 'OFF', '', 0)  END";
		method_2(empty2, isTraining);
		if (!method_1("PromptItemOptions", "GroupsInItems", isTraining))
		{
			empty = "ALTER TABLE [dbo].[GroupsInItems] ADD [PromptItemOptions] BIT DEFAULT((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'show_placeholder_options') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('show_placeholder_options', 'OFF', '', 0) END";
		method_2(empty2, isTraining);
		if (!method_1("GroupDependency", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [GroupDependency] SMALLINT DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		if (!method_1("OptionDependency", "ItemsWithOptions", isTraining))
		{
			empty = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [OptionDependency] NVARCHAR(128) DEFAULT((0)) NOT NULL;";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'print_merchant_copy') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('print_merchant_copy', 'ON', '', 0)  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = 'production_mode') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('production_mode', 'Disabled', '', 0)  END";
		method_2(empty2, isTraining);
		empty = "ALTER PROCEDURE [dbo].[usp_ClosingTotals] AS BEGIN SET NOCOUNT ON; SELECT Name, COUNT(Name) AS Qty, SUM(Value) AS Total FROM Temp GROUP BY Name; END";
		method_2(empty, isTraining);
		method_5("eodreport_company_info", "ON", isTraining);
		method_5("eodreport_tender_summary", "ON", isTraining);
		method_5("eodreport_sales_summary", "ON", isTraining);
		method_5("eodreport_void_summary", "ON", isTraining);
		method_5("eodreport_refund_summary", "ON", isTraining);
		method_5("eodreport_payout_summary", "ON", isTraining);
		method_5("eodreport_other_info", "ON", isTraining);
		method_5("eodreport_employee_summary", "ON", isTraining);
		method_5("eodreport_tipshare_summary", "ON", isTraining);
		if (!method_1("LoyaltyRedemption", "Items", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Items] ADD [LoyaltyRedemption] BIT DEFAULT((1)) NOT NULL;";
			method_2(empty, isTraining);
		}
		method_5("quick_service_view", "tile", isTraining);
		if (!method_0("Payouts", isTraining))
		{
			empty = "CREATE TABLE [dbo].[Payouts] ( [Id] INT IDENTITY (1, 1) NOT NULL, [Reason] NVARCHAR (512) NULL, [Amount] DECIMAL (18, 4) DEFAULT((0)) NOT NULL, [DateCreated] DATETIME NOT NULL, CONSTRAINT [aaaaaPayouts_PK] PRIMARY KEY NONCLUSTERED ([Id] ASC) ) ";
			method_2(empty, isTraining);
		}
		method_5("show_payout_button", "OFF", isTraining);
		method_5("safe_drop_setting", "OFF", isTraining);
		method_5("safe_drop_bill", "0", isTraining);
		method_5("safe_drop_til", "0", isTraining);
		method_5("openclose_store", "OFF", isTraining);
		method_6("frmPayoutSafeDrop", "btnSafeDrop", "Payouts -> Safe Drop", isTraining);
		method_6("frmPayoutSafeDrop", "btnReverseSD", "Payouts -> Rev. Safe Drop", isTraining);
		method_6("frmPayoutSafeDrop", "btnClearSafeDrop", "Payouts -> Clear Safe Drop", isTraining);
		if (!method_1("isOpen", "CompanySetup", isTraining))
		{
			empty = "ALTER TABLE [dbo].[CompanySetup] ADD [isOpen] BIT DEFAULT((1)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("OpeningBalance", "CompanySetup", isTraining))
		{
			empty = "ALTER TABLE [dbo].[CompanySetup] ADD [OpeningBalance] DECIMAL(16,2) DEFAULT((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		if (!method_1("ClosingBalance", "CompanySetup", isTraining))
		{
			empty = "ALTER TABLE [dbo].[CompanySetup] ADD [ClosingBalance] DECIMAL(16,2) DEFAULT((0)) NOT NULL; ";
			method_2(empty, isTraining);
		}
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[TaxRuleRequirements] WHERE [TaxRuleRequirementId] = '0c75e459-7c5b-4c5c-976f-9600ca4f99d7') BEGIN INSERT INTO [dbo].[TaxRuleRequirements] ([TaxRuleRequirementId], [RequirementDesc]) VALUES ('0c75e459-7c5b-4c5c-976f-9600ca4f99d7', 'If Item quantity is')  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS ( SELECT * FROM [dbo].[TaxRuleRequirements] WHERE [TaxRuleRequirementId] = '107126df-8faf-425a-a233-7fc9f7fae9f6') BEGIN INSERT INTO [dbo].[TaxRuleRequirements] ([TaxRuleRequirementId], [RequirementDesc]) VALUES ('107126df-8faf-425a-a233-7fc9f7fae9f6', 'if subtotal of all items are')  END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS (SELECT *  FROM sys.indexes WHERE name='IX_OnlineOrderSyncQueues_DateCreated_Desc' AND object_id = OBJECT_ID('[dbo].[OnlineOrderSyncQueues]')) BEGIN CREATE NONCLUSTERED INDEX IX_OnlineOrderSyncQueues_DateCreated_Desc ON [dbo].[OnlineOrderSyncQueues] (DateCreated DESC) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Orders_DateCreated' AND object_id = OBJECT_ID('[dbo].[Orders]')) BEGIN CREATE NONCLUSTERED INDEX IX_Orders_DateCreated ON dbo.Orders (\tDateCreated DESC ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Orders_OrderNumber' AND object_id = OBJECT_ID('[dbo].[Orders]')) BEGIN CREATE NONCLUSTERED INDEX IX_Orders_OrderNumber ON dbo.Orders (\tOrderNumber DESC ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_ItemsWithOptions_GroupID' AND object_id = OBJECT_ID('[dbo].[ItemsWithOptions]')) BEGIN CREATE NONCLUSTERED INDEX IX_ItemsWithOptions_GroupID ON dbo.ItemsWithOptions (GroupID) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_TransactionReceipts_OrderNumber' AND object_id = OBJECT_ID('[dbo].[TransactionReceipts]')) BEGIN CREATE NONCLUSTERED INDEX IX_TransactionReceipts_OrderNumber ON dbo.TransactionReceipts\t(OrderNumber DESC) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_TransactionReceipts_DateCreated' AND object_id = OBJECT_ID('[dbo].[TransactionReceipts]')) BEGIN CREATE NONCLUSTERED INDEX IX_TransactionReceipts_DateCreated ON dbo.TransactionReceipts (DateCreated DESC) WITH(STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END";
		method_2(empty2, isTraining);
		empty2 = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_GenKeys_KeyName' AND object_id = OBJECT_ID('[dbo].[GenKeys]')) BEGIN CREATE NONCLUSTERED INDEX IX_GenKeys_KeyName ON dbo.GenKeys ( KeyName ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(empty2, isTraining);
		if (!method_1("ItemOptionId", "Orders", isTraining))
		{
			empty = "ALTER TABLE [dbo].[Orders] ADD [ItemOptionId] INT NULL;";
			method_2(empty, isTraining);
		}
	}

	public void DbUpdatedTo_1_12_2(bool isTraining, string version)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		method_5("order_type_receipt", "", isTraining);
		method_5("print_payout", "OFF", isTraining);
		empty = "IF NOT EXISTS ( SELECT * FROM [dbo].[Roles] WHERE [RoleName] = 'Driver') BEGIN INSERT INTO [dbo].[Roles] ([RoleName],[RoleLevel]) VALUES ('Driver',5)  END";
		method_2(empty, isTraining);
		if (!method_1("PrintReceipt", "PaymentTypes", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[PaymentTypes] ADD [PrintReceipt] BIT DEFAULT((1)) NOT NULL;";
			method_2(empty2, isTraining);
		}
		method_6("frmAdminViewOrders", "btnChangePaymentType", "Order History -> Payment Type", isTraining);
		if (!method_1("DateTimeSeated", "Orders", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Orders] ADD [DateTimeSeated] DATETIME NULL;";
			method_2(empty2, isTraining);
		}
		if (!method_1("DateTimeSeated", "Layout", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Layout] ADD [DateTimeSeated] DATETIME NULL;";
			method_2(empty2, isTraining);
		}
		method_5("delivery_management", "OFF", isTraining);
		if (!method_0("OrderTypeGenKeys", isTraining))
		{
			empty2 = "CREATE TABLE [dbo].[OrderTypeGenKeys] ([Id] SMALLINT      IDENTITY (1, 1) NOT NULL,[OrderType] NVARCHAR(128) NULL,[GenKeysId] SMALLINT NOT NULL,CONSTRAINT [PK_OrderTicketOrderType] PRIMARY KEY CLUSTERED ([Id] ASC),CONSTRAINT [FK_OrderTypeGenKeys_GenKeys] FOREIGN KEY ([GenKeysId]) REFERENCES [dbo].[GenKeys] (GenKeyID))";
			method_2(empty2, isTraining);
		}
		if (!method_1("StartKey", "GenKeys", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[GenKeys] ADD [StartKey] INT NULL";
			method_2(empty2, isTraining);
		}
		if (!method_1("EndKey", "GenKeys", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[GenKeys] ADD [EndKey] INT NULL";
			method_2(empty2, isTraining);
		}
		if (method_0("EmployeeClockInOutQueues", isTraining) && !method_1("EmployeeId", "EmployeeClockInOutQueues", isTraining))
		{
			empty2 = "DROP TABLE [dbo].[EmployeeClockInOutQueues];";
			method_2(empty2, isTraining);
		}
		if (!method_0("EmployeeClockInOutQueues", isTraining))
		{
			empty2 = "CREATE TABLE [dbo].[EmployeeClockInOutQueues] ([Id]          INT            IDENTITY (1, 1) NOT NULL, [EmployeePin] NVARCHAR (128) NULL, [Timestamp]   NVARCHAR (128) NULL, [Action]      NVARCHAR (128) NULL, [Synced]      BIT            DEFAULT ((0)) NOT NULL,[EmployeeId] INT NULL,CONSTRAINT [EmployeeClockInOutQueues_PK] PRIMARY KEY NONCLUSTERED ([Id] ASC), CONSTRAINT [FK_EmployeeClockInOutQueues_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([EmployeeID]));";
			method_2(empty2, isTraining);
		}
		if (!method_1("Description", "Groups", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Groups] ADD [Description] nvarchar(MAX);";
			method_2(empty2, isTraining);
		}
		if (!method_1("ItemLongName", "Items", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Items] ADD [ItemLongName] nvarchar(255);";
			method_2(empty2, isTraining);
		}
		method_5("auto_settlement", "OFF", isTraining);
		method_5("auto_settlement_time", "", isTraining);
		if (!method_1("LastDateSettlement", "Terminals", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Terminals] ADD [LastDateSettlement] DATETIME NULL;";
			method_2(empty2, isTraining);
		}
		if (!method_1("DeliveryTravelDistanceKM", "Customers", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Customers] ADD [DeliveryTravelDistanceKM] DECIMAL (6, 2)  NULL;";
			method_2(empty2, isTraining);
		}
		if (!method_1("DeliveryTravelTimeMinutes", "Customers", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Customers] ADD [DeliveryTravelTimeMinutes] INT DEFAULT((0)) NOT NULL;";
			method_2(empty2, isTraining);
		}
		if (!method_1("DeliveryTravelDistanceKM", "Orders", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Orders]  ADD [DeliveryTravelDistanceKM] DECIMAL (6, 2) NULL;";
			method_2(empty2, isTraining);
		}
		if (!method_1("DeliveryTravelTimeMinutes", "Orders", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Orders] ADD [DeliveryTravelTimeMinutes] INT DEFAULT((0)) NOT NULL;";
			method_2(empty2, isTraining);
		}
		if (!method_1("DepartureTime", "Orders", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Orders] ADD [DepartureTime] DATETIME NULL;";
			method_2(empty2, isTraining);
		}
		if (!method_1("DeliveryTime", "Orders", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[Orders] ADD [DeliveryTime] DATETIME NULL;";
			method_2(empty2, isTraining);
		}
		method_5("eodreport_payout_summary", "ON", isTraining);
		method_5("delivery_distance_uom", "KM", isTraining);
		method_5("print_orderticket", "OFF", isTraining);
		if (!method_0("ItemCourses", isTraining))
		{
			empty2 = "CREATE TABLE [dbo].[ItemCourses] ( [Id] INT IDENTITY(1, 1) NOT NULL, [Name] NVARCHAR(128) NULL,[OnHoldMinutes] INT DEFAULT((0)) NOT NULL,CONSTRAINT[ItemCourses_PK] PRIMARY KEY NONCLUSTERED([Id] ASC))";
			method_2(empty2, isTraining);
		}
		foreach (string item in new List<string>
		{
			ItemCourses.Appetizer,
			ItemCourses.Entree,
			ItemCourses.Dessert,
			ItemCourses.Side,
			ItemCourses.Beverage,
			ItemCourses.Uncategorized
		})
		{
			empty = "IF NOT EXISTS ( SELECT * FROM [dbo].[ItemCourses] WHERE [Name] = '" + item + "') BEGIN INSERT INTO [dbo].[ItemCourses] ([Name],[OnHoldMinutes]) VALUES ('" + item + "',0)  END";
			method_2(empty, isTraining);
		}
		if (!method_0("Promotions", isTraining))
		{
			empty2 = "CREATE TABLE [dbo].[Promotions] ([PromoId]           INT             IDENTITY (1, 1) NOT NULL,[PromoName]         NVARCHAR (128)  NULL,[PromoCode]         NVARCHAR (128)  NULL,[Active]            BIT             DEFAULT ((0)) NOT NULL,[StartDate]         DATETIME        NULL,[EndDate]           DATETIME        NULL,[DayTimeOfWeek]     NVARCHAR (1024) NULL,[OrderTypes]        NVARCHAR (512)  NULL,[BuyQty]            DECIMAL (12, 2) NULL,[BuyItemIDs]        NVARCHAR (1024) NULL,[GetQtyString]      NVARCHAR (5)    NULL,[GetItemIDs]        NVARCHAR (1024) NULL,[GetDiscountAmount] DECIMAL (12, 4) NULL,[GetDiscountUOM]    NVARCHAR (1)    NULL,[Synced]            BIT             DEFAULT ((0)) NOT NULL,[DateCreated]       DATETIME        NULL,[DateModified]      DATETIME        NULL,[UserCreated]       INT             NULL,[UserModified]      INT             NULL,[IsDeleted]         BIT             DEFAULT ((0)) NOT NULL,CONSTRAINT [Promotions_PK] PRIMARY KEY NONCLUSTERED ([PromoId] ASC),CONSTRAINT [FK_Promotion_UserCreated] FOREIGN KEY ([UserCreated]) REFERENCES [dbo].[Employees] ([EmployeeID]),CONSTRAINT [FK_Promotion_UserModified] FOREIGN KEY ([UserModified]) REFERENCES [dbo].[Employees] ([EmployeeID]));";
			method_2(empty2, isTraining);
		}
		if (!method_1("Synced", "ImageScreen", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[ImageScreen] ADD [Synced] BIT DEFAULT((0)) NOT NULL;";
			method_2(empty2, isTraining);
		}
		if (!method_1("BlobName", "ImageScreen", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[ImageScreen] ADD [BlobName] NVARCHAR (256) NULL";
			method_2(empty2, isTraining);
		}
		if (!method_1("BlobThumbnailName", "ImageScreen", isTraining))
		{
			empty2 = "ALTER TABLE [dbo].[ImageScreen] ADD [BlobThumbnailName] NVARCHAR (256) NULL;";
			method_2(empty2, isTraining);
		}
		method_6("frmAdmin", "btnPromotions", "Admin -> Promotions", isTraining);
		method_6("frmPayFinish", "btnOpenRegister", "Pay Finish -> Open Til Button", isTraining);
		empty2 = "UPDATE [dbo].[PaymentTypes] SET [SystemDefault] = 0 WHERE Name = 'CASH';";
		method_2(empty2, isTraining);
	}

	public void DbUpdatedTo_1_12_3(bool isTraining, string version)
	{
		string string_;
		if (!method_1("CustomerID", "Appointments", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Appointments] ADD [CustomerID] INT NULL;";
			method_2(string_, isTraining);
			string_ = "ALTER TABLE [dbo].[Appointments] ADD CONSTRAINT FK_Appointments_Customers FOREIGN KEY (CustomerID) REFERENCES dbo.Customers (CustomerID) ON UPDATE NO ACTION ON DELETE NO ACTION";
			method_2(string_, isTraining);
		}
		method_5("fulfillment_threshold", "OFF", isTraining);
		method_5("fulfillment_threshold_time", "1", isTraining);
		if (!method_1("OrderNotes", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [OrderNotes] NVARCHAR (512)  NULL;";
			method_2(string_, isTraining);
		}
		if (!method_0("GroupImages", isTraining))
		{
			string_ = "CREATE TABLE [dbo].[GroupImages] ([Id]                 INT            IDENTITY (1, 1) NOT NULL,[GroupID]            SMALLINT       NOT NULL,[BlobName]           NVARCHAR (256) NOT NULL,[BlobThumbnailName]  NVARCHAR (256) NOT NULL,[ImageAsText]        NVARCHAR (MAX) NULL,[isNewImage]         BIT            DEFAULT ((1)) NOT NULL,[ImageAsTextHighRes] NVARCHAR (MAX) NULL,PRIMARY KEY CLUSTERED ([Id] ASC),CONSTRAINT [FK_GroupImages_Group] FOREIGN KEY ([GroupID]) REFERENCES [dbo].[Groups] ([GroupID]));";
			method_2(string_, isTraining);
		}
		method_6("frmOrderEntry", "btnRemove", "Order Entry -> Remove Item", isTraining);
		method_5("use_combo_potential", "ON", isTraining);
		method_5("http_listener_access_token", "", isTraining);
		if (!method_1("ExcludeFromFreeOption", "ItemsWithOptions", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [ExcludeFromFreeOption] BIT DEFAULT((0)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("Synced", "Suppliers", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Suppliers] ADD [Synced] BIT DEFAULT((0)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("TipShareType", "CustomTipSharing", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[CustomTipSharing] ADD [TipShareType] SMALLINT DEFAULT ((1)) NOT NULL;";
			method_2(string_, isTraining);
		}
		method_5("run_sync_service", "ON", isTraining);
		method_5("delivery_fee_settings_json", "", isTraining);
		if (method_1("Qty", "Orders", isTraining))
		{
			string_ = "alter table [dbo].[Orders] alter column [Qty] Decimal(16,4) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (method_1("Qty", "Refunds", isTraining))
		{
			string_ = "alter table [dbo].[Refunds] alter column [Qty] Decimal(16,4) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("Synced", "Settings", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Settings] ADD [Synced] BIT DEFAULT ((0)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("ProductKey", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [ProductKey] NVARCHAR (38) NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("DefaultPrinter", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [DefaultPrinter] NVARCHAR (50) NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("PhoneModemDeviceName", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [PhoneModemDeviceName] NVARCHAR (128) NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("ShowPrintError", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [ShowPrintError] BIT DEFAULT (-1) NOT NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("MaxFreeOptionPerGroup", "ItemsWithOptions", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [MaxFreeOptionPerGroup] SMALLINT DEFAULT ((-1)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("UseSmartBarcode", "Items", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Items] ADD [UseSmartBarcode] BIT DEFAULT ((0)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("CloverAuthCode", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [CloverAuthCode] NVARCHAR (512) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("StationNotified", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [StationNotified] NVARCHAR (128) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("StationPrinted", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [StationPrinted] NVARCHAR (128) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("Notes", "ItemsWithOptions", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [Notes] NVARCHAR(256) NULL;";
			method_2(string_, isTraining);
		}
		if (version == "1.12.3")
		{
			string_ = "UPDATE [dbo].[Orders] SET Synced=0 WHERE [DiscountReasonItem] != NULL AND [DiscountReasonItem] != '';";
			method_2(string_, isTraining);
			string_ = "Update dbo.Orders SET StationPrinted = StationID WHERE PrintedInKitchen <> 0 AND StationID is not null and StationID <> '' AND (StationPrinted is null OR StationPrinted = '')";
			method_2(string_, isTraining);
			string_ = "Update dbo.UOMS SET Name ='KG' WHERE Name = 'Kilogram'";
			method_2(string_, isTraining);
			string_ = "Update dbo.UOMS SET Name ='LB' WHERE Name = 'Pound'";
			method_2(string_, isTraining);
		}
		if (!method_1("CustomerNotified", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [CustomerNotified] BIT DEFAULT ((0)) NOT NULL;";
			method_2(string_, isTraining);
		}
		method_5("auto_clear_orders", "ON", isTraining);
		method_5("sms_message_order_ready", "Your order at <company_name> is ready. *Do not reply to this message. Please call <company_phone> for any changes.", isTraining);
		if (!method_1("CreatedByTerminalID", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [CreatedByTerminalID] INT NULL;";
			method_2(string_, isTraining);
			string_ = "ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_OrdersCreatedBy_ToTerminals] FOREIGN KEY ([CreatedByTerminalID]) REFERENCES [dbo].[Terminals] ([TerminalID]); ";
			method_2(string_, isTraining);
		}
		if (!method_1("Scale_ComPort", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [Scale_ComPort] NVARCHAR(5) DEFAULT(('NONE'));";
			method_2(string_, isTraining);
		}
		method_5("scale_functionality", "OFF", isTraining);
		method_5("scale_uom", "KG", isTraining);
		method_5("scale_make", "Generic", isTraining);
		method_5("pickup_order_time_increment", "15", isTraining);
		method_5("order_tax_fix", "ON", isTraining);
		method_5("auto_logout_oe", "OFF", isTraining);
		if (!method_1("TaxesIncluded", "Items", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Items] ADD [TaxesIncluded] BIT DEFAULT ((0)) NOT NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("OrderDiscountType", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [OrderDiscountType] NVARCHAR (10) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("OverridePrice", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [OverridePrice] DECIMAL(18, 2) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("Long", "CompanySetup", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[CompanySetup] ADD [Long] NVARCHAR (30) NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("Lat", "CompanySetup", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[CompanySetup] ADD [Lat] NVARCHAR (30) NULL; ";
			method_2(string_, isTraining);
		}
		if (method_1("Quantity", "MaterialsInItem", isTraining))
		{
			string_ = "alter table [dbo].[MaterialsInItem] alter column [Quantity] DECIMAL (18, 4) NULL;";
			method_2(string_, isTraining);
		}
		method_5("capitalize_item_group_text", "ON", isTraining);
		method_5("coin_system", "OFF", isTraining);
		method_5("online_order_notification_all", "OFF", isTraining);
		method_5("online_order_notification_all_audio", "OFF", isTraining);
		method_5("online_order_notification_audio_time", "60", isTraining);
		method_5("show_employee_table", "OFF", isTraining);
		string_ = "ALTER TABLE [dbo].[Stations] Drop Constraint DF_Stations_PaperSize;";
		method_2(string_, isTraining);
		string_ = "ALTER TABLE [dbo].[Stations] ALTER COLUMN [PaperSize] nvarchar(5); ";
		method_2(string_, isTraining);
		string_ = "ALTER TABLE [dbo].[Stations] ADD Constraint DF_Stations_PaperSize DEFAULT '80mm' FOR PaperSize; ";
		method_2(string_, isTraining);
	}

	public void DbUpdatedTo_1_12_4(bool isTraining, string version)
	{
		method_5("enable_custom_discount", "ON", isTraining);
		string string_;
		if (!method_1("AutoPromptOptions", "Items", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Items] ADD [AutoPromptOptions] BIT DEFAULT ((1)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("BatchStockQty", "Items", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Items] ADD [BatchStockQty] DECIMAL(18,4) DEFAULT ((1)) NOT NULL;";
			method_2(string_, isTraining);
		}
		method_5("http_port_range", "8880-8890", isTraining);
		method_5("group_chits_per_table", "OFF", isTraining);
		if (!method_1("TipDesc", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [TipDesc] NVARCHAR(128) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("hasUnconfirmedOnlineOrder", "CompanySetup", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[CompanySetup] ADD [hasUnconfirmedOnlineOrder] BIT DEFAULT((0)) NOT NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("CustomerInfoEmail", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [CustomerInfoEmail] NVARCHAR (128) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("SubSource", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [SubSource] NVARCHAR(50) NULL;";
			method_2(string_, isTraining);
		}
		string_ = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Orders_SharedItemID' AND object_id = OBJECT_ID('[dbo].[Orders]')) BEGIN CREATE NONCLUSTERED INDEX IX_Orders_SharedItemID ON dbo.Orders ( ShareItemID ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(string_, isTraining);
		string_ = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Orders_CustomerID' AND object_id = OBJECT_ID('[dbo].[Orders]')) BEGIN CREATE NONCLUSTERED INDEX IX_Orders_CustomerID ON dbo.Orders ( CustomerID ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(string_, isTraining);
		string_ = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Orders_FulfillmentAt' AND object_id = OBJECT_ID('[dbo].[Orders]')) BEGIN CREATE NONCLUSTERED INDEX IX_Orders_FulfillmentAt ON dbo.Orders ( FulfillmentAt DESC ) WITH ( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(string_, isTraining);
		if (!method_0("OrderAuditsLogs", isTraining))
		{
			string_ = "CREATE TABLE [dbo].[OrderAuditsLogs] ([Id]          INT            IDENTITY (1, 1) NOT NULL,[OrderNumber] NVARCHAR (20)  NULL,[Comment]     NVARCHAR (MAX) NULL, [DateCreated] DATETIME       DEFAULT (getdate()) NOT NULL,[Synced]      BIT            DEFAULT ((0)) NOT NULL,PRIMARY KEY CLUSTERED ([Id] ASC));";
			method_2(string_, isTraining);
		}
		if (!method_0("SettingsAuditLogs", isTraining))
		{
			string_ = "CREATE TABLE [dbo].[SettingsAuditLogs] ([Id]          INT            IDENTITY (1, 1) NOT NULL,[Key]         NVARCHAR (50)  NULL, [Comment]     NVARCHAR (MAX) NULL, [DateCreated] DATETIME       DEFAULT (getdate()) NOT NULL, [Synced]      BIT            DEFAULT ((0)) NOT NULL, PRIMARY KEY CLUSTERED ([Id] ASC));";
			method_2(string_, isTraining);
		}
		if (!method_1("ItemBarcode", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [ItemBarcode] NVARCHAR(50) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("LastModified", "Customers", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Customers] ADD [LastModified] DateTime DEFAULT(GetDate()) NOT NULL;";
			method_2(string_, isTraining);
			string_ = "UPDATE[dbo].[Customers] SET LastModified = DateCreated;";
			method_2(string_, isTraining);
		}
		if (!method_1("FlagID", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [FlagID] TINYINT DEFAULT((0)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("ShowOnPatronOrdering", "Items", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Items] ADD [ShowOnPatronOrdering] BIT DEFAULT ((1)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("PatronOrderingSortOrder", "ItemsInGroups", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[ItemsInGroups] ADD [PatronOrderingSortOrder] SMALLINT DEFAULT 0 NOT NULL; ";
			method_2(string_, isTraining);
			string_ = "UPDATE [dbo].[ItemsInGroups] SET [PatronOrderingSortOrder] = [SortOrder]; ";
			method_2(string_, isTraining);
		}
		if (!method_1("ShowOnPatronOrdering", "ItemsWithOptions", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [ShowOnPatronOrdering] BIT DEFAULT ((1)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("ShowOnPatronOrdering", "ItemsInGroups", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[ItemsInGroups] ADD [ShowOnPatronOrdering] BIT DEFAULT ((1)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("PatronOrderingSortOrder", "ItemsWithOptions", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[ItemsWithOptions] ADD [PatronOrderingSortOrder] SMALLINT DEFAULT 0 NOT NULL; ";
			method_2(string_, isTraining);
			string_ = "UPDATE [dbo].[ItemsWithOptions] SET [PatronOrderingSortOrder] = [SortOrder]; ";
			method_2(string_, isTraining);
		}
		string_ = "ALTER PROCEDURE [dbo].[usp_ItemOptions] AS BEGIN SET NOCOUNT ON;  SELECT  dbo.ItemsWithOptions.ItemWithOptionID, dbo.ItemsWithOptions.ItemID, dbo.Items.ItemID AS Option_ItemID, dbo.Items.Barcode, dbo.Items.ItemName, dbo.Items.ItemLongName, dbo.Items.ShowOnPatronOrdering, dbo.ItemsWithOptions.ShowOnPatronOrdering AS ItemOptionShowOnPatronOrdering, dbo.Items.SortOrder, dbo.ItemsWithOptions.PatronOrderingSortOrder AS PatronOrderingOptionSortOrder, dbo.ItemsWithOptions.Price AS SpecialPrice, dbo.Groups.OrderEntryShow AS OptionsGroupShowOrderEntry,  dbo.ItemsWithOptions.SortOrder AS OptionSortOrder, dbo.ItemsWithOptions.AllowAdditional, dbo.ItemsWithOptions.Tab, dbo.ItemsWithOptions.GroupID, dbo.ItemsWithOptions.Qty, dbo.ItemsWithOptions.MaxGroupOptions,   dbo.Groups.OrderEntryShow AS OptionsGroupShowOrderEntry, dbo.ItemsWithOptions.MinGroupOptions, dbo.ItemsWithOptions.Color, dbo.ItemsWithOptions.Preselect, dbo.ItemsWithOptions.GroupOrderTypes, dbo.ItemsWithOptions.GroupDependency,   dbo.ItemsWithOptions.OptionDependency, dbo.ItemsWithOptions.ToBeDeleted, dbo.Groups.SortOrder AS GroupSortOrder, dbo.ItemsWithOptions.ExcludeFromFreeOption, dbo.ItemsWithOptions.MaxFreeOptionPerGroup,   dbo.ItemsWithOptions.Notes, dbo.Groups.GroupName  FROM  dbo.ItemsWithOptions INNER JOIN  dbo.Options INNER JOIN  dbo.Items ON dbo.Options.ItemID = dbo.Items.ItemID ON dbo.ItemsWithOptions.OptionID = dbo.Options.OptionID LEFT OUTER JOIN  dbo.Groups ON dbo.ItemsWithOptions.GroupID = dbo.Groups.GroupID  ORDER BY dbo.ItemsWithOptions.ItemID; END";
		method_2(string_, isTraining);
		string_ = "UPDATE GROUPS SET OrderEntryShow=1 WHERE OrderEntryShow=0 AND GroupClassification='option'";
		method_2(string_, isTraining);
		string_ = "ALTER TABLE [dbo].[Customers] ALTER COLUMN [CustomerCell]  NVARCHAR (20)  NULL;";
		method_2(string_, isTraining);
		string_ = "ALTER TABLE [dbo].[Customers] ALTER COLUMN [CustomerHome]  NVARCHAR (20)  NULL;";
		method_2(string_, isTraining);
		if (version == "1.12.3")
		{
			string_ = "UPDATE [dbo].[Orders] SET Synced=0 WHERE [DiscountReasonItem] != NULL AND [DiscountReasonItem] != '';";
			method_2(string_, isTraining);
			string_ = "Update dbo.Orders SET StationPrinted = StationID WHERE PrintedInKitchen <> 0 AND StationID is not null and StationID <> '' AND (StationPrinted is null OR StationPrinted = '')";
			method_2(string_, isTraining);
			string_ = "Update dbo.UOMS SET Name ='KG' WHERE Name = 'Kilogram'";
			method_2(string_, isTraining);
			string_ = "Update dbo.UOMS SET Name ='LB' WHERE Name = 'Pound'";
			method_2(string_, isTraining);
		}
		if (!method_1("CustomerNotified", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [CustomerNotified] BIT DEFAULT ((0)) NOT NULL;";
			method_2(string_, isTraining);
		}
		method_5("auto_clear_orders", "OFF", isTraining);
		method_5("sms_message_order_ready", "Your order at <company_name> is ready. *Do not reply to this message. Please call <company_phone> for any changes.", isTraining);
		if (!method_1("CreatedByTerminalID", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [CreatedByTerminalID] INT NULL;";
			method_2(string_, isTraining);
			string_ = "ALTER TABLE [dbo].[Orders] ADD CONSTRAINT [FK_OrdersCreatedBy_ToTerminals] FOREIGN KEY ([CreatedByTerminalID]) REFERENCES [dbo].[Terminals] ([TerminalID]); ";
			method_2(string_, isTraining);
		}
		if (!method_1("Scale_ComPort", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [Scale_ComPort] NVARCHAR(5) DEFAULT(('NONE'));";
			method_2(string_, isTraining);
		}
		method_5("scale_functionality", "OFF", isTraining);
		method_5("scale_uom", "KG", isTraining);
		method_5("scale_make", "Generic", isTraining);
		method_5("order_tax_fix", "ON", isTraining);
		method_5("auto_logout_oe", "OFF", isTraining);
		if (!method_1("CustomerInfoPhone", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [CustomerInfoPhone] NVARCHAR (20) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("TaxesIncluded", "Items", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Items] ADD [TaxesIncluded] BIT DEFAULT ((0)) NOT NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("OrderDiscountType", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [OrderDiscountType] NVARCHAR (10) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("OverridePrice", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [OverridePrice] DECIMAL(18, 2) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("Long", "CompanySetup", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[CompanySetup] ADD [Long] NVARCHAR (30) NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("Lat", "CompanySetup", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[CompanySetup] ADD [Lat] NVARCHAR (30) NULL; ";
			method_2(string_, isTraining);
		}
		method_5("capitalize_item_group_text", "ON", isTraining);
		method_5("coin_system", "OFF", isTraining);
		method_5("online_order_notification_all", "OFF", isTraining);
		method_5("online_order_notification_all_audio", "OFF", isTraining);
		method_5("online_order_notification_audio_time", "60", isTraining);
		method_5("show_employee_table", "OFF", isTraining);
		string_ = "ALTER TABLE [dbo].[Stations] Drop Constraint DF_Stations_PaperSize;";
		method_2(string_, isTraining);
		string_ = "ALTER TABLE [dbo].[Stations] ALTER COLUMN [PaperSize] nvarchar(5); ";
		method_2(string_, isTraining);
		string_ = "ALTER TABLE [dbo].[Stations] ADD Constraint DF_Stations_PaperSize DEFAULT '80mm' FOR PaperSize; ";
		method_2(string_, isTraining);
		method_5("fix_employee_clock", "PENDING", isTraining);
		if (method_3("SELECT Value FROM [dbo].[Settings] WHERE [Key] = 'fix_employee_clock'", isTraining) == "PENDING")
		{
			string_ = "UPDATE [EmployeeClockInOutQueues] Set Synced = 0 WHERE CONVERT(datetime, [Timestamp]) > '12/01/2020'; ";
			method_2(string_, isTraining);
			string_ = "UPDATE [dbo].[Settings] SET Value = 'PROCESSED' WHERE [Key] = 'fix_employee_clock';";
			method_2(string_, isTraining);
		}
		if (!method_1("hasUnconfirmedOnlineOrder", "CompanySetup", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[CompanySetup] ADD [hasUnconfirmedOnlineOrder] BIT DEFAULT((0)) NOT NULL; ";
			method_2(string_, isTraining);
		}
		string_ = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Orders_SharedItemID' AND object_id = OBJECT_ID('[dbo].[Orders]')) BEGIN CREATE NONCLUSTERED INDEX IX_Orders_SharedItemID ON dbo.Orders ( ShareItemID ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(string_, isTraining);
		string_ = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Orders_CustomerID' AND object_id = OBJECT_ID('[dbo].[Orders]')) BEGIN CREATE NONCLUSTERED INDEX IX_Orders_CustomerID ON dbo.Orders ( CustomerID ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(string_, isTraining);
		string_ = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Orders_FulfillmentAt' AND object_id = OBJECT_ID('[dbo].[Orders]')) BEGIN CREATE NONCLUSTERED INDEX IX_Orders_FulfillmentAt ON dbo.Orders ( FulfillmentAt DESC ) WITH ( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(string_, isTraining);
		string_ = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='IX_Orders_DateCleared' AND object_id = OBJECT_ID('[dbo].[Orders]')) BEGIN CREATE NONCLUSTERED INDEX IX_Orders_DateCleared ON dbo.Orders ( DateCleared DESC ) WITH ( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] END;";
		method_2(string_, isTraining);
		if (version == "1.12.3")
		{
			string_ = "UPDATE [Orders] SET Synced = 0 where Paid = 1 AND Void = 0 AND ItemOptionId > 0;";
			method_2(string_, isTraining);
		}
		if (method_1("OrderNumber", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ALTER COLUMN [OrderNumber] nvarchar(40) NULL;";
			method_2(string_, isTraining);
		}
		if (method_1("OrderNumber", "OrderAuditsLogs", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[OrderAuditsLogs] ALTER COLUMN [OrderNumber] nvarchar(40) NULL;";
			method_2(string_, isTraining);
		}
		if (method_1("OrderNumber", "GiftCardTransactionLogs", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[GiftCardTransactionLogs] ALTER COLUMN [OrderNumber] nvarchar(40) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("TimeZoneName", "CompanySetup", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[CompanySetup] ADD [TimeZoneName] NVARCHAR (100) NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("TimeZoneOffset", "CompanySetup", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[CompanySetup] ADD [TimeZoneOffset] INT DEFAULT((0)) NOT NULL; ";
			method_2(string_, isTraining);
		}
		method_5("card_transaction_fee_json", "[]", isTraining);
		if (!method_1("PaymentMethod", "PaymentTerminalTransactionLogs", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[PaymentTerminalTransactionLogs] ADD [PaymentMethod] NVARCHAR(20) NULL;";
			method_2(string_, isTraining);
		}
		method_5("print_eod_clock_out", "OFF", isTraining);
		string_ = "ALTER TABLE [dbo].[Orders] ALTER COLUMN [OrderNotes] NVARCHAR (MAX)  NULL;";
		method_2(string_, isTraining);
		if (!method_1("isReconciled", "InventoryAudits", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[InventoryAudits] ADD [isReconciled] BIT DEFAULT 0 NOT NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("LastGoodInventoryReconciledDate", "Items", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Items] ADD [LastGoodInventoryReconciledDate] DATETIME NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("InstallationToken", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [InstallationToken] NVARCHAR(256) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("InstallationID", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [InstallationID] NVARCHAR(128) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("SystemUID", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [SystemUID] NVARCHAR(128) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("Synced", "Employees", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Employees] ADD [Synced] BIT DEFAULT 0 NOT NULL; ";
			method_2(string_, isTraining);
		}
		if (!method_1("Synced", "UOMs", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[UOMs] ADD [Synced] BIT    DEFAULT ((0)) NOT NULL; ";
			method_2(string_, isTraining);
		}
		string_ = "ALTER TABLE [dbo].[Terminals] ALTER COLUMN [PaymentTerminalAddress] NVARCHAR(50) NULL;";
		method_2(string_, isTraining);
		string_ = "ALTER TABLE [dbo].[PaymentTerminalTransactionLogs] ALTER COLUMN [IP] NVARCHAR(50) NOT NULL;";
		method_2(string_, isTraining);
		method_5("receipt_font_size_additional", "0", isTraining);
		if (!method_1("ThirdPartyOrderId", "Orders", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Orders] ADD [ThirdPartyOrderId] NVARCHAR(128) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("Comment", "OnlineOrderSyncQueues", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[OnlineOrderSyncQueues] ADD [Comment] NVARCHAR(128) NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("IsDeleted", "Stations", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Stations] ADD [IsDeleted] BIT DEFAULT((0)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("ProcessOnlineOrderQueueFlag", "Terminals", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Terminals] ADD [ProcessOnlineOrderQueueFlag] BIT DEFAULT(0) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("ReOrderLimit", "Items", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Items] ADD [ReOrderLimit] DECIMAL (18, 2)  DEFAULT ((-1)) NOT NULL;";
			method_2(string_, isTraining);
		}
		if (!method_1("ReorderQty", "Items", isTraining))
		{
			string_ = "ALTER TABLE [dbo].[Items] ADD [ReorderQty] DECIMAL (18, 2)  NULL;";
			method_2(string_, isTraining);
		}
		if (!method_0("CloudsyncDataArchiver", isTraining))
		{
			string_ = "CREATE TABLE [dbo].[CloudsyncDataArchiver] ([Id] INT IDENTITY (1, 1) NOT NULL,[UniqueIdentifier] NVARCHAR(MAX) NULL,[DataType] NVARCHAR(MAX) NULL,   [DateCreated]      DATETIME NOT NULL,[Synced] BIT DEFAULT((0)) NOT NULL,CONSTRAINT [CloudsyncDataArchiver_PK] PRIMARY KEY NONCLUSTERED ([Id] ASC));";
			method_2(string_, isTraining);
		}
		method_5("is_sql_dependency", "ON", isTraining);
		method_4(isTraining);
	}

	private void method_4(bool bool_0)
	{
		if (bool_0)
		{
			return;
		}
		string text = "";
		string connectionString = getConnectionString(bool_0);
		if (!connectionString.Contains("AttachDbFilename"))
		{
			DbConnectionStringBuilder dbConnectionStringBuilder = new DbConnectionStringBuilder();
			dbConnectionStringBuilder.ConnectionString = connectionString;
			string text2 = dbConnectionStringBuilder["Initial Catalog"] as string;
			try
			{
				_ = dbConnectionStringBuilder["User ID"];
			}
			catch
			{
				_ = dbConnectionStringBuilder["UserID"];
			}
			text = "SELECT is_broker_enabled FROM sys.databases WHERE name = '" + text2 + "'";
			if (!twouihSvv(text, bool_0))
			{
				text = "ALTER DATABASE [" + text2 + "] SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE;";
				method_2(text, bool_0);
			}
		}
	}

	private void method_5(string string_1, string string_2, bool bool_0)
	{
		string string_3 = "IF NOT EXISTS ( SELECT * FROM [dbo].[Settings] WHERE [Key] = '" + string_1 + "') BEGIN INSERT INTO [dbo].[Settings] ([Key], [Value], [ToolTip], [ShowInSettings]) VALUES ('" + string_1 + "', '" + string_2 + "', '', 0)  END";
		method_2(string_3, bool_0);
	}

	private void method_6(string string_1, string string_2, string string_3, bool bool_0)
	{
		string string_4 = "IF NOT EXISTS ( SELECT * FROM [dbo].[ModulesAndFeatures] WHERE [ModuleName]='" + string_1 + "' AND [ControlName]='" + string_2 + "') BEGIN INSERT INTO [dbo].[ModulesAndFeatures] ([ModuleName], [ControlName], [Description]) VALUES ('" + string_1 + "', '" + string_2 + "', '" + string_3 + "') END";
		method_2(string_4, bool_0);
	}

	public DBHelper()
	{
		Class13.FLcy5UmzUUEfT();
		string_0 = string.Empty;
		base._002Ector();
	}
}

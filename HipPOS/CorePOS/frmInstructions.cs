using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Methods;
using CorePOS.CustomControls;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmInstructions : frmMasterForm
{
	private short short_0;

	private InstructionsMethods instructionsMethods_0;

	private string[] string_0;

	private Font font_0;

	private RadListView radListView_0;

	private int int_0;

	private int int_1;

	private IContainer icontainer_1;

	internal Panel InstructionsPanel;

	internal RichTextBox txtCurrentInstructions;

	internal Button btnClear;

	internal Button BtnDone;

	internal Label lblOrderType;

	private Label label10;

	private Label label16;

	private VerticalScrollControl verticalScrollControl1;

	private FlowLayoutPanel pnlSpecialInstructions;

	private Label label1;

	internal Button btnItemOnHold;

	public frmInstructions()
	{
		Class26.Ggkj0JxzN9YmC();
		short_0 = 1;
		instructionsMethods_0 = new InstructionsMethods();
		string_0 = new string[51];
		int_0 = 8;
		base._002Ector();
		InitializeComponent_1();
	}

	private void frmInstructions_Load(object sender, EventArgs e)
	{
	}

	public void page_load(object sender)
	{
		int_1 = 0;
		if (sender is frmOrderEntry)
		{
			radListView_0 = (RadListView)(object)((frmOrderEntry)sender).radListItems;
		}
		else
		{
			radListView_0 = (RadListView)(object)((frmPatron)sender).radListItems;
		}
		int num = 0;
		int num2 = 0;
		int itemId = Convert.ToInt32(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(4).ToString());
		List<SpecialInstruction> source = instructionsMethods_0.SpecialInstructionsListItemAtStation(itemId);
		font_0 = new Font("Arial", 9f, FontStyle.Regular);
		foreach (SpecialInstruction item in source.OrderBy((SpecialInstruction a) => a.SortOrder))
		{
			method_3(item.Instruction.ToUpper(), num, num2, Convert.ToInt16(item.SpecialInstructionID), item.Color);
			if (num == int_0 - 1)
			{
				num2++;
				num = -1;
			}
			num++;
		}
		if (((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Count() >= 8)
		{
			txtCurrentInstructions.Text = ((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(7).ToString();
			string_0 = ((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(7).ToString()
				.Split(Convert.ToChar(","));
		}
		short num3 = 0;
		while (num3 <= string_0.Length - 1 && !string.IsNullOrEmpty(string_0[num3]))
		{
			SpecialInstruction specialInstruction = instructionsMethods_0.SpecialInstructionsList(string_0[num3]);
			if (specialInstruction != null && specialInstruction.SpecialInstructionID != 0 && InstructionsPanel.Controls.Find(specialInstruction.SpecialInstructionID.ToString(), searchAllChildren: false).Count() > 0)
			{
				int_1++;
				InstructionsPanel.Controls[specialInstruction.SpecialInstructionID.ToString()].BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Gold"]);
			}
			num3 = (short)(num3 + 1);
		}
		method_3(Resources._CUSTOM, num, num2, 9999, HelperMethods.ButtonColors()["Gray"]);
		InstructionsPanel.HorizontalScroll.Maximum = 0;
		InstructionsPanel.AutoScroll = false;
		InstructionsPanel.VerticalScroll.Visible = false;
		InstructionsPanel.AutoScroll = true;
		method_4();
		method_10(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0]);
	}

	private void method_3(string string_1, int int_2, int int_3, short short_1, string string_2)
	{
		Label label = new Label();
		label.Name = short_1.ToString();
		label.Text = string_1.Replace("&", "&&");
		label.Font = font_0;
		label.FlatStyle = FlatStyle.Flat;
		label.TextAlign = ContentAlignment.MiddleCenter;
		label.ForeColor = Color.White;
		if (string.IsNullOrEmpty(string_2))
		{
			string_2 = HelperMethods.ButtonColors()["Gray"];
		}
		Color color2 = (label.BackColor = HelperMethods.GetColor(string_2));
		label.Tag = string_2;
		int num = (int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal(InstructionsPanel.Width - 5) / (decimal)int_0)) - 1;
		int num2 = (int)Math.Floor(Convert.ToDecimal(Convert.ToDecimal(InstructionsPanel.Height) / (decimal)int_0)) - 3;
		label.Size = new Size(num, num2);
		label.Location = new Point(int_2 * num + (int_2 + 1) * short_0, int_3 * num2 + (int_3 + 1) * short_0);
		if (string_1 == Resources._CUSTOM)
		{
			label.BackColor = Color.FromArgb(53, 152, 220);
			label.Click += method_9;
		}
		else
		{
			label.Click += method_5;
		}
		InstructionsPanel.Controls.Add(label);
	}

	private void method_4()
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		int num = Convert.ToInt32(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(14).ToString());
		CS_0024_003C_003E8__locals0.itemComboId = Convert.ToInt32(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(5).ToString());
		Convert.ToDecimal(string.IsNullOrEmpty(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_Item(3).ToString()) ? "0.00" : ((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_Item(3).ToString());
		ListViewDataItem val = ((IEnumerable<ListViewDataItem>)radListView_0.get_Items()).Where((ListViewDataItem a) => a.get_SubItems().get_Item(5).ToString() == CS_0024_003C_003E8__locals0.itemComboId.ToString()).FirstOrDefault();
		if ((num == 0 && !string.IsNullOrEmpty(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(6).ToString())) || (CS_0024_003C_003E8__locals0.itemComboId > 0 && val != ((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0]))
		{
			btnItemOnHold.Visible = false;
		}
		else
		{
			btnItemOnHold.Visible = true;
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		Label label = sender as Label;
		if (label.BackColor == HelperMethods.GetColor(label.Tag.ToString()))
		{
			if (int_1 < 10)
			{
				method_6(label.Text);
				label.BackColor = HelperMethods.GetColor(HelperMethods.ButtonColors()["Gold"]);
			}
			else
			{
				new frmMessageBox(Resources.You_have_added_too_many_instru, Resources.TOO_MANY_INSTRUCTIONS).ShowDialog(this);
			}
		}
		else
		{
			method_7(label.Text);
			label.BackColor = HelperMethods.GetColor(label.Tag.ToString());
		}
	}

	private void method_6(string string_1)
	{
		int_1++;
		((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().set_Item(7, (object)((!string.IsNullOrEmpty(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(7).ToString())) ? (((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(7).ToString() + ", " + string_1) : string_1));
		txtCurrentInstructions.Text = ((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(7).ToString();
		method_8();
	}

	private void method_7(string string_1)
	{
		int_1--;
		string obj = ((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(7).ToString();
		List<string> list = new List<string>();
		string[] array = obj.Split(',');
		foreach (string text in array)
		{
			if (text.Replace(" ", "") != string_1.Replace(" ", ""))
			{
				list.Add(text);
			}
		}
		((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().set_Item(7, (object)string.Join(",", list));
		txtCurrentInstructions.Text = ((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(7).ToString();
		method_8();
	}

	private void method_8()
	{
		if (SettingsHelper.GetSettingValueByKey("show_instruction_oe") == "ON")
		{
			string text = ((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_Item(1).ToString();
			string text2 = (text.Contains(" => INSTR: ") ? text.Substring(text.IndexOf(" => INSTR: ")) : "");
			string text3 = ((!string.IsNullOrEmpty(text2)) ? ((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_Item(1).ToString().Replace(text2, "") : text);
			((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].set_Item(1, (object)((!string.IsNullOrEmpty(txtCurrentInstructions.Text)) ? (text3 + " => INSTR: " + txtCurrentInstructions.Text) : text3));
			MemoryLoadedObjects.OrderEntry.CloneListviewToSecondScreen();
		}
	}

	private void method_9(object sender, EventArgs e)
	{
		string empty = string.Empty;
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Custom_Instructions, 3, 32);
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			empty = MemoryLoadedObjects.Keyboard.textEntered;
			if (!string.IsNullOrEmpty(empty))
			{
				method_6(empty);
			}
		}
	}

	private void btnClear_Click(object sender, EventArgs e)
	{
		string_0 = ((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(7).ToString()
			.Split(Convert.ToChar(","));
		short num = 0;
		while (num <= string_0.Length - 1)
		{
			if (!string.IsNullOrEmpty(string_0[0]))
			{
				if (!(string_0[num] != string.Empty))
				{
					break;
				}
				SpecialInstruction specialInstruction = instructionsMethods_0.SpecialInstructionsList(string_0[num]);
				if (specialInstruction != null && specialInstruction.SpecialInstructionID != 0 && InstructionsPanel.Controls.Find(specialInstruction.SpecialInstructionID.ToString(), searchAllChildren: false).Count() > 0)
				{
					InstructionsPanel.Controls[specialInstruction.SpecialInstructionID.ToString()].BackColor = HelperMethods.GetColor(specialInstruction.Color);
				}
				num = (short)(num + 1);
				continue;
			}
			new frmMessageBox(Resources.There_are_no_instruction_s_to_).ShowDialog(this);
			return;
		}
		((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().set_Item(7, (object)"");
		txtCurrentInstructions.Text = "";
		int_1 = 0;
		method_8();
	}

	private void BtnDone_Click(object sender, EventArgs e)
	{
		instructionsMethods_0 = null;
		string_0 = null;
		font_0 = null;
		ControlHelpers.ClearControlsInPanel(InstructionsPanel);
		Close();
		Dispose(disposing: true);
	}

	private void btnItemOnHold_Click(object sender, EventArgs e)
	{
		int num = Convert.ToInt32(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(14).ToString());
		if (num == 0 && !string.IsNullOrEmpty(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(6).ToString()))
		{
			new NotificationLabel(this, "Item cannot be on hold. Item is already sent to kitchen.", NotificationTypes.Warning).Show();
			return;
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Number minutes to hold. \"0\" to remove hold. ", 0, 3, num.ToString());
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals0.itemComboId = Convert.ToInt32(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().get_Item(5).ToString());
		if (CS_0024_003C_003E8__locals0.itemComboId > 0)
		{
			foreach (ListViewDataItem item in ((IEnumerable<ListViewDataItem>)radListView_0.get_Items()).Where((ListViewDataItem a) => a.get_SubItems().get_Item(5).ToString() == CS_0024_003C_003E8__locals0.itemComboId.ToString()))
			{
				item.get_SubItems().set_Item(14, (object)MemoryLoadedObjects.Numpad.numberEntered.ToString());
				method_10(item);
			}
			return;
		}
		((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0].get_SubItems().set_Item(14, (object)MemoryLoadedObjects.Numpad.numberEntered.ToString());
		method_10(((ReadOnlyCollection<ListViewDataItem>)(object)radListView_0.get_SelectedItems())[0]);
	}

	private void method_10(ListViewDataItem listViewDataItem_0)
	{
		if (Convert.ToInt32(listViewDataItem_0.get_SubItems().get_Item(14).ToString()) != 0)
		{
			btnItemOnHold.BackColor = Color.FromArgb(80, 203, 116);
			listViewDataItem_0.set_BackColor(Color.FromArgb(50, 119, 155));
			listViewDataItem_0.set_ForeColor(Color.LightGray);
		}
		else
		{
			btnItemOnHold.BackColor = Color.FromArgb(42, 102, 134);
			listViewDataItem_0.set_BackColor(Color.White);
			listViewDataItem_0.set_ForeColor(Color.Black);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmInstructions));
		label1 = new Label();
		pnlSpecialInstructions = new FlowLayoutPanel();
		btnItemOnHold = new Button();
		verticalScrollControl1 = new VerticalScrollControl();
		InstructionsPanel = new Panel();
		txtCurrentInstructions = new RichTextBox();
		label16 = new Label();
		label10 = new Label();
		btnClear = new Button();
		BtnDone = new Button();
		lblOrderType = new Label();
		pnlSpecialInstructions.SuspendLayout();
		SuspendLayout();
		label1.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label1, "label1");
		label1.ForeColor = Color.White;
		label1.Name = "label1";
		label1.Tag = "product";
		pnlSpecialInstructions.Controls.Add(btnItemOnHold);
		componentResourceManager.ApplyResources(pnlSpecialInstructions, "pnlSpecialInstructions");
		pnlSpecialInstructions.Name = "pnlSpecialInstructions";
		componentResourceManager.ApplyResources(btnItemOnHold, "btnItemOnHold");
		btnItemOnHold.BackColor = Color.FromArgb(42, 102, 134);
		btnItemOnHold.FlatAppearance.BorderColor = Color.White;
		btnItemOnHold.FlatAppearance.BorderSize = 0;
		btnItemOnHold.FlatAppearance.MouseDownBackColor = Color.White;
		btnItemOnHold.ForeColor = Color.White;
		btnItemOnHold.Name = "btnItemOnHold";
		btnItemOnHold.UseVisualStyleBackColor = false;
		btnItemOnHold.Click += btnItemOnHold_Click;
		verticalScrollControl1.BackColor = Color.Transparent;
		verticalScrollControl1.ButtonStyle = "fourbuttons";
		verticalScrollControl1.ConnectedPanel = InstructionsPanel;
		verticalScrollControl1.ConnectedRadListView = null;
		verticalScrollControl1.inputedHeight = 0;
		verticalScrollControl1.inputedWidth = 0;
		componentResourceManager.ApplyResources(verticalScrollControl1, "verticalScrollControl1");
		verticalScrollControl1.Name = "verticalScrollControl1";
		InstructionsPanel.BackColor = Color.FromArgb(35, 39, 56);
		InstructionsPanel.ForeColor = Color.FromArgb(40, 40, 40);
		componentResourceManager.ApplyResources(InstructionsPanel, "InstructionsPanel");
		InstructionsPanel.Name = "InstructionsPanel";
		txtCurrentInstructions.BackColor = Color.White;
		txtCurrentInstructions.BorderStyle = BorderStyle.None;
		componentResourceManager.ApplyResources(txtCurrentInstructions, "txtCurrentInstructions");
		txtCurrentInstructions.Name = "txtCurrentInstructions";
		txtCurrentInstructions.ReadOnly = true;
		label16.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label16, "label16");
		label16.ForeColor = Color.White;
		label16.Name = "label16";
		label16.Tag = "product";
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		btnClear.BackColor = Color.SandyBrown;
		btnClear.FlatAppearance.BorderColor = Color.White;
		btnClear.FlatAppearance.BorderSize = 0;
		btnClear.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(btnClear, "btnClear");
		btnClear.ForeColor = Color.White;
		btnClear.Name = "btnClear";
		btnClear.UseVisualStyleBackColor = false;
		btnClear.Click += btnClear_Click;
		BtnDone.BackColor = Color.FromArgb(80, 203, 116);
		BtnDone.DialogResult = DialogResult.Cancel;
		BtnDone.FlatAppearance.BorderColor = Color.White;
		BtnDone.FlatAppearance.BorderSize = 0;
		BtnDone.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
		componentResourceManager.ApplyResources(BtnDone, "BtnDone");
		BtnDone.ForeColor = Color.White;
		BtnDone.Name = "BtnDone";
		BtnDone.UseVisualStyleBackColor = false;
		BtnDone.Click += BtnDone_Click;
		componentResourceManager.ApplyResources(lblOrderType, "lblOrderType");
		lblOrderType.ForeColor = Color.White;
		lblOrderType.Name = "lblOrderType";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(label1);
		base.Controls.Add(pnlSpecialInstructions);
		base.Controls.Add(verticalScrollControl1);
		base.Controls.Add(txtCurrentInstructions);
		base.Controls.Add(label16);
		base.Controls.Add(label10);
		base.Controls.Add(btnClear);
		base.Controls.Add(BtnDone);
		base.Controls.Add(lblOrderType);
		base.Controls.Add(InstructionsPanel);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmInstructions";
		base.Opacity = 1.0;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.Load += frmInstructions_Load;
		pnlSpecialInstructions.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}

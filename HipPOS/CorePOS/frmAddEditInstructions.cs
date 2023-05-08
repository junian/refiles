using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Business.Methods;
using CorePOS.Data;
using CorePOS.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CorePOS;

public class frmAddEditInstructions : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public string instruct;

		public _003C_003Ec__DisplayClass16_0()
		{
			Class26.Ggkj0JxzN9YmC();
			base._002Ector();
		}
	}

	private int int_0;

	private string string_0;

	private int int_1;

	private bool bool_0;

	private IContainer icontainer_1;

	private ListView lstInstructions;

	private Label lblTextLabel;

	internal Button btnSaveInstruction;

	internal Button btnRemoveInstruction;

	private Label label4;

	internal Button btnShowNumpad_InstructionDescription;

	private RadTextBoxControl txtInstructionDescription;

	internal Button btnAdd;

	private PictureBox pbClose;

	private Class20 ddlStations;

	private Class20 ddlColors;

	private Label label6;

	private Label lblHideControls;

	internal Button btnDown;

	internal Button btnUp;

	private Label lblTitle;

	private Label label3;

	public frmAddEditInstructions(string _type = "instruction")
	{
		Class26.Ggkj0JxzN9YmC();
		int_1 = 100;
		bool_0 = true;
		base._002Ector();
		InitializeComponent_1();
		new FormHelper().ResizeButtonFonts(this);
		string_0 = _type;
	}

	private void frmAddEditInstructions_Load(object sender, EventArgs e)
	{
		if (string_0 != "instruction")
		{
			ddlStations.Visible = false;
			btnShowNumpad_InstructionDescription.Location = new Point(btnSaveInstruction.Left - btnShowNumpad_InstructionDescription.Size.Width - 1, btnShowNumpad_InstructionDescription.Location.Y);
			txtInstructionDescription.Size = new Size(txtInstructionDescription.Left + btnShowNumpad_InstructionDescription.Left - 1, txtInstructionDescription.Height);
			int_1 = 256;
			txtInstructionDescription.MaxLength = int_1;
			Text = "Add/Edit Instructions";
		}
		if (string_0 == ReasonTypes.discount)
		{
			lblTitle.Text = Resources.Add_Edit_Discount_Reasons;
			lblTextLabel.Text = Resources.Discount_Reason_Description;
			Text = "Add/Edit Discount Reasons";
		}
		else if (string_0 == ReasonTypes.refund)
		{
			lblTitle.Text = Resources.Add_Edit_Refund_Reasons;
			lblTextLabel.Text = Resources.Refund_Reason_Description;
			Text = "Add/Edit Refund Reasons";
		}
		else if (string_0 == ReasonTypes.voidreason)
		{
			lblTitle.Text = "Add/Edit Void Reasons";
			lblTextLabel.Text = "Void Reason Description";
			Text = "Add/Edit Void Reasons";
		}
		else if (string_0 == ReasonTypes.tax_change)
		{
			lblTitle.Text = Resources.Add_Edit_Tax_Change_Reasons;
			lblTextLabel.Text = Resources.Tax_Change_Reason_Description;
			string_0 = "tax change";
			Text = "Add/Edit Tax Change Reasons";
		}
		else if (string_0 == ReasonTypes.payout)
		{
			lblTitle.Text = "Add Edit Payout Reason";
			lblTextLabel.Text = "Payout reason description.";
		}
		else
		{
			Button button = btnUp;
			btnDown.Visible = true;
			button.Visible = true;
			lblHideControls.Visible = false;
			ddlStations.Visible = true;
			pbClose.Visible = false;
			StationMethods stationMethods = new StationMethods();
			Dictionary<string, string> dictionary = new Dictionary<string, string> { { "0", "All Station" } };
			foreach (Station station in stationMethods.GetStations())
			{
				dictionary.Add(station.StationID.ToString(), station.StationName);
			}
			ddlStations.DisplayMember = "Value";
			ddlStations.ValueMember = "Key";
			ddlStations.DataSource = new BindingSource(dictionary, null);
		}
		Dictionary<string, string> dictionary2 = HelperMethods.ButtonColors();
		dictionary2.Remove("Red");
		dictionary2.Remove("Gold");
		ddlColors.DisplayMember = "Key";
		ddlColors.ValueMember = "Value";
		ddlColors.DataSource = new BindingSource(dictionary2, null);
		ddlColors.SelectedValue = dictionary2["Gray"];
		method_3();
		bool_0 = false;
	}

	private void method_3()
	{
		lstInstructions.Items.Clear();
		GClass6 gClass = new GClass6();
		if (string_0 == "instruction")
		{
			foreach (SpecialInstruction item in from tblSpecialInstructions in gClass.SpecialInstructions
				select (tblSpecialInstructions) into a
				orderby a.SortOrder
				select a)
			{
				lstInstructions.Items.Add(item.Instruction);
			}
		}
		else
		{
			foreach (Reason item2 in gClass.Reasons.Where((Reason tblDiscountReasons) => tblDiscountReasons.ReasonType == string_0))
			{
				lstInstructions.Items.Add(item2.Value);
			}
		}
		foreach (ListViewItem item3 in lstInstructions.Items)
		{
			if (item3.Text == txtInstructionDescription.Text)
			{
				item3.Focused = true;
				item3.Selected = true;
				item3.EnsureVisible();
			}
		}
	}

	private void lstInstructions_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstInstructions.SelectedItems.Count <= 0)
		{
			return;
		}
		GClass6 gClass = new GClass6();
		txtInstructionDescription.Text = lstInstructions.SelectedItems[0].Text;
		if (string_0 == "instruction")
		{
			SpecialInstruction specialInstruction = gClass.SpecialInstructions.Where((SpecialInstruction s) => s.Instruction == lstInstructions.SelectedItems[0].Text).FirstOrDefault();
			int_0 = specialInstruction.SpecialInstructionID;
			ddlStations.SelectedValue = specialInstruction.StationID.ToString();
			string text = specialInstruction.Color;
			if (string.IsNullOrEmpty(specialInstruction.Color) || text == HelperMethods.ButtonColors()["Gold"])
			{
				text = (specialInstruction.Color = HelperMethods.ButtonColors()["Gray"]);
				Helper.SubmitChangesWithCatch(gClass);
			}
			ddlColors.SelectedValue = text;
			method_5();
		}
		else
		{
			int_0 = (from s in gClass.Reasons
				where s.Value == lstInstructions.SelectedItems[0].Text
				select s.Id).FirstOrDefault();
		}
	}

	private void btnSaveInstruction_Click(object sender, EventArgs e)
	{
		GClass6 gClass = new GClass6();
		if (txtInstructionDescription.Text == string.Empty)
		{
			new frmMessageBox(Resources.Please_enter_a + string_0 + Resources._description, Resources.Invalid_Description).ShowDialog(this);
			return;
		}
		if (int_0 == 0)
		{
			if (string_0 == "instruction")
			{
				if (gClass.SpecialInstructions.Where((SpecialInstruction a) => a.Instruction.ToUpper() == txtInstructionDescription.Text.ToUpper()).FirstOrDefault() != null)
				{
					new frmMessageBox("Instruction already exists please add another one.", "Instruction Exists").Show();
					return;
				}
				SpecialInstruction entity = new SpecialInstruction
				{
					Instruction = txtInstructionDescription.Text,
					StationID = ((!(ddlStations.SelectedValue.ToString() == string.Empty)) ? int.Parse(ddlStations.SelectedValue.ToString()) : 0),
					Color = ddlColors.SelectedValue.ToString(),
					Synced = false
				};
				gClass.SpecialInstructions.InsertOnSubmit(entity);
			}
			else
			{
				if (txtInstructionDescription.Text.Length > 100)
				{
					new frmMessageBox("Reason is too long. Please shorten it.", "ERROR").ShowDialog();
					return;
				}
				if (gClass.Reasons.Where((Reason a) => a.Value.ToUpper() == txtInstructionDescription.Text.ToUpper() && a.ReasonType == string_0).FirstOrDefault() != null)
				{
					new frmMessageBox("Reason already exists please add another one.", "Reason Exists").Show();
					return;
				}
				Reason entity2 = new Reason
				{
					ReasonType = string_0,
					Value = txtInstructionDescription.Text
				};
				gClass.Reasons.InsertOnSubmit(entity2);
			}
		}
		if (lstInstructions.SelectedItems.Count > 0 && int_0 != 0)
		{
			if (string_0 == "instruction")
			{
				if (gClass.SpecialInstructions.Where((SpecialInstruction a) => a.SpecialInstructionID != int_0 && a.Instruction.ToUpper() == txtInstructionDescription.Text.ToUpper()).Count() > 0)
				{
					new frmMessageBox("Instruction already exists please add another one.", "Instruction Exists").Show();
					return;
				}
				SpecialInstruction specialInstruction = gClass.SpecialInstructions.Where((SpecialInstruction s) => s.SpecialInstructionID == int_0).FirstOrDefault();
				specialInstruction.StationID = ((!(ddlStations.SelectedValue.ToString() == string.Empty)) ? int.Parse(ddlStations.SelectedValue.ToString()) : 0);
				specialInstruction.Instruction = txtInstructionDescription.Text;
				specialInstruction.Color = ddlColors.SelectedValue.ToString();
				specialInstruction.Synced = false;
			}
			else
			{
				if (gClass.Reasons.Where((Reason a) => a.Value.ToUpper() == txtInstructionDescription.Text.ToUpper() && a.ReasonType == string_0).Count() > 1)
				{
					new frmMessageBox("Reason already exists please add another one.", "Reason Exists").Show();
					return;
				}
				gClass.Reasons.Where((Reason s) => s.Id == int_0).FirstOrDefault().Value = txtInstructionDescription.Text;
			}
		}
		try
		{
			Helper.SubmitChangesWithCatch(gClass);
			new NotificationLabel(this, "Saved.", NotificationTypes.Success).Show();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		method_3();
	}

	private void btnRemoveInstruction_Click(object sender, EventArgs e)
	{
		if (lstInstructions.SelectedItems.Count == 0)
		{
			new frmMessageBox(Resources.Please_select_an_item_first).ShowDialog(this);
		}
		else
		{
			if (lstInstructions.SelectedItems.Count <= 0)
			{
				return;
			}
			string text = "";
			text = ((string_0 == "instruction") ? "Instruction" : ((string_0 == "discount") ? "Discount Reason" : ((!(string_0 == "refund")) ? "Tax Change" : "Refund Reason")));
			if (new frmMessageBox(Resources.Are_you_sure_you_want_to_delet + " " + text + ": " + lstInstructions.SelectedItems[0].Text + Resources.res, Resources.Delete_Confirmation, CustomMessageBoxButtons.YesNo).ShowDialog(this) != DialogResult.Yes)
			{
				return;
			}
			GClass6 gClass = new GClass6();
			if (string_0 == "instruction")
			{
				SpecialInstruction specialInstruction = gClass.SpecialInstructions.Where((SpecialInstruction s) => s.Instruction == lstInstructions.SelectedItems[0].Text).FirstOrDefault();
				if (specialInstruction != null)
				{
					gClass.SpecialInstructions.DeleteOnSubmit(specialInstruction);
				}
			}
			else
			{
				Reason reason = gClass.Reasons.Where((Reason s) => s.Value == lstInstructions.SelectedItems[0].Text && s.ReasonType == string_0).FirstOrDefault();
				if (reason != null)
				{
					gClass.Reasons.DeleteOnSubmit(reason);
				}
			}
			Helper.SubmitChangesWithCatch(gClass);
			SpecialInstruction specialInstruction2 = gClass.SpecialInstructions.FirstOrDefault();
			if (specialInstruction2 != null)
			{
				specialInstruction2.Synced = false;
				Helper.SubmitChangesWithCatch(gClass);
			}
			txtInstructionDescription.Text = "";
			method_3();
			int_0 = 0;
		}
	}

	private void txtInstructionDescription_Click(object sender, EventArgs e)
	{
		ControlHelpers.txt_click(sender);
	}

	private void btnShowNumpad_InstructionDescription_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		if (Thread.CurrentThread.CurrentCulture.Name.Equals("fr-CA"))
		{
			MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + Resources._description0 + " de l'" + string_0, 1, int_1, txtInstructionDescription.Text);
		}
		else
		{
			MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Enter + string_0.Substring(0, 1).ToUpper() + string_0.Substring(1) + Resources._Description1, 1, int_1, txtInstructionDescription.Text);
		}
		if (MemoryLoadedObjects.Keyboard.ShowDialog(this) == DialogResult.OK)
		{
			txtInstructionDescription.Text = MemoryLoadedObjects.Keyboard.textEntered;
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		txtInstructionDescription.Text = string.Empty;
		int_0 = 0;
		lstInstructions.SelectedItems.Clear();
		btnShowNumpad_InstructionDescription_Click(this, null);
	}

	private void pbClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		if (lstInstructions.SelectedItems.Count > 0)
		{
			int index = lstInstructions.SelectedItems[0].Index;
			if (index > 0)
			{
				ListViewItem item = lstInstructions.Items[index];
				lstInstructions.Items.RemoveAt(index);
				lstInstructions.Items.Insert(index - 1, item);
				lstInstructions.Items[index - 1].EnsureVisible();
				method_4();
			}
		}
		method_5();
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		if (lstInstructions.SelectedItems.Count > 0)
		{
			int num = lstInstructions.SelectedItems[0].Index;
			ListViewItem item = lstInstructions.Items[num];
			if (num < lstInstructions.Items.Count)
			{
				lstInstructions.Items.RemoveAt(num);
				if (num < lstInstructions.Items.Count)
				{
					num++;
				}
				lstInstructions.Items.Insert(num, item);
				lstInstructions.Items[num].EnsureVisible();
				method_4();
			}
		}
		method_5();
	}

	private void method_4()
	{
		GClass6 gClass = new GClass6();
		short num = 0;
		foreach (ListViewItem item in lstInstructions.Items)
		{
			if (!string.IsNullOrEmpty(item.SubItems[0].Text))
			{
				_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
				CS_0024_003C_003E8__locals0.instruct = item.SubItems[0].Text;
				SpecialInstruction specialInstruction = gClass.SpecialInstructions.Where((SpecialInstruction a) => a.Instruction == CS_0024_003C_003E8__locals0.instruct).FirstOrDefault();
				if (specialInstruction != null)
				{
					specialInstruction.SortOrder = num;
				}
				Helper.SubmitChangesWithCatch(gClass);
			}
			num = (short)(num + 1);
		}
	}

	private void method_5()
	{
		if (lstInstructions.SelectedItems.Count > 0)
		{
			int index = lstInstructions.SelectedItems[0].Index;
			if (index == 0)
			{
				btnUp.Enabled = false;
				btnDown.Enabled = true;
			}
			else if (index == lstInstructions.Items.Count - 1)
			{
				btnUp.Enabled = true;
				btnDown.Enabled = false;
			}
			else
			{
				btnUp.Enabled = true;
				btnDown.Enabled = true;
			}
		}
	}

	private void btnUp_EnabledChanged(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		if (!button.Enabled)
		{
			button.Tag = button.BackColor;
			button.BackColor = Color.Gray;
		}
		else if (button.Tag != null)
		{
			button.BackColor = (Color)button.Tag;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAddEditInstructions));
		btnAdd = new Button();
		txtInstructionDescription = new RadTextBoxControl();
		btnShowNumpad_InstructionDescription = new Button();
		label4 = new Label();
		btnRemoveInstruction = new Button();
		btnSaveInstruction = new Button();
		lblTextLabel = new Label();
		lstInstructions = new ListView();
		pbClose = new PictureBox();
		ddlStations = new Class20();
		ddlColors = new Class20();
		label6 = new Label();
		lblHideControls = new Label();
		btnDown = new Button();
		btnUp = new Button();
		lblTitle = new Label();
		label3 = new Label();
		((ISupportInitialize)txtInstructionDescription).BeginInit();
		((ISupportInitialize)pbClose).BeginInit();
		((ISupportInitialize)ddlStations).BeginInit();
		((ISupportInitialize)ddlColors).BeginInit();
		SuspendLayout();
		btnAdd.BackColor = Color.FromArgb(40, 132, 183);
		btnAdd.Cursor = Cursors.Default;
		btnAdd.FlatAppearance.BorderColor = Color.Black;
		btnAdd.FlatAppearance.BorderSize = 0;
		btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnAdd, "btnAdd");
		btnAdd.ForeColor = Color.White;
		btnAdd.Name = "btnAdd";
		btnAdd.UseVisualStyleBackColor = false;
		btnAdd.Click += btnAdd_Click;
		componentResourceManager.ApplyResources(txtInstructionDescription, "txtInstructionDescription");
		txtInstructionDescription.ForeColor = Color.FromArgb(40, 40, 40);
		txtInstructionDescription.Name = "txtInstructionDescription";
		txtInstructionDescription.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtInstructionDescription.Click += txtInstructionDescription_Click;
		((RadTextBoxControlElement)txtInstructionDescription.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtInstructionDescription.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(5f, 5f);
		btnShowNumpad_InstructionDescription.BackColor = Color.FromArgb(77, 174, 225);
		btnShowNumpad_InstructionDescription.DialogResult = DialogResult.OK;
		btnShowNumpad_InstructionDescription.FlatAppearance.BorderColor = Color.Black;
		btnShowNumpad_InstructionDescription.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnShowNumpad_InstructionDescription, "btnShowNumpad_InstructionDescription");
		btnShowNumpad_InstructionDescription.ForeColor = Color.White;
		btnShowNumpad_InstructionDescription.Name = "btnShowNumpad_InstructionDescription";
		btnShowNumpad_InstructionDescription.UseVisualStyleBackColor = false;
		btnShowNumpad_InstructionDescription.Click += btnShowNumpad_InstructionDescription_Click;
		label4.BackColor = Color.LemonChiffon;
		componentResourceManager.ApplyResources(label4, "label4");
		label4.Name = "label4";
		btnRemoveInstruction.BackColor = Color.FromArgb(235, 107, 86);
		btnRemoveInstruction.Cursor = Cursors.Default;
		btnRemoveInstruction.FlatAppearance.BorderColor = Color.Black;
		btnRemoveInstruction.FlatAppearance.BorderSize = 0;
		btnRemoveInstruction.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnRemoveInstruction, "btnRemoveInstruction");
		btnRemoveInstruction.ForeColor = Color.White;
		btnRemoveInstruction.Name = "btnRemoveInstruction";
		btnRemoveInstruction.UseVisualStyleBackColor = false;
		btnRemoveInstruction.Click += btnRemoveInstruction_Click;
		btnSaveInstruction.BackColor = Color.FromArgb(80, 203, 116);
		btnSaveInstruction.Cursor = Cursors.Default;
		btnSaveInstruction.FlatAppearance.BorderColor = Color.Black;
		btnSaveInstruction.FlatAppearance.BorderSize = 0;
		btnSaveInstruction.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 0, 37);
		componentResourceManager.ApplyResources(btnSaveInstruction, "btnSaveInstruction");
		btnSaveInstruction.ForeColor = Color.White;
		btnSaveInstruction.Name = "btnSaveInstruction";
		btnSaveInstruction.UseVisualStyleBackColor = false;
		btnSaveInstruction.Click += btnSaveInstruction_Click;
		lblTextLabel.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(lblTextLabel, "lblTextLabel");
		lblTextLabel.ForeColor = Color.White;
		lblTextLabel.Name = "lblTextLabel";
		lstInstructions.BackColor = Color.White;
		lstInstructions.Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(lstInstructions, "lstInstructions");
		lstInstructions.ForeColor = Color.FromArgb(40, 40, 40);
		lstInstructions.FullRowSelect = true;
		lstInstructions.Groups.AddRange(new ListViewGroup[1] { (ListViewGroup)componentResourceManager.GetObject("lstInstructions.Groups") });
		lstInstructions.HideSelection = false;
		lstInstructions.Name = "lstInstructions";
		lstInstructions.UseCompatibleStateImageBehavior = false;
		lstInstructions.View = View.List;
		lstInstructions.SelectedIndexChanged += lstInstructions_SelectedIndexChanged;
		pbClose.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(pbClose, "pbClose");
		pbClose.Name = "pbClose";
		pbClose.TabStop = false;
		pbClose.Click += pbClose_Click;
		componentResourceManager.ApplyResources(ddlStations, "ddlStations");
		ddlStations.BackColor = Color.White;
		ddlStations.DropDownStyle = RadDropDownStyle.DropDownList;
		ddlStations.EnableKineticScrolling = true;
		ddlStations.Name = "ddlStations";
		ddlStations.RootElement.MinSize = new Size(200, 0);
		ddlStations.Tag = "product";
		ddlStations.ThemeName = "Windows8";
		componentResourceManager.ApplyResources(ddlColors, "ddlColors");
		ddlColors.BackColor = Color.White;
		ddlColors.DropDownStyle = RadDropDownStyle.DropDownList;
		ddlColors.EnableKineticScrolling = true;
		ddlColors.Name = "ddlColors";
		ddlColors.RootElement.MinSize = new Size(150, 0);
		ddlColors.Tag = "product";
		ddlColors.ThemeName = "Windows8";
		label6.BackColor = Color.FromArgb(132, 146, 146);
		componentResourceManager.ApplyResources(label6, "label6");
		label6.ForeColor = Color.White;
		label6.Name = "label6";
		label6.Tag = "product";
		lblHideControls.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(lblHideControls, "lblHideControls");
		lblHideControls.ForeColor = Color.White;
		lblHideControls.Name = "lblHideControls";
		btnDown.BackColor = Color.FromArgb(53, 152, 220);
		btnDown.FlatAppearance.BorderColor = Color.Black;
		btnDown.FlatAppearance.BorderSize = 0;
		btnDown.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnDown, "btnDown");
		btnDown.ForeColor = Color.White;
		btnDown.Name = "btnDown";
		btnDown.Tag = "";
		btnDown.UseVisualStyleBackColor = false;
		btnDown.EnabledChanged += btnUp_EnabledChanged;
		btnDown.Click += btnDown_Click;
		btnUp.BackColor = Color.FromArgb(53, 152, 220);
		btnUp.FlatAppearance.BorderColor = Color.Black;
		btnUp.FlatAppearance.BorderSize = 0;
		btnUp.FlatAppearance.MouseDownBackColor = Color.White;
		componentResourceManager.ApplyResources(btnUp, "btnUp");
		btnUp.ForeColor = Color.White;
		btnUp.Name = "btnUp";
		btnUp.Tag = "";
		btnUp.UseVisualStyleBackColor = false;
		btnUp.EnabledChanged += btnUp_EnabledChanged;
		btnUp.Click += btnUp_Click;
		lblTitle.BackColor = Color.FromArgb(147, 101, 184);
		componentResourceManager.ApplyResources(lblTitle, "lblTitle");
		lblTitle.ForeColor = Color.White;
		lblTitle.Name = "lblTitle";
		label3.BackColor = Color.Gray;
		componentResourceManager.ApplyResources(label3, "label3");
		label3.ForeColor = Color.White;
		label3.Name = "label3";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.Controls.Add(label3);
		base.Controls.Add(btnDown);
		base.Controls.Add(btnUp);
		base.Controls.Add(lblHideControls);
		base.Controls.Add(ddlColors);
		base.Controls.Add(label6);
		base.Controls.Add(btnShowNumpad_InstructionDescription);
		base.Controls.Add(ddlStations);
		base.Controls.Add(pbClose);
		base.Controls.Add(btnAdd);
		base.Controls.Add(txtInstructionDescription);
		base.Controls.Add(label4);
		base.Controls.Add(btnRemoveInstruction);
		base.Controls.Add(btnSaveInstruction);
		base.Controls.Add(lblTextLabel);
		base.Controls.Add(lstInstructions);
		base.Controls.Add(lblTitle);
		base.Name = "frmAddEditInstructions";
		base.Opacity = 1.0;
		base.Load += frmAddEditInstructions_Load;
		((ISupportInitialize)txtInstructionDescription).EndInit();
		((ISupportInitialize)pbClose).EndInit();
		((ISupportInitialize)ddlStations).EndInit();
		((ISupportInitialize)ddlColors).EndInit();
		ResumeLayout(performLayout: false);
	}
}

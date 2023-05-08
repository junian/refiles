using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CorePOS.Business.Enums;
using CorePOS.Data;
using Telerik.WinControls.UI;
using Vlc.DotNet.Forms;

namespace CorePOS;

public class frmVideoUploader : frmMasterForm
{
	private string string_0;

	private Size size_0;

	private string[] string_1;

	private IContainer icontainer_1;

	private VlcControl myVlcControl;

	private Label label2;

	private Label label20;

	internal Button btnClose;

	internal Button btnDeleteImage;

	private Label label10;

	internal Button btnAddImage;

	private ListView lstViewImage;

	private Panel pnlVideo;

	private RadTextBoxControl txtInterval;

	internal Button btnShowKeyboard_txtInterval;

	private Label label1;

	private PictureBox imageContainer;

	private Label label9;

	private Label lblHideInterval;

	internal Button btnDown;

	internal Button btnUp;

	public frmVideoUploader()
	{
		Class26.Ggkj0JxzN9YmC();
		string_0 = AppDomain.CurrentDomain.BaseDirectory + "videos\\";
		string_1 = new string[1] { "input-repeat=-1" };
		base._002Ector();
		InitializeComponent_1();
	}

	private void method_3(object sender, VlcLibDirectoryNeededEventArgs e)
	{
		e.VlcLibDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\vlclib\\");
		_ = e.VlcLibDirectory.Exists;
	}

	private void frmVideoUploader_Load(object sender, EventArgs e)
	{
		if (!Directory.Exists(string_0))
		{
			Directory.CreateDirectory(string_0);
		}
		size_0 = new Size(pnlVideo.Width, pnlVideo.Height);
		method_4();
	}

	private void method_4()
	{
		lstViewImage.Items.Clear();
		List<ImageScreen> list = (from a in new GClass6().ImageScreens
			where a.ImageType == MediaType.second_screen_videos || a.ImageType == MediaType.second_screen_photos
			orderby a.SortOrder
			select a).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		foreach (ImageScreen item in list)
		{
			if (item.ImageType == MediaType.second_screen_videos)
			{
				if (File.Exists(string_0 + item.ImageName))
				{
					lstViewImage.Items.Add(item.ImageName);
					continue;
				}
				lstViewImage.Items.Add(item.ImageName + "|Downloading From Server...");
				lstViewImage.Items[lstViewImage.Items.Count - 1].BackColor = Color.Gray;
			}
			else
			{
				lstViewImage.Items.Add(item.ImageName);
			}
		}
	}

	private void lstViewImage_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstViewImage.SelectedItems.Count <= 0)
		{
			return;
		}
		ImageScreen imageScreen = new GClass6().ImageScreens.Where((ImageScreen a) => a.ImageName == lstViewImage.SelectedItems[0].Text).FirstOrDefault();
		if (imageScreen == null)
		{
			return;
		}
		if (myVlcControl.IsPlaying)
		{
			myVlcControl.Stop();
		}
		if (imageScreen.ImageType == MediaType.second_screen_videos)
		{
			if (lstViewImage.SelectedItems.Count > 0 && lstViewImage.SelectedItems[0].BackColor != Color.Gray)
			{
				txtInterval.Text = "0";
				lblHideInterval.Visible = true;
				imageContainer.Visible = false;
				myVlcControl.Visible = true;
				string text = lstViewImage.SelectedItems[0].Text;
				string fileName = string_0 + text;
				myVlcControl.SetMedia(new FileInfo(fileName), string_1);
				myVlcControl.Play();
			}
			return;
		}
		imageContainer.Visible = true;
		myVlcControl.Visible = false;
		byte[] buffer = Convert.FromBase64String(imageScreen.ImageAsText);
		try
		{
			Image image;
			using (MemoryStream stream = new MemoryStream(buffer))
			{
				image = Image.FromStream(stream);
			}
			imageContainer.Image = image;
			imageContainer.SizeMode = PictureBoxSizeMode.Zoom;
			txtInterval.Text = imageScreen.Interval.ToString();
			lblHideInterval.Visible = false;
		}
		catch (Exception)
		{
			imageContainer.Image = null;
			imageContainer.SizeMode = PictureBoxSizeMode.Zoom;
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		if (myVlcControl.IsPlaying)
		{
			myVlcControl.Stop();
		}
		myVlcControl.Dispose();
		Close();
	}

	private void btnAddImage_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.openSelectedFile = new OpenFileDialog();
		CS_0024_003C_003E8__locals0.openSelectedFile.Filter = "Video and Image Files|*.wmv; *.mp4; *.avi; *.png; *.jpg;";
		CS_0024_003C_003E8__locals0.openSelectedFile.Title = "Select an Image or Video";
		if (CS_0024_003C_003E8__locals0.openSelectedFile.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		if (!CS_0024_003C_003E8__locals0.openSelectedFile.SafeFileName.Contains(".png") && !CS_0024_003C_003E8__locals0.openSelectedFile.SafeFileName.Contains(".jpg"))
		{
			string destFileName = string_0 + CS_0024_003C_003E8__locals0.openSelectedFile.SafeFileName;
			File.Copy(CS_0024_003C_003E8__locals0.openSelectedFile.FileName, destFileName, overwrite: true);
			if (gClass.ImageScreens.Where((ImageScreen a) => a.ImageName == CS_0024_003C_003E8__locals0.openSelectedFile.SafeFileName && a.ImageType == MediaType.second_screen_videos).FirstOrDefault() == null)
			{
				ImageScreen entity = new ImageScreen
				{
					ImageName = CS_0024_003C_003E8__locals0.openSelectedFile.SafeFileName,
					ImageType = MediaType.second_screen_videos,
					ImageAsText = ""
				};
				gClass.ImageScreens.InsertOnSubmit(entity);
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		else
		{
			byte[] array = File.ReadAllBytes(CS_0024_003C_003E8__locals0.openSelectedFile.FileName);
			if (array.Length > 20000000)
			{
				new frmMessageBox("File is too large. 20MB is the maximum upload. ", "Import Error").ShowDialog();
				return;
			}
			string imageAsText = Convert.ToBase64String(array);
			if (gClass.ImageScreens.Where((ImageScreen a) => a.ImageName == CS_0024_003C_003E8__locals0.openSelectedFile.SafeFileName).FirstOrDefault() != null)
			{
				new frmMessageBox("Image already exist please select another image.").ShowDialog(this);
			}
			MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
			MemoryLoadedObjects.Keyboard.LoadFormData("Image Name", 3, 256, CS_0024_003C_003E8__locals0.openSelectedFile.SafeFileName);
			if (MemoryLoadedObjects.Keyboard.ShowDialog() == DialogResult.OK)
			{
				ImageScreen entity2 = new ImageScreen
				{
					ImageName = MemoryLoadedObjects.Keyboard.textEntered,
					ImageAsText = imageAsText,
					ImageType = MediaType.second_screen_photos
				};
				gClass.ImageScreens.InsertOnSubmit(entity2);
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		method_5();
		method_4();
	}

	private void btnDeleteImage_Click(object sender, EventArgs e)
	{
		try
		{
			_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
			if (myVlcControl != null && myVlcControl.IsPlaying)
			{
				myVlcControl.Stop();
			}
			GClass6 gClass = new GClass6();
			CS_0024_003C_003E8__locals0.fileName = lstViewImage.SelectedItems[0].Text;
			string path = string_0 + CS_0024_003C_003E8__locals0.fileName;
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			ImageScreen imageScreen = gClass.ImageScreens.Where((ImageScreen a) => a.ImageName == CS_0024_003C_003E8__locals0.fileName && (a.ImageType == MediaType.second_screen_videos || a.ImageType == MediaType.second_screen_photos)).FirstOrDefault();
			if (imageScreen != null)
			{
				gClass.ImageScreens.DeleteOnSubmit(imageScreen);
				Helper.SubmitChangesWithCatch(gClass);
				method_4();
			}
		}
		catch
		{
			new NotificationLabel(this, "The Image/Video you are trying to delete is currently in use by the second screen. Please close the second screen first by turning it off and restarting Hippos.", NotificationTypes.Warning).Show();
		}
	}

	private void txtInterval_TextChanged(object sender, EventArgs e)
	{
		if (lstViewImage.SelectedItems.Count > 0)
		{
			int num = 0;
			try
			{
				num = Convert.ToInt32(txtInterval.Text);
			}
			catch
			{
				new NotificationLabel(this, "Error please use a valid whole number of seconds.", NotificationTypes.Warning).Show();
				return;
			}
			GClass6 gClass = new GClass6();
			ImageScreen imageScreen = gClass.ImageScreens.Where((ImageScreen a) => a.ImageName == lstViewImage.SelectedItems[0].Text).FirstOrDefault();
			if (imageScreen != null)
			{
				imageScreen.Interval = num;
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
	}

	private void btnShowKeyboard_txtInterval_Click(object sender, EventArgs e)
	{
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Numpad();
		MemoryLoadedObjects.Numpad.LoadFormData("Enter Image Interval", 0, 3, txtInterval.Text);
		if (MemoryLoadedObjects.Numpad.ShowDialog(this) == DialogResult.OK)
		{
			txtInterval.Text = MemoryLoadedObjects.Numpad.numberEntered.ToString();
		}
		base.DialogResult = DialogResult.None;
	}

	private void btnUp_Click(object sender, EventArgs e)
	{
		if (lstViewImage.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, "Select an Image/Video to sort.", NotificationTypes.Notification).Show();
		}
		else if (lstViewImage.SelectedItems.Count > 0)
		{
			int index = lstViewImage.SelectedItems[0].Index;
			if (index > 0)
			{
				ListViewItem item = lstViewImage.Items[index];
				lstViewImage.Items.RemoveAt(index);
				lstViewImage.Items.Insert(index - 1, item);
				lstViewImage.Items[index - 1].EnsureVisible();
				method_5();
			}
		}
	}

	private void btnDown_Click(object sender, EventArgs e)
	{
		if (lstViewImage.SelectedItems.Count == 0)
		{
			new NotificationLabel(this, "Select an Image/Video to sort.", NotificationTypes.Notification).Show();
		}
		else if (lstViewImage.SelectedItems.Count > 0)
		{
			int index = lstViewImage.SelectedItems[0].Index;
			ListViewItem item = lstViewImage.Items[index];
			if (index < lstViewImage.Items.Count - 1)
			{
				lstViewImage.Items.RemoveAt(index);
				lstViewImage.Items.Insert(index + 1, item);
				lstViewImage.Items[index + 1].EnsureVisible();
				method_5();
			}
		}
	}

	private void method_5()
	{
		GClass6 gClass = new GClass6();
		List<ImageScreen> source = gClass.ImageScreens.Where((ImageScreen a) => a.ImageType == MediaType.second_screen_videos || a.ImageType == MediaType.second_screen_photos).ToList();
		int num = 0;
		foreach (ListViewItem item in lstViewImage.Items)
		{
			_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
			CS_0024_003C_003E8__locals0.fileName = item.Text.Split('|')[0];
			source.Where((ImageScreen a) => a.ImageName == CS_0024_003C_003E8__locals0.fileName).FirstOrDefault().SortOrder = num;
			num++;
		}
		Helper.SubmitChangesWithCatch(gClass);
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmVideoUploader));
		myVlcControl = new VlcControl();
		label2 = new Label();
		label20 = new Label();
		btnClose = new Button();
		btnDeleteImage = new Button();
		label10 = new Label();
		btnAddImage = new Button();
		lstViewImage = new ListView();
		pnlVideo = new Panel();
		imageContainer = new PictureBox();
		txtInterval = new RadTextBoxControl();
		btnShowKeyboard_txtInterval = new Button();
		label1 = new Label();
		label9 = new Label();
		lblHideInterval = new Label();
		btnDown = new Button();
		btnUp = new Button();
		((ISupportInitialize)myVlcControl).BeginInit();
		pnlVideo.SuspendLayout();
		((ISupportInitialize)imageContainer).BeginInit();
		((ISupportInitialize)txtInterval).BeginInit();
		SuspendLayout();
		myVlcControl.BackColor = Color.FromArgb(35, 39, 56);
		myVlcControl.Dock = DockStyle.Fill;
		myVlcControl.Location = new Point(0, 0);
		myVlcControl.Name = "myVlcControl";
		myVlcControl.Size = new Size(698, 688);
		myVlcControl.Spu = -1;
		myVlcControl.TabIndex = 1;
		myVlcControl.VlcLibDirectory = null;
		myVlcControl.VlcMediaplayerOptions = null;
		myVlcControl.VlcLibDirectoryNeeded += method_3;
		label2.BackColor = Color.FromArgb(150, 166, 166);
		label2.Font = new Font("Microsoft Sans Serif", 18f);
		label2.ForeColor = Color.White;
		label2.ImeMode = ImeMode.NoControl;
		label2.Location = new Point(324, 40);
		label2.Name = "label2";
		label2.Size = new Size(781, 35);
		label2.TabIndex = 230;
		label2.Text = "Viewer";
		label2.TextAlign = ContentAlignment.MiddleCenter;
		label20.BackColor = Color.FromArgb(150, 166, 166);
		label20.Font = new Font("Microsoft Sans Serif", 18f);
		label20.ForeColor = Color.White;
		label20.ImeMode = ImeMode.NoControl;
		label20.Location = new Point(2, 40);
		label20.Name = "label20";
		label20.Size = new Size(321, 35);
		label20.TabIndex = 229;
		label20.Text = "File List";
		label20.TextAlign = ContentAlignment.MiddleCenter;
		btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.DialogResult = DialogResult.OK;
		btnClose.FlatAppearance.BorderColor = Color.Black;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatStyle = FlatStyle.Flat;
		btnClose.Font = new Font("Microsoft Sans Serif", 12f);
		btnClose.ForeColor = Color.White;
		btnClose.ImageAlign = ContentAlignment.TopCenter;
		btnClose.ImeMode = ImeMode.NoControl;
		btnClose.Location = new Point(217, 683);
		btnClose.Name = "btnClose";
		btnClose.Padding = new Padding(0, 3, 0, 3);
		btnClose.Size = new Size(106, 80);
		btnClose.TabIndex = 228;
		btnClose.Text = "CLOSE";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		btnDeleteImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btnDeleteImage.BackColor = Color.SandyBrown;
		btnDeleteImage.DialogResult = DialogResult.OK;
		btnDeleteImage.FlatAppearance.BorderColor = Color.Black;
		btnDeleteImage.FlatAppearance.BorderSize = 0;
		btnDeleteImage.FlatStyle = FlatStyle.Flat;
		btnDeleteImage.Font = new Font("Microsoft Sans Serif", 12f);
		btnDeleteImage.ForeColor = Color.White;
		btnDeleteImage.ImageAlign = ContentAlignment.TopCenter;
		btnDeleteImage.ImeMode = ImeMode.NoControl;
		btnDeleteImage.Location = new Point(110, 683);
		btnDeleteImage.Name = "btnDeleteImage";
		btnDeleteImage.Padding = new Padding(0, 3, 0, 3);
		btnDeleteImage.Size = new Size(106, 80);
		btnDeleteImage.TabIndex = 227;
		btnDeleteImage.Text = "DELETE";
		btnDeleteImage.UseVisualStyleBackColor = false;
		btnDeleteImage.Click += btnDeleteImage_Click;
		label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Bold);
		label10.ForeColor = Color.White;
		label10.ImeMode = ImeMode.NoControl;
		label10.Location = new Point(3, 4);
		label10.MinimumSize = new Size(720, 35);
		label10.Name = "label10";
		label10.Size = new Size(1019, 35);
		label10.TabIndex = 226;
		label10.Text = "SECOND SCREEN IMAGES AND VIDEOS";
		label10.TextAlign = ContentAlignment.MiddleCenter;
		btnAddImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btnAddImage.BackColor = Color.FromArgb(80, 203, 116);
		btnAddImage.DialogResult = DialogResult.OK;
		btnAddImage.FlatAppearance.BorderColor = Color.Black;
		btnAddImage.FlatAppearance.BorderSize = 0;
		btnAddImage.FlatStyle = FlatStyle.Flat;
		btnAddImage.Font = new Font("Microsoft Sans Serif", 12f);
		btnAddImage.ForeColor = Color.White;
		btnAddImage.ImageAlign = ContentAlignment.TopCenter;
		btnAddImage.ImeMode = ImeMode.NoControl;
		btnAddImage.Location = new Point(3, 683);
		btnAddImage.Name = "btnAddImage";
		btnAddImage.Padding = new Padding(0, 3, 0, 3);
		btnAddImage.Size = new Size(106, 80);
		btnAddImage.TabIndex = 224;
		btnAddImage.Text = "ADD";
		btnAddImage.UseVisualStyleBackColor = false;
		btnAddImage.Click += btnAddImage_Click;
		lstViewImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		lstViewImage.BorderStyle = BorderStyle.None;
		lstViewImage.Font = new Font("Microsoft Sans Serif", 10.8f);
		lstViewImage.HideSelection = false;
		lstViewImage.LabelWrap = false;
		lstViewImage.Location = new Point(3, 76);
		lstViewImage.Margin = new Padding(2);
		lstViewImage.MultiSelect = false;
		lstViewImage.Name = "lstViewImage";
		lstViewImage.Size = new Size(268, 569);
		lstViewImage.TabIndex = 223;
		lstViewImage.UseCompatibleStateImageBehavior = false;
		lstViewImage.View = View.List;
		lstViewImage.SelectedIndexChanged += lstViewImage_SelectedIndexChanged;
		pnlVideo.Controls.Add(myVlcControl);
		pnlVideo.Location = new Point(324, 75);
		pnlVideo.Name = "pnlVideo";
		pnlVideo.Size = new Size(698, 688);
		pnlVideo.TabIndex = 231;
		imageContainer.ImeMode = ImeMode.NoControl;
		imageContainer.InitialImage = null;
		imageContainer.Location = new Point(324, 75);
		imageContainer.Margin = new Padding(2);
		imageContainer.Name = "imageContainer";
		imageContainer.Size = new Size(694, 568);
		imageContainer.SizeMode = PictureBoxSizeMode.Zoom;
		imageContainer.TabIndex = 105;
		imageContainer.TabStop = false;
		txtInterval.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		txtInterval.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
		txtInterval.Location = new Point(109, 647);
		txtInterval.Name = "txtInterval";
		txtInterval.RootElement.PositionOffset = new SizeF(0f, 0f);
		txtInterval.Size = new Size(105, 35);
		txtInterval.TabIndex = 273;
		txtInterval.Tag = "product";
		txtInterval.Text = "0";
		txtInterval.TextAlign = HorizontalAlignment.Center;
		txtInterval.TextChanged += txtInterval_TextChanged;
		txtInterval.Click += btnShowKeyboard_txtInterval_Click;
		((RadTextBoxControlElement)txtInterval.GetChildAt(0)).BorderWidth = 0f;
		((TextBoxViewElement)txtInterval.GetChildAt(0).GetChildAt(0)).PositionOffset = new SizeF(0f, 5f);
		btnShowKeyboard_txtInterval.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btnShowKeyboard_txtInterval.BackColor = Color.FromArgb(77, 174, 225);
		btnShowKeyboard_txtInterval.DialogResult = DialogResult.OK;
		btnShowKeyboard_txtInterval.FlatAppearance.BorderColor = Color.Black;
		btnShowKeyboard_txtInterval.FlatAppearance.BorderSize = 0;
		btnShowKeyboard_txtInterval.FlatStyle = FlatStyle.Flat;
		btnShowKeyboard_txtInterval.Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold);
		btnShowKeyboard_txtInterval.ForeColor = Color.White;
		btnShowKeyboard_txtInterval.Image = (Image)componentResourceManager.GetObject("btnShowKeyboard_txtInterval.Image");
		btnShowKeyboard_txtInterval.ImeMode = ImeMode.NoControl;
		btnShowKeyboard_txtInterval.Location = new Point(271, 647);
		btnShowKeyboard_txtInterval.MinimumSize = new Size(52, 35);
		btnShowKeyboard_txtInterval.Name = "btnShowKeyboard_txtInterval";
		btnShowKeyboard_txtInterval.Size = new Size(52, 35);
		btnShowKeyboard_txtInterval.TabIndex = 272;
		btnShowKeyboard_txtInterval.UseVisualStyleBackColor = false;
		btnShowKeyboard_txtInterval.Click += btnShowKeyboard_txtInterval_Click;
		label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label1.BackColor = Color.FromArgb(150, 166, 166);
		label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label1.ForeColor = Color.White;
		label1.ImeMode = ImeMode.NoControl;
		label1.Location = new Point(3, 647);
		label1.Name = "label1";
		label1.Size = new Size(105, 35);
		label1.TabIndex = 271;
		label1.Text = "Interval";
		label1.TextAlign = ContentAlignment.MiddleCenter;
		label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label9.BackColor = Color.White;
		label9.Font = new Font("Microsoft Sans Serif", 18f);
		label9.ForeColor = Color.Black;
		label9.ImeMode = ImeMode.NoControl;
		label9.Location = new Point(210, 647);
		label9.Name = "label9";
		label9.Size = new Size(60, 35);
		label9.TabIndex = 274;
		label9.Text = "sec";
		label9.TextAlign = ContentAlignment.TopRight;
		lblHideInterval.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lblHideInterval.BackColor = Color.FromArgb(150, 166, 166);
		lblHideInterval.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		lblHideInterval.ForeColor = Color.White;
		lblHideInterval.ImeMode = ImeMode.NoControl;
		lblHideInterval.Location = new Point(3, 646);
		lblHideInterval.Name = "lblHideInterval";
		lblHideInterval.Size = new Size(320, 36);
		lblHideInterval.TabIndex = 275;
		lblHideInterval.TextAlign = ContentAlignment.BottomCenter;
		btnDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		btnDown.BackColor = Color.FromArgb(53, 152, 220);
		btnDown.FlatAppearance.BorderColor = Color.Black;
		btnDown.FlatAppearance.BorderSize = 0;
		btnDown.FlatAppearance.MouseDownBackColor = Color.White;
		btnDown.FlatStyle = FlatStyle.Flat;
		btnDown.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnDown.ForeColor = Color.White;
		btnDown.Image = (Image)componentResourceManager.GetObject("btnDown.Image");
		btnDown.ImeMode = ImeMode.NoControl;
		btnDown.Location = new Point(272, 360);
		btnDown.Margin = new Padding(0, 0, 0, 1);
		btnDown.Name = "btnDown";
		btnDown.Size = new Size(50, 284);
		btnDown.TabIndex = 279;
		btnDown.Tag = "";
		btnDown.TextAlign = ContentAlignment.BottomCenter;
		btnDown.UseVisualStyleBackColor = false;
		btnDown.Click += btnDown_Click;
		btnUp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		btnUp.BackColor = Color.FromArgb(53, 152, 220);
		btnUp.FlatAppearance.BorderColor = Color.Black;
		btnUp.FlatAppearance.BorderSize = 0;
		btnUp.FlatAppearance.MouseDownBackColor = Color.White;
		btnUp.FlatStyle = FlatStyle.Flat;
		btnUp.Font = new Font("Microsoft Sans Serif", 8.25f);
		btnUp.ForeColor = Color.White;
		btnUp.Image = (Image)componentResourceManager.GetObject("btnUp.Image");
		btnUp.ImeMode = ImeMode.NoControl;
		btnUp.Location = new Point(272, 75);
		btnUp.Margin = new Padding(0, 0, 0, 1);
		btnUp.Name = "btnUp";
		btnUp.Size = new Size(50, 284);
		btnUp.TabIndex = 278;
		btnUp.Tag = "";
		btnUp.TextAlign = ContentAlignment.BottomCenter;
		btnUp.UseVisualStyleBackColor = false;
		btnUp.Click += btnUp_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1024, 768);
		base.Controls.Add(btnDown);
		base.Controls.Add(btnUp);
		base.Controls.Add(lblHideInterval);
		base.Controls.Add(label9);
		base.Controls.Add(txtInterval);
		base.Controls.Add(btnShowKeyboard_txtInterval);
		base.Controls.Add(label1);
		base.Controls.Add(imageContainer);
		base.Controls.Add(pnlVideo);
		base.Controls.Add(label2);
		base.Controls.Add(label20);
		base.Controls.Add(btnClose);
		base.Controls.Add(btnDeleteImage);
		base.Controls.Add(label10);
		base.Controls.Add(btnAddImage);
		base.Controls.Add(lstViewImage);
		base.Name = "frmVideoUploader";
		base.Opacity = 1.0;
		Text = "frmVideoUploader";
		base.Load += frmVideoUploader_Load;
		((ISupportInitialize)myVlcControl).EndInit();
		pnlVideo.ResumeLayout(performLayout: false);
		((ISupportInitialize)imageContainer).EndInit();
		((ISupportInitialize)txtInterval).EndInit();
		ResumeLayout(performLayout: false);
	}
}

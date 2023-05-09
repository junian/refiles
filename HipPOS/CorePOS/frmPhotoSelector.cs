using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CorePOS.Data;
using CorePOS.Properties;

namespace CorePOS;

public class frmPhotoSelector : frmMasterForm
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public OpenFileDialog openSelectedImage;

		public frmPhotoSelector _003C_003E4__this;

		public _003C_003Ec__DisplayClass6_0()
		{
			Class26.Ggkj0JxzN9YmC();
			// base._002Ector();
		}
	}

	private string string_0;

	private IContainer icontainer_1;

	private ListView lstViewImage;

	internal Button btnAddImage;

	private PictureBox imageContainer;

	private Label label10;

	internal Button btnDeleteImage;

	internal Button btnClose;

	private Label label20;

	private Label label2;

	public frmPhotoSelector(string _selectorType)
	{
		Class26.Ggkj0JxzN9YmC();
		// base._002Ector();
		InitializeComponent_1();
		string_0 = _selectorType;
	}

	private void frmPhotoSelector_Load(object sender, EventArgs e)
	{
		method_3();
	}

	private void method_3()
	{
		lstViewImage.Clear();
		foreach (ImageScreen item in new GClass6().ImageScreens.Where((ImageScreen a) => a.ImageType == string_0).ToList())
		{
			lstViewImage.Items.Add(item.ImageName);
		}
	}

	private void lstViewImage_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstViewImage.SelectedItems.Count <= 0)
		{
			return;
		}
		byte[] buffer = Convert.FromBase64String(new GClass6().ImageScreens.Where((ImageScreen a) => a.ImageName == lstViewImage.SelectedItems[0].Text).FirstOrDefault().ImageAsText);
		try
		{
			Image image;
			using (MemoryStream stream = new MemoryStream(buffer))
			{
				image = Image.FromStream(stream);
			}
			imageContainer.Image = image;
			imageContainer.SizeMode = PictureBoxSizeMode.Zoom;
		}
		catch (Exception)
		{
			imageContainer.Image = null;
			imageContainer.SizeMode = PictureBoxSizeMode.Zoom;
		}
	}

	private bool method_4(string string_1)
	{
		if (!string_1.ToLower().EndsWith(".png"))
		{
			return string_1.ToLower().EndsWith(".jpg");
		}
		return true;
	}

	private void btnAddImage_Click(object sender, EventArgs e)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0._003C_003E4__this = this;
		GClass6 gClass = new GClass6();
		CS_0024_003C_003E8__locals0.openSelectedImage = new OpenFileDialog();
		if (CS_0024_003C_003E8__locals0.openSelectedImage.ShowDialog(this) != DialogResult.OK)
		{
			return;
		}
		if (!method_4(CS_0024_003C_003E8__locals0.openSelectedImage.FileName))
		{
			new frmMessageBox(Resources.FIle_is_not_an_image, Resources.Import_error).ShowDialog();
			return;
		}
		byte[] array = File.ReadAllBytes(CS_0024_003C_003E8__locals0.openSelectedImage.FileName);
		if (array.Length > 4000000)
		{
			new frmMessageBox("File is too large. 4MB is the maximum upload. ", Resources.Import_error).ShowDialog();
			return;
		}
		string imageAsText = Convert.ToBase64String(array);
		if (gClass.ImageScreens.Where((ImageScreen a) => a.ImageName == CS_0024_003C_003E8__locals0.openSelectedImage.SafeFileName).FirstOrDefault() != null)
		{
			new frmMessageBox(Resources.Image_already_exists_Please_se).ShowDialog(this);
		}
		MemoryLoadedObjects.CheckAndLoadFormsIntoMemory.Keyboard();
		MemoryLoadedObjects.Keyboard.LoadFormData(Resources.Image_Name, 3, 256, CS_0024_003C_003E8__locals0.openSelectedImage.SafeFileName);
		if (MemoryLoadedObjects.Keyboard.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		if (string_0 == "receipt_logo")
		{
			ImageScreen imageScreen = gClass.ImageScreens.Where((ImageScreen a) => a.ImageType == string_0).FirstOrDefault();
			if (imageScreen != null)
			{
				gClass.ImageScreens.DeleteOnSubmit(imageScreen);
				Helper.SubmitChangesWithCatch(gClass);
			}
		}
		ImageScreen entity = new ImageScreen
		{
			ImageName = MemoryLoadedObjects.Keyboard.textEntered,
			ImageAsText = imageAsText,
			ImageType = string_0
		};
		gClass.ImageScreens.InsertOnSubmit(entity);
		Helper.SubmitChangesWithCatch(gClass);
		MemoryLoadedObjects.receipt_logo = gClass.ImageScreens.Where((ImageScreen a) => a.ImageType == string_0).FirstOrDefault();
		method_3();
	}

	private void btnDeleteImage_Click(object sender, EventArgs e)
	{
		if (lstViewImage.SelectedItems.Count <= 0 || new frmMessageBox(Resources.Are_you_sure_you_want_to_delet0, Resources.Delete_Image, CustomMessageBoxButtons.YesNo).ShowDialog(this) != DialogResult.Yes)
		{
			return;
		}
		GClass6 gClass = new GClass6();
		ImageScreen imageScreen = gClass.ImageScreens.Where((ImageScreen a) => a.ImageName == lstViewImage.SelectedItems[0].Text).FirstOrDefault();
		if (imageScreen != null)
		{
			gClass.ImageScreens.DeleteOnSubmit(imageScreen);
			Helper.SubmitChangesWithCatch(gClass);
			method_3();
			if (lstViewImage.Items.Count > 0)
			{
				lstViewImage.Items[0].Selected = true;
				return;
			}
			imageContainer.Image = null;
			imageContainer.SizeMode = PictureBoxSizeMode.Zoom;
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPhotoSelector));
		lstViewImage = new ListView();
		btnAddImage = new Button();
		imageContainer = new PictureBox();
		label10 = new Label();
		btnDeleteImage = new Button();
		btnClose = new Button();
		label20 = new Label();
		label2 = new Label();
		((ISupportInitialize)imageContainer).BeginInit();
		SuspendLayout();
		componentResourceManager.ApplyResources(lstViewImage, "lstViewImage");
		lstViewImage.HideSelection = false;
		lstViewImage.MultiSelect = false;
		lstViewImage.Name = "lstViewImage";
		lstViewImage.UseCompatibleStateImageBehavior = false;
		lstViewImage.View = View.List;
		lstViewImage.SelectedIndexChanged += lstViewImage_SelectedIndexChanged;
		btnAddImage.BackColor = Color.FromArgb(80, 203, 116);
		btnAddImage.DialogResult = DialogResult.OK;
		btnAddImage.FlatAppearance.BorderColor = Color.Black;
		btnAddImage.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnAddImage, "btnAddImage");
		btnAddImage.ForeColor = Color.White;
		btnAddImage.Name = "btnAddImage";
		btnAddImage.UseVisualStyleBackColor = false;
		btnAddImage.Click += btnAddImage_Click;
		imageContainer.BorderStyle = BorderStyle.FixedSingle;
		componentResourceManager.ApplyResources(imageContainer, "imageContainer");
		imageContainer.Name = "imageContainer";
		imageContainer.TabStop = false;
		componentResourceManager.ApplyResources(label10, "label10");
		label10.BackColor = Color.FromArgb(156, 89, 184);
		label10.ForeColor = Color.White;
		label10.Name = "label10";
		btnDeleteImage.BackColor = Color.SandyBrown;
		btnDeleteImage.DialogResult = DialogResult.OK;
		btnDeleteImage.FlatAppearance.BorderColor = Color.Black;
		btnDeleteImage.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnDeleteImage, "btnDeleteImage");
		btnDeleteImage.ForeColor = Color.White;
		btnDeleteImage.Name = "btnDeleteImage";
		btnDeleteImage.UseVisualStyleBackColor = false;
		btnDeleteImage.Click += btnDeleteImage_Click;
		btnClose.BackColor = Color.FromArgb(235, 107, 86);
		btnClose.DialogResult = DialogResult.OK;
		btnClose.FlatAppearance.BorderColor = Color.Black;
		btnClose.FlatAppearance.BorderSize = 0;
		componentResourceManager.ApplyResources(btnClose, "btnClose");
		btnClose.ForeColor = Color.White;
		btnClose.Name = "btnClose";
		btnClose.UseVisualStyleBackColor = false;
		btnClose.Click += btnClose_Click;
		label20.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(label20, "label20");
		label20.ForeColor = Color.White;
		label20.Name = "label20";
		label2.BackColor = Color.FromArgb(150, 166, 166);
		componentResourceManager.ApplyResources(label2, "label2");
		label2.ForeColor = Color.White;
		label2.Name = "label2";
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(35, 39, 56);
		base.ControlBox = false;
		base.Controls.Add(label2);
		base.Controls.Add(label20);
		base.Controls.Add(btnClose);
		base.Controls.Add(btnDeleteImage);
		base.Controls.Add(label10);
		base.Controls.Add(imageContainer);
		base.Controls.Add(btnAddImage);
		base.Controls.Add(lstViewImage);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmPhotoSelector";
		base.Opacity = 1.0;
		base.Load += frmPhotoSelector_Load;
		((ISupportInitialize)imageContainer).EndInit();
		ResumeLayout(performLayout: false);
	}
}

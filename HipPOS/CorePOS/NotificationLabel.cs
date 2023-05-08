using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CorePOS;

public class NotificationLabel : UserControl
{
	private string string_0;

	private Color color_0;

	private Form form_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private IContainer icontainer_0;

	private Label pfuJyNwrkq;

	private Timer timer_0;

	private Timer timer_1;

	private Timer timer_2;

	public NotificationLabel(Form parent, string message, Color notification_type, int timeToHide = 5, int animationType = 1)
	{
		Class26.Ggkj0JxzN9YmC();
		int_1 = 70;
		int_2 = 1;
		base._002Ector();
		InitializeComponent();
		if (parent != null)
		{
			string_0 = message;
			color_0 = notification_type;
			form_0 = parent;
			int_2 = animationType;
			switch (animationType)
			{
			case 1:
				int_0 = parent.Controls.Find("NotificationLabel", searchAllChildren: false).Count();
				break;
			case 2:
				base.Size = new Size(base.Size.Width, 0);
				break;
			}
			parent.Controls.Add(this);
			timer_0.Interval = timeToHide * 1000;
			BringToFront();
			Show();
		}
		else
		{
			Dispose();
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_1.Enabled = true;
	}

	private void NotificationLabel_Load(object sender, EventArgs e)
	{
		pfuJyNwrkq.Width = string_0.Length * 10 + 200;
		if (pfuJyNwrkq.Width > form_0.Width)
		{
			base.Width = form_0.Width;
			pfuJyNwrkq.Width = base.Width;
		}
		else if (pfuJyNwrkq.Width < 500)
		{
			Label label = pfuJyNwrkq;
			base.Width = 500;
			label.Width = 500;
		}
		else
		{
			base.Width = pfuJyNwrkq.Width;
		}
		pfuJyNwrkq.Location = new Point(0, 0);
		pfuJyNwrkq.Text = string_0;
		pfuJyNwrkq.BackColor = color_0;
		pfuJyNwrkq.ForeColor = Color.White;
		if (int_2 == 1)
		{
			base.Height = pfuJyNwrkq.Height;
			base.Location = new Point(form_0.Width / 2 - pfuJyNwrkq.Width / 2, -(base.Height + 20));
		}
		else if (int_2 == 2)
		{
			base.Location = new Point(form_0.Width / 2 - pfuJyNwrkq.Width / 2, int_1);
		}
		timer_2_Tick(null, null);
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (int_2 == 1)
		{
			if (base.Location.Y >= -base.Height)
			{
				base.Location = new Point(base.Location.X, base.Location.Y - 5);
			}
			else
			{
				Dispose();
			}
		}
		else if (int_2 == 2)
		{
			if (base.Size.Height >= 0)
			{
				base.Size = new Size(base.Size.Width, base.Size.Height - 5);
			}
			else
			{
				Dispose();
			}
		}
	}

	private void timer_2_Tick(object sender, EventArgs e)
	{
		if (int_2 == 1)
		{
			if (base.Location.Y >= 0 && base.Location.Y >= int_0 * base.Height + int_0 * 5)
			{
				timer_2.Enabled = false;
				timer_0.Enabled = true;
			}
			else
			{
				base.Location = new Point(base.Location.X, base.Location.Y + 5);
			}
		}
		else if (int_2 == 2)
		{
			if (base.Size.Height >= 0 && base.Size.Height > pfuJyNwrkq.Height)
			{
				timer_2.Enabled = false;
				timer_0.Enabled = true;
			}
			else
			{
				base.Size = new Size(base.Size.Width, base.Size.Height + 5);
			}
		}
	}

	private void pfuJyNwrkq_Click(object sender, EventArgs e)
	{
		timer_2.Enabled = false;
		timer_1.Enabled = true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CorePOS.NotificationLabel));
		this.pfuJyNwrkq = new System.Windows.Forms.Label();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_1 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.timer_2 = new System.Windows.Forms.Timer(this.icontainer_0);
		base.SuspendLayout();
		this.pfuJyNwrkq.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.pfuJyNwrkq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pfuJyNwrkq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		componentResourceManager.ApplyResources(this.pfuJyNwrkq, "lblMessage");
		this.pfuJyNwrkq.ForeColor = System.Drawing.Color.White;
		this.pfuJyNwrkq.Name = "lblMessage";
		this.pfuJyNwrkq.Click += new System.EventHandler(pfuJyNwrkq_Click);
		this.timer_0.Interval = 5000;
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.timer_1.Interval = 40;
		this.timer_1.Tick += new System.EventHandler(timer_1_Tick);
		this.timer_2.Enabled = true;
		this.timer_2.Interval = 40;
		this.timer_2.Tick += new System.EventHandler(timer_2_Tick);
		componentResourceManager.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Transparent;
		base.Controls.Add(this.pfuJyNwrkq);
		base.Name = "NotificationLabel";
		base.Load += new System.EventHandler(NotificationLabel_Load);
		base.ResumeLayout(false);
	}
}

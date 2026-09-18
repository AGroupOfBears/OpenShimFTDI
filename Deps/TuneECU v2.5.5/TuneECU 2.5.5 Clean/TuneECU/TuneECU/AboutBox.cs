using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TuneECU.Properties;
using TuneLibrary;

namespace TuneECU
{

internal class AboutBox : Form
{
	private const int OPACITY_STEP = 10;

	public static double mOpacity;

	private string version;

	private Rectangle mRect;

	private Pen mPen;

	private IContainer components;

	public Timer Opacitytimer;

	public CheckBox mSplash;

	private PictureBox logoPictureBox;

	private PictureBox pictureName;

	public TextBox textBoxDescription;

	public Button okButton;

	private Label author;

	public AboutBox()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		mPen = new Pen(Color.Blue, 2f);
		((Form)this)._002Ector();
		InitializeComponent();
		((TextBoxBase)textBoxDescription).AppendText(ISOMain.LangUI[ISOMain.mLang, 332] + ISOMain.LangUI[ISOMain.mLang, 333]);
		((Control)textBoxDescription).Font = IDraw.tFont;
		((Control)author).Font = IDraw.tbFont;
		((Control)okButton).Font = IDraw.tFont;
		((Control)mSplash).Font = IDraw.tFont;
		((Control)mSplash).Text = ISOMain.LangUI[ISOMain.mLang, 293];
		version = ISOMain.getVersion() + ISOMain.subVersion + Tune.getVersion();
		mRect = new Rectangle(0, 0, ((Control)this).Width, ((Control)this).Height);
	}

	private void AboutBox_Paint(object sender, PaintEventArgs e)
	{
		e.Graphics.DrawRectangle(mPen, mRect);
	}

	private void Opacitytimer_Tick(object sender, EventArgs e)
	{
		mOpacity -= 10.0;
		if (mOpacity < 100.0)
		{
			((Form)this).Opacity = mOpacity / 100.0;
		}
		if ((mOpacity == 30.0) & (Form.ActiveForm != null))
		{
			Form.ActiveForm.Opacity = 100.0;
		}
		if (mOpacity == 0.0)
		{
			Opacitytimer.Enabled = false;
			((Form)this).Close();
			if ((ISOMain.mDebug & 1) == 1)
			{
				ISOMain.WriteTrcFile(null, 0, 0, "");
			}
		}
	}

	private void pictureName_Paint(object sender, PaintEventArgs e)
	{
		SizeF sizeF = e.Graphics.MeasureString(version, IDraw.tFont);
		float num = ((float)((Control)pictureName).Width - sizeF.Width) / 2f;
		float num2 = (float)((Control)pictureName).Height - sizeF.Height + 2f;
		e.Graphics.DrawString(version, IDraw.tFont, (Brush)(object)IDraw.blackBrush, num, num2);
	}

	private void AboutBox_FormClosed(object sender, FormClosedEventArgs e)
	{
		ISOMain.showSplash = mSplash.Checked;
	}

	private void VisitLink()
	{
		Process.Start("http://www.tuneecu.com");
	}

	private void pictureName_Click(object sender, EventArgs e)
	{
		if (((Control)okButton).Visible)
		{
			try
			{
				VisitLink();
				((Form)this).Close();
			}
			catch
			{
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		((Form)this).Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_055d: Expected O, but got Unknown
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AboutBox));
		Opacitytimer = new Timer(components);
		mSplash = new CheckBox();
		logoPictureBox = new PictureBox();
		pictureName = new PictureBox();
		textBoxDescription = new TextBox();
		okButton = new Button();
		author = new Label();
		((ISupportInitialize)logoPictureBox).BeginInit();
		((ISupportInitialize)pictureName).BeginInit();
		((Control)this).SuspendLayout();
		Opacitytimer.Tick += Opacitytimer_Tick;
		((Control)mSplash).AutoSize = true;
		((Control)mSplash).Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mSplash).Location = new Point(208, 200);
		((Control)mSplash).Name = "mSplash";
		((Control)mSplash).Size = new Size(93, 17);
		((Control)mSplash).TabIndex = 6;
		((Control)mSplash).Text = "Show on start";
		((ButtonBase)mSplash).UseVisualStyleBackColor = true;
		logoPictureBox.Image = (Image)componentResourceManager.GetObject("logoPictureBox.Image");
		logoPictureBox.InitialImage = null;
		((Control)logoPictureBox).Location = new Point(10, 20);
		((Control)logoPictureBox).Name = "logoPictureBox";
		((Control)logoPictureBox).Size = new Size(180, 180);
		logoPictureBox.TabIndex = 13;
		logoPictureBox.TabStop = false;
		pictureName.Image = (Image)(object)Resources.TuneECU;
		((Control)pictureName).Location = new Point(200, 20);
		((Control)pictureName).Margin = new Padding(6, 3, 3, 3);
		((Control)pictureName).Name = "pictureName";
		((Control)pictureName).Size = new Size(274, 30);
		pictureName.TabIndex = 14;
		pictureName.TabStop = false;
		((Control)pictureName).Click += pictureName_Click;
		((Control)pictureName).Paint += new PaintEventHandler(pictureName_Paint);
		((Control)textBoxDescription).BackColor = SystemColors.Window;
		((Control)textBoxDescription).Font = new Font("Tahoma", 8.25f);
		((Control)textBoxDescription).Location = new Point(200, 56);
		((Control)textBoxDescription).Margin = new Padding(6, 4, 3, 3);
		((TextBoxBase)textBoxDescription).Multiline = true;
		((Control)textBoxDescription).Name = "textBoxDescription";
		((TextBoxBase)textBoxDescription).ReadOnly = true;
		((Control)textBoxDescription).Size = new Size(274, 128);
		((Control)textBoxDescription).TabIndex = 24;
		((Control)textBoxDescription).TabStop = false;
		textBoxDescription.TextAlign = (HorizontalAlignment)2;
		okButton.DialogResult = (DialogResult)2;
		((Control)okButton).Font = new Font("Tahoma", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)okButton).Location = new Point(388, 196);
		((Control)okButton).Name = "okButton";
		((Control)okButton).Size = new Size(75, 23);
		((Control)okButton).TabIndex = 25;
		((Control)okButton).Text = "&OK";
		((Control)author).BackColor = SystemColors.Window;
		((Control)author).Font = new Font("Tahoma", 8.25f, (FontStyle)1);
		((Control)author).ForeColor = Color.Blue;
		((Control)author).Location = new Point(222, 132);
		((Control)author).Name = "author";
		((Control)author).Size = new Size(230, 15);
		((Control)author).TabIndex = 27;
		((Control)author).Text = "© 2009-2013 Alain Fontaine";
		author.TextAlign = (ContentAlignment)2;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(492, 232);
		((Control)this).Controls.Add((Control)(object)author);
		((Control)this).Controls.Add((Control)(object)okButton);
		((Control)this).Controls.Add((Control)(object)textBoxDescription);
		((Control)this).Controls.Add((Control)(object)pictureName);
		((Control)this).Controls.Add((Control)(object)logoPictureBox);
		((Control)this).Controls.Add((Control)(object)mSplash);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).MaximizeBox = false;
		((Control)this).MaximumSize = new Size(492, 232);
		((Form)this).MinimizeBox = false;
		((Control)this).MinimumSize = new Size(492, 224);
		((Control)this).Name = "AboutBox";
		((Form)this).Opacity = 0.99;
		((Control)this).Padding = new Padding(9);
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = " TuneECU";
		((Form)this).TopMost = true;
		((Form)this).FormClosed += new FormClosedEventHandler(AboutBox_FormClosed);
		((Control)this).Paint += new PaintEventHandler(AboutBox_Paint);
		((ISupportInitialize)logoPictureBox).EndInit();
		((ISupportInitialize)pictureName).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TuneECU
{

public class Logs : Form
{
	private static IntPtr nullHandle;

	private IContainer components;

	private Label _lbLog;

	private GroupBox gbTask;

	public RichTextBox rtbLog;

	public Button closeButton;

	public Button clearButton;

	public CheckBox mShow;

	public Logs()
	{
		InitializeComponent();
	}

	public void Logs_Load(object sender, EventArgs e)
	{
		((Control)_lbLog).Text = ISOMain.LangUI[ISOMain.mLang, 89];
		((Control)clearButton).Text = ISOMain.LangUI[ISOMain.mLang, 76];
		((Control)closeButton).Text = ISOMain.LangUI[ISOMain.mLang, 77];
		((Control)mShow).Text = ISOMain.LangUI[ISOMain.mLang, 292];
		((Form)this).TopMost = mShow.Checked;
		ISOMain.logHandle = ((Control)this).Handle;
	}

	private void _lbLog_Paint(object sender, PaintEventArgs e)
	{
		IDraw.PaintLabel(sender, e, 0);
	}

	private void Button_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		Button val = (Button)sender;
		if (val == clearButton)
		{
			((TextBoxBase)rtbLog).Clear();
			ISOMain.sbLog = new StringBuilder("");
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void showLog_CheckedChanged(object sender, EventArgs e)
	{
		((Form)this).TopMost = mShow.Checked;
	}

	private void Logs_FormClosed(object sender, FormClosedEventArgs e)
	{
		ISOMain.showLog = false;
		ISOMain.LogTop = mShow.Checked;
		ISOMain.logHandle = nullHandle;
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Logs));
		_lbLog = new Label();
		gbTask = new GroupBox();
		rtbLog = new RichTextBox();
		closeButton = new Button();
		clearButton = new Button();
		mShow = new CheckBox();
		((Control)gbTask).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)_lbLog).AutoSize = true;
		((Control)_lbLog).BackColor = Color.DarkGray;
		((Control)_lbLog).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbLog).ForeColor = SystemColors.Menu;
		((Control)_lbLog).Location = new Point(11, 10);
		((Control)_lbLog).MinimumSize = new Size(480, 15);
		((Control)_lbLog).Name = "_lbLog";
		((Control)_lbLog).Size = new Size(480, 15);
		((Control)_lbLog).TabIndex = 3;
		((Control)_lbLog).Text = "Log";
		_lbLog.TextAlign = (ContentAlignment)16;
		((Control)_lbLog).Paint += new PaintEventHandler(_lbLog_Paint);
		((Control)gbTask).BackColor = SystemColors.Control;
		((Control)gbTask).Controls.Add((Control)(object)rtbLog);
		((Control)gbTask).Location = new Point(11, 22);
		((Control)gbTask).Name = "gbTask";
		((Control)gbTask).Size = new Size(480, 198);
		((Control)gbTask).TabIndex = 4;
		gbTask.TabStop = false;
		((Control)rtbLog).BackColor = SystemColors.Window;
		((TextBoxBase)rtbLog).BorderStyle = (BorderStyle)0;
		((Control)rtbLog).Font = new Font("Arial", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)rtbLog).ForeColor = SystemColors.WindowText;
		((Control)rtbLog).Location = new Point(2, 8);
		((TextBoxBase)rtbLog).MaxLength = 4096;
		((Control)rtbLog).Name = "rtbLog";
		((TextBoxBase)rtbLog).ReadOnly = true;
		rtbLog.ScrollBars = (RichTextBoxScrollBars)2;
		((Control)rtbLog).Size = new Size(476, 188);
		((Control)rtbLog).TabIndex = 2;
		((Control)rtbLog).Text = "";
		((Control)closeButton).Anchor = (AnchorStyles)10;
		((Control)closeButton).Location = new Point(400, 236);
		((Control)closeButton).Name = "closeButton";
		((Control)closeButton).Size = new Size(75, 23);
		((Control)closeButton).TabIndex = 0;
		((Control)closeButton).Text = "&Close";
		((Control)closeButton).Click += Button_Click;
		((Control)clearButton).Anchor = (AnchorStyles)10;
		((Control)clearButton).Location = new Point(292, 236);
		((Control)clearButton).Name = "clearButton";
		((Control)clearButton).Size = new Size(75, 23);
		((Control)clearButton).TabIndex = 1;
		((Control)clearButton).Text = "Cl&ear";
		((Control)clearButton).Click += Button_Click;
		((Control)mShow).AutoSize = true;
		((Control)mShow).Location = new Point(26, 238);
		((Control)mShow).Name = "mShow";
		((Control)mShow).Size = new Size(87, 17);
		((Control)mShow).TabIndex = 5;
		((Control)mShow).Text = "Always show";
		((ButtonBase)mShow).UseVisualStyleBackColor = true;
		mShow.CheckedChanged += showLog_CheckedChanged;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(502, 278);
		((Control)this).Controls.Add((Control)(object)mShow);
		((Control)this).Controls.Add((Control)(object)clearButton);
		((Control)this).Controls.Add((Control)(object)closeButton);
		((Control)this).Controls.Add((Control)(object)_lbLog);
		((Control)this).Controls.Add((Control)(object)gbTask);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).MaximumSize = new Size(508, 302);
		((Control)this).MinimumSize = new Size(508, 302);
		((Control)this).Name = "Logs";
		((Control)this).Text = " TuneECU";
		((Form)this).Load += Logs_Load;
		((Form)this).FormClosed += new FormClosedEventHandler(Logs_FormClosed);
		((Control)gbTask).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TuneECU.Controls;

namespace TuneECU
{

public class mOpenFileDialog : OpenFileDialogEx
{
	private IContainer components;

	private GroupBox gbInfos;

	public RichTextBox rtbInfos;

	public Label _lbInfos;

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		_lbInfos = new Label();
		gbInfos = new GroupBox();
		rtbInfos = new RichTextBox();
		((Control)gbInfos).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)_lbInfos).Anchor = (AnchorStyles)13;
		((Control)_lbInfos).BackColor = Color.DarkGray;
		((Control)_lbInfos).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbInfos).ForeColor = SystemColors.Menu;
		((Control)_lbInfos).Location = new Point(6, 4);
		((Control)_lbInfos).MinimumSize = new Size(48, 15);
		((Control)_lbInfos).Name = "_lbInfos";
		((Control)_lbInfos).Size = new Size(224, 15);
		((Control)_lbInfos).TabIndex = 4;
		((Control)_lbInfos).Text = "Informations";
		_lbInfos.TextAlign = (ContentAlignment)16;
		((Control)_lbInfos).Paint += new PaintEventHandler(_lbInfos_Paint);
		((Control)gbInfos).Anchor = (AnchorStyles)13;
		((Control)gbInfos).Controls.Add((Control)(object)rtbInfos);
		((Control)gbInfos).Location = new Point(6, 16);
		((Control)gbInfos).Name = "gbInfos";
		((Control)gbInfos).Size = new Size(224, 108);
		((Control)gbInfos).TabIndex = 5;
		gbInfos.TabStop = false;
		((Control)rtbInfos).Anchor = (AnchorStyles)13;
		((Control)rtbInfos).BackColor = SystemColors.Window;
		((TextBoxBase)rtbInfos).BorderStyle = (BorderStyle)0;
		((Control)rtbInfos).Font = new Font("Arial", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)rtbInfos).ForeColor = SystemColors.WindowText;
		((Control)rtbInfos).Location = new Point(2, 8);
		((TextBoxBase)rtbInfos).MaxLength = 2000;
		((Control)rtbInfos).Name = "rtbInfos";
		((TextBoxBase)rtbInfos).ReadOnly = true;
		rtbInfos.ScrollBars = (RichTextBoxScrollBars)2;
		((Control)rtbInfos).Size = new Size(220, 98);
		((Control)rtbInfos).TabIndex = 2;
		((Control)rtbInfos).Text = "";
		((Control)this).Controls.Add((Control)(object)_lbInfos);
		((Control)this).Controls.Add((Control)(object)gbInfos);
		((Control)this).Name = "mOpenFileDialog";
		((Control)this).Size = new Size(237, 142);
		((Control)gbInfos).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	public mOpenFileDialog()
	{
		InitializeComponent();
		((Control)_lbInfos).Text = ISOMain.LangUI[ISOMain.mLang, (ISOMain.typInfo == 0) ? 88 : 90];
	}

	public override void OnFileNameChanged(string filePath)
	{
		try
		{
			string text = ISOMain.ReadInfo(filePath);
			int num = text.IndexOf("|");
			int num2 = text.IndexOf(":");
			((Control)rtbInfos).Text = text.Substring(num2 + 1);
			if ((num > 0) & (num2 > num))
			{
				((Control)_lbInfos).Text = ISOMain.LangUI[ISOMain.mLang, 67] + text.Substring(0, num) + "  (" + text.Substring(num + 1, num2 - num - 1) + ")";
			}
			else if (num2 > 0)
			{
				((Control)_lbInfos).Text = ISOMain.LangUI[ISOMain.mLang, 67] + text.Substring(0, num2);
			}
		}
		catch (Exception)
		{
		}
	}

	public override void OnFolderNameChanged(string folderName)
	{
		((Control)_lbInfos).Text = ISOMain.LangUI[ISOMain.mLang, (ISOMain.typInfo == 0) ? 88 : 90];
		((TextBoxBase)rtbInfos).Clear();
	}

	public override void OnClosingDialog()
	{
	}

	private void _lbInfos_Paint(object sender, PaintEventArgs e)
	{
		IDraw.PaintLabel(sender, e, 0);
	}
}
}

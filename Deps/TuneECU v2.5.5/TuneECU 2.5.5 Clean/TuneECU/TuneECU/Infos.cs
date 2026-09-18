using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TuneECU
{

public class Infos : Form
{
	private IContainer components;

	private GroupBox gbInfos;

	public RichTextBox rtbInfos;

	private ToolStripMenuItem copyNoteSubMenu;

	private ToolStripMenuItem pasteNoteSubMenu;

	private ToolStripMenuItem suppNoteSubMenu;

	private ToolStripSeparator noteSeparatorS;

	private ToolStripMenuItem undoNoteSubMenu;

	public Button okButton;

	public Button AbortButton;

	private ContextMenuStrip cNotesMenu;

	private ToolStripMenuItem cutNoteSubMenu;

	private Label _lbInfos;

	public CheckBox mShow;

	private static IntPtr nullHandle;

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
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
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
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Expected O, but got Unknown
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c5: Expected O, but got Unknown
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_0830: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Infos));
		gbInfos = new GroupBox();
		rtbInfos = new RichTextBox();
		cNotesMenu = new ContextMenuStrip(components);
		cutNoteSubMenu = new ToolStripMenuItem();
		copyNoteSubMenu = new ToolStripMenuItem();
		pasteNoteSubMenu = new ToolStripMenuItem();
		suppNoteSubMenu = new ToolStripMenuItem();
		noteSeparatorS = new ToolStripSeparator();
		undoNoteSubMenu = new ToolStripMenuItem();
		okButton = new Button();
		AbortButton = new Button();
		_lbInfos = new Label();
		mShow = new CheckBox();
		((Control)gbInfos).SuspendLayout();
		((Control)cNotesMenu).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)gbInfos).Controls.Add((Control)(object)rtbInfos);
		((Control)gbInfos).Location = new Point(11, 22);
		((Control)gbInfos).Name = "gbInfos";
		((Control)gbInfos).Size = new Size(480, 198);
		((Control)gbInfos).TabIndex = 4;
		gbInfos.TabStop = false;
		((Control)rtbInfos).BackColor = SystemColors.Window;
		((TextBoxBase)rtbInfos).BorderStyle = (BorderStyle)0;
		((Control)rtbInfos).ContextMenuStrip = cNotesMenu;
		((Control)rtbInfos).Font = new Font("Arial", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)rtbInfos).ForeColor = SystemColors.WindowText;
		((Control)rtbInfos).Location = new Point(2, 8);
		((TextBoxBase)rtbInfos).MaxLength = 2000;
		((Control)rtbInfos).Name = "rtbInfos";
		rtbInfos.ScrollBars = (RichTextBoxScrollBars)2;
		((Control)rtbInfos).Size = new Size(476, 188);
		((Control)rtbInfos).TabIndex = 2;
		((Control)rtbInfos).Text = "";
		((Control)rtbInfos).TextChanged += rtbInfos_TextChanged;
		((ToolStrip)cNotesMenu).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[6]
		{
			(ToolStripItem)cutNoteSubMenu,
			(ToolStripItem)copyNoteSubMenu,
			(ToolStripItem)pasteNoteSubMenu,
			(ToolStripItem)suppNoteSubMenu,
			(ToolStripItem)noteSeparatorS,
			(ToolStripItem)undoNoteSubMenu
		});
		((Control)cNotesMenu).Name = "cNotesMenu";
		((Control)cNotesMenu).Size = new Size(117, 120);
		((ToolStripDropDown)cNotesMenu).Opening += cNotesMenu_Opening;
		((ToolStripItem)cutNoteSubMenu).Enabled = false;
		((ToolStripItem)cutNoteSubMenu).Name = "cutNoteSubMenu";
		((ToolStripItem)cutNoteSubMenu).Size = new Size(116, 22);
		((ToolStripItem)cutNoteSubMenu).Tag = 1;
		((ToolStripItem)cutNoteSubMenu).Text = "Cut";
		((ToolStripItem)cutNoteSubMenu).Click += cutNoteSubMenu_Click;
		((ToolStripItem)copyNoteSubMenu).Enabled = false;
		((ToolStripItem)copyNoteSubMenu).Name = "copyNoteSubMenu";
		((ToolStripItem)copyNoteSubMenu).Size = new Size(116, 22);
		((ToolStripItem)copyNoteSubMenu).Tag = 2;
		((ToolStripItem)copyNoteSubMenu).Text = "Copy";
		((ToolStripItem)copyNoteSubMenu).Click += copyNoteSubMenu_Click;
		((ToolStripItem)pasteNoteSubMenu).Enabled = false;
		((ToolStripItem)pasteNoteSubMenu).Name = "pasteNoteSubMenu";
		((ToolStripItem)pasteNoteSubMenu).Size = new Size(116, 22);
		((ToolStripItem)pasteNoteSubMenu).Tag = 3;
		((ToolStripItem)pasteNoteSubMenu).Text = "Paste";
		((ToolStripItem)pasteNoteSubMenu).Click += pasteNoteSubMenu_Click;
		((ToolStripItem)suppNoteSubMenu).Enabled = false;
		((ToolStripItem)suppNoteSubMenu).Name = "suppNoteSubMenu";
		((ToolStripItem)suppNoteSubMenu).Size = new Size(116, 22);
		((ToolStripItem)suppNoteSubMenu).Tag = 4;
		((ToolStripItem)suppNoteSubMenu).Text = "Delete";
		((ToolStripItem)suppNoteSubMenu).Click += suppNoteSubMenu_Click;
		((ToolStripItem)noteSeparatorS).Name = "noteSeparatorS";
		((ToolStripItem)noteSeparatorS).Size = new Size(113, 6);
		((ToolStripItem)undoNoteSubMenu).Name = "undoNoteSubMenu";
		((ToolStripItem)undoNoteSubMenu).Size = new Size(116, 22);
		((ToolStripItem)undoNoteSubMenu).Tag = 5;
		((ToolStripItem)undoNoteSubMenu).Text = "Undo";
		((ToolStripItem)undoNoteSubMenu).Click += undoNoteSubMenu_Click;
		((Control)okButton).Anchor = (AnchorStyles)10;
		((Control)okButton).Location = new Point(292, 236);
		((Control)okButton).Name = "okButton";
		((Control)okButton).Size = new Size(75, 23);
		((Control)okButton).TabIndex = 0;
		((Control)okButton).Text = "&OK";
		((Control)okButton).Click += InfosClose_Click;
		((Control)AbortButton).Anchor = (AnchorStyles)10;
		((Control)AbortButton).Location = new Point(400, 236);
		((Control)AbortButton).Name = "AbortButton";
		((Control)AbortButton).Size = new Size(75, 23);
		((Control)AbortButton).TabIndex = 1;
		((Control)AbortButton).Text = "&Cancel";
		((Control)AbortButton).Click += InfosClose_Click;
		((Control)_lbInfos).AutoSize = true;
		((Control)_lbInfos).BackColor = Color.DarkGray;
		((Control)_lbInfos).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbInfos).ForeColor = SystemColors.Menu;
		((Control)_lbInfos).Location = new Point(11, 10);
		((Control)_lbInfos).MinimumSize = new Size(480, 15);
		((Control)_lbInfos).Name = "_lbInfos";
		((Control)_lbInfos).Size = new Size(480, 15);
		((Control)_lbInfos).TabIndex = 3;
		((Control)_lbInfos).Text = "Informations";
		_lbInfos.TextAlign = (ContentAlignment)16;
		((Control)_lbInfos).Paint += new PaintEventHandler(_lbInfos_Paint);
		((Control)mShow).AutoSize = true;
		((Control)mShow).Location = new Point(26, 238);
		((Control)mShow).Name = "mShow";
		((Control)mShow).Size = new Size(87, 17);
		((Control)mShow).TabIndex = 6;
		((Control)mShow).Text = "Always show";
		((ButtonBase)mShow).UseVisualStyleBackColor = true;
		mShow.CheckedChanged += showLog_CheckedChanged;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(502, 278);
		((Control)this).Controls.Add((Control)(object)mShow);
		((Control)this).Controls.Add((Control)(object)_lbInfos);
		((Control)this).Controls.Add((Control)(object)AbortButton);
		((Control)this).Controls.Add((Control)(object)okButton);
		((Control)this).Controls.Add((Control)(object)gbInfos);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Control)this).MaximumSize = new Size(508, 302);
		((Control)this).MinimumSize = new Size(508, 302);
		((Control)this).Name = "Infos";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = " TuneECU";
		((Form)this).Load += Infos_Load;
		((Form)this).FormClosed += new FormClosedEventHandler(Infos_FormClosed);
		((Control)gbInfos).ResumeLayout(false);
		((Control)cNotesMenu).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public Infos()
	{
		InitializeComponent();
	}

	public void Infos_Load(object sender, EventArgs e)
	{
		((Control)_lbInfos).Text = ISOMain.LangUI[ISOMain.mLang, 88];
		((ToolStripItem)cutNoteSubMenu).Text = ISOMain.LangUI[ISOMain.mLang, 36];
		((ToolStripItem)copyNoteSubMenu).Text = ISOMain.LangUI[ISOMain.mLang, 37];
		((ToolStripItem)pasteNoteSubMenu).Text = ISOMain.LangUI[ISOMain.mLang, 38];
		((ToolStripItem)suppNoteSubMenu).Text = ISOMain.LangUI[ISOMain.mLang, 39];
		((ToolStripItem)undoNoteSubMenu).Text = ISOMain.LangUI[ISOMain.mLang, 40];
		((Control)AbortButton).Text = ISOMain.LangUI[ISOMain.mLang, 74];
		((Control)okButton).Text = ISOMain.LangUI[ISOMain.mLang, 75];
		((Control)mShow).Text = ISOMain.LangUI[ISOMain.mLang, 292];
		((Form)this).TopMost = mShow.Checked;
		ISOMain.infoHandle = ((Control)this).Handle;
	}

	private void _lbInfos_Paint(object sender, PaintEventArgs e)
	{
		IDraw.PaintLabel(sender, e, 0);
	}

	private void cNotesMenu_Opening(object sender, CancelEventArgs e)
	{
		((ToolStripItem)cutNoteSubMenu).Enabled = !((TextBoxBase)rtbInfos).ReadOnly & (((TextBoxBase)rtbInfos).SelectionLength > 0);
		((ToolStripItem)copyNoteSubMenu).Enabled = ((TextBoxBase)rtbInfos).SelectionLength > 0;
		((ToolStripItem)pasteNoteSubMenu).Enabled = !((TextBoxBase)rtbInfos).ReadOnly & ISOMain.clipData.GetDataPresent(DataFormats.Text);
		((ToolStripItem)suppNoteSubMenu).Enabled = !((TextBoxBase)rtbInfos).ReadOnly & (((TextBoxBase)rtbInfos).SelectionLength > 0);
		((ToolStripItem)undoNoteSubMenu).Enabled = !((TextBoxBase)rtbInfos).ReadOnly & ((TextBoxBase)rtbInfos).CanUndo;
	}

	private void cutNoteSubMenu_Click(object sender, EventArgs e)
	{
		((TextBoxBase)rtbInfos).Cut();
	}

	private void copyNoteSubMenu_Click(object sender, EventArgs e)
	{
		((TextBoxBase)rtbInfos).Copy();
	}

	private void pasteNoteSubMenu_Click(object sender, EventArgs e)
	{
		((TextBoxBase)rtbInfos).Paste();
	}

	private void suppNoteSubMenu_Click(object sender, EventArgs e)
	{
		int selectionStart = ((TextBoxBase)rtbInfos).SelectionStart;
		int selectionLength = ((TextBoxBase)rtbInfos).SelectionLength;
		((Control)rtbInfos).Text = ((Control)rtbInfos).Text.Remove(selectionStart, selectionLength);
	}

	private void undoNoteSubMenu_Click(object sender, EventArgs e)
	{
		((TextBoxBase)rtbInfos).Undo();
	}

	private void rtbInfos_TextChanged(object sender, EventArgs e)
	{
		ISOMain.infoMod = true;
	}

	private void showLog_CheckedChanged(object sender, EventArgs e)
	{
		((Form)this).TopMost = mShow.Checked;
	}

	private void InfosClose_Click(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		Button val = (Button)sender;
		if (val == okButton)
		{
			ISOMain.descMap = ((Control)rtbInfos).Text;
		}
		((Form)this).Close();
	}

	private void Infos_FormClosed(object sender, FormClosedEventArgs e)
	{
		ISOMain.showInfo = false;
		ISOMain.InfoTop = mShow.Checked;
		ISOMain.infoHandle = nullHandle;
	}
}
}

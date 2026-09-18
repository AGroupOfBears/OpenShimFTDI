using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace TuneECU;

public class QueryForm : Form
{
	private IContainer components;

	public Button abortButton;

	public Button okButton;

	private GroupBox MapBox;

	public RadioButton radioMap2;

	public RadioButton radioMap1;

	public GroupBox writeBox;

	public Label rLabel;

	public Label sLabel;

	public Label tLabel;

	public Label _lbMap;

	private Panel shifterPanel;

	private GroupBox lowBox;

	private Label _msLow;

	private Label _lbLow;

	private NumericUpDown lowUpDown;

	private NumericUpDown mhUpDown;

	private NumericUpDown lmUpDown;

	private GroupBox midBox;

	private Label _msMid;

	private Label _lbMid;

	private NumericUpDown midUpDown;

	private GroupBox highBox;

	private Label _msHigh;

	private Label _lbHigh;

	private NumericUpDown highUpDown;

	private Label lowLabel;

	private Label midLabel;

	private Label highLabel;

	private Label lmLabel;

	private Label mhLabel;

	private Label _Gear;

	private RadioButton rbGear3;

	private RadioButton rbGear2;

	private RadioButton rbGear1;

	private RadioButton rbGear4;

	private Panel panelGear;

	private RadioButton rbGear6;

	private RadioButton rbGear5;

	private int cLabel;

	public static int boxMode;

	public static int boxValue;

	public static int pGear;

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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
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
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Expected O, but got Unknown
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected O, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Expected O, but got Unknown
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Expected O, but got Unknown
		//IL_069b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Expected O, but got Unknown
		//IL_0921: Unknown result type (might be due to invalid IL or missing references)
		//IL_092b: Expected O, but got Unknown
		//IL_0c22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2c: Expected O, but got Unknown
		//IL_0c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca5: Expected O, but got Unknown
		//IL_0d14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1e: Expected O, but got Unknown
		//IL_0e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e89: Expected O, but got Unknown
		//IL_0f11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1b: Expected O, but got Unknown
		//IL_0fab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb5: Expected O, but got Unknown
		//IL_10da: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e4: Expected O, but got Unknown
		//IL_12b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c2: Expected O, but got Unknown
		//IL_1329: Unknown result type (might be due to invalid IL or missing references)
		//IL_1333: Expected O, but got Unknown
		//IL_13ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b7: Expected O, but got Unknown
		//IL_1446: Unknown result type (might be due to invalid IL or missing references)
		//IL_1450: Expected O, but got Unknown
		//IL_15dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e6: Expected O, but got Unknown
		//IL_164d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1657: Expected O, but got Unknown
		//IL_16d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_16db: Expected O, but got Unknown
		//IL_176a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1774: Expected O, but got Unknown
		//IL_1900: Unknown result type (might be due to invalid IL or missing references)
		//IL_190a: Expected O, but got Unknown
		//IL_1971: Unknown result type (might be due to invalid IL or missing references)
		//IL_197b: Expected O, but got Unknown
		//IL_19f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ff: Expected O, but got Unknown
		//IL_1a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a98: Expected O, but got Unknown
		abortButton = new Button();
		okButton = new Button();
		MapBox = new GroupBox();
		radioMap2 = new RadioButton();
		radioMap1 = new RadioButton();
		_lbMap = new Label();
		writeBox = new GroupBox();
		panelGear = new Panel();
		rbGear6 = new RadioButton();
		rbGear5 = new RadioButton();
		_Gear = new Label();
		rbGear4 = new RadioButton();
		rbGear1 = new RadioButton();
		rbGear3 = new RadioButton();
		rbGear2 = new RadioButton();
		tLabel = new Label();
		sLabel = new Label();
		rLabel = new Label();
		shifterPanel = new Panel();
		mhLabel = new Label();
		lmLabel = new Label();
		mhUpDown = new NumericUpDown();
		lmUpDown = new NumericUpDown();
		lowBox = new GroupBox();
		lowLabel = new Label();
		_msLow = new Label();
		_lbLow = new Label();
		lowUpDown = new NumericUpDown();
		midBox = new GroupBox();
		midLabel = new Label();
		_msMid = new Label();
		_lbMid = new Label();
		midUpDown = new NumericUpDown();
		highBox = new GroupBox();
		highLabel = new Label();
		_msHigh = new Label();
		_lbHigh = new Label();
		highUpDown = new NumericUpDown();
		((Control)MapBox).SuspendLayout();
		((Control)writeBox).SuspendLayout();
		((Control)panelGear).SuspendLayout();
		((Control)shifterPanel).SuspendLayout();
		((ISupportInitialize)mhUpDown).BeginInit();
		((ISupportInitialize)lmUpDown).BeginInit();
		((Control)lowBox).SuspendLayout();
		((ISupportInitialize)lowUpDown).BeginInit();
		((Control)midBox).SuspendLayout();
		((ISupportInitialize)midUpDown).BeginInit();
		((Control)highBox).SuspendLayout();
		((ISupportInitialize)highUpDown).BeginInit();
		((Control)this).SuspendLayout();
		((Control)abortButton).Anchor = (AnchorStyles)10;
		abortButton.DialogResult = (DialogResult)2;
		((Control)abortButton).Location = new Point(260, 120);
		((Control)abortButton).Name = "abortButton";
		((Control)abortButton).Size = new Size(75, 23);
		((Control)abortButton).TabIndex = 2;
		((Control)abortButton).Text = "&Cancel";
		((Control)abortButton).Visible = false;
		((Control)okButton).Anchor = (AnchorStyles)10;
		okButton.DialogResult = (DialogResult)1;
		((Control)okButton).Location = new Point(152, 120);
		((Control)okButton).Name = "okButton";
		((Control)okButton).Size = new Size(75, 23);
		((Control)okButton).TabIndex = 3;
		((Control)okButton).Text = "&Ok";
		((Control)okButton).Click += okButton_Click;
		((Control)MapBox).Anchor = (AnchorStyles)13;
		((Control)MapBox).Controls.Add((Control)(object)radioMap2);
		((Control)MapBox).Controls.Add((Control)(object)radioMap1);
		((Control)MapBox).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)MapBox).Location = new Point(11, 22);
		((Control)MapBox).Name = "MapBox";
		((Control)MapBox).Size = new Size(340, 86);
		((Control)MapBox).TabIndex = 4;
		MapBox.TabStop = false;
		((Control)MapBox).Visible = false;
		((Control)radioMap2).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)radioMap2).Location = new Point(12, 34);
		((Control)radioMap2).Name = "radioMap2";
		((Control)radioMap2).Size = new Size(305, 24);
		((Control)radioMap2).TabIndex = 1;
		((ButtonBase)radioMap2).UseVisualStyleBackColor = true;
		((Control)radioMap2).Visible = false;
		radioMap1.Checked = true;
		((Control)radioMap1).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)radioMap1).Location = new Point(12, 10);
		((Control)radioMap1).Name = "radioMap1";
		((Control)radioMap1).Size = new Size(305, 24);
		((Control)radioMap1).TabIndex = 0;
		radioMap1.TabStop = true;
		((ButtonBase)radioMap1).UseVisualStyleBackColor = true;
		((Control)_lbMap).Anchor = (AnchorStyles)13;
		((Control)_lbMap).BackColor = Color.DarkGray;
		((Control)_lbMap).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbMap).ForeColor = SystemColors.Menu;
		((Control)_lbMap).Location = new Point(11, 10);
		((Control)_lbMap).Name = "_lbMap";
		((Control)_lbMap).Size = new Size(340, 15);
		((Control)_lbMap).TabIndex = 5;
		((Control)_lbMap).Text = "Map";
		_lbMap.TextAlign = (ContentAlignment)16;
		((Control)_lbMap).Paint += new PaintEventHandler(_lbMap_Paint);
		((Control)writeBox).Anchor = (AnchorStyles)15;
		((Control)writeBox).Controls.Add((Control)(object)panelGear);
		((Control)writeBox).Controls.Add((Control)(object)tLabel);
		((Control)writeBox).Controls.Add((Control)(object)sLabel);
		((Control)writeBox).Controls.Add((Control)(object)rLabel);
		((Control)writeBox).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)writeBox).Location = new Point(11, 22);
		((Control)writeBox).Name = "writeBox";
		((Control)writeBox).Size = new Size(340, 86);
		((Control)writeBox).TabIndex = 6;
		writeBox.TabStop = false;
		((Control)writeBox).Visible = false;
		((Control)writeBox).Paint += new PaintEventHandler(writeBox_Paint);
		((Control)panelGear).Anchor = (AnchorStyles)10;
		((Control)panelGear).Controls.Add((Control)(object)rbGear6);
		((Control)panelGear).Controls.Add((Control)(object)rbGear5);
		((Control)panelGear).Controls.Add((Control)(object)_Gear);
		((Control)panelGear).Controls.Add((Control)(object)rbGear4);
		((Control)panelGear).Controls.Add((Control)(object)rbGear1);
		((Control)panelGear).Controls.Add((Control)(object)rbGear3);
		((Control)panelGear).Controls.Add((Control)(object)rbGear2);
		((Control)panelGear).Location = new Point(40, 60);
		((Control)panelGear).Name = "panelGear";
		((Control)panelGear).Size = new Size(284, 24);
		((Control)panelGear).TabIndex = 9;
		((Control)panelGear).Visible = false;
		((Control)rbGear6).AutoSize = true;
		((Control)rbGear6).Enabled = false;
		((Control)rbGear6).Location = new Point(250, 2);
		((Control)rbGear6).Name = "rbGear6";
		((Control)rbGear6).Size = new Size(31, 17);
		((Control)rbGear6).TabIndex = 10;
		((Control)rbGear6).Tag = 5;
		((Control)rbGear6).Text = "6";
		((ButtonBase)rbGear6).UseVisualStyleBackColor = true;
		rbGear6.CheckedChanged += rbGear_CheckedChanged;
		((Control)rbGear5).AutoSize = true;
		((Control)rbGear5).Enabled = false;
		((Control)rbGear5).Location = new Point(210, 2);
		((Control)rbGear5).Name = "rbGear5";
		((Control)rbGear5).Size = new Size(31, 17);
		((Control)rbGear5).TabIndex = 9;
		((Control)rbGear5).Tag = 4;
		((Control)rbGear5).Text = "5";
		((ButtonBase)rbGear5).UseVisualStyleBackColor = true;
		rbGear5.CheckedChanged += rbGear_CheckedChanged;
		((Control)_Gear).AutoSize = true;
		((Control)_Gear).BackColor = Color.Silver;
		_Gear.BorderStyle = (BorderStyle)1;
		((Control)_Gear).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_Gear).ForeColor = SystemColors.ControlText;
		((Control)_Gear).Location = new Point(2, 3);
		((Control)_Gear).Name = "_Gear";
		((Control)_Gear).Size = new Size(36, 15);
		((Control)_Gear).TabIndex = 4;
		((Control)_Gear).Text = "Gear";
		((Control)rbGear4).AutoSize = true;
		((Control)rbGear4).Enabled = false;
		((Control)rbGear4).Location = new Point(170, 2);
		((Control)rbGear4).Name = "rbGear4";
		((Control)rbGear4).Size = new Size(31, 17);
		((Control)rbGear4).TabIndex = 8;
		((Control)rbGear4).Tag = 3;
		((Control)rbGear4).Text = "4";
		((ButtonBase)rbGear4).UseVisualStyleBackColor = true;
		rbGear4.CheckedChanged += rbGear_CheckedChanged;
		((Control)rbGear1).AutoSize = true;
		rbGear1.Checked = true;
		((Control)rbGear1).Location = new Point(50, 2);
		((Control)rbGear1).Name = "rbGear1";
		((Control)rbGear1).Size = new Size(31, 17);
		((Control)rbGear1).TabIndex = 5;
		rbGear1.TabStop = true;
		((Control)rbGear1).Tag = 0;
		((Control)rbGear1).Text = "1";
		((ButtonBase)rbGear1).UseVisualStyleBackColor = true;
		rbGear1.CheckedChanged += rbGear_CheckedChanged;
		((Control)rbGear3).AutoSize = true;
		((Control)rbGear3).Location = new Point(130, 2);
		((Control)rbGear3).Name = "rbGear3";
		((Control)rbGear3).Size = new Size(31, 17);
		((Control)rbGear3).TabIndex = 7;
		((Control)rbGear3).Tag = 2;
		((Control)rbGear3).Text = "3";
		((ButtonBase)rbGear3).UseVisualStyleBackColor = true;
		rbGear3.CheckedChanged += rbGear_CheckedChanged;
		((Control)rbGear2).AutoSize = true;
		((Control)rbGear2).Location = new Point(90, 2);
		((Control)rbGear2).Name = "rbGear2";
		((Control)rbGear2).Size = new Size(31, 17);
		((Control)rbGear2).TabIndex = 6;
		((Control)rbGear2).Tag = 1;
		((Control)rbGear2).Text = "2";
		((ButtonBase)rbGear2).UseVisualStyleBackColor = true;
		rbGear2.CheckedChanged += rbGear_CheckedChanged;
		((Control)tLabel).AutoSize = true;
		((Control)tLabel).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)tLabel).Location = new Point(60, 53);
		((Control)tLabel).Name = "tLabel";
		((Control)tLabel).Size = new Size(0, 13);
		((Control)tLabel).TabIndex = 3;
		tLabel.TextAlign = (ContentAlignment)32;
		((Control)sLabel).AutoSize = true;
		((Control)sLabel).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)sLabel).Location = new Point(60, 35);
		((Control)sLabel).Name = "sLabel";
		((Control)sLabel).Size = new Size(0, 13);
		((Control)sLabel).TabIndex = 1;
		sLabel.TextAlign = (ContentAlignment)32;
		((Control)rLabel).AutoSize = true;
		((Control)rLabel).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)rLabel).Location = new Point(60, 17);
		((Control)rLabel).Name = "rLabel";
		((Control)rLabel).Size = new Size(0, 13);
		((Control)rLabel).TabIndex = 0;
		rLabel.TextAlign = (ContentAlignment)32;
		((Control)shifterPanel).Controls.Add((Control)(object)mhLabel);
		((Control)shifterPanel).Controls.Add((Control)(object)lmLabel);
		((Control)shifterPanel).Controls.Add((Control)(object)mhUpDown);
		((Control)shifterPanel).Controls.Add((Control)(object)lmUpDown);
		((Control)shifterPanel).Controls.Add((Control)(object)lowBox);
		((Control)shifterPanel).Controls.Add((Control)(object)midBox);
		((Control)shifterPanel).Controls.Add((Control)(object)highBox);
		((Control)shifterPanel).Location = new Point(11, 26);
		((Control)shifterPanel).Name = "shifterPanel";
		((Control)shifterPanel).Size = new Size(340, 88);
		((Control)shifterPanel).TabIndex = 9;
		((Control)shifterPanel).Visible = false;
		((Control)mhLabel).BackColor = SystemColors.Window;
		((Control)mhLabel).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)mhLabel).ForeColor = SystemColors.ControlDark;
		((Control)mhLabel).Location = new Point(141, 49);
		((Control)mhLabel).Name = "mhLabel";
		((Control)mhLabel).Size = new Size(59, 17);
		((Control)mhLabel).TabIndex = 18;
		mhLabel.TextAlign = (ContentAlignment)64;
		((Control)lmLabel).BackColor = SystemColors.Window;
		((Control)lmLabel).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lmLabel).ForeColor = SystemColors.ControlDark;
		((Control)lmLabel).Location = new Point(141, 18);
		((Control)lmLabel).Name = "lmLabel";
		((Control)lmLabel).Size = new Size(59, 17);
		((Control)lmLabel).TabIndex = 17;
		lmLabel.TextAlign = (ContentAlignment)64;
		((UpDownBase)mhUpDown).BorderStyle = (BorderStyle)0;
		((Control)mhUpDown).Enabled = false;
		((Control)mhUpDown).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		mhUpDown.Increment = new decimal(new int[4] { 100, 0, 0, 0 });
		((Control)mhUpDown).Location = new Point(140, 49);
		mhUpDown.Maximum = new decimal(new int[4] { 16000, 0, 0, 0 });
		mhUpDown.Minimum = new decimal(new int[4] { 2500, 0, 0, 0 });
		((Control)mhUpDown).Name = "mhUpDown";
		((Control)mhUpDown).Size = new Size(75, 17);
		((Control)mhUpDown).TabIndex = 11;
		((Control)mhUpDown).Tag = 11;
		((UpDownBase)mhUpDown).TextAlign = (HorizontalAlignment)1;
		mhUpDown.Value = new decimal(new int[4] { 2500, 0, 0, 0 });
		mhUpDown.ValueChanged += UpDown_ValueChanged;
		((UpDownBase)lmUpDown).BorderStyle = (BorderStyle)0;
		((Control)lmUpDown).Enabled = false;
		((Control)lmUpDown).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		lmUpDown.Increment = new decimal(new int[4] { 100, 0, 0, 0 });
		((Control)lmUpDown).Location = new Point(140, 18);
		lmUpDown.Maximum = new decimal(new int[4] { 16000, 0, 0, 0 });
		lmUpDown.Minimum = new decimal(new int[4] { 2500, 0, 0, 0 });
		((Control)lmUpDown).Name = "lmUpDown";
		((Control)lmUpDown).Size = new Size(75, 17);
		((Control)lmUpDown).TabIndex = 10;
		((Control)lmUpDown).Tag = 10;
		((UpDownBase)lmUpDown).TextAlign = (HorizontalAlignment)1;
		lmUpDown.Value = new decimal(new int[4] { 2500, 0, 0, 0 });
		lmUpDown.ValueChanged += UpDown_ValueChanged;
		((Control)lowBox).Controls.Add((Control)(object)lowLabel);
		((Control)lowBox).Controls.Add((Control)(object)_msLow);
		((Control)lowBox).Controls.Add((Control)(object)_lbLow);
		((Control)lowBox).Controls.Add((Control)(object)lowUpDown);
		((Control)lowBox).Location = new Point(0, -4);
		((Control)lowBox).Name = "lowBox";
		((Control)lowBox).Size = new Size(340, 31);
		((Control)lowBox).TabIndex = 9;
		lowBox.TabStop = false;
		((Control)lowLabel).BackColor = SystemColors.Window;
		((Control)lowLabel).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lowLabel).Location = new Point(246, 10);
		((Control)lowLabel).Name = "lowLabel";
		((Control)lowLabel).Size = new Size(42, 17);
		((Control)lowLabel).TabIndex = 7;
		lowLabel.TextAlign = (ContentAlignment)64;
		((Control)_msLow).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_msLow).ForeColor = SystemColors.ControlDarkDark;
		((Control)_msLow).Location = new Point(308, 13);
		((Control)_msLow).Name = "_msLow";
		((Control)_msLow).Size = new Size(28, 15);
		((Control)_msLow).TabIndex = 6;
		((Control)_msLow).Text = "ms";
		((Control)_lbLow).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbLow).ForeColor = SystemColors.ControlDarkDark;
		((Control)_lbLow).Location = new Point(16, 11);
		((Control)_lbLow).Name = "_lbLow";
		((Control)_lbLow).Size = new Size(96, 15);
		((Control)_lbLow).TabIndex = 3;
		((Control)_lbLow).Text = "Low Rpm";
		_lbLow.TextAlign = (ContentAlignment)4;
		((UpDownBase)lowUpDown).BorderStyle = (BorderStyle)0;
		((Control)lowUpDown).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		lowUpDown.Increment = new decimal(new int[4] { 10, 0, 0, 0 });
		((Control)lowUpDown).Location = new Point(244, 10);
		lowUpDown.Maximum = new decimal(new int[4] { 500, 0, 0, 0 });
		((Control)lowUpDown).Name = "lowUpDown";
		((Control)lowUpDown).Size = new Size(60, 17);
		((Control)lowUpDown).TabIndex = 0;
		((Control)lowUpDown).Tag = 0;
		((UpDownBase)lowUpDown).TextAlign = (HorizontalAlignment)1;
		lowUpDown.ValueChanged += UpDown_ValueChanged;
		((Control)midBox).Controls.Add((Control)(object)midLabel);
		((Control)midBox).Controls.Add((Control)(object)_msMid);
		((Control)midBox).Controls.Add((Control)(object)_lbMid);
		((Control)midBox).Controls.Add((Control)(object)midUpDown);
		((Control)midBox).Location = new Point(0, 24);
		((Control)midBox).Name = "midBox";
		((Control)midBox).Size = new Size(340, 31);
		((Control)midBox).TabIndex = 12;
		midBox.TabStop = false;
		((Control)midLabel).BackColor = SystemColors.Window;
		((Control)midLabel).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)midLabel).Location = new Point(246, 10);
		((Control)midLabel).Name = "midLabel";
		((Control)midLabel).Size = new Size(42, 17);
		((Control)midLabel).TabIndex = 8;
		midLabel.TextAlign = (ContentAlignment)64;
		((Control)_msMid).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_msMid).ForeColor = SystemColors.ControlDarkDark;
		((Control)_msMid).Location = new Point(308, 13);
		((Control)_msMid).Name = "_msMid";
		((Control)_msMid).Size = new Size(28, 15);
		((Control)_msMid).TabIndex = 6;
		((Control)_msMid).Text = "ms";
		((Control)_lbMid).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbMid).ForeColor = SystemColors.ControlDarkDark;
		((Control)_lbMid).Location = new Point(16, 11);
		((Control)_lbMid).Name = "_lbMid";
		((Control)_lbMid).Size = new Size(96, 15);
		((Control)_lbMid).TabIndex = 3;
		((Control)_lbMid).Text = "Mid Rpm";
		_lbMid.TextAlign = (ContentAlignment)4;
		((UpDownBase)midUpDown).BorderStyle = (BorderStyle)0;
		((Control)midUpDown).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		midUpDown.Increment = new decimal(new int[4] { 10, 0, 0, 0 });
		((Control)midUpDown).Location = new Point(244, 10);
		midUpDown.Maximum = new decimal(new int[4] { 500, 0, 0, 0 });
		((Control)midUpDown).Name = "midUpDown";
		((Control)midUpDown).Size = new Size(60, 17);
		((Control)midUpDown).TabIndex = 0;
		((Control)midUpDown).Tag = 1;
		((UpDownBase)midUpDown).TextAlign = (HorizontalAlignment)1;
		midUpDown.ValueChanged += UpDown_ValueChanged;
		((Control)highBox).Controls.Add((Control)(object)highLabel);
		((Control)highBox).Controls.Add((Control)(object)_msHigh);
		((Control)highBox).Controls.Add((Control)(object)_lbHigh);
		((Control)highBox).Controls.Add((Control)(object)highUpDown);
		((Control)highBox).Location = new Point(0, 52);
		((Control)highBox).Name = "highBox";
		((Control)highBox).Size = new Size(340, 31);
		((Control)highBox).TabIndex = 13;
		highBox.TabStop = false;
		((Control)highLabel).BackColor = SystemColors.Window;
		((Control)highLabel).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)highLabel).Location = new Point(246, 10);
		((Control)highLabel).Name = "highLabel";
		((Control)highLabel).Size = new Size(42, 17);
		((Control)highLabel).TabIndex = 8;
		highLabel.TextAlign = (ContentAlignment)64;
		((Control)_msHigh).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_msHigh).ForeColor = SystemColors.ControlDarkDark;
		((Control)_msHigh).Location = new Point(308, 13);
		((Control)_msHigh).Name = "_msHigh";
		((Control)_msHigh).Size = new Size(28, 15);
		((Control)_msHigh).TabIndex = 6;
		((Control)_msHigh).Text = "ms";
		((Control)_lbHigh).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)_lbHigh).ForeColor = SystemColors.ControlDarkDark;
		((Control)_lbHigh).Location = new Point(16, 11);
		((Control)_lbHigh).Name = "_lbHigh";
		((Control)_lbHigh).Size = new Size(96, 15);
		((Control)_lbHigh).TabIndex = 3;
		((Control)_lbHigh).Text = "High Rpm";
		_lbHigh.TextAlign = (ContentAlignment)4;
		((UpDownBase)highUpDown).BorderStyle = (BorderStyle)0;
		((Control)highUpDown).Font = new Font("Tahoma", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		highUpDown.Increment = new decimal(new int[4] { 10, 0, 0, 0 });
		((Control)highUpDown).Location = new Point(244, 10);
		highUpDown.Maximum = new decimal(new int[4] { 500, 0, 0, 0 });
		((Control)highUpDown).Name = "highUpDown";
		((Control)highUpDown).Size = new Size(60, 17);
		((Control)highUpDown).TabIndex = 0;
		((Control)highUpDown).Tag = 2;
		((UpDownBase)highUpDown).TextAlign = (HorizontalAlignment)1;
		highUpDown.ValueChanged += UpDown_ValueChanged;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).CancelButton = (IButtonControl)(object)abortButton;
		((Form)this).ClientSize = new Size(362, 158);
		((Control)this).Controls.Add((Control)(object)shifterPanel);
		((Control)this).Controls.Add((Control)(object)_lbMap);
		((Control)this).Controls.Add((Control)(object)writeBox);
		((Control)this).Controls.Add((Control)(object)okButton);
		((Control)this).Controls.Add((Control)(object)abortButton);
		((Control)this).Controls.Add((Control)(object)MapBox);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Control)this).Name = "QueryForm";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = " TuneECU";
		((Form)this).Load += messageForm_Load;
		((Control)MapBox).ResumeLayout(false);
		((Control)writeBox).ResumeLayout(false);
		((Control)writeBox).PerformLayout();
		((Control)panelGear).ResumeLayout(false);
		((Control)panelGear).PerformLayout();
		((Control)shifterPanel).ResumeLayout(false);
		((ISupportInitialize)mhUpDown).EndInit();
		((ISupportInitialize)lmUpDown).EndInit();
		((Control)lowBox).ResumeLayout(false);
		((ISupportInitialize)lowUpDown).EndInit();
		((Control)midBox).ResumeLayout(false);
		((ISupportInitialize)midUpDown).EndInit();
		((Control)highBox).ResumeLayout(false);
		((ISupportInitialize)highUpDown).EndInit();
		((Control)this).ResumeLayout(false);
	}

	public QueryForm()
	{
		InitializeComponent();
	}

	private void messageForm_Load(object sender, EventArgs e)
	{
		((Control)okButton).Font = IDraw.tFont;
		((Control)abortButton).Font = IDraw.tFont;
		switch (boxMode)
		{
		case 0:
			((Control)radioMap1).Font = IDraw.tFont;
			((Control)radioMap2).Font = IDraw.tFont;
			((Control)MapBox).Show();
			((Control)abortButton).Show();
			((Control)this).Width = 368;
			((Control)_lbMap).Text = ISOMain.LangUI[ISOMain.mLang, 316];
			((Control)okButton).Text = ISOMain.LangUI[ISOMain.mLang, 318];
			((Control)abortButton).Text = ISOMain.LangUI[ISOMain.mLang, 74];
			cLabel = 0;
			if (ISORead.dataSensor[85] != null && ISORead.dataSensor[85].Length > 0)
			{
				((Control)radioMap2).Text = ISORead.dataSensor[85] + " (" + ISORead.baseMap2 + ")";
				((Control)radioMap2).Visible = true;
			}
			return;
		case 100:
			((Control)_lbLow).Font = IDraw.tbFont;
			((Control)_lbMid).Font = IDraw.tbFont;
			((Control)_lbHigh).Font = IDraw.tbFont;
			((Control)_msLow).Font = IDraw.tbFont;
			((Control)_msMid).Font = IDraw.tbFont;
			((Control)_msHigh).Font = IDraw.tbFont;
			((Control)lowLabel).Font = IDraw.tbFont;
			((Control)midLabel).Font = IDraw.tbFont;
			((Control)mhLabel).Font = IDraw.tbFont;
			((Control)lmLabel).Font = IDraw.tbFont;
			((Control)highLabel).Font = IDraw.tbFont;
			((Control)lowUpDown).Font = IDraw.tbFont;
			((Control)midUpDown).Font = IDraw.tbFont;
			((Control)highUpDown).Font = IDraw.tbFont;
			((Control)lmUpDown).Font = IDraw.tbFont;
			((Control)mhUpDown).Font = IDraw.tbFont;
			((Control)shifterPanel).Show();
			((Control)abortButton).Show();
			((Control)this).Width = 368;
			((Control)_lbMap).Text = ISOMain.LangUI[ISOMain.mLang, 324];
			setShifterBox();
			((Control)okButton).Text = ISOMain.LangUI[ISOMain.mLang, 75];
			((Control)abortButton).Text = ISOMain.LangUI[ISOMain.mLang, 74];
			cLabel = 0;
			return;
		}
		((Control)writeBox).Font = IDraw.rFont;
		((Control)writeBox).Show();
		((Control)okButton).Visible = boxMode != 4;
		((Control)abortButton).Visible = (boxMode > 3) & (boxMode < 12);
		((Control)rLabel).Font = IDraw.tbFont;
		((Control)sLabel).Font = IDraw.tbFont;
		((Control)tLabel).Font = IDraw.tbFont;
		int width = ((Control)this).Width;
		int num = Math.Max(((Control)rLabel).Width, ((Control)sLabel).Width);
		if (((Control)tLabel).Width > num)
		{
			num = ((Control)tLabel).Width;
		}
		if (num < 160)
		{
			num = 160;
		}
		((Control)this).Height = ((((Control)tLabel).Text == "") ? 180 : 197);
		((Control)tLabel).Visible = ((Control)this).Height > 180;
		((Control)this).Width = num + 104;
		((Control)this).Left = ((Control)this).Left - (num - width) / 2;
		((Control)rLabel).AutoSize = false;
		((Control)sLabel).AutoSize = false;
		((Control)tLabel).AutoSize = false;
		((Control)rLabel).Width = num;
		((Control)sLabel).Width = num;
		((Control)tLabel).Width = num;
		((Control)okButton).Text = ISOMain.LangUI[ISOMain.mLang, (boxMode == 7) ? 338 : 75];
		((Control)abortButton).Text = ISOMain.LangUI[ISOMain.mLang, (boxMode == 7) ? 337 : 74];
		if (!((Control)abortButton).Visible)
		{
			((Control)okButton).Left = (((Control)this).Width - ((Control)okButton).Width) / 2;
		}
		else if (!((Control)okButton).Visible)
		{
			((Control)abortButton).Left = (((Control)this).Width - ((Control)abortButton).Width) / 2;
		}
		((Control)panelGear).Visible = (boxMode & 0xFC) == 12;
		if (((Control)panelGear).Visible)
		{
			((Control)_Gear).Font = IDraw.tbFont;
			((Control)rbGear1).Font = IDraw.tFont;
			((Control)rbGear2).Font = IDraw.tFont;
			((Control)rbGear3).Font = IDraw.tFont;
			((Control)rbGear4).Font = IDraw.tFont;
			((Control)rbGear5).Font = IDraw.tFont;
			((Control)rbGear6).Font = IDraw.tFont;
			((Control)panelGear).Left = (((Control)this).Width - ((Control)panelGear).Width) / 2;
			((Control)rbGear4).Enabled = boxMode > 12;
			((Control)rbGear5).Enabled = boxMode > 13;
			((Control)rbGear6).Enabled = boxMode > 14;
			pGear = 0;
		}
		cLabel = ((ISOMain.epMap & (boxMode == 10)) ? 4 : 0);
		setupForm();
	}

	private void setShifterBox()
	{
		int i = 0;
		int[] array = new int[3];
		int num = 30;
		int num2 = 150;
		string[] array2 = new string[2];
		string text;
		for (text = ISOMain.LangUI[ISOMain.mLang, 325]; (text.IndexOf(":") > 0) & (i < 2); i++)
		{
			int num3 = text.IndexOf(":");
			array2[i] = text.Substring(0, num3);
			text = text.Substring(num3 + 1, text.Length - num3 - 1);
		}
		((Control)_lbLow).Text = array2[0];
		((Control)_lbMid).Text = array2[1];
		((Control)_lbHigh).Text = text;
		lowUpDown.Minimum = num;
		midUpDown.Minimum = num;
		highUpDown.Minimum = num;
		lowUpDown.Maximum = num2;
		midUpDown.Maximum = num2;
		highUpDown.Maximum = num2;
		lowUpDown.Increment = 10m;
		midUpDown.Increment = 10m;
		highUpDown.Increment = 10m;
		for (int num3 = 0; num3 < 3; num3++)
		{
			array[num3] = ((boxValue >> num3 * 5) & 0x1F) * 10;
			if (array[num3] < num)
			{
				array[num3] = num;
			}
			if (array[num3] > num2)
			{
				array[num3] = num2;
			}
		}
		lowUpDown.Value = array[0];
		midUpDown.Value = array[1];
		highUpDown.Value = array[2];
		((Control)lmLabel).Tag = (boxValue >> 24) & 0xFF;
		((Control)mhLabel).Tag = (boxValue >> 16) & 0xFF;
		num = (int)((Control)lmLabel).Tag * 100;
		num2 = (int)((Control)mhLabel).Tag * 100;
		lmUpDown.Minimum = num;
		lmUpDown.Maximum = num;
		mhUpDown.Minimum = num2;
		mhUpDown.Maximum = num2;
	}

	private void setupForm()
	{
		switch (boxMode)
		{
		case 1:
			if (((Control)_lbMap).Text == "")
			{
				((Control)_lbMap).Text = ISOMain.LangUI[ISOMain.mLang, 326];
			}
			SystemSounds.Exclamation.Play();
			break;
		case 2:
			if (((Control)_lbMap).Text == "")
			{
				((Control)_lbMap).Text = ISOMain.LangUI[ISOMain.mLang, 327];
			}
			SystemSounds.Hand.Play();
			break;
		case 7:
		case 8:
			if (((Control)_lbMap).Text == "")
			{
				((Control)_lbMap).Text = ISOMain.LangUI[ISOMain.mLang, 328];
			}
			SystemSounds.Exclamation.Play();
			break;
		default:
			if (((Control)_lbMap).Text == "")
			{
				((Control)_lbMap).Text = ISOMain.LangUI[ISOMain.mLang, 329];
			}
			SystemSounds.Exclamation.Play();
			break;
		}
	}

	private void UpDown_ValueChanged(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		NumericUpDown val = (NumericUpDown)sender;
		switch ((int)((Control)val).Tag)
		{
		case 0:
			((Control)lowLabel).Text = val.Value.ToString();
			break;
		case 1:
			((Control)midLabel).Text = val.Value.ToString();
			break;
		case 2:
			((Control)highLabel).Text = val.Value.ToString();
			break;
		case 10:
			((Control)lmLabel).Text = val.Value.ToString();
			break;
		case 11:
			((Control)mhLabel).Text = val.Value.ToString();
			break;
		}
	}

	private void _lbMap_Paint(object sender, PaintEventArgs e)
	{
		IDraw.PaintLabel(sender, e, cLabel);
	}

	private void writeBox_Paint(object sender, PaintEventArgs e)
	{
		switch (boxMode)
		{
		case 1:
			e.Graphics.DrawIcon(SystemIcons.Information, 14, 16);
			break;
		case 2:
			e.Graphics.DrawIcon(SystemIcons.Error, 14, 16);
			break;
		case 7:
		case 8:
			e.Graphics.DrawIcon(SystemIcons.Question, 14, 16);
			break;
		default:
			e.Graphics.DrawIcon(SystemIcons.Warning, 14, 16);
			break;
		}
	}

	private void rbGear_CheckedChanged(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		RadioButton val = (RadioButton)sender;
		if (val.Checked)
		{
			pGear = (int)((Control)val).Tag;
		}
	}

	private void okButton_Click(object sender, EventArgs e)
	{
		if (boxMode == 0)
		{
			ISORead.qDST = (radioMap2.Checked ? 1 : 0);
		}
		else if (boxMode == 100)
		{
			boxValue = (int)(lowUpDown.Value / 10m) | ((int)(midUpDown.Value / 10m) << 5) | ((int)(highUpDown.Value / 10m) << 10) | ((int)(mhUpDown.Value / 100m) << 16) | ((int)(lmUpDown.Value / 100m) << 24);
		}
	}
}

#nullable disable
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RdpSigner;

partial class SignTab
{
    private IContainer components = null;

    private TableLayoutPanel _root;
    private TableLayoutPanel _form;
    private Label _certLabel;
    private Label _selectedCert;
    private Button _pickCert;
    private Label _rdpPathLabel;
    private TextBox _rdpPath;
    private Button _browseRdp;
    private FlowLayoutPanel _optionsPanel;
    private CheckBox _backup;
    private FlowLayoutPanel _buttonPanel;
    private Button _sign;
    private TextBox _log;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

	private void InitializeComponent()
	{
		_root = new TableLayoutPanel();
		_form = new TableLayoutPanel();
		_certLabel = new Label();
		_selectedCert = new Label();
		_pickCert = new Button();
		_rdpPathLabel = new Label();
		_rdpPath = new TextBox();
		_browseRdp = new Button();
		_optionsPanel = new FlowLayoutPanel();
		_backup = new CheckBox();
		_buttonPanel = new FlowLayoutPanel();
		_sign = new Button();
		_log = new TextBox();
		_root.SuspendLayout();
		_form.SuspendLayout();
		_optionsPanel.SuspendLayout();
		_buttonPanel.SuspendLayout();
		SuspendLayout();
		// 
		// _root
		// 
		_root.ColumnCount = 1;
		_root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		_root.Controls.Add(_form, 0, 0);
		_root.Controls.Add(_log, 0, 1);
		_root.Dock = DockStyle.Fill;
		_root.Location = new Point(11, 13);
		_root.Margin = new Padding(3, 4, 3, 4);
		_root.Name = "_root";
		_root.RowCount = 2;
		_root.RowStyles.Add(new RowStyle());
		_root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
		_root.Size = new Size(785, 649);
		_root.TabIndex = 0;
		// 
		// _form
		// 
		_form.AutoSize = true;
		_form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		_form.ColumnCount = 3;
		_form.ColumnStyles.Add(new ColumnStyle());
		_form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
		_form.ColumnStyles.Add(new ColumnStyle());
		_form.Controls.Add(_certLabel, 0, 0);
		_form.Controls.Add(_selectedCert, 1, 0);
		_form.Controls.Add(_pickCert, 2, 0);
		_form.Controls.Add(_rdpPathLabel, 0, 1);
		_form.Controls.Add(_rdpPath, 1, 1);
		_form.Controls.Add(_browseRdp, 2, 1);
		_form.Controls.Add(_optionsPanel, 1, 2);
		_form.Controls.Add(_buttonPanel, 1, 3);
		_form.Dock = DockStyle.Top;
		_form.Location = new Point(3, 4);
		_form.Margin = new Padding(3, 4, 3, 4);
		_form.Name = "_form";
		_form.RowCount = 4;
		_form.RowStyles.Add(new RowStyle());
		_form.RowStyles.Add(new RowStyle());
		_form.RowStyles.Add(new RowStyle());
		_form.RowStyles.Add(new RowStyle());
		_form.Size = new Size(779, 225);
		_form.TabIndex = 0;
		// 
		// _certLabel
		// 
		_certLabel.Anchor = AnchorStyles.Left;
		_certLabel.AutoSize = true;
		_certLabel.Location = new Point(0, 14);
		_certLabel.Margin = new Padding(0, 8, 9, 8);
		_certLabel.Name = "_certLabel";
		_certLabel.Size = new Size(80, 20);
		_certLabel.TabIndex = 0;
		_certLabel.Text = "Certificate:";
		// 
		// _selectedCert
		// 
		_selectedCert.Dock = DockStyle.Fill;
		_selectedCert.Location = new Point(92, 0);
		_selectedCert.Name = "_selectedCert";
		_selectedCert.Size = new Size(534, 48);
		_selectedCert.TabIndex = 1;
		_selectedCert.Text = "(none)";
		_selectedCert.TextAlign = ContentAlignment.MiddleLeft;
		// 
		// _pickCert
		// 
		_pickCert.AutoSize = true;
		_pickCert.Location = new Point(632, 4);
		_pickCert.Margin = new Padding(3, 4, 3, 4);
		_pickCert.Name = "_pickCert";
		_pickCert.Size = new Size(144, 40);
		_pickCert.TabIndex = 2;
		_pickCert.Text = "Pick certificate…";
		_pickCert.UseVisualStyleBackColor = true;
		_pickCert.Click += OnPickCertClicked;
		// 
		// _rdpPathLabel
		// 
		_rdpPathLabel.Anchor = AnchorStyles.Left;
		_rdpPathLabel.AutoSize = true;
		_rdpPathLabel.Location = new Point(0, 62);
		_rdpPathLabel.Margin = new Padding(0, 8, 9, 8);
		_rdpPathLabel.Name = "_rdpPathLabel";
		_rdpPathLabel.Size = new Size(65, 20);
		_rdpPathLabel.TabIndex = 3;
		_rdpPathLabel.Text = "RDP file:";
		// 
		// _rdpPath
		// 
		_rdpPath.Dock = DockStyle.Fill;
		_rdpPath.Location = new Point(92, 52);
		_rdpPath.Margin = new Padding(3, 4, 3, 4);
		_rdpPath.Name = "_rdpPath";
		_rdpPath.Size = new Size(534, 27);
		_rdpPath.TabIndex = 4;
		_rdpPath.TextChanged += OnRdpPathChanged;
		// 
		// _browseRdp
		// 
		_browseRdp.AutoSize = true;
		_browseRdp.Location = new Point(632, 52);
		_browseRdp.Margin = new Padding(3, 4, 3, 4);
		_browseRdp.Name = "_browseRdp";
		_browseRdp.Size = new Size(89, 40);
		_browseRdp.TabIndex = 5;
		_browseRdp.Text = "Browse…";
		_browseRdp.UseVisualStyleBackColor = true;
		_browseRdp.Click += OnBrowseRdpClicked;
		// 
		// _optionsPanel
		// 
		_optionsPanel.AutoSize = true;
		_form.SetColumnSpan(_optionsPanel, 2);
		_optionsPanel.Controls.Add(_backup);
		_optionsPanel.Dock = DockStyle.Top;
		_optionsPanel.Location = new Point(92, 100);
		_optionsPanel.Margin = new Padding(3, 4, 3, 4);
		_optionsPanel.Name = "_optionsPanel";
		_optionsPanel.Size = new Size(684, 32);
		_optionsPanel.TabIndex = 6;
		// 
		// _backup
		// 
		_backup.AutoSize = true;
		_backup.Checked = true;
		_backup.CheckState = CheckState.Checked;
		_backup.Location = new Point(3, 4);
		_backup.Margin = new Padding(3, 4, 3, 4);
		_backup.Name = "_backup";
		_backup.Size = new Size(242, 24);
		_backup.TabIndex = 0;
		_backup.Text = "Back up original to .rdp.bak first";
		_backup.UseVisualStyleBackColor = true;
		// 
		// _buttonPanel
		// 
		_buttonPanel.AutoSize = true;
		_form.SetColumnSpan(_buttonPanel, 2);
		_buttonPanel.Controls.Add(_sign);
		_buttonPanel.Dock = DockStyle.Top;
		_buttonPanel.FlowDirection = FlowDirection.RightToLeft;
		_buttonPanel.Location = new Point(92, 140);
		_buttonPanel.Margin = new Padding(3, 4, 3, 4);
		_buttonPanel.Name = "_buttonPanel";
		_buttonPanel.Padding = new Padding(0, 11, 0, 11);
		_buttonPanel.Size = new Size(684, 81);
		_buttonPanel.TabIndex = 7;
		// 
		// _sign
		// 
		_sign.AutoSize = true;
		_sign.Enabled = false;
		_sign.Location = new Point(595, 15);
		_sign.Margin = new Padding(3, 4, 3, 4);
		_sign.Name = "_sign";
		_sign.Padding = new Padding(9, 5, 9, 5);
		_sign.Size = new Size(86, 51);
		_sign.TabIndex = 0;
		_sign.Text = "Sign";
		_sign.UseVisualStyleBackColor = true;
		_sign.Click += OnSignClicked;
		// 
		// _log
		// 
		_log.BackColor = Color.White;
		_log.Dock = DockStyle.Fill;
		_log.Font = new Font("Consolas", 9F);
		_log.Location = new Point(3, 237);
		_log.Margin = new Padding(3, 4, 3, 4);
		_log.Multiline = true;
		_log.Name = "_log";
		_log.ReadOnly = true;
		_log.ScrollBars = ScrollBars.Vertical;
		_log.Size = new Size(779, 408);
		_log.TabIndex = 1;
		// 
		// SignTab
		// 
		AutoScaleDimensions = new SizeF(8F, 20F);
		AutoScaleMode = AutoScaleMode.Font;
		Controls.Add(_root);
		Margin = new Padding(3, 4, 3, 4);
		Name = "SignTab";
		Padding = new Padding(11, 13, 11, 13);
		Size = new Size(807, 675);
		_root.ResumeLayout(false);
		_root.PerformLayout();
		_form.ResumeLayout(false);
		_form.PerformLayout();
		_optionsPanel.ResumeLayout(false);
		_optionsPanel.PerformLayout();
		_buttonPanel.ResumeLayout(false);
		_buttonPanel.PerformLayout();
		ResumeLayout(false);
	}
}

#nullable disable
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RdpSigner;

partial class ImportTrustTab
{
    private IContainer components = null;

    private TableLayoutPanel _root;
    private TableLayoutPanel _form;
    private Label _certPathLabel;
    private TextBox _certPath;
    private Button _browseCert;
    private Label _passwordLabel;
    private TextBox _password;
    private Label _scopeLabel;
    private FlowLayoutPanel _scopePanel;
    private RadioButton _scopeCurrentUser;
    private RadioButton _scopeLocalMachine;
    private Label _storesLabel;
    private FlowLayoutPanel _storesPanel;
    private CheckBox _storeTrustedPublisher;
    private CheckBox _storeRoot;
    private CheckBox _storeMy;
    private CheckBox _trustPolicy;
    private Label _info;
    private FlowLayoutPanel _buttonPanel;
    private Button _import;
    private TextBox _log;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

	private void InitializeComponent()
	{
		ComponentResourceManager resources = new ComponentResourceManager(typeof(ImportTrustTab));
		_root = new TableLayoutPanel();
		_form = new TableLayoutPanel();
		_certPathLabel = new Label();
		_certPath = new TextBox();
		_browseCert = new Button();
		_passwordLabel = new Label();
		_password = new TextBox();
		_scopeLabel = new Label();
		_scopePanel = new FlowLayoutPanel();
		_scopeCurrentUser = new RadioButton();
		_scopeLocalMachine = new RadioButton();
		_storesLabel = new Label();
		_storesPanel = new FlowLayoutPanel();
		_storeTrustedPublisher = new CheckBox();
		_storeRoot = new CheckBox();
		_storeMy = new CheckBox();
		_trustPolicy = new CheckBox();
		_info = new Label();
		_buttonPanel = new FlowLayoutPanel();
		_import = new Button();
		_log = new TextBox();
		_root.SuspendLayout();
		_form.SuspendLayout();
		_scopePanel.SuspendLayout();
		_storesPanel.SuspendLayout();
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
		_form.Controls.Add(_certPathLabel, 0, 0);
		_form.Controls.Add(_certPath, 1, 0);
		_form.Controls.Add(_browseCert, 2, 0);
		_form.Controls.Add(_passwordLabel, 0, 1);
		_form.Controls.Add(_password, 1, 1);
		_form.Controls.Add(_scopeLabel, 0, 2);
		_form.Controls.Add(_scopePanel, 1, 2);
		_form.Controls.Add(_storesLabel, 0, 3);
		_form.Controls.Add(_storesPanel, 1, 3);
		_form.Controls.Add(_trustPolicy, 1, 4);
		_form.Controls.Add(_info, 1, 5);
		_form.Controls.Add(_buttonPanel, 1, 6);
		_form.Dock = DockStyle.Top;
		_form.Location = new Point(3, 4);
		_form.Margin = new Padding(3, 4, 3, 4);
		_form.Name = "_form";
		_form.RowCount = 7;
		_form.RowStyles.Add(new RowStyle());
		_form.RowStyles.Add(new RowStyle());
		_form.RowStyles.Add(new RowStyle());
		_form.RowStyles.Add(new RowStyle());
		_form.RowStyles.Add(new RowStyle());
		_form.RowStyles.Add(new RowStyle());
		_form.RowStyles.Add(new RowStyle());
		_form.Size = new Size(779, 454);
		_form.TabIndex = 0;
		// 
		// _certPathLabel
		// 
		_certPathLabel.Anchor = AnchorStyles.Left;
		_certPathLabel.AutoSize = true;
		_certPathLabel.Location = new Point(0, 14);
		_certPathLabel.Margin = new Padding(0, 8, 9, 8);
		_certPathLabel.Name = "_certPathLabel";
		_certPathLabel.Size = new Size(105, 20);
		_certPathLabel.TabIndex = 0;
		_certPathLabel.Text = "Certificate file:";
		// 
		// _certPath
		// 
		_certPath.Dock = DockStyle.Fill;
		_certPath.Location = new Point(117, 4);
		_certPath.Margin = new Padding(3, 4, 3, 4);
		_certPath.Name = "_certPath";
		_certPath.Size = new Size(564, 27);
		_certPath.TabIndex = 1;
		_certPath.TextChanged += OnCertPathChanged;
		// 
		// _browseCert
		// 
		_browseCert.AutoSize = true;
		_browseCert.Location = new Point(687, 4);
		_browseCert.Margin = new Padding(3, 4, 3, 4);
		_browseCert.Name = "_browseCert";
		_browseCert.Size = new Size(89, 40);
		_browseCert.TabIndex = 2;
		_browseCert.Text = "Browse…";
		_browseCert.UseVisualStyleBackColor = true;
		_browseCert.Click += OnBrowseCertClicked;
		// 
		// _passwordLabel
		// 
		_passwordLabel.Anchor = AnchorStyles.Left;
		_passwordLabel.AutoSize = true;
		_passwordLabel.Location = new Point(0, 56);
		_passwordLabel.Margin = new Padding(0, 8, 9, 8);
		_passwordLabel.Name = "_passwordLabel";
		_passwordLabel.Size = new Size(103, 20);
		_passwordLabel.TabIndex = 3;
		_passwordLabel.Text = "PFX password:";
		// 
		// _password
		// 
		_password.Dock = DockStyle.Fill;
		_password.Enabled = false;
		_password.Location = new Point(117, 52);
		_password.Margin = new Padding(3, 4, 3, 4);
		_password.Name = "_password";
		_password.Size = new Size(564, 27);
		_password.TabIndex = 4;
		_password.UseSystemPasswordChar = true;
		// 
		// _scopeLabel
		// 
		_scopeLabel.Anchor = AnchorStyles.Left;
		_scopeLabel.AutoSize = true;
		_scopeLabel.Location = new Point(0, 94);
		_scopeLabel.Margin = new Padding(0, 8, 9, 8);
		_scopeLabel.Name = "_scopeLabel";
		_scopeLabel.Size = new Size(74, 20);
		_scopeLabel.TabIndex = 5;
		_scopeLabel.Text = "Install for:";
		// 
		// _scopePanel
		// 
		_scopePanel.AutoSize = true;
		_scopePanel.Controls.Add(_scopeCurrentUser);
		_scopePanel.Controls.Add(_scopeLocalMachine);
		_scopePanel.Dock = DockStyle.Top;
		_scopePanel.Location = new Point(117, 88);
		_scopePanel.Margin = new Padding(3, 4, 3, 4);
		_scopePanel.Name = "_scopePanel";
		_scopePanel.Size = new Size(564, 32);
		_scopePanel.TabIndex = 6;
		// 
		// _scopeCurrentUser
		// 
		_scopeCurrentUser.AutoSize = true;
		_scopeCurrentUser.Checked = true;
		_scopeCurrentUser.Location = new Point(3, 4);
		_scopeCurrentUser.Margin = new Padding(3, 4, 3, 4);
		_scopeCurrentUser.Name = "_scopeCurrentUser";
		_scopeCurrentUser.Size = new Size(107, 24);
		_scopeCurrentUser.TabIndex = 0;
		_scopeCurrentUser.TabStop = true;
		_scopeCurrentUser.Text = "CurrentUser";
		_scopeCurrentUser.UseVisualStyleBackColor = true;
		// 
		// _scopeLocalMachine
		// 
		_scopeLocalMachine.AutoSize = true;
		_scopeLocalMachine.Location = new Point(116, 4);
		_scopeLocalMachine.Margin = new Padding(3, 4, 3, 4);
		_scopeLocalMachine.Name = "_scopeLocalMachine";
		_scopeLocalMachine.Size = new Size(234, 24);
		_scopeLocalMachine.TabIndex = 1;
		_scopeLocalMachine.Text = "LocalMachine (requires admin)";
		_scopeLocalMachine.UseVisualStyleBackColor = true;
		// 
		// _storesLabel
		// 
		_storesLabel.Anchor = AnchorStyles.Left;
		_storesLabel.AutoSize = true;
		_storesLabel.Location = new Point(0, 150);
		_storesLabel.Margin = new Padding(0, 8, 9, 8);
		_storesLabel.Name = "_storesLabel";
		_storesLabel.Size = new Size(81, 20);
		_storesLabel.TabIndex = 7;
		_storesLabel.Text = "Install into:";
		// 
		// _storesPanel
		// 
		_storesPanel.AutoSize = true;
		_storesPanel.Controls.Add(_storeTrustedPublisher);
		_storesPanel.Controls.Add(_storeRoot);
		_storesPanel.Controls.Add(_storeMy);
		_storesPanel.Dock = DockStyle.Top;
		_storesPanel.Location = new Point(117, 128);
		_storesPanel.Margin = new Padding(3, 4, 3, 4);
		_storesPanel.Name = "_storesPanel";
		_storesPanel.Size = new Size(564, 64);
		_storesPanel.TabIndex = 8;
		// 
		// _storeTrustedPublisher
		// 
		_storeTrustedPublisher.AutoSize = true;
		_storeTrustedPublisher.Checked = true;
		_storeTrustedPublisher.CheckState = CheckState.Checked;
		_storeTrustedPublisher.Location = new Point(3, 4);
		_storeTrustedPublisher.Margin = new Padding(3, 4, 3, 4);
		_storeTrustedPublisher.Name = "_storeTrustedPublisher";
		_storeTrustedPublisher.Size = new Size(139, 24);
		_storeTrustedPublisher.TabIndex = 0;
		_storeTrustedPublisher.Text = "TrustedPublisher";
		_storeTrustedPublisher.UseVisualStyleBackColor = true;
		// 
		// _storeRoot
		// 
		_storeRoot.AutoSize = true;
		_storeRoot.Checked = true;
		_storeRoot.CheckState = CheckState.Checked;
		_storeRoot.Location = new Point(148, 4);
		_storeRoot.Margin = new Padding(3, 4, 3, 4);
		_storeRoot.Name = "_storeRoot";
		_storeRoot.Size = new Size(63, 24);
		_storeRoot.TabIndex = 1;
		_storeRoot.Text = "Root";
		_storeRoot.UseVisualStyleBackColor = true;
		// 
		// _storeMy
		// 
		_storeMy.AutoSize = true;
		_storeMy.Checked = true;
		_storeMy.CheckState = CheckState.Checked;
		_storeMy.Location = new Point(3, 36);
		_storeMy.Margin = new Padding(3, 4, 3, 4);
		_storeMy.Name = "_storeMy";
		_storeMy.Size = new Size(409, 24);
		_storeMy.TabIndex = 2;
		_storeMy.Text = "My (Personal, required for signing RDP files, requires .pfx)";
		_storeMy.UseVisualStyleBackColor = true;
		// 
		// _trustPolicy
		// 
		_trustPolicy.Checked = true;
		_trustPolicy.CheckState = CheckState.Checked;
		_form.SetColumnSpan(_trustPolicy, 2);
		_trustPolicy.Location = new Point(114, 204);
		_trustPolicy.Margin = new Padding(0, 8, 0, 8);
		_trustPolicy.Name = "_trustPolicy";
		_trustPolicy.Size = new Size(395, 57);
		_trustPolicy.TabIndex = 9;
		_trustPolicy.Text = "Suppress RDP connection security warning (add thumbprint to TrustedCertThumbprints policy)";
		_trustPolicy.UseVisualStyleBackColor = true;
		// 
		// _info
		// 
		_info.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		_form.SetColumnSpan(_info, 2);
		_info.ForeColor = Color.DimGray;
		_info.Location = new Point(114, 277);
		_info.Margin = new Padding(0, 8, 0, 8);
		_info.Name = "_info";
		_info.Size = new Size(665, 80);
		_info.TabIndex = 9;
		_info.Text = resources.GetString("_info.Text");
		// 
		// _buttonPanel
		// 
		_buttonPanel.AutoSize = true;
		_form.SetColumnSpan(_buttonPanel, 2);
		_buttonPanel.Controls.Add(_import);
		_buttonPanel.Dock = DockStyle.Top;
		_buttonPanel.FlowDirection = FlowDirection.RightToLeft;
		_buttonPanel.Location = new Point(117, 369);
		_buttonPanel.Margin = new Padding(3, 4, 3, 4);
		_buttonPanel.Name = "_buttonPanel";
		_buttonPanel.Padding = new Padding(0, 11, 0, 11);
		_buttonPanel.Size = new Size(659, 81);
		_buttonPanel.TabIndex = 10;
		// 
		// _import
		// 
		_import.AutoSize = true;
		_import.Location = new Point(506, 15);
		_import.Margin = new Padding(3, 4, 3, 4);
		_import.Name = "_import";
		_import.Padding = new Padding(9, 5, 9, 5);
		_import.Size = new Size(150, 51);
		_import.TabIndex = 0;
		_import.Text = "Import && Trust";
		_import.UseVisualStyleBackColor = true;
		_import.Click += OnImportClicked;
		// 
		// _log
		// 
		_log.BackColor = Color.White;
		_log.Dock = DockStyle.Fill;
		_log.Font = new Font("Consolas", 9F);
		_log.Location = new Point(3, 466);
		_log.Margin = new Padding(3, 4, 3, 4);
		_log.Multiline = true;
		_log.Name = "_log";
		_log.ReadOnly = true;
		_log.ScrollBars = ScrollBars.Vertical;
		_log.Size = new Size(779, 179);
		_log.TabIndex = 1;
		// 
		// ImportTrustTab
		// 
		AutoScaleDimensions = new SizeF(8F, 20F);
		AutoScaleMode = AutoScaleMode.Font;
		Controls.Add(_root);
		Margin = new Padding(3, 4, 3, 4);
		Name = "ImportTrustTab";
		Padding = new Padding(11, 13, 11, 13);
		Size = new Size(807, 675);
		_root.ResumeLayout(false);
		_root.PerformLayout();
		_form.ResumeLayout(false);
		_form.PerformLayout();
		_scopePanel.ResumeLayout(false);
		_scopePanel.PerformLayout();
		_storesPanel.ResumeLayout(false);
		_storesPanel.PerformLayout();
		_buttonPanel.ResumeLayout(false);
		_buttonPanel.PerformLayout();
		ResumeLayout(false);
	}
}

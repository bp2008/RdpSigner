#nullable disable
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RdpSigner;

partial class GenerateTab
{
    private IContainer components = null;

    private TableLayoutPanel _root;
    private TableLayoutPanel _form;
    private Label _nameLabel;
    private TextBox _subject;
    private Label _yearsLabel;
    private NumericUpDown _years;
    private Label _pfxPathLabel;
    private TextBox _pfxPath;
    private Button _browsePfx;
    private Label _passwordLabel;
    private TextBox _password;
    private Label _passwordConfirmLabel;
    private TextBox _passwordConfirm;
    private FlowLayoutPanel _optionsPanel;
    private CheckBox _alsoCer;
    private FlowLayoutPanel _buttonPanel;
    private Button _generate;
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
		_nameLabel = new Label();
		_subject = new TextBox();
		_yearsLabel = new Label();
		_years = new NumericUpDown();
		_pfxPathLabel = new Label();
		_pfxPath = new TextBox();
		_browsePfx = new Button();
		_passwordLabel = new Label();
		_password = new TextBox();
		_passwordConfirmLabel = new Label();
		_passwordConfirm = new TextBox();
		_optionsPanel = new FlowLayoutPanel();
		_alsoCer = new CheckBox();
		_buttonPanel = new FlowLayoutPanel();
		_generate = new Button();
		_log = new TextBox();
		_root.SuspendLayout();
		_form.SuspendLayout();
		((ISupportInitialize)_years).BeginInit();
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
		_form.Controls.Add(_nameLabel, 0, 0);
		_form.Controls.Add(_subject, 1, 0);
		_form.Controls.Add(_yearsLabel, 0, 1);
		_form.Controls.Add(_years, 1, 1);
		_form.Controls.Add(_pfxPathLabel, 0, 2);
		_form.Controls.Add(_pfxPath, 1, 2);
		_form.Controls.Add(_browsePfx, 2, 2);
		_form.Controls.Add(_passwordLabel, 0, 3);
		_form.Controls.Add(_password, 1, 3);
		_form.Controls.Add(_passwordConfirmLabel, 0, 4);
		_form.Controls.Add(_passwordConfirm, 1, 4);
		_form.Controls.Add(_optionsPanel, 1, 5);
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
		_form.Size = new Size(779, 321);
		_form.TabIndex = 0;
		// 
		// _nameLabel
		// 
		_nameLabel.Anchor = AnchorStyles.Left;
		_nameLabel.AutoSize = true;
		_nameLabel.Location = new Point(0, 8);
		_nameLabel.Margin = new Padding(0, 8, 9, 8);
		_nameLabel.Name = "_nameLabel";
		_nameLabel.Size = new Size(52, 20);
		_nameLabel.TabIndex = 0;
		_nameLabel.Text = "Name:";
		// 
		// _subject
		// 
		_subject.Dock = DockStyle.Fill;
		_subject.Location = new Point(144, 4);
		_subject.Margin = new Padding(3, 4, 3, 4);
		_subject.Name = "_subject";
		_subject.Size = new Size(537, 27);
		_subject.TabIndex = 1;
		_subject.Text = "RDP Publisher";
		// 
		// _yearsLabel
		// 
		_yearsLabel.Anchor = AnchorStyles.Left;
		_yearsLabel.AutoSize = true;
		_yearsLabel.Location = new Point(0, 44);
		_yearsLabel.Margin = new Padding(0, 8, 9, 8);
		_yearsLabel.Name = "_yearsLabel";
		_yearsLabel.Size = new Size(109, 20);
		_yearsLabel.TabIndex = 2;
		_yearsLabel.Text = "Validity (years):";
		// 
		// _years
		// 
		_years.Dock = DockStyle.Fill;
		_years.Location = new Point(144, 40);
		_years.Margin = new Padding(3, 4, 3, 4);
		_years.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
		_years.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
		_years.Name = "_years";
		_years.Size = new Size(537, 27);
		_years.TabIndex = 3;
		_years.Value = new decimal(new int[] { 500, 0, 0, 0 });
		// 
		// _pfxPathLabel
		// 
		_pfxPathLabel.Anchor = AnchorStyles.Left;
		_pfxPathLabel.AutoSize = true;
		_pfxPathLabel.Location = new Point(0, 86);
		_pfxPathLabel.Margin = new Padding(0, 8, 9, 8);
		_pfxPathLabel.Name = "_pfxPathLabel";
		_pfxPathLabel.Size = new Size(86, 20);
		_pfxPathLabel.TabIndex = 4;
		_pfxPathLabel.Text = "Output .pfx:";
		// 
		// _pfxPath
		// 
		_pfxPath.Dock = DockStyle.Fill;
		_pfxPath.Location = new Point(144, 76);
		_pfxPath.Margin = new Padding(3, 4, 3, 4);
		_pfxPath.Name = "_pfxPath";
		_pfxPath.Size = new Size(537, 27);
		_pfxPath.TabIndex = 5;
		// 
		// _browsePfx
		// 
		_browsePfx.AutoSize = true;
		_browsePfx.Location = new Point(687, 76);
		_browsePfx.Margin = new Padding(3, 4, 3, 4);
		_browsePfx.Name = "_browsePfx";
		_browsePfx.Size = new Size(89, 40);
		_browsePfx.TabIndex = 6;
		_browsePfx.Text = "Browse…";
		_browsePfx.UseVisualStyleBackColor = true;
		_browsePfx.Click += OnBrowsePfxClicked;
		// 
		// _passwordLabel
		// 
		_passwordLabel.Anchor = AnchorStyles.Left;
		_passwordLabel.AutoSize = true;
		_passwordLabel.Location = new Point(0, 128);
		_passwordLabel.Margin = new Padding(0, 8, 9, 8);
		_passwordLabel.Name = "_passwordLabel";
		_passwordLabel.Size = new Size(103, 20);
		_passwordLabel.TabIndex = 7;
		_passwordLabel.Text = "PFX password:";
		// 
		// _password
		// 
		_password.Dock = DockStyle.Fill;
		_password.Location = new Point(144, 124);
		_password.Margin = new Padding(3, 4, 3, 4);
		_password.Name = "_password";
		_password.Size = new Size(537, 27);
		_password.TabIndex = 8;
		_password.UseSystemPasswordChar = true;
		// 
		// _passwordConfirmLabel
		// 
		_passwordConfirmLabel.Anchor = AnchorStyles.Left;
		_passwordConfirmLabel.AutoSize = true;
		_passwordConfirmLabel.Location = new Point(0, 164);
		_passwordConfirmLabel.Margin = new Padding(0, 8, 9, 8);
		_passwordConfirmLabel.Name = "_passwordConfirmLabel";
		_passwordConfirmLabel.Size = new Size(132, 20);
		_passwordConfirmLabel.TabIndex = 9;
		_passwordConfirmLabel.Text = "Confirm password:";
		// 
		// _passwordConfirm
		// 
		_passwordConfirm.Dock = DockStyle.Fill;
		_passwordConfirm.Location = new Point(144, 160);
		_passwordConfirm.Margin = new Padding(3, 4, 3, 4);
		_passwordConfirm.Name = "_passwordConfirm";
		_passwordConfirm.Size = new Size(537, 27);
		_passwordConfirm.TabIndex = 10;
		_passwordConfirm.UseSystemPasswordChar = true;
		// 
		// _optionsPanel
		// 
		_optionsPanel.AutoSize = true;
		_form.SetColumnSpan(_optionsPanel, 2);
		_optionsPanel.Controls.Add(_alsoCer);
		_optionsPanel.Dock = DockStyle.Top;
		_optionsPanel.Location = new Point(144, 196);
		_optionsPanel.Margin = new Padding(3, 4, 3, 4);
		_optionsPanel.Name = "_optionsPanel";
		_optionsPanel.Size = new Size(632, 32);
		_optionsPanel.TabIndex = 11;
		// 
		// _alsoCer
		// 
		_alsoCer.AutoSize = true;
		_alsoCer.Checked = true;
		_alsoCer.CheckState = CheckState.Checked;
		_alsoCer.Location = new Point(3, 4);
		_alsoCer.Margin = new Padding(3, 4, 3, 4);
		_alsoCer.Name = "_alsoCer";
		_alsoCer.Size = new Size(234, 24);
		_alsoCer.TabIndex = 0;
		_alsoCer.Text = "Also save public .cer alongside";
		_alsoCer.UseVisualStyleBackColor = true;
		// 
		// _buttonPanel
		// 
		_buttonPanel.AutoSize = true;
		_form.SetColumnSpan(_buttonPanel, 2);
		_buttonPanel.Controls.Add(_generate);
		_buttonPanel.Dock = DockStyle.Top;
		_buttonPanel.FlowDirection = FlowDirection.RightToLeft;
		_buttonPanel.Location = new Point(144, 236);
		_buttonPanel.Margin = new Padding(3, 4, 3, 4);
		_buttonPanel.Name = "_buttonPanel";
		_buttonPanel.Padding = new Padding(0, 11, 0, 11);
		_buttonPanel.Size = new Size(632, 81);
		_buttonPanel.TabIndex = 12;
		// 
		// _generate
		// 
		_generate.AutoSize = true;
		_generate.Location = new Point(520, 15);
		_generate.Margin = new Padding(3, 4, 3, 4);
		_generate.Name = "_generate";
		_generate.Padding = new Padding(9, 5, 9, 5);
		_generate.Size = new Size(109, 51);
		_generate.TabIndex = 0;
		_generate.Text = "Generate";
		_generate.UseVisualStyleBackColor = true;
		_generate.Click += OnGenerateClicked;
		// 
		// _log
		// 
		_log.BackColor = Color.White;
		_log.Dock = DockStyle.Fill;
		_log.Font = new Font("Consolas", 9F);
		_log.Location = new Point(3, 333);
		_log.Margin = new Padding(3, 4, 3, 4);
		_log.Multiline = true;
		_log.Name = "_log";
		_log.ReadOnly = true;
		_log.ScrollBars = ScrollBars.Vertical;
		_log.Size = new Size(779, 312);
		_log.TabIndex = 1;
		// 
		// GenerateTab
		// 
		AutoScaleDimensions = new SizeF(8F, 20F);
		AutoScaleMode = AutoScaleMode.Font;
		Controls.Add(_root);
		Margin = new Padding(3, 4, 3, 4);
		Name = "GenerateTab";
		Padding = new Padding(11, 13, 11, 13);
		Size = new Size(807, 675);
		_root.ResumeLayout(false);
		_root.PerformLayout();
		_form.ResumeLayout(false);
		_form.PerformLayout();
		((ISupportInitialize)_years).EndInit();
		_optionsPanel.ResumeLayout(false);
		_optionsPanel.PerformLayout();
		_buttonPanel.ResumeLayout(false);
		_buttonPanel.PerformLayout();
		ResumeLayout(false);
	}
}

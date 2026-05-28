#nullable disable
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RdpSigner;

partial class MainForm
{
    private IContainer components = null;

    private TabControl _tabs;
    private TabPage _generatePage;
    private GenerateTab _generateTab;
    private TabPage _importTrustPage;
    private ImportTrustTab _importTrustTab;
    private TabPage _signPage;
    private SignTab _signTab;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _tabs = new TabControl();
        _generatePage = new TabPage();
        _generateTab = new GenerateTab();
        _importTrustPage = new TabPage();
        _importTrustTab = new ImportTrustTab();
        _signPage = new TabPage();
        _signTab = new SignTab();
        _tabs.SuspendLayout();
        _generatePage.SuspendLayout();
        _importTrustPage.SuspendLayout();
        _signPage.SuspendLayout();
        SuspendLayout();

        // _tabs
        _tabs.Controls.Add(_generatePage);
        _tabs.Controls.Add(_importTrustPage);
        _tabs.Controls.Add(_signPage);
        _tabs.Dock = DockStyle.Fill;
        _tabs.Location = new Point(0, 0);
        _tabs.Name = "_tabs";
        _tabs.SelectedIndex = 0;
        _tabs.Size = new Size(720, 540);
        _tabs.TabIndex = 0;

        // _generatePage
        _generatePage.Controls.Add(_generateTab);
        _generatePage.Location = new Point(4, 24);
        _generatePage.Name = "_generatePage";
        _generatePage.Padding = new Padding(3);
        _generatePage.Size = new Size(712, 512);
        _generatePage.TabIndex = 0;
        _generatePage.Text = "Generate";
        _generatePage.UseVisualStyleBackColor = true;

        // _generateTab
        _generateTab.Dock = DockStyle.Fill;
        _generateTab.Location = new Point(3, 3);
        _generateTab.Name = "_generateTab";
        _generateTab.Size = new Size(706, 506);
        _generateTab.TabIndex = 0;

        // _importTrustPage
        _importTrustPage.Controls.Add(_importTrustTab);
        _importTrustPage.Location = new Point(4, 24);
        _importTrustPage.Name = "_importTrustPage";
        _importTrustPage.Padding = new Padding(3);
        _importTrustPage.Size = new Size(712, 512);
        _importTrustPage.TabIndex = 1;
        _importTrustPage.Text = "Import && Trust";
        _importTrustPage.UseVisualStyleBackColor = true;

        // _importTrustTab
        _importTrustTab.Dock = DockStyle.Fill;
        _importTrustTab.Location = new Point(3, 3);
        _importTrustTab.Name = "_importTrustTab";
        _importTrustTab.Size = new Size(706, 506);
        _importTrustTab.TabIndex = 0;

        // _signPage
        _signPage.Controls.Add(_signTab);
        _signPage.Location = new Point(4, 24);
        _signPage.Name = "_signPage";
        _signPage.Padding = new Padding(3);
        _signPage.Size = new Size(712, 512);
        _signPage.TabIndex = 2;
        _signPage.Text = "Sign";
        _signPage.UseVisualStyleBackColor = true;

        // _signTab
        _signTab.Dock = DockStyle.Fill;
        _signTab.Location = new Point(3, 3);
        _signTab.Name = "_signTab";
        _signTab.Size = new Size(706, 506);
        _signTab.TabIndex = 0;

        // MainForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(720, 540);
        Controls.Add(_tabs);
        MinimumSize = new Size(640, 480);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "RDP Signer";
        _tabs.ResumeLayout(false);
        _generatePage.ResumeLayout(false);
        _importTrustPage.ResumeLayout(false);
        _signPage.ResumeLayout(false);
        ResumeLayout(false);
    }
}

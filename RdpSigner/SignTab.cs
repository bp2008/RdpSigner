using RdpSigner.Core;

namespace RdpSigner;

public partial class SignTab : UserControl
{
    private string? _thumbprint;
    private string? _certSubject;

    public SignTab()
    {
        InitializeComponent();
    }

    private void OnPickCertClicked(object? sender, EventArgs e)
    {
        var picked = CertPicker.PickCodeSigningCert(this);
        if (picked == null) return;

        _thumbprint = picked.Thumbprint;
        _certSubject = picked.Subject;
        _selectedCert.Text = $"{_certSubject}  —  {_thumbprint}";
        FormHelpers.AppendLog(_log, $"Selected: {_certSubject} ({_thumbprint})");
        picked.Dispose();
        UpdateSignButton();
    }

    private void OnBrowseRdpClicked(object? sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog { Filter = "RDP file (*.rdp)|*.rdp|All files (*.*)|*.*" };
        if (ofd.ShowDialog(this) == DialogResult.OK)
        {
            _rdpPath.Text = ofd.FileName;
            UpdateSignButton();
        }
    }

    private void OnRdpPathChanged(object? sender, EventArgs e) => UpdateSignButton();

    private void UpdateSignButton()
    {
        _sign.Enabled = !string.IsNullOrEmpty(_thumbprint) && !string.IsNullOrEmpty(_rdpPath.Text);
    }

    private void OnSignClicked(object? sender, EventArgs e)
    {
        try
        {
            var rdp = _rdpPath.Text.Trim();
            if (!File.Exists(rdp))
                throw new InvalidOperationException($"RDP file does not exist: {rdp}");
            if (string.IsNullOrEmpty(_thumbprint))
                throw new InvalidOperationException("Pick a certificate first.");

            if (_backup.Checked)
            {
                var bak = rdp + ".bak";
                if (File.Exists(bak))
                {
                    var choice = MessageBox.Show(
                        this,
                        $"Backup file already exists:\n{bak}\n\nOverwrite it?",
                        "Overwrite backup?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (choice != DialogResult.Yes) return;
                }
                File.Copy(rdp, bak, overwrite: true);
                FormHelpers.AppendLog(_log, $"Backup written: {bak}");
            }

            _sign.Enabled = false;
            FormHelpers.AppendLog(_log, $"Running rdpsign.exe /sha256 {_thumbprint} \"{rdp}\"…");

            var result = RdpSign.Sign(_thumbprint!, rdp);

            if (!string.IsNullOrWhiteSpace(result.StdOut))
                FormHelpers.AppendLog(_log, "stdout: " + result.StdOut.TrimEnd());
            if (!string.IsNullOrWhiteSpace(result.StdErr))
                FormHelpers.AppendLog(_log, "stderr: " + result.StdErr.TrimEnd());

            if (result.ExitCode != 0)
            {
                var msg = $"rdpsign.exe exited with code {result.ExitCode}.";
                FormHelpers.AppendError(_log, msg);
                MessageBox.Show(this, msg + "\n\n" + result.StdErr, "Sign failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormHelpers.AppendLog(_log, "Signed successfully. First lines of the signed file:");
            var lines = File.ReadLines(rdp).Take(5);
            foreach (var line in lines)
                FormHelpers.AppendLog(_log, "  " + line);
        }
        catch (Exception ex)
        {
            FormHelpers.AppendError(_log, ex.Message);
            MessageBox.Show(this, ex.Message, "Sign failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            UpdateSignButton();
        }
    }
}

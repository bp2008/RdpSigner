using System.Security.Cryptography.X509Certificates;
using RdpSigner.Core;

namespace RdpSigner;

public partial class GenerateTab : UserControl
{
	public GenerateTab()
	{
		InitializeComponent();
	}

	private void OnBrowsePfxClicked(object? sender, EventArgs e)
	{
		using var sfd = new SaveFileDialog
		{
			Filter = "PFX certificate (*.pfx)|*.pfx",
			DefaultExt = "pfx",
			FileName = "RdpSigner.pfx",
		};
		if (sfd.ShowDialog(this) == DialogResult.OK)
			_pfxPath.Text = sfd.FileName;
	}

	private void OnGenerateClicked(object? sender, EventArgs e)
	{
		try
		{
			var nameInput = _subject.Text.Trim();
			if (string.IsNullOrEmpty(nameInput))
				throw new InvalidOperationException("Enter a name for the certificate.");

			// Accept plain names ("RDP Publisher") or explicit DN notation ("CN=…").
			var subjectDn = nameInput.Contains('=') ? nameInput : $"CN={nameInput}";

			if (_password.Text != _passwordConfirm.Text)
				throw new InvalidOperationException("Passwords do not match.");

			var pfxPath = _pfxPath.Text.Trim();
			if (string.IsNullOrEmpty(pfxPath))
				throw new InvalidOperationException("Choose an output .pfx file path.");

			var dir = Path.GetDirectoryName(Path.GetFullPath(pfxPath));
			if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
				throw new InvalidOperationException($"Output directory does not exist: {dir}");

			_generate.Enabled = false;
			FormHelpers.AppendLog(_log, $"Generating self-signed cert: subject={subjectDn}, validity={(int)_years.Value} year(s)…");

			using var cert = CertGenerator.CreateSelfSignedCodeSigningCert(subjectDn, (int)_years.Value);

			File.WriteAllBytes(pfxPath, cert.Export(X509ContentType.Pfx, string.IsNullOrEmpty(_password.Text) ? null : _password.Text));
			FormHelpers.AppendLog(_log, $"Wrote PFX: {pfxPath}");

			if (_alsoCer.Checked)
			{
				var cerPath = Path.ChangeExtension(pfxPath, ".cer");
				File.WriteAllBytes(cerPath, cert.Export(X509ContentType.Cert));
				FormHelpers.AppendLog(_log, $"Wrote CER: {cerPath}");
			}

			FormHelpers.AppendLog(_log, $"Subject:    {cert.Subject}");
			FormHelpers.AppendLog(_log, $"Thumbprint: {cert.Thumbprint}");
			FormHelpers.AppendLog(_log, $"Valid:      {cert.NotBefore:u}  →  {cert.NotAfter:u}");
			FormHelpers.AppendLog(_log, "Done. Switch to the Import & Trust tab to install this cert into the Windows certificate stores.");
		}
		catch (Exception ex)
		{
			FormHelpers.AppendError(_log, ex.Message);
			MessageBox.Show(this, ex.Message, "Generate failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			_generate.Enabled = true;
		}
	}
}

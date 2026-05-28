using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using RdpSigner.Core;

namespace RdpSigner;

public partial class ImportTrustTab : UserControl
{
	public ImportTrustTab()
	{
		InitializeComponent();
	}

	private void OnBrowseCertClicked(object? sender, EventArgs e)
	{
		using var ofd = new OpenFileDialog
		{
			Filter = "Certificate files (*.pfx;*.cer;*.crt;*.p12)|*.pfx;*.cer;*.crt;*.p12|All files (*.*)|*.*",
		};
		if (ofd.ShowDialog(this) == DialogResult.OK)
		{
			_certPath.Text = ofd.FileName;
			UpdateFieldsForFileType();
		}
	}

	private void OnCertPathChanged(object? sender, EventArgs e) => UpdateFieldsForFileType();

	private void UpdateFieldsForFileType()
	{
		var isPfx = IsPfx(_certPath.Text);
		_password.Enabled = isPfx;
		_storeMy.Enabled = isPfx;
		if (!isPfx) _storeMy.Checked = false;
	}

	private static bool IsPfx(string path)
	{
		var ext = Path.GetExtension(path);
		return string.Equals(ext, ".pfx", StringComparison.OrdinalIgnoreCase)
			|| string.Equals(ext, ".p12", StringComparison.OrdinalIgnoreCase);
	}

	private void OnImportClicked(object? sender, EventArgs e)
	{
		try
		{
			var path = _certPath.Text.Trim();
			if (string.IsNullOrEmpty(path) || !File.Exists(path))
				throw new InvalidOperationException("Choose an existing certificate file.");

			var location = _scopeLocalMachine.Checked ? StoreLocation.LocalMachine : StoreLocation.CurrentUser;

			var stores = new List<StoreName>();
			if (_storeTrustedPublisher.Checked) stores.Add(StoreName.TrustedPublisher);
			if (_storeRoot.Checked) stores.Add(StoreName.Root);
			if (_storeMy.Checked && _storeMy.Enabled) stores.Add(StoreName.My);

			if (stores.Count == 0)
				throw new InvalidOperationException("Pick at least one destination store.");

			_import.Enabled = false;
			FormHelpers.AppendLog(_log, $"Loading certificate: {path}");

			using var cert = CertInstaller.LoadCertFromFile(path, string.IsNullOrEmpty(_password.Text) ? null : _password.Text, location);
			FormHelpers.AppendLog(_log, $"Subject:    {cert.Subject}");
			FormHelpers.AppendLog(_log, $"Thumbprint: {cert.Thumbprint}");
			FormHelpers.AppendLog(_log, $"Has private key: {cert.HasPrivateKey}");

			foreach (var s in stores)
			{
				CertInstaller.InstallCert(cert, location, new[] { s });
				FormHelpers.AppendLog(_log, $"Installed into {location}\\{s}");
			}

			if (_trustPolicy.Checked)
			{
				CertTrust.AddTrustedThumbprint(cert.Thumbprint, localMachine: location == StoreLocation.LocalMachine);
				var hive = location == StoreLocation.LocalMachine ? "HKLM" : "HKCU";
				FormHelpers.AppendLog(_log, $"Added thumbprint to {hive}\\Software\\Policies\\Microsoft\\Windows NT\\Terminal Services\\TrustedCertThumbprints");
				FormHelpers.AppendLog(_log, "Signed RDP files from this certificate will now open with NO security warning.");
			}
			else
			{
				FormHelpers.AppendLog(_log, "Done. Signed RDP files will show a verified-publisher warning (not the red unknown-publisher warning).");
			}
		}
		catch (UnauthorizedAccessException)
		{
			var msg = "Access denied. Please try running this app as administrator.";
			FormHelpers.AppendError(_log, msg);
			MessageBox.Show(this, msg, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		catch (CryptographicException ex) when ((uint)ex.HResult == 0x80070005) // E_ACCESSDENIED
		{
			var msg = "Access denied. To install into LocalMachine stores, re-launch the app as administrator.";
			FormHelpers.AppendError(_log, msg);
			MessageBox.Show(this, msg, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		catch (CryptographicException ex)
		{
			FormHelpers.AppendError(_log, ex.Message);
			MessageBox.Show(this, ex.Message, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		catch (Exception ex)
		{
			FormHelpers.AppendError(_log, ex.Message);
			MessageBox.Show(this, ex.Message, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		finally
		{
			_import.Enabled = true;
		}
	}
}

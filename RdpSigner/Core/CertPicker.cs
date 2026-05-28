using System.Security.Cryptography.X509Certificates;

namespace RdpSigner.Core;

internal static class CertPicker
{
    private const string CodeSigningOid = "1.3.6.1.5.5.7.3.3";

    public static X509Certificate2? PickCodeSigningCert(IWin32Window owner)
    {
        var candidates = new X509Certificate2Collection();
        AddSigningCertsFrom(candidates, StoreLocation.CurrentUser);
        AddSigningCertsFrom(candidates, StoreLocation.LocalMachine);

        if (candidates.Count == 0)
        {
            MessageBox.Show(
                owner,
                "No code-signing certificates with a private key were found in CurrentUser\\My or LocalMachine\\My.\n\n" +
                "Generate one on the Generate tab, then install it via the Import & Trust tab.",
                "No certificates available",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return null;
        }

        var selected = X509Certificate2UI.SelectFromCollection(
            candidates,
            "Select a code-signing certificate",
            "Pick the certificate to use for signing the RDP file.",
            X509SelectionFlag.SingleSelection,
            owner.Handle);

        return selected.Count > 0 ? selected[0] : null;
    }

    private static void AddSigningCertsFrom(X509Certificate2Collection target, StoreLocation location)
    {
        try
        {
            using var store = new X509Store(StoreName.My, location);
            store.Open(OpenFlags.ReadOnly);
            var now = DateTime.Now;
            foreach (var cert in store.Certificates)
            {
                if (!cert.HasPrivateKey) continue;
                if (cert.NotBefore > now || cert.NotAfter < now) continue;
                if (!HasCodeSigningEku(cert)) continue;
                target.Add(cert);
            }
        }
        catch (System.Security.Cryptography.CryptographicException)
        {
            // Store unavailable (e.g. LocalMachine on a restricted account) — skip silently.
        }
    }

    private static bool HasCodeSigningEku(X509Certificate2 cert)
    {
        foreach (var ext in cert.Extensions)
        {
            if (ext is X509EnhancedKeyUsageExtension eku)
            {
                foreach (var oid in eku.EnhancedKeyUsages)
                {
                    if (oid.Value == CodeSigningOid) return true;
                }
            }
        }
        return false;
    }
}

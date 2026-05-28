using System.Security.Cryptography.X509Certificates;

namespace RdpSigner.Core;

internal static class CertInstaller
{
    public static void InstallCert(
        X509Certificate2 cert,
        StoreLocation location,
        IEnumerable<StoreName> stores)
    {
        foreach (var storeName in stores)
        {
            using var store = new X509Store(storeName, location);
            store.Open(OpenFlags.ReadWrite);
            store.Add(cert);
        }
    }

    public static X509Certificate2 LoadCertFromFile(string path, string? pfxPassword, StoreLocation targetLocation)
    {
        var ext = Path.GetExtension(path);
        if (string.Equals(ext, ".pfx", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(ext, ".p12", StringComparison.OrdinalIgnoreCase))
        {
            var flags = X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable;
            flags |= targetLocation == StoreLocation.LocalMachine
                ? X509KeyStorageFlags.MachineKeySet
                : X509KeyStorageFlags.UserKeySet;

            return X509CertificateLoader.LoadPkcs12FromFile(path, pfxPassword, flags);
        }

        return X509CertificateLoader.LoadCertificateFromFile(path);
    }
}

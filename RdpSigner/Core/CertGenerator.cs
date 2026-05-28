using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace RdpSigner.Core;

internal static class CertGenerator
{
    private const string CodeSigningOid = "1.3.6.1.5.5.7.3.3";

    public static X509Certificate2 CreateSelfSignedCodeSigningCert(
        string subjectName,
        int validityYears,
        int keySize = 2048)
    {
        if (string.IsNullOrWhiteSpace(subjectName))
            throw new ArgumentException("Subject name is required.", nameof(subjectName));
        if (validityYears < 1)
            throw new ArgumentOutOfRangeException(nameof(validityYears), "Must be at least 1 year.");

        using var rsa = RSA.Create(keySize);

        var req = new CertificateRequest(
            subjectName,
            rsa,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1);

        req.CertificateExtensions.Add(
            new X509EnhancedKeyUsageExtension(
                new OidCollection { new Oid(CodeSigningOid) },
                critical: true));

        req.CertificateExtensions.Add(
            new X509KeyUsageExtension(
                X509KeyUsageFlags.DigitalSignature,
                critical: true));

        req.CertificateExtensions.Add(
            new X509BasicConstraintsExtension(
                certificateAuthority: false,
                hasPathLengthConstraint: false,
                pathLengthConstraint: 0,
                critical: true));

        req.CertificateExtensions.Add(
            new X509SubjectKeyIdentifierExtension(req.PublicKey, critical: false));

        var notBefore = DateTimeOffset.UtcNow.AddMinutes(-5);
        var notAfter = notBefore.AddYears(validityYears);

        return req.CreateSelfSigned(notBefore, notAfter);
    }
}

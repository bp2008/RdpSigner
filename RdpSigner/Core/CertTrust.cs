using Microsoft.Win32;

namespace RdpSigner.Core;

internal static class CertTrust
{
    // GPO: "Specify SHA1 thumbprints of certificates representing trusted .rdp publishers."
    // When the signing cert's thumbprint appears here, signed .rdp files open with NO
    // "Do you trust this remote connection?" warning at all — not even the yellow
    // verified-publisher version. The value is a REG_SZ list of 40-char uppercase
    // hex SHA-1 thumbprints separated by semicolons.
    private const string PolicySubKey = @"Software\Policies\Microsoft\Windows NT\Terminal Services";
    private const string TrustedThumbprintsValue = "TrustedCertThumbprints";

    public static void AddTrustedThumbprint(string thumbprint, bool localMachine)
    {
        if (string.IsNullOrWhiteSpace(thumbprint))
            throw new ArgumentException("Thumbprint is required.", nameof(thumbprint));

        var normalized = Normalize(thumbprint);
        var root = localMachine ? Registry.LocalMachine : Registry.CurrentUser;

        using var key = root.CreateSubKey(PolicySubKey, writable: true)
            ?? throw new InvalidOperationException(
                $"Could not open or create registry key: {(localMachine ? "HKLM" : "HKCU")}\\{PolicySubKey}");

        var existing = key.GetValue(TrustedThumbprintsValue) as string;
        var entries = Parse(existing);

        if (!entries.Contains(normalized, StringComparer.OrdinalIgnoreCase))
            entries.Add(normalized);

        key.SetValue(TrustedThumbprintsValue, string.Join(";", entries), RegistryValueKind.String);
    }

    private static string Normalize(string thumbprint)
    {
        Span<char> buffer = stackalloc char[thumbprint.Length];
        var len = 0;
        foreach (var c in thumbprint)
        {
            if (!char.IsWhiteSpace(c)) buffer[len++] = char.ToUpperInvariant(c);
        }
        return new string(buffer[..len]);
    }

    private static List<string> Parse(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new List<string>();

        return value
            .Split(new[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => Normalize(s))
            .Where(s => s.Length > 0)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
    }
}

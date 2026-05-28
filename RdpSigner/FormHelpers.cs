namespace RdpSigner;

internal static class FormHelpers
{
    public static void AppendLog(TextBox log, string message)
    {
        log.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
    }

    public static void AppendError(TextBox log, string message)
    {
        log.AppendText($"[{DateTime.Now:HH:mm:ss}] ERROR: {message}{Environment.NewLine}");
    }
}

using System.Diagnostics;
using System.Text;

namespace RdpSigner.Core;

internal static class RdpSign
{
    public record SignResult(int ExitCode, string StdOut, string StdErr, string ExecutablePath);

    public static SignResult Sign(string thumbprint, string rdpFilePath)
    {
        if (string.IsNullOrWhiteSpace(thumbprint))
            throw new ArgumentException("Thumbprint is required.", nameof(thumbprint));
        if (!File.Exists(rdpFilePath))
            throw new FileNotFoundException("RDP file not found.", rdpFilePath);

        var rdpsign = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.System),
            "rdpsign.exe");

        if (!File.Exists(rdpsign))
            throw new FileNotFoundException(
                $"rdpsign.exe was not found at {rdpsign}. It ships with Windows; check the System32 directory.",
                rdpsign);

        var psi = new ProcessStartInfo
        {
            FileName = rdpsign,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
        };
        psi.ArgumentList.Add("/sha256");
        psi.ArgumentList.Add(thumbprint);
        psi.ArgumentList.Add(rdpFilePath);

        var stdout = new StringBuilder();
        var stderr = new StringBuilder();

        using var proc = new Process { StartInfo = psi };
        proc.OutputDataReceived += (_, e) => { if (e.Data != null) stdout.AppendLine(e.Data); };
        proc.ErrorDataReceived += (_, e) => { if (e.Data != null) stderr.AppendLine(e.Data); };

        proc.Start();
        proc.BeginOutputReadLine();
        proc.BeginErrorReadLine();
        proc.WaitForExit();

        return new SignResult(proc.ExitCode, stdout.ToString(), stderr.ToString(), rdpsign);
    }
}

using System;
using System.Diagnostics;

namespace backMeUp
{
    public class CommandOutput
    {
        public int code { get; private set; } = 0;
        public string stdOut { get; private set; } = String.Empty;
        public string stdErr { get; private set; } = String.Empty;

        public CommandOutput(Process p)
        {
            stdOut = p.StandardOutput.ReadToEnd();
            stdErr = p.StandardError.ReadToEnd();
            code   = p.ExitCode;
        }

        public bool success()
        {
            return code == 0;
        }

        public override string ToString()
        {
            return $"Standard Output: {stdOut}\nStandard Error: {stdErr}\nCode: {code}";
        }
    }
}
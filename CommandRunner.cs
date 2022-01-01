using System;
using System.Diagnostics;

namespace backMeUp
{
    public class CommandRunner
    {
        public static CommandOutput run(string command)
        {
            var x = new Process()
            {
                StartInfo =
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    FileName = "bash",
                    Arguments = $"-c \"{command}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };

            x.Start();
            x.WaitForExit();

            return new CommandOutput(x);
        }

        public static CommandOutput watchFile(string path)
        {
            return run($"inotifywait -e modify {path}");
        }
    }
}
using System;
using System.Threading;

namespace backMeUp
{
    public class WatchedDirectory : Watched
    {
        public WatchedDirectory(string path) : base(path) {}

        protected override void watch()
        {
            Console.WriteLine($"Started watching for {targetPath}.");
            int changeCount = 1;
            while (true)
            {
                var output = CommandRunner.watchFile(targetPath);
                Console.WriteLine($"Directory {targetPath} changed for the {changeCount++} time. Backing up…");
                Thread.Sleep(8000);
                Backup.backupDirectory(targetPath);
                Console.WriteLine($"Directory {targetPath} backed up successfully!");
            }
        }
    }
}
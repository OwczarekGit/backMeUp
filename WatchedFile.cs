using System;
using System.Threading;

namespace backMeUp
{
    public class WatchedFile : Watched
    {
        public WatchedFile(string path) : base(path) {}

        protected override void watch()
        {
            Console.WriteLine($"Started watching for {targetPath}.");
            int changeCount = 1;
            while (true)
            {
                var output = CommandRunner.watchFile(targetPath);
                Console.WriteLine($"File {targetPath} changed for the {changeCount++} time. Backing up…");
                Thread.Sleep(8000);
                Backup.backupFile(targetPath);
                Console.WriteLine($"File {targetPath} backed up successfully!");
            }
        }
    }
}

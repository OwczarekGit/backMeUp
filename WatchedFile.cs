using System;
using System.IO;
using System.Threading;

namespace backMeUp
{
    public class WatchedFile
    {
        public string filePath { get; private set; } = String.Empty;
        public Thread worker;
        
        public WatchedFile(string path)
        {
            filePath = path;
        }

        public void start()
        {
            worker = new Thread(watch);
            worker.Start();
        }

        private void watch()
        {
            Console.WriteLine($"Started watching for {filePath}.");
            int changeCount = 1;
            while (true)
            {
                var output = CommandRunner.watchFile(filePath);
                Console.WriteLine($"File {filePath} changed for the {changeCount++} time. Backing up…");
                Backup.backupFile(filePath);
                Console.WriteLine($"File {filePath} backed up successfully!");
            }
        }
    }
}
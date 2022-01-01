using System;
using System.IO;
using System.Linq;

namespace backMeUp
{
    public class Backup
    {
        public static string BACKUP_DIR = Directory.GetCurrentDirectory() + "/backups";
            
        
        public static bool backupFile(string path)
        {
            if (!Directory.Exists(BACKUP_DIR))
                Directory.CreateDirectory(BACKUP_DIR);
            
            var now = DateTime.Now;
            var hours = now.ToString("HH");
            var minutes = now.ToString("mm");
            var seconds = now.ToString("ss");
            var day = now.ToString("dd");
            var month = now.ToString("MM");
            var year = now.ToString("yyyy");

            var formated = $"{hours}.{minutes}.{seconds}-{day}.{month}.{year}";

            var split = path.Split("/");
            var name = split.LastOrDefault();
            var outputName = $"{formated}-{name}";
            
            File.Copy(path, $"{BACKUP_DIR}/{outputName}");
            
            return true;
        }

        public static bool backupDirectory(string path)
        {
            if (!Directory.Exists(BACKUP_DIR))
                Directory.CreateDirectory(BACKUP_DIR);

            var now = DateTime.Now;
            var hours = now.ToString("HH");
            var minutes = now.ToString("mm");
            var seconds = now.ToString("ss");
            var day = now.ToString("dd");
            var month = now.ToString("MM");
            var year = now.ToString("yyyy");

            var formated = $"{hours}.{minutes}.{seconds}-{day}.{month}.{year}";

            var split = path.Trim().Split("/");
            var name = split.LastOrDefault();
            var archiveName = $"{formated}-{name}";

            var compressed = CommandRunner.compressDirectory(path, archiveName);

            if (compressed.success())
                File.Move($"{archiveName}.tar.gz", $"{BACKUP_DIR}/{archiveName}.tar.gz");

            return true;
        }
    }
}
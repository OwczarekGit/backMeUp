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
            var hours = now.Hour;
            var minutes = now.Minute;
            var seconds = now.Second;
            var day = now.Day;
            var month = now.Month;
            var year = now.Year;

            var formated = $"{hours}-{minutes}-{seconds}-{day}-{month}-{year}";

            var split = path.Split("/");
            var name = split.LastOrDefault();
            var outputName = $"{name}.{formated}";
            
            File.Copy(path, $"{BACKUP_DIR}/{outputName}");
            
            return true;
        }
    }
}
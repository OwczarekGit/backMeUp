using System.IO;

namespace backMeUp
{
    public class Utils
    {
        public static bool isDirectory(string path)
        {
            var attrs = File.GetAttributes(path);
            if (attrs.HasFlag(FileAttributes.Directory))
                return true;

            return false;
        }

        public static bool isFile(string path)
        {
            return !isDirectory(path);
        }
    }
}
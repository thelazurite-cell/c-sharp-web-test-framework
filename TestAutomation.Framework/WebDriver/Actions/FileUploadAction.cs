using System.IO;
using System.Text;
using Coypu;

namespace TestAutomation.Framework.WebDriver.Actions
{
    public static class FileUploadAction
    {
        public static string BrowserDownloadDirectory { get; set; } = @"C:\Downloads";

        public static void SaveFile(int sizeInMb, string fullPath, string contents)
        {
            using (var fs = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                fs.Write(Encoding.UTF8.GetBytes(contents), 0, contents.Length);
                fs.SetLength(1024 * 1024 * sizeInMb);
                fs.Close();
            }
        }

        public static void DeleteFile(string fullPath)
        {
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }

        public static void DeleteDownloadedFile(string fileName) => DeleteFile(GetDownloadFullPath(fileName));

        public static bool DownloadedFile(this Scope browser, string fileName, bool shouldBeEmpty = false)
        {
            var fullPath = GetDownloadFullPath(fileName);

            return File.Exists(fullPath) && (new FileInfo(fullPath).Length > 0 && !shouldBeEmpty);
        }

        private static string GetDownloadFullPath(string fileName)
        {
            return Path.Combine(BrowserDownloadDirectory, fileName);
        }
    }
}
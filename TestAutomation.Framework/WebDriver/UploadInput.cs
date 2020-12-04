using System.IO;
using Coypu;
using TestAutomation.Framework.ClassExtenders;
using TestAutomation.Framework.Configuration;
using TestAutomation.Framework.WebDriver.Actions;
using TestAutomation.Framework.WebDriver.Interfaces;

namespace TestAutomation.Framework.WebDriver
{
    using static ElementLocator;
    using static ConfigurationSingleton;

    /// <summary>
    /// The HTML File Uploader - the default specification for uploading a file
    /// </summary>
    public class UploadInput : DomObject, IFileUploader
    {
        public UploadInput(Locator locator, Scope scope, bool wait = true)
            : base(locator, scope, wait) { }

        /// <summary>
        /// Gets the accepted limit for file size
        /// </summary>
        public static int FileSizeLimit
        {
            get
            {
                int.TryParse(Config.GetAppContextItem("MaxUploadSizeInMb"), out var maxSize);
                return maxSize;
            }
        }

        /// <inheritdoc />
        public void UploadFile(int sizeInMb, string fileName = "generic-document.txt")
        {
            var uploader = Locate(this.Locator);
            var fullPath = Path.Combine(Path.GetTempPath(), fileName);
            var contents = $"This is a generic text file";

            FileUploadAction.SaveFile(sizeInMb, fullPath, contents);

            uploader.SendKeys(fullPath);

            if (!this.Wait) return;
            if (this.Scope is BrowserSession browser)
            {
                browser.WaitForAjax();
            }
        }
    }
}
namespace TestAutomation.Framework.WebDriver.Interfaces
{
    /// <summary>
    /// The File Uploader interface, used by tests to send a file to the remote server.
    /// </summary>
    public interface IFileUploader
    {
        /// <summary>
        /// Uploads a file to the remote server.
        /// </summary>
        /// <param name="sizeInMb">sets the file's size to a fixed value.</param>
        /// <param name="fileName">the filename to use</param>
        void UploadFile(int sizeInMb, string fileName = "generic-document.txt");
    }
}
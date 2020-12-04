namespace TestAutomation.Framework.Configuration
{
    public class FrameworkOptions
    {
        public int MaxAjaxCallWaitInSeconds { get; set; }
        public int MaxPageLoadWaitInSeconds { get; set; }
        public int MaxExplicitWaitInSeconds { get; set; }
        public string Browser { get; set; }
        public bool Ssl { get; set; }
        public int Port { get; set; }
        public bool Headless { get; set; }
    }
}
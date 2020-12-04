namespace TestAutomation.Framework.Configuration
{
    /// <summary>
    /// The test run item class - Describes a test or test suite.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class TestCategory
    {
        /// <summary>
        /// Gets or sets the tag for a test run item.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a test item should run.
        /// </summary>
        public bool ShouldRun { get; set; }

        /// <summary>
        /// Gets or sets a value stating why a test is disabled.
        /// </summary>
        public string Because { get; set; }
    }
}
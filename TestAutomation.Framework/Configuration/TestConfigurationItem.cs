namespace TestAutomation.Framework.Configuration
{
    /// <summary>
    /// The configuration class.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global - Class gets serialized dynamically
    public class TestConfigurationItem
    {
        /// <summary>
        /// Gets or sets the tag
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }
    }
}
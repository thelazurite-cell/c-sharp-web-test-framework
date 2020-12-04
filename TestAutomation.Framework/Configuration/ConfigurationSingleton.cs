using System;
using System.IO;
using System.Reflection;
using JsonFx.Json;
using TestAutomation.Framework.Configuration.Interfaces;

namespace TestAutomation.Framework.Configuration
{
    /// <summary>
    /// The test configuration repository - used by the feature tests to determine which tests should run.
    /// configuration is available currently.
    /// </summary>
    public static class ConfigurationSingleton
    {
        /// <summary>
        /// Gets the constant value for file name.
        /// </summary>
        public const string FileName = "framework-configuration.json";

        /// <summary>
        /// Initializes static members of the <see cref="ConfigurationSingleton"/> class.
        /// </summary>
        static ConfigurationSingleton()
        {
            Config = ReadConfiguration();
        }

        /// <summary>
        /// Gets an instance of the test configuration.
        /// </summary>
        public static IFrameworkConfiguration Config { get; }

        private static JsonFrameworkConfiguration ReadConfiguration()
        {
            return ReadTestConfiguration(IfItExists());
        }

        private static JsonFrameworkConfiguration ReadTestConfiguration(string path)
        {
            return new JsonReader().Read<JsonFrameworkConfiguration>(File.ReadAllText(path));
        }

        private static string IfItExists()
        {
            var path = Path.Combine(
                Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location) ??
                throw new InvalidOperationException("Could not find the configuration location"),
                FileName);

            if (!File.Exists(path))
            {
                throw new InvalidOperationException("Could not find the configuration file.");
            }

            return path;
        }
    }
}
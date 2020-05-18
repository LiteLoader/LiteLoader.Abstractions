using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LiteLoader.Plugins
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginInfoAttribute : Attribute
    {
        /// <summary>
        /// Human readable plugin name
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Author of the plugin
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Version of the plugin
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// Force the plugin loader to load this plugin on the game thread
        /// </summary>
        public bool ForceSyncronousLoad { get; set; } = false;

        /// <summary>
        /// Defines plugin information
        /// </summary>
        /// <param name="title"><see cref="Title"/></param>
        /// <param name="author"><see cref="Author"/></param>
        /// <param name="version"><see cref="Version"/></param>
        public PluginInfoAttribute(string title, string author, string version)
        {
            Title = string.IsNullOrEmpty(title) ? throw new ArgumentNullException(nameof(title)) : title;
            Author = string.IsNullOrEmpty(author) ? throw new ArgumentNullException(nameof(author)) : author;

            if (string.IsNullOrEmpty(version))
            {
                throw new ArgumentNullException(nameof(version));
            }

            string[] vSplit = version.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (vSplit.Length == 0)
            {
                throw new ArgumentNullException(nameof(version));
            }

            if (vSplit.Length > 4 || !Enumerable.All(vSplit, v => Regex.IsMatch(v, @"\d+")))
            {
                throw new ArgumentException("Version number does not meet semantic versioning standards");
            }

            Version = new Version(version);
        }

        /// <summary>
        /// Defines plugin information
        /// </summary>
        /// <param name="title"><see cref="Title"/></param>
        /// <param name="author"><see cref="Author"/></param>
        /// <param name="version"><see cref="Version"/></param>
        public PluginInfoAttribute(string title, string author, double version) : this(title, author, version.ToString("0.##"))
        {
        }
    }
}

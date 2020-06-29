using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LiteLoader.Modules
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ModuleInfoAttribute : Attribute
    {
        /// <summary>
        /// Author of the module
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Force the module loader to load this module on the game thread
        /// </summary>
        public bool ForceSyncronousLoad { get; set; } = false;

        /// <summary>
        /// Human readable module name
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Version of the module
        /// </summary>
        public Version Version { get; }

        /// <summary>
        /// Defines module information
        /// </summary>
        /// <param name="title"><see cref="Title"/></param>
        /// <param name="author"><see cref="Author"/></param>
        /// <param name="version"><see cref="Version"/></param>
        public ModuleInfoAttribute(string title, string author, string version)
        {
            Title = string.IsNullOrEmpty(title) ? null : title;
            Author = string.IsNullOrEmpty(author) ? null : author;

            if (string.IsNullOrEmpty(version))
            {
                version = null;
                return;
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
        /// Defines module information
        /// </summary>
        /// <param name="title"><see cref="Title"/></param>
        /// <param name="author"><see cref="Author"/></param>
        /// <param name="version"><see cref="Version"/></param>
        public ModuleInfoAttribute(string title, string author, double version) : this(title, author, version.ToString("0.##"))
        {
        }
    }
}

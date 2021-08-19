using System.IO;
using System.Reflection;

namespace Instil.Poker.Core.Tests.Utils
{
    internal static class AssetUtils
    {
        /// <summary>
        /// Get file path of Asset.
        /// </summary>
        /// <param name="fileName">File Name of Asset to retrieve path for.</param>
        /// <returns>Filepath of defined Asset.</returns>
        public static string GetPath(string fileName)
        {
            var currentAssemblyPath = GetAssetsPath();
            return Path.Combine(currentAssemblyPath, "Assets", fileName);
        }

        /// <summary>
        /// Get file path of Assets folder.
        /// </summary>
        /// <returns>Filepath of Assets folder.</returns>
        public static string GetAssetsPath()
        {
            var currentAssembly = Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(currentAssembly);
        }
    }
}
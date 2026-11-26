using System;
using System.IO;
namespace Math4Kid
{
    internal static class AssetPaths
    {
        internal static Uri Image(string path) => new Uri("pack://application:,,,/Math4Kid;component/" + path.TrimStart('/'), UriKind.Absolute);
        internal static Uri Sound(string path) => new Uri(Path.Combine(AppContext.BaseDirectory, path.TrimStart('/').Replace('/', Path.DirectorySeparatorChar)), UriKind.Absolute);
    }
}

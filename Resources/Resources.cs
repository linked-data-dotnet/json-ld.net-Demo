using System.Reflection;
using System.IO;

namespace JsonLD.Demo.Resources
{

    internal static class Resources
    {

        private static readonly Assembly _thisAssembly = typeof(Resources).GetTypeInfo().Assembly;
        public static string ReadString(string name)
        {
            var resourceName = $"{nameof(JsonLD)}.{nameof(Demo)}.{nameof(Resources)}.{name}";
            using var resourceStream = _thisAssembly.GetManifestResourceStream(resourceName);
            using var streamReader = new StreamReader(resourceStream);
            return streamReader.ReadToEnd();
        }
    }
}
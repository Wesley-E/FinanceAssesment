using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace FinanceAssessment.Configuration
{
    public class AppSettingsManager
    {
        private static AppSettingsManager _instance;
        private readonly JObject _secrets;
        private const string Namespace = "FinanceAssessment.Configuration";
        private const string Filename = "appsettings.json";

        public AppSettingsManager()
        {
            var assembly = typeof(AppSettingsManager).GetTypeInfo().Assembly;
            var output = this.GetType().Assembly.GetManifestResourceNames();
            var stream = assembly.GetManifestResourceStream($"{Namespace}.{Filename}");
            using var reader = new StreamReader(stream ?? throw new 
                FileNotFoundException($"{Filename} not found in {Namespace}"));
            var json = reader.ReadToEnd();
            _secrets = JObject.Parse(json);
        }

        public static AppSettingsManager Settings => _instance ??= new AppSettingsManager();

        public string this[string name]
        {
            get
            {
                try
                {
                    var path = name.Split(":");
                    var node = _secrets[path[0]];
                    for (var index = 1; index < path.Length; index++)
                    {
                        node = node?[path[index]];
                    }

                    return node?.ToString();
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

    }
}
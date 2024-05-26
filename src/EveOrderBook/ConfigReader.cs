using System.Text.Json;

namespace EveOrderBook
{
    internal static class ConfigReader
    {
        public static Config Read(string configPath) {
            JsonSerializerOptions options = new JsonSerializerOptions {
                AllowTrailingCommas = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
            };

            using FileStream configStream = File.OpenRead(configPath);
            Config config = JsonSerializer.Deserialize<Config>(configStream, options);
            return config;
        }
    }
}

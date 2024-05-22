using System.Text.Json;

namespace EveOrderBook
{
    internal static class ConfigReader
    {
        public static Config Read(string configPath) {
            using FileStream configStream = File.OpenRead(configPath);
            Config config = JsonSerializer.Deserialize<Config>(configStream);
            return config;
        }
    }
}

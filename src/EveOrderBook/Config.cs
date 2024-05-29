using System.Text.Json;

namespace EveOrderBook;

internal readonly struct Config
{
    public static readonly string DefaultConfigPath = Path.Combine(Directory.GetCurrentDirectory(), "Config.json");

    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions {
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };

    public static Config Read(FileInfo configFile) {
        using FileStream configStream = configFile.OpenRead();
        Config config = JsonSerializer.Deserialize<Config>(configStream, SerializerOptions);
        return config;
    }

    public static Config Read(string configPath) {
        return Read(new FileInfo(configPath));
    }

    public decimal BuyBrokerFee { get; init; }

    public decimal SellBrokerFee { get; init; }

    public decimal SellTax { get; init; }

    public string StationId { get; init; }
}

using System.Text.Json;

namespace EveOrderBook;

internal readonly struct Config
{
    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions {
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };

    public static Config Read(string configPath) {
        using FileStream configStream = File.OpenRead(configPath);
        Config config = JsonSerializer.Deserialize<Config>(configStream, SerializerOptions);
        return config;
    }

    public string StationId { get; init; }

    public decimal BuyBrokerFee { get; init; }

    public decimal SellBrokerFee { get; init; }

    public decimal SellTax { get; init; }

    public string HelpMessageFormat { get; init; }
}

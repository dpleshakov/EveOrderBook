using System.CommandLine;

namespace EveOrderBook;

public class Program
{
    public static async Task<int> Main(string[] args) {
        Option<FileInfo> configFileOption = CommandLine.GetConfigFileOption();
        Option<DirectoryInfo> marketlogsDirectoryOption = CommandLine.GetMarketlogsDirectoryOption();

        RootCommand rootCommand = new RootCommand(CommandLine.Description);
        rootCommand.AddOption(configFileOption);
        rootCommand.AddOption(marketlogsDirectoryOption);

        rootCommand.SetHandler(WatchMarketlogs, configFileOption, marketlogsDirectoryOption);

        return await rootCommand.InvokeAsync(args);
    }

    private static void WatchMarketlogs(FileInfo configFile, DirectoryInfo marketlogsDirectory) {
        Config config = Config.Read(configFile);

        Taxes taxes = new Taxes {
            BuyBrokerFee = config.BuyBrokerFee,
            SellBrokerFee = config.SellBrokerFee,
            SellTax = config.SellTax,
        };

        Marketlogs marketlogs = new Marketlogs(config.StationId, taxes, marketlogsDirectory.FullName);

        marketlogs.WriteProfitMarginToConsole();

        marketlogs.StartWatch();

        Thread.Sleep(Timeout.Infinite);
    }
}

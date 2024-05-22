namespace EveOrderBook
{
    internal class Program
    {
        static void Main() {
            string configFileName = "Config.json";
            string configPath = Path.Combine(Directory.GetCurrentDirectory(), configFileName);

            if (!File.Exists(configPath)) {
                Console.WriteLine($"Error: missing configuration file '{configFileName}'");
            }

            Config config = ConfigReader.Read(configPath);

            Taxes taxes = new Taxes {
                BuyBrokerFee = config.BuyBrokerFee,
                SellBrokerFee = config.SellBrokerFee,
                SellTax = config.SellTax,
            };

            Marketlogs marketlogs = new Marketlogs(config.StationId, taxes);

            marketlogs.WriteProfitMarginToConsole();
            marketlogs.StartWatch();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}

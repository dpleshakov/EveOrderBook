using System.Globalization;

namespace EveOrderBook
{
    internal sealed class Marketlogs
    {
        private readonly Taxes Taxes;

        private readonly string StationId;

        private readonly string SourceMarketlogsDirectory;

        private readonly FileSystemWatcher SourceMarketlogsWatcher;

        public Marketlogs(string statiodId, Taxes taxes, string? sourceMarketlogsDirectory = null) {
            StationId = statiodId;
            Taxes = taxes;

            if (!string.IsNullOrEmpty(sourceMarketlogsDirectory)) {
                SourceMarketlogsDirectory = sourceMarketlogsDirectory;
            }
            else {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                SourceMarketlogsDirectory = Path.Combine(documentsPath, "EVE", "logs", "Marketlogs");
            }

            SourceMarketlogsWatcher = new FileSystemWatcher();

            SourceMarketlogsWatcher.Path = SourceMarketlogsDirectory;
            SourceMarketlogsWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            SourceMarketlogsWatcher.Filter = "*.txt";

            SourceMarketlogsWatcher.Created += new FileSystemEventHandler(OnChanged);
        }

        public void StartWatch() {
            SourceMarketlogsWatcher.EnableRaisingEvents = true;
        }

        public void StopWatch() {
            SourceMarketlogsWatcher.EnableRaisingEvents = false;
        }

        public void WriteProfitMarginToConsole() {
            string? marketlogsPath = GetLastFile(SourceMarketlogsDirectory);
            if (marketlogsPath == null) {
                return;
            }

            IEnumerable<MarketOrder> orders = ReadOrders(marketlogsPath);

            IEnumerable<MarketOrder> buyOrders = FilterBuyOrders(orders);
            IEnumerable<MarketOrder> sellOrders = FilterSellOrders(orders);

            MarketOrder topBuyOrder = buyOrders.OrderByDescending(order => order.Price).First();
            MarketOrder topSellOrder = sellOrders.OrderBy(order => order.Price).First();

            Console.Clear();

            {
                ProfitMargin margin = ProfitMarginCalculator.Calculate(topBuyOrder.Price, topSellOrder.Price, quantity: 1, Taxes);

                Console.WriteLine("Top order, 1 quantity");
                ConsoleWriter.Write(margin);
            }
        }

        private IEnumerable<MarketOrder> FilterBuyOrders(IEnumerable<MarketOrder> orders) {
            IEnumerable<MarketOrder> buyOrder = orders.Where(order => order.Bid == true);
            buyOrder = buyOrder.Where(order => order.StationID == StationId || order.Jumps <= order.Range);

            return buyOrder;
        }

        private IEnumerable<MarketOrder> FilterSellOrders(IEnumerable<MarketOrder> orders) {
            IEnumerable<MarketOrder> sellOrder = orders.Where(order => order.Bid == false);
            sellOrder = sellOrder.Where(order => order.StationID == StationId);

            return sellOrder;
        }

        private void OnChanged(object source, FileSystemEventArgs e) {
            Thread.Sleep(500);
            WriteProfitMarginToConsole();
        }

        private static string? GetLastFile(string directoryPath) {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            IEnumerable<FileInfo> files = directory.GetFiles().OrderByDescending(f => f.LastWriteTime);

            string? lastWriteTimeFilePath = null;
            if (files.Any()) {
                lastWriteTimeFilePath = files.First().FullName;
            }

            return lastWriteTimeFilePath;
        }

        private static IEnumerable<MarketOrder> ReadOrders(string marketlogPath) {
            IEnumerable<string> lines = File.ReadAllLines(marketlogPath);
            lines = lines.Skip(1);

            List<MarketOrder> orders = [];

            foreach (string line in lines) {
                string[] values = line.Split(',');

                MarketOrder order = new() {
                    Price = decimal.Parse(values[0], CultureInfo.InvariantCulture.NumberFormat),
                    VolRemaining = values[1],
                    TypeID = values[2],
                    Range = int.Parse(values[3]),
                    OrderID = values[4],
                    VolEntered = values[5],
                    MinVolume = values[6],
                    Bid = bool.Parse(values[7]),
                    IssueDate = values[8],
                    Duration = values[9],
                    StationID = values[10],
                    RegionID = values[11],
                    SolarSystemID = values[12],
                    Jumps = uint.Parse(values[13]),
                };

                orders.Add(order);
            }

            return orders;
        }
    }
}

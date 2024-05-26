namespace EveOrderBook
{
    internal readonly struct Config
    {
        public string StationId { get; init; }

        public decimal BuyBrokerFee { get; init; }

        public decimal SellBrokerFee { get; init; }

        public decimal SellTax { get; init; }

        public bool SkipHelpMessage {  get; init; }
    }
}

namespace EveOrderBook
{
    public readonly struct Taxes
    {
        public decimal BuyBrokerFee { get; init; }

        public decimal SellBrokerFee { get; init; }

        public decimal SellTax { get; init; }
    }
}

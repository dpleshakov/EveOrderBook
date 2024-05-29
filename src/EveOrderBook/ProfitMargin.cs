namespace EveOrderBook;

public readonly struct ProfitMargin
{
    public Taxes Taxes { get; init; }

    public decimal BuyPrice { get; init; }

    public decimal SellPrice { get; init; }

    public uint Quantity { get; init; }

    public decimal TotalBuyPrice { get; init; }

    public decimal TotalSellPrice { get; init; }

    public decimal Profit { get; init; }

    public decimal Margin { get; init; }

    public ProfitMarginRatio Ratio { get; init; }
}

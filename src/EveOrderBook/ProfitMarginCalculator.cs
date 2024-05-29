namespace EveOrderBook;

public static class ProfitMarginCalculator
{
    public static ProfitMargin Calculate(decimal buyPrice, decimal sellPrice, uint quantity, Taxes taxes) {
        decimal totalBuyPrice = GetTotalBuy(buyPrice, quantity, taxes.BuyBrokerFee);
        decimal totalSellPrice = GetTotalSell(sellPrice, quantity, taxes.SellBrokerFee, taxes.SellTax);
        decimal profit = GetProfit(totalBuyPrice, totalSellPrice);
        decimal profitMargin = GetProfitMargin(totalBuyPrice, profit);
        ProfitMarginRatio profitMarginRatio = GetProfitMarginRatio(profitMargin);

        return new ProfitMargin {
            Taxes = taxes,
            BuyPrice = buyPrice,
            SellPrice = sellPrice,
            Quantity = quantity,
            TotalBuyPrice = totalBuyPrice,
            TotalSellPrice = totalSellPrice,
            Profit = profit,
            Margin = profitMargin,
            Ratio = profitMarginRatio
        };
    }

    private static decimal GetTotalBuy(decimal buyPrice, uint quantity, decimal buyBrokerFee) {
        decimal buyBrokerFeeAmount = buyPrice * quantity * buyBrokerFee / 100m;
        if (buyBrokerFeeAmount < 100m) {
            buyBrokerFeeAmount = 100m;
        }

        decimal totalBuy = buyPrice * quantity + buyBrokerFeeAmount;
        return Math.Round(totalBuy, 2);
    }

    private static decimal GetTotalSell(decimal sellPrice, uint quantity, decimal sellBrokerFee, decimal taxRate) {
        decimal sellBrokerFeeAmount = sellPrice * quantity * sellBrokerFee / 100m;
        if (sellBrokerFeeAmount < 100m) {
            sellBrokerFeeAmount = 100m;
        }

        decimal sellTaxAmount = sellPrice * quantity * taxRate / 100m;

        decimal totalSell = sellPrice * quantity - sellBrokerFeeAmount - sellTaxAmount;
        return Math.Round(totalSell, 2);
    }

    private static decimal GetProfit(decimal totalBuy, decimal totalSell) {
        decimal profit = totalSell - totalBuy;
        return Math.Round(profit, 2);
    }

    private static decimal GetProfitMargin(decimal totalBuy, decimal profit) {
        decimal profitMargin = profit / totalBuy * 100m;
        return Math.Round(profitMargin, 2);
    }

    private static ProfitMarginRatio GetProfitMarginRatio(decimal profitMargin) {
        if (profitMargin < 4) {
            return ProfitMarginRatio.Bad;
        }
        else if (profitMargin >=4 && profitMargin < 10) {
            return ProfitMarginRatio.Normal;
        }
        else if (profitMargin >= 10 && profitMargin < 20) {
            return ProfitMarginRatio.Good;
        }
        else {
            return ProfitMarginRatio.VeryGood;
        }
    }
}

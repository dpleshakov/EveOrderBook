namespace EveOrderBook.Tests;

[TestClass()]
public class ProfitMarginCalculatorTests
{
    [TestMethod()]
    public void MarginKeepBuyPriceUnchanged() {
        Taxes taxes = new Taxes { BuyBrokerFee = 1m, SellBrokerFee = 2m, SellTax = 3m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(10_000m, 20_000m, quantity: 1, taxes);
        Assert.AreEqual(10_000m, actualMargin.BuyPrice);
    }

    [TestMethod()]
    public void MarginKeepSellPriceUnchanged() {
        Taxes taxes = new Taxes { BuyBrokerFee = 1m, SellBrokerFee = 2m, SellTax = 3m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(10_000m, 20_000m, quantity: 1, taxes);
        Assert.AreEqual(20_000m, actualMargin.SellPrice);
    }

    [TestMethod()]
    public void TotalBuyCalculation() {
        Taxes taxes = new Taxes { BuyBrokerFee = 1m, SellBrokerFee = 2m, SellTax = 3m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(10_000m, 20_000m, quantity: 1, taxes);
        Assert.AreEqual(10_100m, actualMargin.TotalBuyPrice);
    }

    [TestMethod()]
    public void TotalBuyAtLeast100() {
        Taxes taxes = new Taxes { BuyBrokerFee = 1m, SellBrokerFee = 2m, SellTax = 3m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(100m, 20_000m, quantity: 1, taxes);
        Assert.AreEqual(200m, actualMargin.TotalBuyPrice);
    }

    [TestMethod()]
    public void TotalBuyWithZeroFee() {
        Taxes taxes = new Taxes { BuyBrokerFee = 0m, SellBrokerFee = 2m, SellTax = 3m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(10_000m, 20_000m, quantity: 1, taxes);
        // Broker fee amount is still 100
        Assert.AreEqual(10_100m, actualMargin.TotalBuyPrice);
    }

    [TestMethod()]
    public void TotalSellCalculation() {
        Taxes taxes = new Taxes { BuyBrokerFee = 1m, SellBrokerFee = 2m, SellTax = 3m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(10_000m, 20_000m, quantity: 1, taxes);
        // Broker fee amount is still 400, tax amount is 600
        Assert.AreEqual(19_000m, actualMargin.TotalSellPrice);
    }

    [TestMethod()]
    public void TotalSellAtLeast100() {
        Taxes taxes = new Taxes { BuyBrokerFee = 1m, SellBrokerFee = 2m, SellTax = 3m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(10_000m, 200m, quantity: 1, taxes);
        // Broker fee amount is still 100, tax amount is 6
        Assert.AreEqual(94m, actualMargin.TotalSellPrice);
    }

    [TestMethod()]
    public void TotalSellWithZeroFee() {
        Taxes taxes = new Taxes { BuyBrokerFee = 1m, SellBrokerFee = 0m, SellTax = 3m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(10_000m, 20_000m, quantity: 1, taxes);
        // Broker fee amount is still 100, tax amount is 600
        Assert.AreEqual(19_300m, actualMargin.TotalSellPrice);
    }

    [TestMethod()]
    public void TotalSellWithZeroTax() {
        Taxes taxes = new Taxes { BuyBrokerFee = 1m, SellBrokerFee = 2m, SellTax = 0m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(10_000m, 20_000m, quantity: 1, taxes);
        // Broker fee amount is 400, tax amount doesn't have minimum value
        Assert.AreEqual(19_600m, actualMargin.TotalSellPrice);
    }

    [TestMethod()]
    public void ProfitCalculation() {
        Taxes taxes = new Taxes { BuyBrokerFee = 1m, SellBrokerFee = 2m, SellTax = 3m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(10_000m, 20_000m, quantity: 1, taxes);
        // Profit = (20_000m - 20_000m * 2% - 20_000m * 3%) - (10_000m + 10_000m * 1%)
        Assert.AreEqual(8_900m, actualMargin.Profit);
    }

    [TestMethod()]
    public void MarginAmountCalculation() {
        Taxes taxes = new Taxes { BuyBrokerFee = 1m, SellBrokerFee = 2m, SellTax = 3m };
        ProfitMargin actualMargin = ProfitMarginCalculator.Calculate(10_000m, 20_000m, quantity: 1, taxes);
        // Margin = 8900 (profit) / 10_100 (total buy)
        Assert.AreEqual(88.12m, actualMargin.Margin);
    }
}
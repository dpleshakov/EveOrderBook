using System.Globalization;
using Spectre;
using Spectre.Console;

namespace EveOrderBook;

public static class ConsoleWriter
{
    public static void Write(ProfitMargin profitMargin) {
        Write(new ProfitMargin[] { profitMargin });
    }

    public static void Write(IEnumerable<ProfitMargin> profitMargins) {
        Table table = new Table();
        table.Border = TableBorder.Horizontal;

        table.AddColumn(new TableColumn("Quantity").RightAligned());
        table.AddColumn(new TableColumn("Margin").Centered());
        table.AddColumn(new TableColumn("Profit").RightAligned());
        table.AddColumn(new TableColumn("Buy Price").RightAligned());
        table.AddColumn(new TableColumn("Buy Total").RightAligned());
        table.AddColumn(new TableColumn("Sell Price").RightAligned());
        table.AddColumn(new TableColumn("Sell Total").RightAligned());

        foreach (ProfitMargin profitMargin in profitMargins) {
            table.AddRow(
                profitMargin.Quantity.ToString("N0"),
                FormatProfitMargin(profitMargin.Margin, profitMargin.Ratio),
                AbbreviateNumber(profitMargin.Profit) + " ISK",
                AbbreviateNumber(profitMargin.BuyPrice) + " ISK",
                AbbreviateNumber(profitMargin.TotalBuyPrice) + " ISK",
                AbbreviateNumber(profitMargin.SellPrice) + " ISK",
                AbbreviateNumber(profitMargin.TotalSellPrice) + " ISK");
        }

        AnsiConsole.Write(table);
    }

    public static string AbbreviateNumber(decimal number) {
        return AbbreviateNumber(number, CultureInfo.CurrentCulture);
    }

    public static string AbbreviateNumber(decimal number, CultureInfo cultureInfo) {
        uint magnitude = 0;

        if (number != 0) {
            decimal absoluteNumber = Math.Abs(number);

            magnitude = (uint)(Math.Log10((double)absoluteNumber) / 3);

            // Limit the magnitude to prevent exceeding 't' suffix.
            magnitude = magnitude > 4 ? 4 : magnitude;
        }

        string suffix = magnitude switch {
            0 => "",   // No suffix for values under one thousand.
            1 => "k",  // 'k' for thousand.
            2 => "m",  // 'm' for million.
            3 => "b",  // 'b' for billion.
            _ => "t",  // 't' for trillion and above.
        };

        decimal divisor = Convert.ToDecimal(Math.Pow(10, magnitude * 3));
        decimal abbreviatedNumber = number / divisor;

        return abbreviatedNumber.ToString("N2", cultureInfo) + suffix;
    }

    public static string FormatProfitMargin(decimal margin, ProfitMarginRatio ratio) {
        string color = ratio switch {
            ProfitMarginRatio.Bad => "red",
            ProfitMarginRatio.Normal => "yellow",
            ProfitMarginRatio.Good => "green",
            ProfitMarginRatio.VeryGood => "lime",
            _ => "red", // Default to red if ratio is not recognized.
        };

        string markdownMargin = $"[{color}]{margin:#,##0.00}%[/]";
        return markdownMargin;
    }
}

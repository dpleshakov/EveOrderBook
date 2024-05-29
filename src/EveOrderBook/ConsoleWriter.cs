using System.Globalization;

namespace EveOrderBook;

public static class ConsoleWriter
{
    private const int FirstColumnLenth = 8;

    private const int SecondColumnLength = 12;

    private const int ThirdColumnLength = 12;

    private const string Separator = " | ";

    private readonly static int FullLength = FirstColumnLenth + SecondColumnLength + ThirdColumnLength + Separator.Length * 2;

    public static void Write(ProfitMargin profitMargin) {
        Console.WriteLine(new String('-', FullLength));

        Console.Write($"{"",FirstColumnLenth}");
        Console.Write(Separator);
        Console.Write($"{"Buy",SecondColumnLength}");
        Console.Write(Separator);
        Console.Write($"{"Sell",ThirdColumnLength}");
        Console.WriteLine();

        Console.WriteLine(new String('-', FullLength));

        Console.Write($"{"Price",FirstColumnLenth}");
        Console.Write(Separator);
        Console.Write($"{ToShortIsk(profitMargin.BuyPrice),SecondColumnLength}");
        Console.Write(Separator);
        Console.Write($"{ToShortIsk(profitMargin.SellPrice),ThirdColumnLength}");
        Console.WriteLine();

        Console.Write($"{"Total",FirstColumnLenth}");
        Console.Write(Separator);
        Console.Write($"{ToShortIsk(profitMargin.TotalBuyPrice),SecondColumnLength}");
        Console.Write(Separator);
        Console.Write($"{ToShortIsk(profitMargin.TotalSellPrice),ThirdColumnLength}");
        Console.WriteLine();

        Console.WriteLine(new String('-', FullLength));

        Console.Write($"{"Profit",FirstColumnLenth}");
        Console.Write(Separator);
        Console.Write($"{ToShortIsk(profitMargin.Profit),SecondColumnLength}");
        Console.Write(Separator);
        Console.Write($"{"",ThirdColumnLength}");
        Console.WriteLine();

        Console.Write($"{"Margin",FirstColumnLenth}");
        Console.Write(Separator);
        WriteProfitMargin(profitMargin.Margin, SecondColumnLength);
        Console.Write(Separator);
        Console.Write($"{"",ThirdColumnLength}");
        Console.WriteLine();
    }

    public static string ToShortIsk(decimal number) {
        return ToShortIsk(number, CultureInfo.CurrentCulture);
    }

    public static string ToShortIsk(decimal number, CultureInfo cultureInfo) {
        string suffix = "";

        if (number >= 1_000m && number < 1_000_000m) {
            suffix = "k";
            number = number / 1_000m;
        }
        else if (number >= 1_000_000m && number < 1_000_000_000m) {
            suffix = "m";
            number = number / 1_000_000m;
        }
        else if (number >= 1_000_000_000m && number < 1_000_000_000_000m) {
            suffix = "b";
            number = number / 1_000_000_000m;
        }
        else if (number >= 1_000_000_000_000m) {
            suffix = "t";
            number = number / 1_000_000_000_000m;
        }

        string numberShortForm = number.ToString("N2", cultureInfo);
        string result = $"{numberShortForm}{suffix} ISK";

        return result;
    }

    private static void WriteProfitMargin(decimal marginAmount, uint lenght) {
        ConsoleColor defaultColor = Console.ForegroundColor;

        if (marginAmount <= 0m) {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (marginAmount > 0m && marginAmount <= 10m) {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if (marginAmount > 10m && marginAmount <= 20m) {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        else {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        Console.Write($"{marginAmount,ThirdColumnLength-1:#,##0.00}%");

        Console.ForegroundColor = defaultColor;
    }
}

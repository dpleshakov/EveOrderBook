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
        Console.Write($"{AbbreviateNumber(profitMargin.BuyPrice),SecondColumnLength} ISK");
        Console.Write(Separator);
        Console.Write($"{AbbreviateNumber(profitMargin.SellPrice),ThirdColumnLength} ISK");
        Console.WriteLine();

        Console.Write($"{"Total",FirstColumnLenth}");
        Console.Write(Separator);
        Console.Write($"{AbbreviateNumber(profitMargin.TotalBuyPrice),SecondColumnLength} ISK");
        Console.Write(Separator);
        Console.Write($"{AbbreviateNumber(profitMargin.TotalSellPrice),ThirdColumnLength} ISK");
        Console.WriteLine();

        Console.WriteLine(new String('-', FullLength));

        Console.Write($"{"Profit",FirstColumnLenth}");
        Console.Write(Separator);
        Console.Write($"{AbbreviateNumber(profitMargin.Profit),SecondColumnLength} ISK");
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

﻿using System.Globalization;

namespace EveOrderBook.Tests;

[TestClass()]
public class ConsoleWriterTests
{
    private static IEnumerable<object[]> AbbreviateNumberTestData {
        get {
            return [
                [ "0.00", 0m ],
                [ "1.00", 1m ],
                [ "99.00", 99m ],
                [ "100.00", 100m ],
                [ "101.00", 101m ],
                [ "234.56", 234.56m ],
                [ "999.00", 999m ],
                [ "1.00k", 1_000m ],
                [ "1.00k", 1_001m ],
                [ "1.01k", 1_010m ],
                [ "1.10k", 1_100m ],
                [ "1.99k", 1_990m ],
                [ "2.00k", 1_999m ],
                [ "9.99k", 9_990m ],
                [ "10.00k", 9_999m ],
                [ "10.00k", 10_000m ],
                [ "10.00k", 10_001m ],
                [ "99.99k", 99_990m ],
                [ "100.00k", 99_999m ],
                [ "100.00k", 100_000m ],
                [ "100.00k", 100_001m ],
                [ "567.89k", 567_890m ],
                [ "999.99k", 999_990m ],
                [ "1.00m", 1_000_000m ],
                [ "1.00m", 1_001_000m ],
                [ "1.01m", 1_010_000m ],
                [ "1.10m", 1_100_000m ],
                [ "1.99m", 1_990_000m ],
                [ "2.00m", 1_999_000m ],
                [ "9.99m", 9_990_000m ],
                [ "10.00m", 9_999_999m ],
                [ "10.00m", 10_000_000m ],
                [ "10.00m", 10_001_000m ],
                [ "99.99m", 99_990_000m ],
                [ "100.00m", 99_999_999m ],
                [ "100.00m", 100_000_000m ],
                [ "100.00m", 100_001_000m ],
                [ "234.56m", 234_560_000m ],
                [ "999.99m", 999_990_000m ],
                [ "1.00b", 1_000_000_000m ],
                [ "1.00b", 1_001_000_000m ],
                [ "1.01b", 1_010_000_000m ],
                [ "1.10b", 1_100_000_000m ],
                [ "1.99b", 1_990_000_000m ],
                [ "2.00b", 1_999_000_000m ],
                [ "9.99b", 9_990_000_000m ],
                [ "10.00b", 9_999_999_999m ],
                [ "10.00b", 10_000_000_000m ],
                [ "10.00b", 10_001_000_000m ],
                [ "99.99b", 99_990_000_000m ],
                [ "100.00b", 99_999_999_999m ],
                [ "100.00b", 100_000_000_000m ],
                [ "100.00b", 100_001_000_000m ],
                [ "234.56b", 234_560_000_000m ],
                [ "999.99b", 999_990_000_000m ],
                [ "1.00t", 1_000_000_000_000m ],
                [ "1.00t", 1_001_000_000_000m ],
                [ "1.01t", 1_010_000_000_000m ],
                [ "1.10t", 1_100_000_000_000m ],
                [ "1.99t", 1_990_000_000_000m ],
                [ "2.00t", 1_999_000_000_000m ],
                [ "9.99t", 9_990_000_000_000m ],
                [ "10.00t", 9_999_999_999_999m ],
                [ "10.00t", 10_000_000_000_000m ],
                [ "10.00t", 10_001_000_000_000m ],
                [ "99.99t", 99_990_000_000_000m ],
                [ "100.00t", 99_999_999_999_999m ],
                [ "100.00t", 100_000_000_000_000m ],
                [ "100.00t", 100_001_000_000_000m ],
                [ "234.56t", 234_560_000_000_000m ],
                [ "999.99t", 999_990_000_000_000m ],
            ];
        }
    }

    [TestMethod()]
    [DynamicData(nameof(AbbreviateNumberTestData))]
    public void TestToAbbreviateNumber(string expectedAbbreviateNumber, decimal inputNumber) {
        string actualAbbreviateNumber = ConsoleWriter.ToAbbreviateNumber(inputNumber, CultureInfo.InvariantCulture);
        Assert.AreEqual(expectedAbbreviateNumber, actualAbbreviateNumber);
    }
}
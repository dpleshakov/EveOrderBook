﻿using System.Globalization;

namespace EveOrderBook.Tests;

[TestClass()]
public class ToShortIskTests
{
    // Decimal type hasn't supported yet, see https://github.com/dotnet/runtime/issues/4525
    [TestMethod()]
    [DataRow("0.00 ISK", "0")]
    [DataRow("1.00 ISK", "1")]
    [DataRow("99.00 ISK", "99")]
    [DataRow("100.00 ISK", "100")]
    [DataRow("101.00 ISK", "101")]
    [DataRow("234.56 ISK", "234.56")]
    [DataRow("999.00 ISK", "999")]
    [DataRow("1.00k ISK", "1000")]
    [DataRow("1.00k ISK", "1001")]
    [DataRow("1.01k ISK", "1010")]
    [DataRow("1.10k ISK", "1100")]
    [DataRow("1.99k ISK", "1990")]
    [DataRow("2.00k ISK", "1999")]
    [DataRow("9.99k ISK", "9990")]
    [DataRow("10.00k ISK", "9999")]
    [DataRow("10.00k ISK", "10000")]
    [DataRow("10.00k ISK", "10001")]
    [DataRow("99.99k ISK", "99990")]
    [DataRow("100.00k ISK", "99999")]
    [DataRow("100.00k ISK", "100000")]
    [DataRow("100.00k ISK", "100001")]
    [DataRow("567.89k ISK", "567890")]
    [DataRow("999.99k ISK", "999990")]
    [DataRow("1.00m ISK", "1000000")]
    [DataRow("1.00m ISK", "1001000")]
    [DataRow("1.01m ISK", "1010000")]
    [DataRow("1.10m ISK", "1100000")]
    [DataRow("1.99m ISK", "1990000")]
    [DataRow("2.00m ISK", "1999000")]
    [DataRow("9.99m ISK", "9990000")]
    [DataRow("10.00m ISK", "9999999")]
    [DataRow("10.00m ISK", "10000000")]
    [DataRow("10.00m ISK", "10001000")]
    [DataRow("99.99m ISK", "99990000")]
    [DataRow("100.00m ISK", "99999999")]
    [DataRow("100.00m ISK", "100000000")]
    [DataRow("100.00m ISK", "100001000")]
    [DataRow("234.56m ISK", "234560000")]
    [DataRow("999.99m ISK", "999990000")]
    [DataRow("1.00b ISK", "1000000000")]
    [DataRow("1.00b ISK", "1001000000")]
    [DataRow("1.01b ISK", "1010000000")]
    [DataRow("1.10b ISK", "1100000000")]
    [DataRow("1.99b ISK", "1990000000")]
    [DataRow("2.00b ISK", "1999000000")]
    [DataRow("9.99b ISK", "9990000000")]
    [DataRow("10.00b ISK", "9999999999")]
    [DataRow("10.00b ISK", "10000000000")]
    [DataRow("10.00b ISK", "10001000000")]
    [DataRow("99.99b ISK", "99990000000")]
    [DataRow("100.00b ISK", "99999999999")]
    [DataRow("100.00b ISK", "100000000000")]
    [DataRow("100.00b ISK", "100001000000")]
    [DataRow("234.56b ISK", "234560000000")]
    [DataRow("999.99b ISK", "999990000000")]
    [DataRow("1.00t ISK", "1000000000000")]
    [DataRow("1.00t ISK", "1001000000000")]
    [DataRow("1.01t ISK", "1010000000000")]
    [DataRow("1.10t ISK", "1100000000000")]
    [DataRow("1.99t ISK", "1990000000000")]
    [DataRow("2.00t ISK", "1999000000000")]
    [DataRow("9.99t ISK", "9990000000000")]
    [DataRow("10.00t ISK", "9999999999999")]
    [DataRow("10.00t ISK", "10000000000000")]
    [DataRow("10.00t ISK", "10001000000000")]
    [DataRow("99.99t ISK", "99990000000000")]
    [DataRow("100.00t ISK", "99999999999999")]
    [DataRow("100.00t ISK", "100000000000000")]
    [DataRow("100.00t ISK", "100001000000000")]
    [DataRow("234.56t ISK", "234560000000000")]
    [DataRow("999.99t ISK", "999990000000000")]
    public void ToShortIsk(string expectedShortIsk, string actualIsk) {
        decimal actualIskValue = decimal.Parse(actualIsk, CultureInfo.InvariantCulture);
        Assert.AreEqual(expectedShortIsk, ConsoleWriter.ToShortIsk(actualIskValue, CultureInfo.InvariantCulture));
    }
}
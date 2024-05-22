namespace EveOrderBook.Tests
{
    [TestClass()]
    public class ToShortIskTests
    {
        [TestMethod()]
        public void ToShortIskLessOneThousand() {
            Assert.AreEqual("0,00 ISK", ConsoleWriter.ToShortIsk(0m));
            Assert.AreEqual("1,00 ISK", ConsoleWriter.ToShortIsk(1m));
            Assert.AreEqual("99,00 ISK", ConsoleWriter.ToShortIsk(99m));
            Assert.AreEqual("100,00 ISK", ConsoleWriter.ToShortIsk(100m));
            Assert.AreEqual("101,00 ISK", ConsoleWriter.ToShortIsk(101m));
            Assert.AreEqual("234,56 ISK", ConsoleWriter.ToShortIsk(234.56m));
            Assert.AreEqual("999,00 ISK", ConsoleWriter.ToShortIsk(999m));
        }

        [TestMethod()]
        public void ToShortIskLessOneMillion() {
            Assert.AreEqual("1,00k ISK", ConsoleWriter.ToShortIsk(1_000m));
            Assert.AreEqual("1,00k ISK", ConsoleWriter.ToShortIsk(1_001m));
            Assert.AreEqual("1,01k ISK", ConsoleWriter.ToShortIsk(1_010m));
            Assert.AreEqual("1,10k ISK", ConsoleWriter.ToShortIsk(1_100m));
            Assert.AreEqual("1,99k ISK", ConsoleWriter.ToShortIsk(1_990m));
            Assert.AreEqual("2,00k ISK", ConsoleWriter.ToShortIsk(1_999m));
            Assert.AreEqual("9,99k ISK", ConsoleWriter.ToShortIsk(9_990m));
            Assert.AreEqual("10,00k ISK", ConsoleWriter.ToShortIsk(9_999m));
            Assert.AreEqual("10,00k ISK", ConsoleWriter.ToShortIsk(10_000m));
            Assert.AreEqual("10,00k ISK", ConsoleWriter.ToShortIsk(10_001m));
            Assert.AreEqual("99,99k ISK", ConsoleWriter.ToShortIsk(99_990m));
            Assert.AreEqual("100,00k ISK", ConsoleWriter.ToShortIsk(99_999m));
            Assert.AreEqual("100,00k ISK", ConsoleWriter.ToShortIsk(100_000m));
            Assert.AreEqual("100,00k ISK", ConsoleWriter.ToShortIsk(100_001m));
            Assert.AreEqual("567,89k ISK", ConsoleWriter.ToShortIsk(567_890m));
            Assert.AreEqual("999,99k ISK", ConsoleWriter.ToShortIsk(999_990m));
        }

        [TestMethod()]
        public void ToShortIskLessOneBillion() {
            Assert.AreEqual("1,00m ISK", ConsoleWriter.ToShortIsk(1_000_000m));
            Assert.AreEqual("1,00m ISK", ConsoleWriter.ToShortIsk(1_001_000m));
            Assert.AreEqual("1,01m ISK", ConsoleWriter.ToShortIsk(1_010_000m));
            Assert.AreEqual("1,10m ISK", ConsoleWriter.ToShortIsk(1_100_000m));
            Assert.AreEqual("1,99m ISK", ConsoleWriter.ToShortIsk(1_990_000m));
            Assert.AreEqual("2,00m ISK", ConsoleWriter.ToShortIsk(1_999_000m));
            Assert.AreEqual("9,99m ISK", ConsoleWriter.ToShortIsk(9_990_000m));
            Assert.AreEqual("10,00m ISK", ConsoleWriter.ToShortIsk(9_999_999m));
            Assert.AreEqual("10,00m ISK", ConsoleWriter.ToShortIsk(10_000_000m));
            Assert.AreEqual("10,00m ISK", ConsoleWriter.ToShortIsk(10_001_000m));
            Assert.AreEqual("99,99m ISK", ConsoleWriter.ToShortIsk(99_990_000m));
            Assert.AreEqual("100,00m ISK", ConsoleWriter.ToShortIsk(99_999_999m));
            Assert.AreEqual("100,00m ISK", ConsoleWriter.ToShortIsk(100_000_000m));
            Assert.AreEqual("100,00m ISK", ConsoleWriter.ToShortIsk(100_001_000m));
            Assert.AreEqual("234,56m ISK", ConsoleWriter.ToShortIsk(234_560_000m));
            Assert.AreEqual("999,99m ISK", ConsoleWriter.ToShortIsk(999_990_000m));
        }

        [TestMethod()]
        public void ToShortIskLessOneTrillion() {
            Assert.AreEqual("1,00b ISK", ConsoleWriter.ToShortIsk(1_000_000_000m));
            Assert.AreEqual("1,00b ISK", ConsoleWriter.ToShortIsk(1_001_000_000m));
            Assert.AreEqual("1,01b ISK", ConsoleWriter.ToShortIsk(1_010_000_000m));
            Assert.AreEqual("1,10b ISK", ConsoleWriter.ToShortIsk(1_100_000_000m));
            Assert.AreEqual("1,99b ISK", ConsoleWriter.ToShortIsk(1_990_000_000m));
            Assert.AreEqual("2,00b ISK", ConsoleWriter.ToShortIsk(1_999_000_000m));
            Assert.AreEqual("9,99b ISK", ConsoleWriter.ToShortIsk(9_990_000_000m));
            Assert.AreEqual("10,00b ISK", ConsoleWriter.ToShortIsk(9_999_999_999m));
            Assert.AreEqual("10,00b ISK", ConsoleWriter.ToShortIsk(10_000_000_000m));
            Assert.AreEqual("10,00b ISK", ConsoleWriter.ToShortIsk(10_001_000_000m));
            Assert.AreEqual("99,99b ISK", ConsoleWriter.ToShortIsk(99_990_000_000m));
            Assert.AreEqual("100,00b ISK", ConsoleWriter.ToShortIsk(99_999_999_999m));
            Assert.AreEqual("100,00b ISK", ConsoleWriter.ToShortIsk(100_000_000_000m));
            Assert.AreEqual("100,00b ISK", ConsoleWriter.ToShortIsk(100_001_000_000m));
            Assert.AreEqual("234,56b ISK", ConsoleWriter.ToShortIsk(234_560_000_000m));
            Assert.AreEqual("999,99b ISK", ConsoleWriter.ToShortIsk(999_990_000_000m));
        }

        [TestMethod()]
        public void ToShortIskMoreOneTrillion() {
            Assert.AreEqual("1,00t ISK", ConsoleWriter.ToShortIsk(1_000_000_000_000m));
            Assert.AreEqual("1,00t ISK", ConsoleWriter.ToShortIsk(1_001_000_000_000m));
            Assert.AreEqual("1,01t ISK", ConsoleWriter.ToShortIsk(1_010_000_000_000m));
            Assert.AreEqual("1,10t ISK", ConsoleWriter.ToShortIsk(1_100_000_000_000m));
            Assert.AreEqual("1,99t ISK", ConsoleWriter.ToShortIsk(1_990_000_000_000m));
            Assert.AreEqual("2,00t ISK", ConsoleWriter.ToShortIsk(1_999_000_000_000m));
            Assert.AreEqual("9,99t ISK", ConsoleWriter.ToShortIsk(9_990_000_000_000m));
            Assert.AreEqual("10,00t ISK", ConsoleWriter.ToShortIsk(9_999_999_999_999m));
            Assert.AreEqual("10,00t ISK", ConsoleWriter.ToShortIsk(10_000_000_000_000m));
            Assert.AreEqual("10,00t ISK", ConsoleWriter.ToShortIsk(10_001_000_000_000m));
            Assert.AreEqual("99,99t ISK", ConsoleWriter.ToShortIsk(99_990_000_000_000m));
            Assert.AreEqual("100,00t ISK", ConsoleWriter.ToShortIsk(99_999_999_999_999m));
            Assert.AreEqual("100,00t ISK", ConsoleWriter.ToShortIsk(100_000_000_000_000m));
            Assert.AreEqual("100,00t ISK", ConsoleWriter.ToShortIsk(100_001_000_000_000m));
            Assert.AreEqual("234,56t ISK", ConsoleWriter.ToShortIsk(234_560_000_000_000m));
            Assert.AreEqual("999,99t ISK", ConsoleWriter.ToShortIsk(999_990_000_000_000m));
        }
    }
}
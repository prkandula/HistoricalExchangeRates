using HistoricalExchangeRate.Model;
using NUnit.Framework;

namespace HistoricalExchangeRate.Tests
{
    [TestFixture]
    public class ExchangeRateTest
    {
        private ExchangeRate _exchangeRate = new ExchangeRate();
        [Test]
        public void GetRates_AValiddates_MinimumExchangeDateIsNotNullOrEmpty()
        {
            // Arrange
            string[] dates = { "2020-02-01" , "2020-02-27"};
            string baseCurrency = "GBP";
            string symbols = "USD";
            // Act
            var rates = _exchangeRate.GetRate(dates, baseCurrency, symbols);
            // Assert
            Assert.IsTrue(!string.IsNullOrEmpty(rates.Result.MinExchDate));
        }

        [Test]
        public void GetRates_AValiddates_MaximumExchangeDateAreEqual()
        {
            // Arrange
            string[] dates = { "2018-02-01", "2018-02-15", "2018-03-01" };
            string baseCurrency = "SEK";
            string symbols = "NOK";
            // Act
            var rates = this._exchangeRate.GetRate(dates, baseCurrency, symbols);
            double acutal = rates.Result.MaxExchangeRate;
            double expected = 0.979845;
            // Assert
            Assert.AreEqual(expected, acutal);
        }

        [Test]
        public void GetRates_AValiddates_IsNotCompletedSuccessfully()
        {
            // Arrange
            string[] dates = { "Not date" };
            string baseCurrency = "SEK";
            string symbols = "NOK";
            // Act
            var rates = this._exchangeRate.GetRate(dates, baseCurrency, symbols);

            // Assert
            Assert.IsFalse(rates.IsCompletedSuccessfully);
        }

    }
}

namespace ToteBetting.BL.Products
{
    using System.Collections.Generic;
    using ToteBetting.BL.Interfaces;
    using ToteBetting.DL.Interface;

    /// <summary>
    /// The betting product class
    /// </summary>
    internal class Product : IProduct
    {
        private readonly double commission;
        private IDataStore dataStore;
        private string productCode;
        private IDividendCalculator dividendCalculator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prodCode"></param>
        /// <param name="betsDataStore"></param>
        /// <param name="calculator"></param>
        /// <param name="betCommission"></param>
        public Product(string prodCode, IDataStore betsDataStore, IDividendCalculator calculator, double betCommission)
        {
            productCode = prodCode;
            dataStore = betsDataStore;
            dividendCalculator = calculator;
            commission = betCommission;
        }

        /// <inheritdoc />
        public void AddBetData(IList<int> runners, double betAmount)
        {
            dataStore.InsertIntoDataStore(productCode, runners, betAmount);
        }

        /// <inheritdoc />
        public IDictionary<int, double> GetDividend()
        {
            var betsList = dataStore.QueryBetsFromDataStore(productCode);
            return dividendCalculator.DoCalculate(betsList, commission);
        }

        /// <inheritdoc />
        public void ResetBetData()
        {
            dataStore.ResetBetsFromDataStore(productCode);
        }
    }
}
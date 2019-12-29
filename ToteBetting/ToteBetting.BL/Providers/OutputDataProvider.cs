namespace ToteBetting.BL.Providers
{
    using System.Collections.Generic;
    using ToteBetting.BL.Data;
    using ToteBetting.BL.Interfaces;

    /// <summary>
    /// Class provides formatted data for displaying purpose
    /// </summary>
    internal class OutputDataProvider : IOutputDataProvider
    {
        /// <inheritdoc/>
        public IDictionary<int, double> GetWinDividend => GetDividend(ProductData.WinCode);
        public IDictionary<int, double> GetPlaceDividend => GetDividend(ProductData.PlaceCode);
        public IDictionary<int, double> GetExactaDividend => GetDividend(ProductData.ExactaCode);
        public IDictionary<int, double> GetQuinellaDividend => GetDividend(ProductData.QuinellaCode);

        private IDictionary<int, double> GetDividend(string code)
        {
            if (ProductData.ProductsHost == null || ProductData.ProductsHost.Count == 0)
            {
                return new Dictionary<int, double>();
            }

            IProduct bettingProduct = (IProduct)ProductData.ProductsHost[code];
            var dividends = bettingProduct.GetDividend();
            if (dividends == null)
            {
                return new Dictionary<int, double>();
            }

            return dividends;
        }
    }
}

namespace ToteBetting.BL.Providers
{
    using System.Linq;
    using ToteBetting.BL.Data;
    using ToteBetting.BL.Interfaces;

    /// <summary>
    /// Class provides formatted data for displaying purpose
    /// </summary>
    internal class OutputDataProvider : IOutputDataProvider
    {
        /// <inheritdoc />
        public string OutputData => GetFormattedDataForOutput();

        /// <summary>
        /// Make the formatted data
        /// </summary>
        private string GetFormattedDataForOutput()
        {
            string formattedData = GetFormattedWinDataForOutput() + GetFormattedPlaceDataForOutput() +
                            GetFormattedExactaDataForOutput() + GetFormattedQuinellaDataForOutput();
            return formattedData == string.Empty ? "Not enough data available" : formattedData;
        }

        private string GetFormattedWinDataForOutput()
        {
            string formattedData = string.Empty;
            if (ProductData.ProductsHost == null || ProductData.ProductsHost.Count == 0)
            {
                return formattedData;
            }

            IProduct bettingProduct = (IProduct)ProductData.ProductsHost[ProductData.WinCode];
            var dividends = bettingProduct.GetDividend();
            if (dividends == null || dividends.Count == 0)
            {
                return formattedData;
            }

            formattedData = "Win - Runner " + bettingProduct.GetDividend().Keys.ToList()[0] + " - " +
                                bettingProduct.GetDividend().Values.ToList()[0] + "\n";
            return formattedData;
        }

        private string GetFormattedPlaceDataForOutput()
        {
            string formattedData = string.Empty;
            if (ProductData.ProductsHost == null || ProductData.ProductsHost.Count == 0)
            {
                return formattedData;
            }

            IProduct bettingProduct = (IProduct) ProductData.ProductsHost[ProductData.PlaceCode];
            var dividends = bettingProduct.GetDividend();
            if (dividends == null || dividends.Count == 0)
            {
                return formattedData;
            }

            formattedData = formattedData + "Place - Runner " + bettingProduct.GetDividend().Keys.ToList()[0] +
                            " - " +
                            bettingProduct.GetDividend().Values.ToList()[0] + "\n";
            formattedData = formattedData + "Place - Runner " + bettingProduct.GetDividend().Keys.ToList()[1] +
                            " - " +
                            bettingProduct.GetDividend().Values.ToList()[1] + "\n";
            formattedData = formattedData + "Place - Runner " + bettingProduct.GetDividend().Keys.ToList()[2] +
                            " - " +
                            bettingProduct.GetDividend().Values.ToList()[2] + "\n";
            return formattedData;
        }

        private string GetFormattedExactaDataForOutput()
        {
            string formattedData = string.Empty;
            if (ProductData.ProductsHost == null || ProductData.ProductsHost.Count == 0)
            {
                return formattedData;
            }

            IProduct bettingProduct = (IProduct) ProductData.ProductsHost[ProductData.ExactaCode];
            var dividends = bettingProduct.GetDividend();
            if (dividends == null || dividends.Count == 0)
            {
                return formattedData;
            }

            formattedData = formattedData + "Exacta - Runners " + bettingProduct.GetDividend().Keys.ToList()[0] +
                            ", " + bettingProduct.GetDividend().Keys.ToList()[1] + " - " +
                            bettingProduct.GetDividend().Values.ToList()[0] + "\n";
            return formattedData;
        }

        private string GetFormattedQuinellaDataForOutput()
        {
            string formattedData = string.Empty;
            if (ProductData.ProductsHost == null || ProductData.ProductsHost.Count == 0)
            {
                return formattedData;
            }

            IProduct bettingProduct = (IProduct) ProductData.ProductsHost[ProductData.QuinellaCode];
            var dividends = bettingProduct.GetDividend();
            if (dividends == null || dividends.Count == 0)
            {
                return formattedData;
            }

            formattedData = formattedData + "Quinella - Runners " + bettingProduct.GetDividend().Keys.ToList()[0] +
                            ", " + bettingProduct.GetDividend().Keys.ToList()[1] + " - " +
                            bettingProduct.GetDividend().Values.ToList()[0] + "\n";
            return formattedData;
        }
    }
}

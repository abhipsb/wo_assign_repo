namespace ToteBetting.PL.Providers
{
    using System.Linq;
    using System.Collections.Generic;
    using ToteBetting.BL.Creator;
    using ToteBetting.BL.Interfaces;

    /// <summary>
    /// Class provides formatted data for displaying purpose
    /// </summary>
    internal class FormattedOutputDataProvider : IFormattedOutputDataProvider
    {
        private readonly IOutputDataProvider outputProvider = BlAccessor.GetOutputDataProvider();

        /// <inheritdoc />
        public string OutputData => GetFormattedDataForOutput();

        /// <summary>
        /// Make the formatted data
        /// </summary>
        private string GetFormattedDataForOutput()
        {
            string formattedData = GetFormattedDataForSingleRunner("Win", outputProvider.GetWinDividend) +
                                   GetFormattedDataForSingleRunner("Place", outputProvider.GetPlaceDividend) + 
                                   GetFormattedDataForMultiRunner("Exacta", outputProvider.GetExactaDividend) +
                                   GetFormattedDataForMultiRunner("Quinella", outputProvider.GetQuinellaDividend);
            return formattedData == string.Empty ? "Not enough data available" : formattedData;
        }

        private string GetFormattedDataForSingleRunner(string product, IDictionary<int, double> dividends)
        {
            string formattedData = string.Empty;
            if (dividends.Count == 0)
            {
                return formattedData;
            }

            for (int i = 0; i < dividends.Count; i++)
            {
                int runner = dividends.Keys.ToList()[i];
                double dividend = dividends.Values.ToList()[i];
                if (double.IsNaN(dividend) || double.IsInfinity(dividend))
                {
                    dividend = 0;
                }

                formattedData = formattedData + product + " - Runner " + runner + " - " + dividend + "\n";
            }

            return formattedData;
        }

        private string GetFormattedDataForMultiRunner(string product, IDictionary<int, double> dividends)
        {
            string formattedData = string.Empty;
            if (dividends.Count == 0)
            {
                return formattedData;
            }

            int runner1 = dividends.Keys.ToList()[0];
            int runner2 = dividends.Keys.ToList()[1];
            double dividend = dividends.Values.ToList()[0];
            if (double.IsNaN(dividend) || double.IsInfinity(dividend))
            {
                dividend = 0;
            }

            formattedData = formattedData + product + " - Runners " + runner1 + ", " + runner2 + " - " + dividend + "\n";
            return formattedData;
        }
    }
}

namespace ToteBetting.PL.Providers
{
    using System.Linq;
    using System.Collections.Generic;
    using ToteBetting.BL.Creator;
    using ToteBetting.BL.Interfaces;
    using ToteBetting.PL.Interfaces;

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
            string formattedData = GetFormattedWinDataForOutput() + GetFormattedPlaceDataForOutput() +
                            GetFormattedExactaDataForOutput() + GetFormattedQuinellaDataForOutput();
            return formattedData == string.Empty ? "Not enough data available" : formattedData;
        }

        private string GetFormattedWinDataForOutput()
        {
            string formattedData = string.Empty;
            IDictionary<int, double> dividends = outputProvider.GetWinDividend;
            if (dividends.Count == 0)
            {
                return formattedData;
            }

            formattedData = "Win - Runner " + dividends.Keys.ToList()[0] + " - " +
                            dividends.Values.ToList()[0] + "\n";
            return formattedData;
        }

        private string GetFormattedPlaceDataForOutput()
        {
            string formattedData = string.Empty;
            IDictionary<int, double> dividends = outputProvider.GetWinDividend;
            if (dividends.Count == 0)
            {
                return formattedData;
            }

            formattedData = formattedData + "Place - Runner " + dividends.Keys.ToList()[0] +
                            " - " +
                            dividends.Values.ToList()[0] + "\n";
            formattedData = formattedData + "Place - Runner " + dividends.Keys.ToList()[1] +
                            " - " +
                            dividends.Values.ToList()[1] + "\n";
            formattedData = formattedData + "Place - Runner " + dividends.Keys.ToList()[2] +
                            " - " +
                            dividends.Values.ToList()[2] + "\n";
            return formattedData;
        }

        private string GetFormattedExactaDataForOutput()
        {
            string formattedData = string.Empty;
            IDictionary<int, double> dividends = outputProvider.GetWinDividend;
            if (dividends.Count == 0)
            {
                return formattedData;
            }

            formattedData = formattedData + "Exacta - Runners " + dividends.Keys.ToList()[0] +
                            ", " + dividends.Keys.ToList()[1] + " - " +
                            dividends.Values.ToList()[0] + "\n";
            return formattedData;
        }

        private string GetFormattedQuinellaDataForOutput()
        {
            string formattedData = string.Empty;
            IDictionary<int, double> dividends = outputProvider.GetWinDividend;
            if (dividends.Count == 0)
            {
                return formattedData;
            }

            formattedData = formattedData + "Quinella - Runners " + dividends.Keys.ToList()[0] +
                            ", " + dividends.Keys.ToList()[1] + " - " +
                            dividends.Values.ToList()[0] + "\n";
            return formattedData;
        }
    }
}

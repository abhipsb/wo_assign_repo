namespace ToteBetting.BL.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for providing Output Data
    /// </summary>
    public interface IOutputDataProvider
    {
        /// <summary>
        /// WIN Dividend
        /// </summary>
        IDictionary<int, double> GetWinDividend { get; }

        /// <summary>
        /// PLACE Dividend
        /// </summary>
        IDictionary<int, double> GetPlaceDividend { get; }

        /// <summary>
        /// EXACTA Dividend
        /// </summary>
        IDictionary<int, double> GetExactaDividend { get; }

        /// <summary>
        /// QUINELLA Dividend
        /// </summary>
        IDictionary<int, double> GetQuinellaDividend { get; }
    }
}
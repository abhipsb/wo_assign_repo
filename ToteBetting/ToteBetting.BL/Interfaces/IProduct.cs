namespace ToteBetting.BL.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for betting product
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Method to add betting data
        /// </summary>
        /// <param name="runners"></param>
        /// <param name="betAmount"></param>
        void AddBetData(IList<int> runners, double betAmount);

        /// <summary>
        /// Method to get dividend
        /// </summary>
        /// <returns></returns>
        IDictionary<int, double> GetDividend();

        /// <summary>
        /// Reset all previous Bets
        /// </summary>
        void ResetBetData();
    }
}

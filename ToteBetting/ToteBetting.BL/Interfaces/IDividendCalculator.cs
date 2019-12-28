namespace ToteBetting.BL.Interfaces
{
    using System.Collections.Generic;
    using ToteBetting.DL.Interface;

    /// <summary>
    /// Interface for dividend calculation
    /// </summary>
    internal interface IDividendCalculator
    {
        /// <summary>
        /// Commission amount from a betting product
        /// </summary>
        double CommissionAmount { get; set; }
        
        /// <summary>
        /// Method to calculate the dividend
        /// </summary>
        /// <param name="betsList">list of all bets in a product</param>
        /// <param name="commissionPercent">% commission to be taken</param>
        /// <returns>Dictionary containing winner as key and dividend as value</returns>
        IDictionary<int, double> DoCalculate(IList<BetDataStruct> betsList, double commissionPercent);
    }
}
namespace ToteBetting.BL.Products
{
    using System;
    using System.Collections.Generic;
    using ToteBetting.BL.Data;
    using ToteBetting.BL.Interfaces;
    using ToteBetting.DL.Interface;

    /// <summary>
    /// Calculator for PLACE Product
    /// </summary>
    internal class PlaceCalculator : IDividendCalculator
    {
        /// <inheritdoc />
        public double CommissionAmount { get; set; }

        /// <inheritdoc />
        public IDictionary<int, double> DoCalculate(IList<BetDataStruct> betsList, double commissionPercent)
        {
            double totalBetPool = 0;
            double firstWinPool = 0;
            double secondWinPool = 0;
            double thirdWinPool = 0;
            IDictionary<int, double> dividendsCollection = new Dictionary<int, double>();
            IInputParser result = (IInputParser)ProductData.BettingResult;
            if (result == null)
            {
                return dividendsCollection;
            }

            foreach (var bet in betsList)
            {
                totalBetPool = totalBetPool + bet.BetAmount;
                if (bet.Runners[0] == result.RunnersList[0])
                {
                    firstWinPool = firstWinPool + bet.BetAmount;
                    continue;
                }

                if (bet.Runners[0] == result.RunnersList[1])
                {
                    secondWinPool = secondWinPool + bet.BetAmount;
                    continue;
                }

                if (bet.Runners[0] == result.RunnersList[2])
                {
                    thirdWinPool = thirdWinPool + bet.BetAmount;
                }
            }

            CommissionAmount = totalBetPool * commissionPercent / 100.0;
            totalBetPool = (totalBetPool - CommissionAmount) / 3;
            double dividend = Math.Round(totalBetPool / firstWinPool, 2);
            dividendsCollection.Add(result.RunnersList[0], dividend);
            dividend = Math.Round(totalBetPool / secondWinPool, 2);
            dividendsCollection.Add(result.RunnersList[1], dividend);
            dividend = Math.Round(totalBetPool / thirdWinPool, 2);
            dividendsCollection.Add(result.RunnersList[2], dividend);
            return dividendsCollection;
        }
    }
}
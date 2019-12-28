namespace ToteBetting.DL.Stores
{
    using System.Collections.Generic;
    using ToteBetting.DL.Interface;

    internal class ListCollectionDataStore : IDataStore
    {
        private IList<BetDataStruct> betsList;

        public ListCollectionDataStore()
        {
            betsList = new List<BetDataStruct>();
        }

        public bool InsertIntoDataStore(string productCode, IList<int> runners, double betAmount)
        {
            var betData = new BetDataStruct
            {
                Runners = new List<int>(), ProductCode = productCode
            };

            for (int i = 0; i < runners.Count; i++)
            {
                betData.Runners.Add(runners[i]);
            }

            betData.BetAmount = betAmount;
            betsList.Add(betData);
            return true;
        }

        public IList<BetDataStruct> QueryBetsFromDataStore(string productCode)
        {
            IList<BetDataStruct> prodBetsList = new List<BetDataStruct>();
            foreach (var bet in betsList)
            {
                if (bet.ProductCode == productCode)
                {
                    prodBetsList.Add(bet);
                }
            }

            return prodBetsList;
        }

        public void ResetBetsFromDataStore(string productCode)
        {
            IList<BetDataStruct> tobeRemovedBets = new List<BetDataStruct>();
            foreach (var bet in betsList)
            {
                if (bet.ProductCode == productCode)
                {
                    tobeRemovedBets.Add(bet);
                }
            }

            foreach (var betsToRemove in tobeRemovedBets)
            {
                betsList.Remove(betsToRemove);
            }
        }
    }
}

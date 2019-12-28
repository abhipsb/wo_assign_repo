namespace ToteBetting.DL.Interface
{
    using System.Collections.Generic;

    internal struct BetDataStruct
    {
        public string ProductCode;
        public IList<int> Runners;
        public double BetAmount;
    }

    /// <summary>
    /// Interface to access Data Store
    /// </summary>
    internal interface IDataStore
    {
        bool InsertIntoDataStore(string productCode, IList<int> runners, double betAmount);

        IList<BetDataStruct> QueryBetsFromDataStore(string productCode);

        void ResetBetsFromDataStore(string productCode);
    }
}

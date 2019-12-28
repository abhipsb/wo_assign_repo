namespace ToteBetting.DL.Creator
{
    using ToteBetting.DL.Interface;
    using ToteBetting.DL.Stores;

    /// <summary>
    /// Class to create the instances
    /// </summary>
    internal class InstanceCreator
    {
        /// <summary>
        /// Creates the instance of DataStore
        /// </summary>
        /// <returns></returns>
        public static IDataStore CreateDataStoreInstance()
        {
            return new ListCollectionDataStore();
        }        
    }
}
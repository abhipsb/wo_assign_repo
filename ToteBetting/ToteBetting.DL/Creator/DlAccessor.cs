namespace ToteBetting.DL.Creator
{
    /// <summary>
    /// Class used for interfacing between PL and BL
    /// </summary>
    public static class DlAccessor
    {
        public static object GetDataStoreInstance()
        {
            return InstanceCreator.CreateDataStoreInstance();
        }
    }
}
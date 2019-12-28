namespace ToteBetting.BL.Creator
{
    using System.Collections.Generic;
    using ToteBetting.BL.Data;
    using ToteBetting.BL.Handlers;
    using ToteBetting.BL.Interfaces;
    using ToteBetting.BL.Products;
    using ToteBetting.BL.Providers;
    using ToteBetting.DL.Creator;
    using ToteBetting.DL.Interface;

    /// <summary>
    /// Class to provide the instances of different classes
    /// </summary>
    internal class InstanceCreator
    {
        /// <summary>
        /// Gets the instance of GetOutputDataProvider class
        /// </summary>
        /// <returns></returns>
        public static object CreateOutputDataProvider()
        {
            return new OutputDataProvider();
        }

        /// <summary>
        /// Create and return the instance of Product class
        /// </summary>
        /// <param name="calculator"></param>
        /// <param name="betCommission"></param>
        /// <returns></returns>
        public static object CreateProductInstance(string prodCode, IDataStore betsDataStore,
            IDividendCalculator calculator, double betCommission)
        {
            return new Product(prodCode, betsDataStore, calculator, betCommission);
        }

        /// <summary>
        /// Gets the Data Store instance from DL via DlAccessor
        /// </summary>
        /// <returns></returns>
        public static object GetDataStoreInstance()
        {
            return DlAccessor.GetDataStoreInstance();
        }
        /// <summary>
        /// Create the instance of ResultInputHandler class
        /// </summary>
        /// <returns></returns>
        public static object CreateResultInputHandler()
        {
            return new ResultInputHandler();
        }

        /// <summary>
        /// Create the instance of ResultInputHandler class
        /// </summary>
        /// <returns></returns>
        public static object CreateBetInputHandler()
        {
            return new BetInputHandler();
        }
        
        /// <summary>
        /// Initialize the Global variables i.e. all betting Products
        /// </summary>
        public static void InitializeGlobal()
        {
            ProductData.ProductsHost = new Dictionary<string, object>();
            IDataStore dataStore = (IDataStore)GetDataStoreInstance();
            if (!ProductData.ProductsHost.ContainsKey(ProductData.WinCode))
            {
                ProductData.ProductsHost.Add(ProductData.WinCode,
                    CreateProductInstance(ProductData.WinCode, dataStore, new WinCalculator(), 15));
            }

            if (!ProductData.ProductsHost.ContainsKey(ProductData.PlaceCode))
            {
                ProductData.ProductsHost.Add(ProductData.PlaceCode,
                    CreateProductInstance(ProductData.PlaceCode, dataStore, new PlaceCalculator(), 12));
            }

            if (!ProductData.ProductsHost.ContainsKey(ProductData.ExactaCode))
            {
                ProductData.ProductsHost.Add(ProductData.ExactaCode,
                    CreateProductInstance(ProductData.ExactaCode, dataStore, new ExactaCalculator(), 18));
            }

            if (!ProductData.ProductsHost.ContainsKey(ProductData.QuinellaCode))
            {
                ProductData.ProductsHost.Add(ProductData.QuinellaCode,
                    CreateProductInstance(ProductData.QuinellaCode, dataStore, new QuinellaCalculator(), 18));
            }
        }
    }
}

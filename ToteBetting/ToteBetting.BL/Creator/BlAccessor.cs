namespace ToteBetting.BL.Creator
{
    using ToteBetting.BL.Data;
    using ToteBetting.BL.Interfaces;

    /// <summary>
    /// Class used for interfacing between PL and BL
    /// </summary>
    public static class BlAccessor
    {
        /// <summary>
        /// Static constructor to make sure the Global variables are initialized before use
        /// </summary>
        static BlAccessor()
        {
            InitGlobals();
        }

        /// <summary>
        /// Gets the instance of GetOutputDataProvider class
        /// </summary>
        /// <returns></returns>
        public static IOutputDataProvider GetOutputDataProvider()
        {
            return InstanceCreator.CreateOutputDataProvider() as IOutputDataProvider;
        }

        /// <summary>
        /// Gets the instance of Product class using its code
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public static IProduct GetProduct(string productCode)
        {
            return ProductData.GetProductByCode(productCode) as IProduct;
        }

        /// <summary>
        /// Process the bet input
        /// </summary>
        /// <param name="userInputValue"></param>
        /// <param name="resetPrevious"></param>
        /// <returns>true if success, false otherwise</returns>
        public static bool ProcessBetInput(string userInputValue, bool resetPrevious = false)
        {
            string upperCaseInput = userInputValue.ToUpper();
            IUserInputHandler inputHandler = InstanceCreator.CreateBetInputHandler() as IUserInputHandler;
            if (resetPrevious)
            {
                ResetGlobals();
            }

            return inputHandler.Process(upperCaseInput);
        }

        /// <summary>
        /// Process the result input
        /// </summary>
        /// <param name="userInputValue"></param>
        /// <returns>true if success, false otherwise</returns>
        public static bool ProcessResultInput(string userInputValue)
        {
            string upperCaseInput = userInputValue.ToUpper();
            IUserInputHandler inputHandler = InstanceCreator.CreateResultInputHandler() as IUserInputHandler;
            return inputHandler.Process(upperCaseInput);
        }

        /// <summary>
        /// Reset all the previous stored data i.e. all bets and result
        /// </summary>
        public static void ResetGlobals()
        {
            foreach (IProduct product in ProductData.ProductsHost.Values)
            {
                product?.ResetBetData();
            }

            ProductData.BettingResult = null;
        }

        /// <summary>
        /// Initialize the global variables
        /// </summary>
        public static void InitGlobals()
        {
            InstanceCreator.InitializeGlobal();
        }
    }
}
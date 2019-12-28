namespace ToteBetting.BL.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// Definations for common constants
    /// </summary>
    internal static class ProductData
    {
        public const string WinCode = "W";
        public const string PlaceCode = "P";
        public const string ExactaCode = "E";
        public const string QuinellaCode = "Q";

        /// <summary>
        /// Host the instances of all products
        /// </summary>
        public static IDictionary<string, object> ProductsHost;

        /// <summary>
        /// Stores the result data
        /// </summary>
        public static object BettingResult;

        /// <summary>
        /// Get the instance of Product using its code
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public static object GetProductByCode(string productCode)
        {
            string code = productCode?.ToUpper();
            if (code == null || ProductsHost == null || ProductsHost.Count == 0)
            {
                return null;
            }

            if (ProductsHost.ContainsKey(code))
            {
                return ProductsHost[code];
            }

            return null;
        }
    }
}
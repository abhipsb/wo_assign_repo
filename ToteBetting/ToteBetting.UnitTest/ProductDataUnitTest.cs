namespace ToteBetting.UnitTest
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToteBetting.BL.Data;

    [TestClass]
    public class ProductDataUnitTest
    {
        [TestMethod]
        public void Negative_Scenarios_Test()
        {
            var productInfo = ProductData.GetProductByCode(null);
            Assert.IsNull(productInfo);

            productInfo = ProductData.GetProductByCode("");
            Assert.IsNull(productInfo);

            productInfo = ProductData.GetProductByCode(string.Empty);
            Assert.IsNull(productInfo);

            productInfo = ProductData.GetProductByCode("X");
            Assert.IsNull(productInfo);

            ProductData.ProductsHost = new Dictionary<string, object>();
            productInfo = ProductData.GetProductByCode("");
            Assert.IsNull(productInfo);
        }
    }
}
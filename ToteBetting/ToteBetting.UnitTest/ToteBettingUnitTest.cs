namespace ToteBetting.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToteBetting.BL.Creator;
    using ToteBetting.BL.Interfaces;

    [TestClass]
    public class ToteBettingUnitTest
    {
        private const string WinCode = "W";
        private const string PlaceCode = "P";
        private const string ExactaCode = "E";
        private const string QuinellaCode = "Q";

        [TestInitialize]
        public void Init()
        {
            BlAccessor.InitGlobals();
        }

        [TestCleanup]
        public void Cleanup()
        {
            BlAccessor.ResetGlobals();
        }

        [TestMethod]
        public void ProductInfo_Valid()
        {
            IProduct productInfo = BlAccessor.GetProduct(WinCode);
            Assert.IsNotNull(productInfo);
            productInfo = BlAccessor.GetProduct(PlaceCode);
            Assert.IsNotNull(productInfo);
            productInfo = BlAccessor.GetProduct(ExactaCode);
            Assert.IsNotNull(productInfo);
            productInfo = BlAccessor.GetProduct(QuinellaCode);
            Assert.IsNotNull(productInfo);
        }

        [TestMethod]
        public void ProductInfo_Invalid()
        {
            IProduct productInfo = BlAccessor.GetProduct("AnyString");
            Assert.IsNull(productInfo);
        }

        [TestMethod]
        public void GetDividend_Without_Result_Initialize_Test()
        {
            string inputValue = "W:1:3";
            BlAccessor.ProcessBetInput(inputValue);
            var bettingProduct = BlAccessor.GetProduct(WinCode);
            var dividend = bettingProduct.GetDividend();
            Assert.IsNotNull(bettingProduct);
            Assert.IsTrue(BlAccessor.ProcessBetInput(inputValue, true));

            inputValue = "p:1:3";
            BlAccessor.ProcessBetInput(inputValue);
            bettingProduct = BlAccessor.GetProduct(PlaceCode);
            dividend = bettingProduct.GetDividend();
            Assert.IsNotNull(bettingProduct);

            inputValue = "e:1,2:3";
            BlAccessor.ProcessBetInput(inputValue);
            bettingProduct = BlAccessor.GetProduct(ExactaCode);
            dividend = bettingProduct.GetDividend();
            Assert.IsNotNull(bettingProduct);

            inputValue = "q:1,2:3";
            BlAccessor.ProcessBetInput(inputValue);
            bettingProduct = BlAccessor.GetProduct(QuinellaCode);
            dividend = bettingProduct.GetDividend();
            Assert.IsNotNull(bettingProduct);
        }

        [TestMethod]
        public void ResultInput_Negative_Tests()
        {
            string inputValue = "w:2,3:2";
            bool success = BlAccessor.ProcessResultInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "r:2,3:2";
            success = BlAccessor.ProcessResultInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "r:2:2";
            success = BlAccessor.ProcessResultInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "r:3:2:3";
            success = BlAccessor.ProcessResultInput(inputValue);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void BetInput_Negative_Tests()
        {
            string inputValue = "w:2,3:2";
            bool success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "x:2,3:2";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "p:2,3:2";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "e:2:2";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "e:2,2:2";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "q:3:2";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "x:y:z";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "w:x,y:z";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsFalse(success);

            inputValue = "w :3:2";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Get_Win_Dividend_Test()
        {
            // Add Win Bets
            BlAccessor.ProcessBetInput("W:1:3");
            BlAccessor.ProcessBetInput("W:2:4");
            BlAccessor.ProcessBetInput("W:3:5");
            BlAccessor.ProcessBetInput("W:4:5");
            BlAccessor.ProcessBetInput("W:1:16");
            BlAccessor.ProcessBetInput("W:2:8");
            BlAccessor.ProcessBetInput("W:3:22");
            BlAccessor.ProcessBetInput("W:4:57");
            BlAccessor.ProcessBetInput("W:1:42");
            BlAccessor.ProcessBetInput("W:2:98");
            BlAccessor.ProcessBetInput("W:3:63");
            BlAccessor.ProcessBetInput("W:4:15");

            BlAccessor.ProcessResultInput("r:2:3:1");

            var bettingProduct = BlAccessor.GetProduct(WinCode);
            Assert.IsNotNull(bettingProduct);
            var dividend = bettingProduct.GetDividend();
            Assert.IsTrue(dividend.Count == 1);
            Assert.IsTrue(dividend.ContainsKey(2));
        }

        [TestMethod]
        public void Get_Place_Dividend_Test()
        {
            // Add Place Bets
            BlAccessor.ProcessBetInput("P:1:31");
            BlAccessor.ProcessBetInput("P:2:89");
            BlAccessor.ProcessBetInput("P:3:28");
            BlAccessor.ProcessBetInput("P:4:72");
            BlAccessor.ProcessBetInput("P:1:40");
            BlAccessor.ProcessBetInput("P:2:16");
            BlAccessor.ProcessBetInput("P:3:82");
            BlAccessor.ProcessBetInput("P:4:52");
            BlAccessor.ProcessBetInput("P:1:18");
            BlAccessor.ProcessBetInput("P:2:74");
            BlAccessor.ProcessBetInput("P:3:39");
            BlAccessor.ProcessBetInput("P:4:105");

            BlAccessor.ProcessResultInput("r:2:3:1");

            var bettingProduct = BlAccessor.GetProduct(PlaceCode);
            Assert.IsNotNull(bettingProduct);
            var dividend = bettingProduct.GetDividend();
            Assert.IsTrue(dividend.Count == 3);
            Assert.IsTrue(dividend.ContainsKey(2));
            Assert.IsTrue(dividend.ContainsKey(3));
            Assert.IsTrue(dividend.ContainsKey(1));
        }

        [TestMethod]
        public void Get_Exacta_Dividend_Test()
        {
            // Add Win Exacta Bets
            BlAccessor.ProcessBetInput("E:1,2:13");
            BlAccessor.ProcessBetInput("E:2,3:98");
            BlAccessor.ProcessBetInput("E:1,3:82");
            BlAccessor.ProcessBetInput("E:3,2:27");
            BlAccessor.ProcessBetInput("E:1,2:5");
            BlAccessor.ProcessBetInput("E:2,3:61");
            BlAccessor.ProcessBetInput("E:1,3:28");
            BlAccessor.ProcessBetInput("E:3,2:25");
            BlAccessor.ProcessBetInput("E:1,2:81");
            BlAccessor.ProcessBetInput("E:2,3:47");
            BlAccessor.ProcessBetInput("E:1,3:93");
            BlAccessor.ProcessBetInput("E:3,2:51");

            BlAccessor.ProcessResultInput("r:2:3:1");

            var bettingProduct = BlAccessor.GetProduct(ExactaCode);
            Assert.IsNotNull(bettingProduct);
            var dividend = bettingProduct.GetDividend();
            Assert.IsTrue(dividend.Count == 2);
            Assert.IsTrue(dividend.ContainsKey(2));
            Assert.IsTrue(dividend.ContainsKey(3));
        }

        [TestMethod]
        public void Get_Quinella_Dividend_Test()
        {
            // Add Win Quinella Bets
            BlAccessor.ProcessBetInput("Q:1,2:19");
            BlAccessor.ProcessBetInput("Q:2,3:77");
            BlAccessor.ProcessBetInput("Q:1,3:26");
            BlAccessor.ProcessBetInput("Q:2,4:63");
            BlAccessor.ProcessBetInput("Q:1,2:66");
            BlAccessor.ProcessBetInput("Q:2,3:82");
            BlAccessor.ProcessBetInput("Q:1,3:90");
            BlAccessor.ProcessBetInput("Q:2,4:48");
            BlAccessor.ProcessBetInput("Q:1,2:18");
            BlAccessor.ProcessBetInput("Q:2,3:93");
            BlAccessor.ProcessBetInput("Q:1,3:62");
            BlAccessor.ProcessBetInput("Q:2,4:25");

            BlAccessor.ProcessResultInput("r:2:3:1");

            var bettingProduct = BlAccessor.GetProduct(QuinellaCode);
            Assert.IsNotNull(bettingProduct);
            var dividend = bettingProduct.GetDividend();
            Assert.IsTrue(dividend.Count == 2);
            Assert.IsTrue(dividend.ContainsKey(2));
            Assert.IsTrue(dividend.ContainsKey(3));
        }
    }
}

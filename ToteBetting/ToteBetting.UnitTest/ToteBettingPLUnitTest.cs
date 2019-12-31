namespace ToteBetting.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToteBetting.BL.Creator;
    using ToteBetting.PL.Providers;

    [TestClass]
    public class ToteBettingPlUnitTest
    {
        private const string NotEnoughExpectedOutputData = "Not enough data available";

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
        public void FormattedOutputDataProvider_Without_Any_Input_Test()
        {
            IFormattedOutputDataProvider outputProvider = new FormattedOutputDataProvider();
            Assert.IsTrue(outputProvider.OutputData == NotEnoughExpectedOutputData);
        }

        [TestMethod]
        public void FormattedOutputDataProvider_Without_Result_Input_Test()
        {
            IFormattedOutputDataProvider outputProvider = new FormattedOutputDataProvider();
            string inputValue = "w:2:3";
            bool success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsTrue(success);
            Assert.IsTrue(outputProvider.OutputData == NotEnoughExpectedOutputData);

            inputValue = "p:1:3";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsTrue(success);
            Assert.IsTrue(outputProvider.OutputData == NotEnoughExpectedOutputData);

            inputValue = "e:1,2:3";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsTrue(success);
            Assert.IsTrue(outputProvider.OutputData == NotEnoughExpectedOutputData);

            inputValue = "q:1,2:3";
            success = BlAccessor.ProcessBetInput(inputValue);
            Assert.IsTrue(success);
            Assert.IsTrue(outputProvider.OutputData == NotEnoughExpectedOutputData);
        }

        [TestMethod]
        public void FormattedOutputDataProvider_Only_ResultInput_Test()
        {
            IFormattedOutputDataProvider outputProvider = new FormattedOutputDataProvider();
            string inputValue = "r:1:2:3";
            bool success = BlAccessor.ProcessResultInput(inputValue);
            Assert.IsTrue(success);
            Assert.IsTrue(outputProvider.OutputData != NotEnoughExpectedOutputData);
        }
    }
}

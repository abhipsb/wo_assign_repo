namespace ToteBetting.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ToteBetting.BL.Creator;
    using ToteBetting.BL.Interfaces;

    [TestClass]
    public class OutputDataProviderTest
    {
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
        public void Negative_Scenarios_Without_Initialize()
        {
            var provider = InstanceCreator.CreateOutputDataProvider() as IOutputDataProvider;
            Assert.IsNotNull(provider);
            Assert.IsTrue(provider.GetWinDividend.Count == 0);
            Assert.IsTrue(provider.GetPlaceDividend.Count == 0);
            Assert.IsTrue(provider.GetExactaDividend.Count == 0);
            Assert.IsTrue(provider.GetQuinellaDividend.Count == 0);
        }

        [TestMethod]
        public void Negative_Scenarios_With_Initialize()
        {            
            var provider = BlAccessor.GetOutputDataProvider() as IOutputDataProvider;
            Assert.IsNotNull(provider);
            Assert.IsTrue(provider.GetWinDividend.Count == 0);
            Assert.IsTrue(provider.GetPlaceDividend.Count == 0);
            Assert.IsTrue(provider.GetExactaDividend.Count == 0);
            Assert.IsTrue(provider.GetQuinellaDividend.Count == 0);
        }

        [TestMethod]
        public void All_Inputs_Scenarios_Test()
        {
            BlAccessor.ProcessBetInput("W:1:3");
            BlAccessor.ProcessBetInput("P:1:31");
            BlAccessor.ProcessBetInput("E:1,2:13");
            BlAccessor.ProcessBetInput("Q:1,2:19");

            BlAccessor.ProcessResultInput("r:2:3:1");

            var provider = BlAccessor.GetOutputDataProvider() as IOutputDataProvider;
            Assert.IsNotNull(provider);
            Assert.IsTrue(provider.GetWinDividend.Count != 0);
            Assert.IsTrue(provider.GetPlaceDividend.Count != 0);
            Assert.IsTrue(provider.GetExactaDividend.Count != 0);
            Assert.IsTrue(provider.GetQuinellaDividend.Count != 0);
        }

        [TestMethod]
        public void Win_Inputs_Scenarios_Test()
        {
            BlAccessor.ProcessBetInput("W:1:3");
            BlAccessor.ProcessBetInput("W:1:31");

            BlAccessor.ProcessResultInput("r:2:3:1");

            var provider = BlAccessor.GetOutputDataProvider() as IOutputDataProvider;
            Assert.IsNotNull(provider);
            Assert.IsTrue(provider.GetWinDividend.Count != 0);
        }

        [TestMethod]
        public void Place_Inputs_Scenarios_Test()
        {
            BlAccessor.ProcessBetInput("P:1:3");
            BlAccessor.ProcessBetInput("P:1:31");

            BlAccessor.ProcessResultInput("r:2:3:1");

            var provider = BlAccessor.GetOutputDataProvider() as IOutputDataProvider;
            Assert.IsNotNull(provider);
            Assert.IsTrue(provider.GetPlaceDividend.Count != 0);
        }

        [TestMethod]
        public void Exacta_Inputs_Scenarios_Test()
        {
            BlAccessor.ProcessBetInput("E:1,2:13");
            BlAccessor.ProcessBetInput("E:1,2:13");

            BlAccessor.ProcessResultInput("r:2:3:1");

            var provider = BlAccessor.GetOutputDataProvider() as IOutputDataProvider;
            Assert.IsNotNull(provider);
            Assert.IsTrue(provider.GetExactaDividend.Count != 0);
        }

        [TestMethod]
        public void Quinella_Inputs_Scenarios_Test()
        {
            BlAccessor.ProcessBetInput("Q:1,2:19");
            BlAccessor.ProcessBetInput("Q:1,2:19");

            BlAccessor.ProcessResultInput("r:2:3:1");

            var provider = BlAccessor.GetOutputDataProvider() as IOutputDataProvider;
            Assert.IsNotNull(provider);
            Assert.IsTrue(provider.GetQuinellaDividend.Count != 0);
        }
    }
}
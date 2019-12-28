namespace ToteBetting.BL.Handlers
{
    using ToteBetting.BL.Data;
    using ToteBetting.BL.Interfaces;
    using ToteBetting.BL.Providers;

    /// <inheritdoc />
    /// <summary>
    /// Handler for the user choice of bet input
    /// </summary>
    internal class BetInputHandler : IUserInputHandler
    {
        /// <inheritdoc />
        public bool Process(string betInput)
        {
            IBetInputParser inputParser = ParserProvider.GetBetInputParser(betInput) as IBetInputParser;
            if (inputParser == null)
            {
                return false;
            }

            inputParser.DoParse(betInput);
            if (!inputParser.IsSuccess)
            {
                return false;
            }

            IProduct product = ProductData.ProductsHost[inputParser.ProductCode] as IProduct;
            product.AddBetData(inputParser.RunnersList, inputParser.BetAmount);
            return true;
        }
    }
}
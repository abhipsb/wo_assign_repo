namespace ToteBetting.BL.Handlers
{
    using ToteBetting.BL.Data;
    using ToteBetting.BL.Interfaces;
    using ToteBetting.BL.Providers;

    /// <summary>
    /// Handler for the user choice of result input
    /// </summary>
    internal class ResultInputHandler : IUserInputHandler
    {
        /// <inheritdoc />
        public bool Process(string resultInput)
        {
            IInputParser inputParser = ParserProvider.GetResultInputParser(resultInput) as IInputParser;
            if (inputParser == null)
            {
                return false;
            }

            inputParser.DoParse(resultInput);
            if (!inputParser.IsSuccess)
            {
                return false;
            }

            ProductData.BettingResult = inputParser;
            return true;
        }
    }
}
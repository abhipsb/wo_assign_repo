namespace ToteBetting.BL.Parsers
{
    /// <summary>
   /// Class to parse the Bet to get runner, amount and put them separately
    /// </summary>
    internal abstract class BetInputParserBase
    {
        private readonly char[] _inputSeparator = { ':' };
        protected readonly int ProductCodeIndex = 0;
        protected readonly int RunnersIndex = 1;
        protected readonly int BetAmountIndex = 2;
        protected string[] InputArray = null;

        protected BetInputParserBase()
        {
            ProductCode = string.Empty;
            Runners = string.Empty;
            BetAmount = 0;
        }

        public string ProductCode { get; set; }

        public string Runners { get; set; }

        public double BetAmount { get; set; }

        /// <summary>
        /// Parse the input
        /// </summary>
        /// <param name="input"></param>
        public virtual void DoParse(string input)
        {
            InputArray = input.Split(_inputSeparator);
            ProductCode = InputArray[ProductCodeIndex];
            Runners = InputArray[RunnersIndex];
            BetAmount = double.Parse(InputArray[BetAmountIndex]);
        }
    }
}

namespace ToteBetting.BL.Providers
{
    using System.Text.RegularExpressions;
    using ToteBetting.BL.Interfaces;
    using ToteBetting.BL.Parsers;

    /// <summary>
    /// Class provides different Parser instances based on input
    /// </summary>
    internal class ParserProvider
    {
        private const string RegExSingleRunner = @"[WP]:[0-9]+:[0-9]+";
        private const string RegExMultipleRunner = @"[EQ]:[0-9]+,[0-9]+:[0-9]+";
        private const string RegExBetResult = @"[R]:[0-9]+:[0-9]+:[0-9]+";

        /// <summary>
        /// Get the parser for bet input
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static IInputParser GetBetInputParser(string inputValue)
        {
            Match match = Regex.Match(inputValue, RegExSingleRunner);
            if (match.Success)
            {
                return new SingleRunnerParser();
            }

            match = Regex.Match(inputValue, RegExMultipleRunner);
            if (match.Success)
            {
                return new MultipleRunnerParser();
            }

            return null;
        }

        /// <summary>
        /// Get the parser for betting result
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static IInputParser GetResultInputParser(string inputValue)
        {
            Match match = Regex.Match(inputValue, RegExBetResult);
            if (match.Success)
            {
                return new ResultParser();
            }

            return null;
        }
    }
}

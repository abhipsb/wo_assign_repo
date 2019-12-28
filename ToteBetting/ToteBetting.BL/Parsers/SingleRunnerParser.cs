namespace ToteBetting.BL.Parsers
{
    using System;
    using System.Collections.Generic;
    using ToteBetting.BL.Interfaces;

    /// <summary>
    /// Parser class to be used when single runner is involved in betting input
    /// </summary>
    internal class SingleRunnerParser : BetInputParserBase, IBetInputParser
    {
        /// <inheritdoc />
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SingleRunnerParser()
        {
            RunnersList = new List<int>();
        }

        /// <inheritdoc />
        public IList<int> RunnersList { get; set; }

        /// <inheritdoc />
        public override void DoParse(string input)
        {
            base.DoParse(input);
            RunnersList.Add(int.Parse(Runners));
            IsSuccess = true;
        }
    }
}

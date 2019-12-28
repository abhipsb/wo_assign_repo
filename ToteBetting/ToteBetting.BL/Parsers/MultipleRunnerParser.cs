namespace ToteBetting.BL.Parsers
{
    using System.Collections.Generic;
    using ToteBetting.BL.Interfaces;

    /// <summary>
    /// Parser class to be used when more than one runners are involved in betting input
    /// </summary>
    internal class MultipleRunnerParser : BetInputParserBase, IBetInputParser
    {
        private readonly char[] _runnerSeparator = { ',' };

        /// <inheritdoc />
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MultipleRunnerParser()
        {
            RunnersList = new List<int>();
        }

        /// <inheritdoc />
        public IList<int> RunnersList { get; set; }

        /// <inheritdoc />
        public override void DoParse(string input)
        {
            base.DoParse(input);
            string[] runnersArray = Runners.Split(_runnerSeparator);
            for (int index = 0; index < runnersArray.Length; index++)
            {
                var runner = int.Parse(runnersArray[index]);
                if (RunnersList.Contains(runner))
                {
                    IsSuccess = false;
                    return;
                }

                RunnersList.Add(runner);
                IsSuccess = true;
            }
        }
    }
}

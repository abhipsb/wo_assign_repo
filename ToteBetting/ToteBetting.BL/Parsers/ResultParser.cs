namespace ToteBetting.BL.Parsers
{
    using System.Collections.Generic;
    using ToteBetting.BL.Interfaces;

    /// <summary>
    /// Class for parsing the result input
    /// </summary>
    internal class ResultParser : IInputParser
    {
        private readonly char[] _inputSeparator = { ':' };

        /// <inheritdoc />
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ResultParser()
        {
            RunnersList = new List<int>();
        }

        /// <inheritdoc />
        public IList<int> RunnersList { get; set; }

        /// <inheritdoc />
        public void DoParse(string input)
        {
            var inputArray = input.Split(_inputSeparator);
            for (int index = 1; index < inputArray.Length; index++)
            {
                var runner = int.Parse(inputArray[index]);
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

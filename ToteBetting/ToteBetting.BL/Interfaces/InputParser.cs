namespace ToteBetting.BL.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Common interface for parsing
    /// </summary>
    public interface IInputParser
    {
        /// <summary>
        /// If parsing is successfull
        /// </summary>
        bool IsSuccess { get; set; }

        /// <summary>
        /// List of runners
        /// </summary>
        IList<int> RunnersList { get; set; }

        /// <summary>
        /// Method to parse the input and separate the values
        /// </summary>
        /// <param name="input"></param>
        void DoParse(string input);
    }
}

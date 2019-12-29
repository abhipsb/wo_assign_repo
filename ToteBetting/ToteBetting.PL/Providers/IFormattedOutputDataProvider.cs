namespace ToteBetting.PL.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for providing Output Data
    /// </summary>
    public interface IFormattedOutputDataProvider
    {
        /// <summary>
        /// Formatted data for display
        /// </summary>
        string OutputData { get; }
    }
}
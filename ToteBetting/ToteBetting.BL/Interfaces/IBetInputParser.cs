namespace ToteBetting.BL.Interfaces
{
    /// <summary>
    /// Interface for bet parsing
    /// </summary>
    public interface IBetInputParser : IInputParser
    {
        /// <summary>
        /// Code for the betting product
        /// </summary>
        string ProductCode { get; set; }

        /// <summary>
        /// Bet amount
        /// </summary>
        double BetAmount { get; set; }
    }
}

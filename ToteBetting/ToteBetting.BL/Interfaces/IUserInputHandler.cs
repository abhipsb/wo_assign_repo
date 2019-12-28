namespace ToteBetting.BL.Interfaces
{
    /// <summary>
    /// Interface for user input handling e.g. Bets
    /// </summary>
    public interface IUserInputHandler
    {
        /// <summary>
        /// Process the user input and pass to the corresponding Bet Product
        /// </summary>
        /// <param name="betInput"></param>
        /// <returns>true - if success, false otherwise</returns>
        bool Process(string betInput);
    }
}

namespace ToteBetting.PL.Ui
{
    using System;
    using ToteBetting.BL.Creator;
    using ToteBetting.BL.Interfaces;
    using ToteBetting.PL.Providers;

    /// <summary>
    /// Main class of the exe
    /// </summary>
    public class UserInterface
    {
        private const char MenuChoiceBet = '1';
        private const char MenuChoiceResult = '2';
        private const char MenuChoiceDisplay = '3';
        private const char MenuChoiceReset = '4';
        private const char MenuChoiceExit = '5';
        private const string ExitCode = "exit";

        /// <summary>
        /// The main function of console app
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string userInputValue = string.Empty;
            char mainMenuChoice = 'A';
            while (true)
            {
                bool clearConsole = false;
                if (userInputValue == string.Empty)
                {
                    mainMenuChoice = MenuProvider.DoGetMainMenuChoice();
                    clearConsole = true;
                }

                userInputValue = GetUserInputAsPerChoice(mainMenuChoice, clearConsole);
                if (mainMenuChoice.Equals(MenuChoiceExit))
                {
                    break; // Exit the main while loop => Terminate the program
                }

                if (userInputValue.ToLower().Equals(ExitCode))
                {
                    userInputValue = string.Empty;
                    continue;
                }

                ProcessUserInput(mainMenuChoice, userInputValue);
            }
        }


        /// <summary>
        /// Gets the input from user as per choice e.g. Bets / Result
        /// </summary>
        /// <param name="userChoice"></param>
        /// <param name="clearConsole"></param>
        /// <returns></returns>
        private static string GetUserInputAsPerChoice(char userChoice, bool clearConsole = true)
        {
            string userInputValue = string.Empty;
            switch (userChoice)
            {
                case MenuChoiceBet:
                    userInputValue = MenuProvider.DoGetBetsInput(clearConsole);
                    break;
                case MenuChoiceResult:
                    userInputValue = MenuProvider.DoGetResultInput(clearConsole);
                    break;
                case MenuChoiceDisplay:
                    //userInputValue = MenuProvider.DoGetBallotInput(clearConsole);
                    break;
                case MenuChoiceReset:
                    break;
                case MenuChoiceExit:
                    //userInputValue = MenuChoiceExit.ToString();
                    break;
            }

            return userInputValue;
        }

        /// <summary>
        /// Send the user input to BL for processing
        /// </summary>
        /// <param name="userChoice"></param>
        /// <param name="userInputValue"></param>
        private static void ProcessUserInput(char userChoice, string userInputValue)
        {
            bool processResult = true;
            bool reset = false;
            switch (userChoice)
            {
                case MenuChoiceBet:
                    processResult = BlAccessor.ProcessBetInput(userInputValue, reset);
                    break;
                case MenuChoiceResult:
                    processResult = BlAccessor.ProcessResultInput(userInputValue);
                    reset = false;
                    break;
                case MenuChoiceDisplay:
                    ProcessDividendOutput();
                    //reset = true;
                    break;
                case MenuChoiceReset:
                    BlAccessor.ResetGlobals();
                    break;
                case MenuChoiceExit:
                    break;
            }

            if (!processResult)
            {
                DisplayError();
            }
        }

        /// <summary>
        /// Prepare the dividends data for display
        /// </summary>
        /// <param name="userInputValue"></param>
        private static void ProcessDividendOutput()
        {
            IOutputDataProvider outputProvider = BlAccessor.GetOutputDataProvider();
            DisplayOutput(outputProvider.OutputData);
        }

        /// <summary>
        /// Display the dividends
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ballotRounds"></param>
        //private static void DisplayDividends(BallotResult result, int ballotRounds)
        //{
        //    Console.WriteLine("\nResults after round " + ballotRounds + " ballot count");
        //    foreach (var kingdomName in result.TieList)
        //    {
        //        IKingdom kingdom = BlAccessor.GetKingdom(kingdomName);
        //        Console.WriteLine("Output: Allies for " + kingdom.KingdomName + ": " + kingdom.AlliesNameList.Count);
        //    }
        //}

        /// <summary>
        /// Display the error message
        /// </summary>
        private static void DisplayError()
        {
            Console.WriteLine("Invalid input");
        }
        
        /// <summary>
        /// Display the result on console and wait
        /// </summary>
        /// <param name="outputResult">String which needs to be displayed</param>
        private static void DisplayOutput(string outputResult)
        {
            Console.Out.WriteLine();
            Console.Out.WriteLine("Output:");
            Console.Out.WriteLine(outputResult);
            Console.Out.WriteLine();
            Console.Out.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
}
namespace ToteBetting.PL.Providers
{
    using System;

    /// <summary>
    /// Class provides the different menus for user input
    /// </summary>
    internal class MenuProvider
    {
        private static  string m_HeaderLines = "=======================";
        private static  string m_MainMenuLines = "==========";
        private static  string m_InputMenuLines = "========================";
        private static  string m_WelcomeMessage = "Welcome to ToteBetting";
        private static  string m_MainMenuText = "Main Menu";
        private static  string m_ChoseOptionText = "Choose from below options:";
        private static  string m_YourChoiceText = "Your Choice: ";
        private static  int m_DivideBy = 2;
        private static  int m_YPos0 = 0;
        private static  int m_YPos1 = 1;
        private static  int m_YPos2 = 2;

        /// <summary>
        /// Display the main program header
        /// </summary>
        private static void DisplayHeader()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / m_DivideBy, m_YPos0);
            Console.Out.WriteLine(m_HeaderLines);
            Console.SetCursorPosition(Console.WindowWidth / m_DivideBy, m_YPos1);
            Console.Out.WriteLine(m_WelcomeMessage);
            Console.SetCursorPosition(Console.WindowWidth / m_DivideBy, m_YPos2);
            Console.Out.WriteLine(m_HeaderLines);
        }

        /// <summary>
        /// Display main menu
        /// </summary>
        internal static char DoGetMainMenuChoice()
        {
            DisplayHeader();
            Console.Out.WriteLine(m_MainMenuLines);
            Console.Out.WriteLine(m_MainMenuText);
            Console.Out.WriteLine(m_MainMenuLines);
            Console.Out.WriteLine(m_ChoseOptionText);
            Console.Out.WriteLine("1. Input Bets");
            Console.Out.WriteLine("2. Input Result");
            Console.Out.WriteLine("3. Display Dividends");
            Console.Out.WriteLine("4. Reset All Previous Inputs");
            Console.Out.WriteLine("5. Exit");
            Console.Out.Write(m_YourChoiceText);
            return Console.ReadKey(true).KeyChar;
        }

        /// <summary>
        /// Get the inputs for Betting
        /// </summary>
        /// <param name="showMenu"></param>
        /// <returns></returns>
        internal static string DoGetBetsInput(bool showMenu = true)
        {
            return DoGetInput(showMenu);
        }

        /// <summary>
        /// Get the input of betting result
        /// </summary>
        /// <param name="showMenu"></param>
        /// <returns></returns>
        internal static string DoGetResultInput(bool showMenu = true)
        {
            return DoGetInput(showMenu, true);
        }

        /// <summary>
        /// Read the input from user
        /// </summary>
        /// <returns></returns>
        private static string DoGetUserInput()
        {
            Console.Out.WriteLine("Input [type exit to stop]: ");
            return Console.ReadLine();
        }
        
        /// <summary>
        /// Get the input from user
        /// </summary>
        private static string DoGetInput(bool showMenu = true, bool isResultInput = false)
        {
            string displayString = "Input the bets:";
            if (isResultInput)
            {
                displayString = "Input the results:";
            }

            if (showMenu)
            {
                DisplayHeader();
                Console.Out.WriteLine(m_InputMenuLines);
                Console.Out.WriteLine(displayString);
                Console.Out.WriteLine(m_InputMenuLines);
            }

            return DoGetUserInput();
        }
    }
}

This file provides the information about the solution to the problem named "Tote Betting".
This is a console based application, developed in Visual Studio 2017 environment. [.Net Framework 4.5.2]

=========================================================================================================
1. Running the application
=========================================================================================================
1.1 Open the ToteBetting.sln in Visual Studio
1.2 Make sure ToteBetting.PL is the startup project
1.3 Press F5 or "Ctrl + F5" key to run the application
1.4 A console window will be displayed

=========================================================================================================
2. How to use the application
=========================================================================================================
2.1 On the console window, choose the option by pressing respective number key.

-> 2.1.1 Pressing number key 1 will open the page to input the bets
	-> input the bet in the prescribed format and press Enter key
		-> if the input is accepted, system will prompt for input again
		-> if the input is not accepted, system will show error "Invalid Input" and prompt for input again
			NOTE: For multiple runners input, duplicate runners are not accepted in each input
	-> the input prompt will continue untill you input exit
	NOTE: Every accepted input is stored and accumulated in memory.		

-> 2.1.2 Pressing number key 2 will open the page to input the result
	-> input the result in the prescribed format and press Enter key
		-> if the input is accepted, system will prompt for input again
		-> if the input is not accepted, system will show error "Invalid Input" and prompt for input again
			NOTE: For multiple runners input, duplicate runners are not accepted in each input
	-> the input prompt will continue untill you input exit
	NOTE: Every accepted input overwrites the previously stored input in memory

-> 2.1.3 Pressing number key 3 will display the dividends in prescribed format as per the betting result
-> 2.1.4 Pressing number key 4 will reset the all previously stored bets and result i.e. all inputs will be removed from memory
	-> NOTE: Please use this step only when you want to remove all previous inputs and start fresh
-> 2.1.5 Pressing number key 5 will close/quit the application

=========================================================================================================
3. Code organization
=========================================================================================================
There are 4 assenblies in the solution i.e ToteBetting.PL, ToteBetting.BL, ToteBetting.DL and ToteBetting.UnitTest.

3.1 ToteBetting.PL [exe]
	-> This is the main executable assembly.
	-> It's the Presentation Layer or Ui. All kind of Input/Output is handled here.
	-> It gets user input and send it to BL layer for processing via an interfacing class BlAccessor.
	-> After processing is done at BL layer, the results are displayed accordingly.

3.2 ToteBetting.BL [dll]
	-> This assembly is Business Layer.
	-> It processes the user input and send the results back.
	-> Two handler classes are implemented that handles two types of input i.e. Bets and Result.
	-> Three parser classes are implemented to parse three types of input i.e. Bet with one runner, Bet with more than one runner and Result.
		-> There is one base parser class with common behaviour.
	-> A Product class is implemented for representing the betting products i.e. WIN, PLACE, EXACTA, and QUINELLA.
		-> The class aggregates DataStore (via Interface) for storing the Bets data.
		-> The class aggregates Dividend Calculator (via Interface) for getting the dividend as per result.
	-> Four different classes implemented to calculate dividends for each product type i.e. ExactaCalculator, PlaceCalculator, QuinellaCalculator, and WinCalculator
	-> The InstanceCreator class is a kind of factory which creates instances of different classes.
	-> ParserProvider class is used to get appropriate parser as per the input e.g. parser for bet or result inputs.
	-> OutputDataProvider class provides the dividends of each product for display purpose.
	-> The class BlAccessor provides functionality for interfacing with PL or any external component e.g. Unit Tests.

3.3 ToteBetting.DL [dll]
	-> This assembly is Data Layer.
	-> ListCollectionDataStore class is implemented to store/retrieve bets data.
	-> Currently all the bets data is stored unsing List collection.
	-> The access to the data store is provided via an interface IDataStore.
	-> The InstanceCreator class creates the instance of the ListCollectionDataStore.
	-> The class DlAccessor provides functionality for interfacing with BL or any external component.

3.4 ToteBetting.UnitTest [dll]
	-> This is the Unit Test assembly.
	-> All Unit Tests run with each build.
	-> If all tests are passed then build will be success otherwise failure.

All the layers (PL, BL and DL) are separate and independent, and connected via Accessor classes.

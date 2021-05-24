#include<iostream>
using namespace std;

void main()
{
	int userChoice = 0;
	char userSwitched = 'I'; // placeholder value 'I'
	int gamesPlayed = 0;
	int gamesWon = 0;
	int gamesLost = 0;
	char playAgain = 'R'; // placeholder value 'R'

	// set the seed for the random number
	srand((unsigned int)time(NULL));

	int winningCardIndex = rand() % 3;;



	while (playAgain != 'N' && playAgain != 'n')
	{
		cout << "There is only one card that wins. The others lose. Try to pick the winning card!" << endl;
		cout << "Pick a card: [1] [2] [3]" << endl;

		do
		{
			cin >> userChoice;

			if (userChoice < 1 || userChoice > 3)
			{
				// prevents the program from going into an endless loop after a non-number is entered
				cin.clear();
				cin.ignore(100, '\n');

				cout << "Enter a number from [1-3]." << endl;
			}

		} while (userChoice < 1 || userChoice > 3);

		cout << "'User chose " << userChoice << "'" << endl;

		cout << "You made your choice. Now, I'll put away one of the cards you didn't choose. It is a losing card." << endl;
		cout << "You have the opportunity to change your mind. Will you switch cards with me?" << endl;
		cout << "Switch cards? [Y\\N]" << endl;

		do
		{
			cin >> userSwitched;

			if (userSwitched != 'Y' && userSwitched != 'N' &&
				userSwitched != 'y' && userSwitched != 'n')
			{
				cin.clear();
				cin.ignore(100, '\n');
				cout << "Enter Yes or No [Y\\N]." << endl;
			}

		} while (userSwitched != 'Y' && userSwitched != 'N' &&
			userSwitched != 'y' && userSwitched != 'n');



		// there are basically 4 possible outcomes
		// outcome 1: player chose correctly at first try and doesn't switch	   -> player wins
		// outcome 2: player chose correctly at first try but switches			   -> player loses
		// outcome 3: player chose wrong at first try but switches to winning card -> player wins
		// outcome 4: player chose wrong but doesn't switch						   -> player loses

		if (userChoice == winningCardIndex)
		{
			if (userSwitched == 'N' || userSwitched == 'n')
			{
				// player won
				gamesWon++;
				cout << "Congratulations! You won!" << endl;
			}
			else
			{
				// player lost
				gamesLost++;
				cout << "You lost. :(" << endl;
			}
		}
		else
		{
			if (userSwitched == 'Y' || userSwitched == 'y')
			{
				// player won
				gamesWon++;
				cout << "Congratulations! You won!" << endl;
			}
			else
			{
				// player lost
				gamesLost++;
				cout << "You lost. :(" << endl;
			}
		}
		gamesPlayed++;

		cout << "Do you want to play again? Press any button to replay, or 'N' to quit." << endl;
		cin >> playAgain;
	}


	cout << "Times played: " << gamesPlayed << endl;
	cout << "Times won: " << gamesWon << ", or " << gamesWon * 1.0f / gamesPlayed * 100.0f << "% of games have been won." << endl;
	cout << "Times lost: " << gamesLost << ", or " << gamesLost * 1.0f / gamesPlayed * 100.0f << "% of games have been lost." << endl;

	cin.get();
}
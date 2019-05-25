using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV2
{
    class Tic
    {
        //to fill the field
        private string[] basicNumbers = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        //global player names
        private string namePlayer1;
        private string namePlayer2;

        //to keep looping while true
        private bool inGame = true;

        //creating the field
        private void Field()
        {
            Console.WriteLine("----------");
            Console.WriteLine(" {0} | {1} | {2}", basicNumbers[0], basicNumbers[1], basicNumbers[2]); // 1 2 3
            Console.WriteLine("----------");
            Console.WriteLine(" {0} | {1} | {2}", basicNumbers[3], basicNumbers[4], basicNumbers[5]); // 4 5 6
            Console.WriteLine("----------");
            Console.WriteLine(" {0} | {1} | {2}", basicNumbers[6], basicNumbers[7], basicNumbers[8]); // 7 8 9
            Console.WriteLine("----------");
        }
        //to get the name of the players
        private void GetName()
        {
            Console.WriteLine("Player1 (x) please give in a name...");
            namePlayer1 = Console.ReadLine();
            Console.WriteLine("Player2 (o) please give in a name...");
            namePlayer2 = Console.ReadLine();
            Console.WriteLine("Names entered, please press enter to start game!");
            Console.ReadLine();

        }

        //method to get the players numbers
        private void InputPlayer1()
        {
            Console.WriteLine("{0} please give in a number...", namePlayer1);
            string inputString = Console.ReadLine();
            int inP1;
            //conversion to int for comparison reasons
            bool inputBool = Int32.TryParse(inputString, out inP1);
            if (inputBool)
            {
                //in case the value is negative
                if(inP1 < 0)
                {
                    inP1 = -inP1;
                }
                //field is from 1 to 9
                if (inP1 > 9)
                {
                    Console.WriteLine("Please give in a valid number!");
                }
                if(inP1 > 0 && inP1 <= 9)
                {
                    if (CheckInput(inP1))
                    {
                        //inP1 is the value the player gives. -1 gives the index of that value
                        basicNumbers[inP1 - 1] = "x";
                    }
                }
                
            }
        }
        //same as InputPlayer1
        private void InputPlayer2()
        {
            Console.WriteLine("{0} please give in a number...", namePlayer2);
            string inputString = Console.ReadLine();
            int inP2;
            bool inputBool = Int32.TryParse(inputString, out inP2);
            if (inputBool)
            {
                if (inP2 < 0)
                {
                    inP2 = -inP2;
                }
                if (inP2 > 9)
                {
                    Console.WriteLine("Please give in a valid number!");
                }
                if (inP2 > 0 && inP2 <= 9)
                {
                    if (CheckInput(inP2))
                    {
                        basicNumbers[inP2 - 1] = "o";
                    }
                }

            }
        }

        //check if the value has not already been given
        private bool CheckInput(int playerInput)
        {
            //convert playerInput (inP1) to a string for comparison reasons
            string playerInputString = Convert.ToString(playerInput);
            //for loop to prevent having to use multiple if statements
            for(int i = 0; i < 9; i++)
            {
                //basicNumbers are the numbers in the field
                if(playerInputString == basicNumbers[i])
                {
                    return true;
                }
                               
            }
            Console.WriteLine("Number already taken!");
            //count is used to decide when the game ends in a draw
            //after 8 turns the game is a draw (field is full without winner)
            //a double value should not count for this, as it does not fill the field with x or o
            count--;
            return false;
        }

        //multiple if statements to check if player1 has won (three in a row (vertical, horizontally and cross))
        //"prints" Field so the players can see.
        private bool CheckWinnerP1()
        {
            if(basicNumbers[0] == "x" && basicNumbers[1] == "x" && basicNumbers[2] == "x")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer1);
                return inGame = false;
            }
            if (basicNumbers[3] == "x" && basicNumbers[4] == "x" && basicNumbers[5] == "x")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer1);
                return inGame = false;
            }
            if (basicNumbers[6] == "x" && basicNumbers[7] == "x" && basicNumbers[8] == "x")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer1);
                return inGame = false;
            }
            if (basicNumbers[0] == "x" && basicNumbers[3] == "x" && basicNumbers[6] == "x")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer1);
                return inGame = false;
            }
            if (basicNumbers[1] == "x" && basicNumbers[4] == "x" && basicNumbers[7] == "x")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer1);
                return inGame = false;
            }
            if (basicNumbers[2] == "x" && basicNumbers[5] == "x" && basicNumbers[8] == "x")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer1);
                return inGame = false;
            }
            if (basicNumbers[0] == "x" && basicNumbers[4] == "x" && basicNumbers[8] == "x")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer1);
                return inGame = false;
            }
            if (basicNumbers[2] == "x" && basicNumbers[4] == "x" && basicNumbers[6] == "x")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer1);
                return inGame = false;
            }
            //to decide when it is a draw
            if (count == 8)
            {
                Field();
                Console.WriteLine("Draw!");
                return inGame = false;
            }
            return inGame = true;
        }

        //same as above for player2
        private bool CheckWinnerP2()
        {
            if (basicNumbers[0] == "o" && basicNumbers[1] == "o" && basicNumbers[2] == "o")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer2);
                return inGame = false;
            }
            if (basicNumbers[3] == "o" && basicNumbers[4] == "o" && basicNumbers[5] == "o")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer2);
                return inGame = false;
            }
            if (basicNumbers[6] == "o" && basicNumbers[7] == "o" && basicNumbers[8] == "o")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer2);
                return inGame = false;
            }
            if (basicNumbers[0] == "o" && basicNumbers[3] == "o" && basicNumbers[6] == "o")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer2);
                return inGame = false;
            }
            if (basicNumbers[1] == "o" && basicNumbers[4] == "o" && basicNumbers[7] == "o")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer2);
                return inGame = false;
            }
            if (basicNumbers[2] == "o" && basicNumbers[5] == "o" && basicNumbers[8] == "o")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer2);
                return inGame = false;
            }
            if (basicNumbers[0] == "o" && basicNumbers[4] == "o" && basicNumbers[8] == "o")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer2);
                return inGame = false;
            }
            if (basicNumbers[2] == "o" && basicNumbers[4] == "o" && basicNumbers[6] == "o")
            {
                Field();
                Console.WriteLine("{0} has won the game!", namePlayer2);
                return inGame = false;
            }
            if(count == 8)
            {
                Field();
                Console.WriteLine("Draw!");
                return inGame = false;
            }
            return inGame = true;
        }
        //in order to restart the game
        private void RestartGame()
        {
            Console.WriteLine("Want to play again? Press enter\nType exit to stop playing");
            string restartString = Console.ReadLine();
            //if player types exit (with or without capitals) the console will close
            if(restartString.ToLower() == "exit")
            {
                Environment.Exit(0);
            }
            //otherwise it will reset the counter, reset the basicNumbers (field) and set inGame to true
            //inGame is set to false after a player wins
            else
            {
                count = 0;
                basicNumbers = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                inGame = true;
            }
        }
        //to determine a draw
        //8 turns means a field filled without winner
        private int count = 0;

        //Game for players in seperate methods. To ensure right order of methods
        private void GameP1()
        {
            //showing the field
            Field();
            //getting input
            InputPlayer1();
            //check if player has won
            CheckWinnerP1();
            //has he won, show RestartGame
            if(inGame == false)
            {
                RestartGame();
            }
            //increase count to determine draw
            count++;
        }

        //same as GameP1
        private void GameP2()
        {
            Field();
            InputPlayer2();
            CheckWinnerP2();
            if(inGame == false)
            {
                RestartGame();
            }
            count++;
        }

        //Game
        public void Game()
        {
            GetName();
            while (inGame)
            {
                GameP1();
                GameP2();
            }
        }
    }
}

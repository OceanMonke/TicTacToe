using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    class Program
    {

        static char[,] playBoard =
        {
            {'1', '2', '3' }, // Row 0
            {'4', '5', '6' }, // Row 1
            {'7', '8', '9' }  // Row 2
        };

        

        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2;
            bool inputCorrect = true;
            char input = ' ';




            do
            {
                if (player == 2)
                {
                    player = 1;
                    
                    InputXorO(player, input);

                }
                else
                {
                    player = 2;
                    
                    InputXorO(player, input);
                }

                Board();

                #region
                // Checking winning conditions

                char[] playerChars = { 'X', 'O' };

                foreach (char playerChar in playerChars)
                {
                    if ((playBoard[0,0] == playerChar) && (playBoard[0,1] == playerChar) && (playBoard[0,2] == playerChar) 
                        || (playBoard[1, 0] == playerChar) && (playBoard[1, 1] == playerChar) && (playBoard[1, 2] == playerChar)
                        || (playBoard[2, 0] == playerChar) && (playBoard[2, 1] == playerChar) && (playBoard[2, 2] == playerChar)
                        || (playBoard[0, 0] == playerChar) && (playBoard[1, 0] == playerChar) && (playBoard[2, 0] == playerChar)
                        || (playBoard[0, 1] == playerChar) && (playBoard[1, 1] == playerChar) && (playBoard[2, 1] == playerChar)
                        || (playBoard[0, 2] == playerChar) && (playBoard[1, 2] == playerChar) && (playBoard[2, 2] == playerChar)
                        || (playBoard[0, 0] == playerChar) && (playBoard[1, 1] == playerChar) && (playBoard[2, 2] == playerChar)
                        || (playBoard[0, 2] == playerChar) && (playBoard[1, 1] == playerChar) && (playBoard[2, 0] == playerChar)
                        ) 
                    {
                        Console.WriteLine("We have a winner!");

                        if (playerChar == 'X')
                        {
                            player = 1;
                        }
                        else
                        {
                            player = 2;
                        }
                        Console.WriteLine($"The winner is Player {player}");

                        Console.WriteLine("Press any key to reset the game!");
                        Console.ReadKey();

                        ResetBoard();
                        break;

                    }
                    else if (turns == 8)
                    {
                        Console.WriteLine("Draw!");
                        Console.WriteLine("Press any key to reset the game!");
                        Console.ReadKey();

                        ResetBoard();
                        break;

                    }

                    
                }

                #endregion


                #region
                // Entering field numbers and checking if fields are already taken

                do
                {
                    
                    Console.WriteLine("\nPlayer {0}: Choose your field!", player);
                    input = Console.ReadKey().KeyChar;

                    string inputString = input.ToString();
                    bool correctInput = Regex.IsMatch(inputString, "[0-9]");

                    turns++;
                    

                    if (!correctInput)
                    {
                        Console.WriteLine("\n\nPlease enter correct field number!");
                        inputCorrect = false;
                    }
                    else
                    {
                        if (input.Equals('1') && (playBoard[0, 0] == '1'))
                        {
                            inputCorrect = true;
                        }
                        else if (input.Equals('2') && (playBoard[0, 1] == '2'))
                        {
                            inputCorrect = true;
                        }
                        else if (input.Equals('3') && (playBoard[0, 2] == '3'))
                        {
                            inputCorrect = true;
                        }
                        else if (input.Equals('4') && (playBoard[1, 0] == '4'))
                        {
                            inputCorrect = true;
                        }
                        else if (input.Equals('5') && (playBoard[1, 1] == '5'))
                        {
                            inputCorrect = true;
                        }
                        else if (input.Equals('6') && (playBoard[1, 2] == '6'))
                        {
                            inputCorrect = true;
                        }
                        else if (input.Equals('7') && (playBoard[2, 0] == '7'))
                        {
                            inputCorrect = true;
                        }
                        else if (input.Equals('8') && (playBoard[2, 1] == '8'))
                        {
                            inputCorrect = true;
                        }
                        else if (input.Equals('9') && (playBoard[2, 2] == '9'))
                        {
                            inputCorrect = true;
                        }
                        else
                        {
                            Console.WriteLine("\nThis field is already taken!");
                            inputCorrect = false;
                        }

                        Console.Clear(); 
                    }

                    
                     

                } while (!inputCorrect);

                #endregion


            } while (inputCorrect);
        }

        public static void ResetBoard()
        {
            char[,] playBoardInit =
        {
            {'1', '2', '3' }, // Row 0
            {'4', '5', '6' }, // Row 1
            {'7', '8', '9' }  // Row 2
        };

            playBoard = playBoardInit;
            Board();
            turns = 0;
        }

        public static void Board()
        {

            Console.WriteLine("\n       |       |        ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", playBoard[0,0], playBoard[0, 1], playBoard[0, 2]);
            Console.WriteLine("_______|_______|_______");       
            Console.WriteLine("       |       |        ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", playBoard[1, 0], playBoard[1, 1], playBoard[1, 2]);
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |        ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", playBoard[2, 0], playBoard[2, 1], playBoard[2, 2]);
            Console.WriteLine("       |       |       ");

        }

        public static void InputXorO(int player, int input)
        {
            char playerSign = ' ';

            if (player == 2) 
            {
                playerSign = 'X';
            }
            else if (player == 1)
            {
                playerSign = 'O';
            }

            switch (input)
            {
                case '1':
                    playBoard[0, 0] = playerSign;
                    break;
                case '2':
                    playBoard[0, 1] = playerSign;
                    break;
                case '3':
                    playBoard[0, 2] = playerSign;
                    break;
                case '4':
                    playBoard[1, 0] = playerSign;
                    break;
                case '5':
                    playBoard[1, 1] = playerSign;
                    break;
                case '6':
                    playBoard[1, 2] = playerSign;
                    break;
                case '7':
                    playBoard[2, 0] = playerSign;
                    break;
                case '8':
                    playBoard[2, 1] = playerSign;
                    break;
                case '9':
                    playBoard[2, 2] = playerSign;
                    break;
            }
        }

    }
}

using System;

namespace TicTacToe_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Play();
        }
        public static void Play()
        {
            int playAgain;
            do
            {
                SingleGame();
                Console.Write("Enter 1 to play again or enter any other key to stop playing");
                if(int.TryParse(Console.ReadLine(), out playAgain) && playAgain == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Starting new game...");
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Exiting game...");
                }
            }while(playAgain == 1);
        }
        public static void SingleGame()
        {
            //variables declaration
            int selectedField;
            bool isPlayerOne = true;
            bool gameWon = false;
            bool gameTie = false;
            string winningPlayer;
            //Initialize Matrix Obj
            Matrix matrix = new Matrix();
            while (!gameWon && !gameTie)
            {
                matrix.DisplayMatrix();
                selectedField = matrix.MoveSelector(isPlayerOne);
                if (selectedField > 0)
                {
                    matrix.ApplyMove(selectedField, isPlayerOne);
                    gameWon = matrix.checkWin(selectedField);
                    if (!gameWon)
                    {
                        gameTie = matrix.CheckTie();
                        isPlayerOne = !isPlayerOne;
                    }
                }
                Console.Clear();
            }
            matrix.DisplayMatrix();
            if (gameTie)
            {
                Console.WriteLine("Game Tie!");
            }
            else
            {
                winningPlayer = isPlayerOne ? "Player 1" : "Player 2";
                Console.WriteLine($"{winningPlayer} won the game!");
            } 
        }
    }
}

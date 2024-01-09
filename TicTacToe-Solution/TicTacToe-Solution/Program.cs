using System;

namespace TicTacToe_Solution
{
    class Program
    {
        static char[,] board = new char[3, 3];
        public static void InitiatilizeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        public static void DisplayBoard()
        {
            Console.WriteLine("  1 2 3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write((i + 1) + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int[] GetPlayerMove()
        {
            int[] move = new int[2];

            Console.WriteLine($"Player choose a row to play");
            move[0] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Player choose a column to play");
            move[1] = Convert.ToInt32(Console.ReadLine());

            return move;
        }

        static bool IsValidMove(int row, int column)
        {
            return row > 0 && row < 4 && column > 0  && column < 4 && board[row - 1, column - 1] == '-';
        }

        static bool CheckForWin(char player)
        {
            // verify rows and columns. 
            // Possible Horizontal or Vertical win
            for (int i = 0;i < 3;i++)
            {
                if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) || (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                {
                    return true;
                }
            }
            // Verify Diagonal Win
            if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) || (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
            {
                return true;
            }

            return false;
        }

        static bool BoardIsFull()
        {
            foreach (char position in board) {
                if (position == '-')
                {
                    return false;
                }
            }

            return true;
        }

        static void Game()
        {
            bool gameFinish = false;
            char currentPlayer = 'X';
            InitiatilizeBoard();

            while (!gameFinish)
            {
                DisplayBoard();

                Console.WriteLine($"Player {currentPlayer} turn");

                int[] currentPlayerMove = GetPlayerMove();
                int row = currentPlayerMove[0];
                int column = currentPlayerMove[1];

                while (!IsValidMove(row, column))
                {
                    Console.WriteLine("Invalid Move");
                    currentPlayerMove = GetPlayerMove();
                    row = currentPlayerMove[0];
                    column = currentPlayerMove[1];
                }

                board[row - 1, column - 1] = currentPlayer;

                if (CheckForWin(currentPlayer))
                {
                    DisplayBoard();
                    Console.WriteLine($"Player {currentPlayer} Wins!");
                    gameFinish = true;
                }
                else if (BoardIsFull())
                {
                    DisplayBoard();
                    Console.WriteLine($"It's a draw!");
                    gameFinish = true;
                }
                else
                {
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                }
            }

            Console.WriteLine($"Do you wanto to play again?");
            Console.WriteLine($"Type S (Yes) or N (No)");
            string response = Console.ReadLine().ToLower();
            if (response != "s" || response != "n")
            {
                Console.WriteLine($"Invalid Response");
                Console.WriteLine($"Type S (Yes) or N (No)");
                response = Console.ReadLine().ToLower();
            }
           

            if (response == "s")
            {
                Game();
            }
            else
            {
                return;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Tic Tac Toe Game");

            Game();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


        }
    }
}

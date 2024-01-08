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

            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void DisplayBoard()
        {
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            bool gameFinish = false;
            char currentPlayer = 'X';

            InitiatilizeBoard();

            Console.WriteLine("Welcome to the Tic Tac Toe Game");

            while (!gameFinish)
            {
                DisplayBoard();

                Console.WriteLine($"Player {currentPlayer} turn");


            }


        }
    }
}

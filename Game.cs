using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        private string[,] board = {
            {"1", "2", "3"},
            {"4", "5", "6"},
            {"7", "8", "9"}
        };
        private string currentTurn = "X";
        private bool gameFinished = false;

        public void GameLoop()
        {
            while (!this.gameFinished)
            {
                Console.Clear();
                this.DrawBoard();
                this.PlayTheTurn();
                this.IsGameFinished();
            }
        }

        public void DrawBoard()
        {
            Console.WriteLine();
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(" | ");
                    }
                    Console.Write(this.board[i, j] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine(" -------------");
            }
        }

        private void IsGameFinished()
        {
            this.CheckForWinner();
            if (IsBoardFilled())
            {
                Console.WriteLine("No winners!");
                this.gameFinished = true;
            }
        }

        private void CheckForWinner()
        {
            this.CheckColumnsForWinner();
            this.CheckRowsForWinner();
            this.CheckDiagonalForWinner();
        }

        private void CheckRowsForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (this.board[i, 0] == "X" && this.board[i, 1] == "X" && this.board[i, 2] == "X")
                {
                    Console.WriteLine("X is the winner!");
                    this.gameFinished = true;
                }else if (this.board[i, 0] == "O" && this.board[i, 1] == "O" && this.board[i, 2] == "O")
                {
                    Console.WriteLine("O is the winner!");
                    this.gameFinished = true;
                }
            }
        }

        private void CheckColumnsForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (this.board[0, i] == "X" && this.board[1, i] == "X" && this.board[2, i] == "X")
                {
                    Console.WriteLine("X is the winner!");
                    this.gameFinished = true;
                }
                else if (this.board[0, i] == "O" && this.board[1, i] == "O" && this.board[2, i] == "O")
                {
                    Console.WriteLine("O is the winner!");
                    this.gameFinished = true;
                }
            }
        }

        private void CheckDiagonalForWinner()
        {
            if (this.board[1, 1] == "X")
            {
                if (this.board[0, 0] == "X" && this.board[2, 2] == "X")
                {
                    Console.WriteLine("X is the winner!");
                    this.gameFinished = true;
                }
                else if (this.board[2, 0] == "X" && this.board[0, 2] == "X")
                {
                    Console.WriteLine("X is the winner!");
                    this.gameFinished = true;
                }
            } else if (this.board[1, 1] == "O")
            {
                if (this.board[0, 0] == "O" && this.board[2, 2] == "O")
                {
                    Console.WriteLine("O is the winner!");
                    this.gameFinished = true;
                }
                else if (this.board[2, 0] == "O" && this.board[0, 2] == "O")
                {
                    Console.WriteLine("O is the winner!");
                    this.gameFinished = true;
                }
            }
        }

        private bool IsBoardFilled()
        {
            bool filled = true;
            for (int i = 0; i<3; i++)
            {
                for (int j = 0; j<3; j++)
                {
                    if(this.board[i, j] != "X" && this.board[i, j] != "O")
                    {
                        filled = false;
                    }
                }
            }
            return filled;
        }

        private void PlayTheTurn()
        {
            string input = this.GetUserInputs();
            while (!this.ValidateInput(input))
            {
                input = this.GetUserInputs();
            }
            this.UpdateBoard(input);
        }

        private void UpdateBoard(string input)
        {
            int row = 0; int column = 0;
            switch (input)
            {
                case "1":
                    row = 0;
                    column = 0;
                    break;
                case "2":
                    row = 0;
                    column = 1;
                    break;
                case "3":
                    row = 0;
                    column = 2;
                    break;
                case "4":
                    row = 1;
                    column = 0;
                    break;
                case "5":
                    row = 1;
                    column = 1;
                    break;
                case "6":
                    row = 1;
                    column = 2;
                    break;
                case "7":
                    row = 2;
                    column = 0;
                    break;
                case "8":
                    row = 2;
                    column = 1;
                    break;
                case "9":
                    row = 2;
                    column = 2;
                    break;
            }
            if (this.board[row, column] != "X" && this.board[row, column] != "Y")
            {
                this.board[row, column] = this.currentTurn;
                this.currentTurn = this.currentTurn == "X" ? "O" : "X";
            }
            
        }

        private string GetUserInputs()
        {
            Console.Write("Select your box (current turn {0}): ", this.currentTurn);
            return Console.ReadLine();
        }

        private bool ValidateInput(string input)
        {
            int num;
            if (int.TryParse(input, out num) && num > 0 && num < 10)
            {
                return true;
            }
            return false;
        }
    }
}

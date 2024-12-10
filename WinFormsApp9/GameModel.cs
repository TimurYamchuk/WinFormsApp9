
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    public class GameModel
    {
        private string[,] board = new string[3, 3];
        private string currentPlayer = "X";

        public string[,] Board => board;
        public string CurrentPlayer => currentPlayer;

        public void MakeMove(int row, int col)
        {
            board[row, col] = currentPlayer;
            currentPlayer = currentPlayer == "X" ? "O" : "X";
        }

        public bool CheckWin(out string winner)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(board[i, 0]) && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    winner = board[i, 0];
                    return true;
                }

                if (!string.IsNullOrEmpty(board[0, i]) && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    winner = board[0, i];
                    return true;
                }
            }

            if (!string.IsNullOrEmpty(board[0, 0]) && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                winner = board[0, 0];
                return true;
            }

            if (!string.IsNullOrEmpty(board[0, 2]) && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                winner = board[0, 2];
                return true;
            }

            winner = null;
            return false;
        }

        public bool CheckDraw()
        {
            return board.Cast<string>().All(cell => !string.IsNullOrEmpty(cell));
        }

        public void Reset()
        {
            board = new string[3, 3];
            currentPlayer = "X";
        }
    }
}

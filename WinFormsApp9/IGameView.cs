using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    public interface IGameView
    {
        event Action<int, int> CellClicked;
        event Action<bool> NewGameRequested;
        bool IsEasyMode { get; }
        bool IsPlayerXFirst { get; }

        void UpdateBoard(string[,] board);
        void ShowMessage(string message);
        void DisableAllButtons();
    }
}

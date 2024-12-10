using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    public class GamePresenter
    {
        private readonly IGameView view;
        private readonly GameModel model;

        public GamePresenter(IGameView view, GameModel model)
        {
            this.view = view;
            this.model = model;

            this.view.CellClicked += OnCellClicked;
            this.view.NewGameRequested += OnNewGameRequested;

            StartNewGame(view.IsPlayerXFirst);
        }

        private void OnCellClicked(int row, int col)
        {
            model.MakeMove(row, col);
            view.UpdateBoard(model.Board);

            if (model.CheckWin(out string winner))
            {
                view.ShowMessage($"{winner} победил!");
                view.DisableAllButtons();
                return;
            }

            if (model.CheckDraw())
            {
                view.ShowMessage("Ничья!");
            }
        }

        private void OnNewGameRequested(bool isPlayerXFirst)
        {
            StartNewGame(isPlayerXFirst);
        }

        private void StartNewGame(bool isPlayerXFirst)
        {
            model.Reset();
            if (!isPlayerXFirst)
            {
                model.MakeMove(1, 1); // Ход AI в центр
            }
            view.UpdateBoard(model.Board);
        }
    }
}


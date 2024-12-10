using System;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class Form1 : Form, IGameView
    {
        private Button[,] buttons = new Button[3, 3];
        private RadioButton easyModeButton;
        private RadioButton hardModeButton;
        private CheckBox firstMoveCheckbox;
        private Button newGameButton;

        public event Action<int, int> CellClicked;
        public event Action<bool> NewGameRequested;

        public bool IsEasyMode => easyModeButton.Checked;
        public bool IsPlayerXFirst => firstMoveCheckbox.Checked;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (buttons[i, j] == clickedButton)
                        {
                            CellClicked?.Invoke(i, j);
                            return;
                        }
                    }
                }
            }
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            NewGameRequested?.Invoke(IsPlayerXFirst);
        }

        public void UpdateBoard(string[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Text = board[i, j];
                    buttons[i, j].Enabled = string.IsNullOrEmpty(board[i, j]);
                }
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Игра окончена");
        }

        public void DisableAllButtons()
        {
            foreach (var button in buttons)
            {
                button.Enabled = false;
            }
        }
    }
}

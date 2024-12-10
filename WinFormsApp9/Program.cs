using System;
using System.Windows.Forms;

namespace TicTacToeGame
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new Form1();
            var model = new GameModel();
            var presenter = new GamePresenter(view, model);

            Application.Run(view);
        }
    }
}

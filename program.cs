using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Figures;
using Chess.Exeptions;
using Chess.GUI;

using System.Windows.Forms;
namespace Chess
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ////throw new InvalidFigureMovement("deba");
            ///Some Testing
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window ChessGame = new window("Agd","Marto");
            ChessGame.AddEvents();
            Application.Run(ChessGame);
            
           
           
            
            
        }

    }
}

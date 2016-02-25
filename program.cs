using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Figures;
namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {

            ChessBoard masa = new ChessBoard();
            //masa.placeWhiteFigures();
            //masa.placeBlackFigures();
            //Console.WriteLine(masa);
            Console.WriteLine(masa);
            
            Queen C = new Queen('A', 2, true);
            Queen D = new Queen('B',3, true);
           Queen S = new Queen('C', 4, true);
            masa.placeFigure(C);
           masa.placeFigure(D);
          
            masa.placeFigure(S);

            Console.WriteLine(masa.PathBetweenBoxesFree(masa.getChessBoxByCoordinates('C', 4), masa.getChessBoxByCoordinates('A', 2)));
            Console.WriteLine(masa);
         
            
           
           
        }
    }
}

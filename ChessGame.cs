using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Exeptions;
namespace Chess
{
    class ChessGame
    {
        private ChessBoard board;
        public bool lastMovedWhite;
        public ChessGame()
        {
            board = new ChessBoard();
            board.placeBlackFigures();
            board.placeWhiteFigures();
            lastMovedWhite=false;
          
        }
        public ChessBoard Board
        {
            get
            {
                return this.board;
            }

            private set
            {
                this.board = value;
            }
        }
        public void Move(char figureX,int figureY, char destX,int destY,bool isWhiteColorPlayer)
        {
            if (lastMovedWhite==isWhiteColorPlayer)
            {
                throw new ArgumentException("It's the other player's turn!");
            }
            ChessBox figureBox = board.getChessBoxByCoordinates(figureX, figureY);
            if ((figureBox.Figure==null)||(figureBox.Figure.isWhite!=isWhiteColorPlayer))
            {
                throw new InvalidFigureMovementExeption("Invalid operation! You should move one of your figures!");
            }
            ChessBox endBox = board.getChessBoxByCoordinates(figureX, figureY);
            board.Move(figureBox, endBox);
            lastMovedWhite = !lastMovedWhite;
        }
        public void Move(ChessBox start,ChessBox end, bool isWhiteColorPlayer)
        {
            if (lastMovedWhite==isWhiteColorPlayer)
            {
                throw new ArgumentException("It's the other player's turn!");
            }
            if ((start.Figure == null) || (start.Figure.isWhite != isWhiteColorPlayer))
            {
                throw new InvalidFigureMovementExeption("Invalid operation! You should move one of your figures!");
            }
            board.Move(start, end);
            lastMovedWhite = !lastMovedWhite;

        }
        
   
    }
}

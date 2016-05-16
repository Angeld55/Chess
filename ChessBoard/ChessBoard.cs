using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;
using Chess.Figures;
using Chess.Exeptions;

namespace Chess
{
    public class ChessBoard
    {
        private ChessBox[,] chessBoard;

        public ChessBoard()
        {
            chessBoard = new ChessBox[8, 8];

            //Fill The Board with ChessBoxes;
            bool isWhite = true;
            int arrArgX = 0;
            for (int i = 1; (i < 9); i++)
            {
                int arrArgY = 0;

                for (char a = 'A'; a < 'I'; a++)
                {
                    chessBoard[arrArgX, arrArgY] = new ChessBox(a, i, isWhite);
                    if (a != 'H')
                    {
                        isWhite = !isWhite;
                    }
                    
                    arrArgY++;
                }
                arrArgX++;
                
            }

          //inTheMatrix
          //MatrixCoordinates->ChessBoxCoordinates
          //X->  0-->'A' ,1-->'B'..
          //Y->  0--> 1,  1--> 2 ..
        }
        public void Move(ChessBox start,ChessBox end)
        {
            Move(start.Figure, end.Xcoord, end.Ycoord);
        }
        public ChessBox[,] Boxes 
        {
            get
            {
                return this.chessBoard;
            }
        }
        public void placeBlackFigures()
        {
            Figure[] pawns = new Figure[8];
            Figure[] otherFigures = new Figure[8];
            char currentChar = 'A';
            char charPositionPawn = 'A';
            for (int i = 0; i < 8; i++)
            {

                pawns[i] = new Pawn(charPositionPawn, 2, false);
                charPositionPawn++;


                if ((currentChar == 'A') || (currentChar == 'H'))
                {
                    otherFigures[i] = new Rook(currentChar, 1, false);
                }
                else if ((currentChar == 'B') || (currentChar == 'G'))
                {
                    otherFigures[i] = new Knight(currentChar, 1, false);
                }
                else if ((currentChar == 'C') || (currentChar == 'F'))
                {
                    otherFigures[i] = new Bishop(currentChar, 1, false);
                }
                else if (currentChar == 'E')
                {
                    otherFigures[i] = new King(currentChar, 1, false);
                }
                else
                {
                    otherFigures[i] = new Queen(currentChar, 1, false);

                }

                currentChar++;
            }
            for (int i = 0; i < 8; i++)
            {
                placeFigure(pawns[i]);
                placeFigure(otherFigures[i]);
            }


        }
        public void placeWhiteFigures()
        {
            Figure[] pawns = new Figure[8];
            Figure[] otherFigures = new Figure[8];
            char currentChar = 'A';
            char charPositionPawn = 'A';
            for (int i = 0; i < 8; i++)
            {

                pawns[i] = new Pawn(charPositionPawn, 7, true);
                charPositionPawn++;


                if ((currentChar == 'A') || (currentChar == 'H'))
                {
                    otherFigures[i] = new Rook(currentChar, 8, true);
                }
                else if ((currentChar == 'B') || (currentChar == 'G'))
                {
                    otherFigures[i] = new Knight(currentChar, 8, true);
                }
                else if ((currentChar == 'C') || (currentChar == 'F'))
                {
                    otherFigures[i] = new Bishop(currentChar, 8, true);
                }
                else if (currentChar == 'E')
                {
                    otherFigures[i] = new King(currentChar, 8, true);
                }
                else
                {
                    otherFigures[i] = new Queen(currentChar, 8, true);

                }

                currentChar++;
            }
            for (int i = 0; i < 8; i++)
            {
                placeFigure(pawns[i]);
                placeFigure(otherFigures[i]);
            }


        }
        public void Move(Figure f, char x, int y)
        
        {

            var chessBoxStart = this.getChessBoxByCoordinates(f.Xpositon, f.Ypositon);
            var chessBoxEnd = this.getChessBoxByCoordinates(x, y);
            bool isFigureWhite = f.isWhite;
            if (f.getFigureType().Equals("Pawn"))
            {
                this.MovePawn(f, x, y);
            }
            else if(f.getFigureType().Equals("King")&&chessBoxEnd.isFigureOn()&&chessBoxEnd.Figure.getFigureType().Equals("Rook")&&chessBoxStart.Figure.isWhite==chessBoxEnd.Figure.isWhite)
            {//checking for Rocade
                King king = (King)f;
                Rook rook = (Rook)chessBoxEnd.Figure;

                if (PathBetweenBoxesFree(chessBoxStart,chessBoxEnd))
                {
                    if ((!king.isMoved)&&(!rook.isMoved))
                    {
                        if(rook.Xpositon=='A')
                        {
                            chessBoxEnd.Figure.Move('D', chessBoxEnd.Ycoord);
                            this.getChessBoxByCoordinates('D', chessBoxEnd.Ycoord).Figure = chessBoxEnd.Figure;
                            chessBoxEnd.deleteFigure();

                            chessBoxStart.Figure.Move('C', chessBoxStart.Ycoord);
                            this.getChessBoxByCoordinates('C', chessBoxStart.Ycoord).Figure = chessBoxStart.Figure;
                            chessBoxStart.deleteFigure();

                            if (isInChess(f.isWhite))
                            {
                                king.BackToLastPosition();
                                rook.BackToLastPosition();
                                chessBoxEnd.Figure = this.getChessBoxByCoordinates('D', chessBoxEnd.Ycoord).Figure;
                                chessBoxStart.Figure = this.getChessBoxByCoordinates('C', chessBoxStart.Ycoord).Figure;
                                this.getChessBoxByCoordinates('D', chessBoxEnd.Ycoord).deleteFigure();
                                this.getChessBoxByCoordinates('C', chessBoxStart.Ycoord).deleteFigure();
                                throw new KingInChessExeption("You cannot move here! You will be in chess!");
                            }
                        }
                        else
                        {
                            chessBoxEnd.Figure.Move('F', chessBoxEnd.Ycoord);
                            this.getChessBoxByCoordinates('F', chessBoxEnd.Ycoord).Figure = chessBoxEnd.Figure;
                            chessBoxEnd.deleteFigure();

                            chessBoxStart.Figure.Move('G', chessBoxStart.Ycoord);
                            this.getChessBoxByCoordinates('G', chessBoxStart.Ycoord).Figure = chessBoxStart.Figure;
                            chessBoxStart.deleteFigure();

                            if (isInChess(f.isWhite))
                            {
                                king.BackToLastPosition();
                                rook.BackToLastPosition();
                                chessBoxEnd.Figure = this.getChessBoxByCoordinates('F', chessBoxEnd.Ycoord).Figure;
                                chessBoxStart.Figure = this.getChessBoxByCoordinates('G', chessBoxStart.Ycoord).Figure;
                                this.getChessBoxByCoordinates('F', chessBoxEnd.Ycoord).deleteFigure();
                                this.getChessBoxByCoordinates('G', chessBoxStart.Ycoord).deleteFigure();
                                throw new KingInChessExeption("You cannot move here! You will be in chess!");
                            }
                        }
                    }
                    else
                    {
                        throw new RocadeNotPossibleExeption("Rocade not possible!The figures has been moved");
                    }
                }
                else
                {
                    throw new RocadeNotPossibleExeption("Rocade not possible!There is a figure on the way!");
                }
            }
            else
            {
                if (PathBetweenBoxesFree(chessBoxStart, chessBoxEnd))
                {
                    if (chessBoxEnd.isFigureOn())
                    {
                        if (chessBoxStart.Figure.isWhite != chessBoxEnd.Figure.isWhite)
                        {
                            Figure figureToDestroy = chessBoxEnd.Figure;
                            f.Move(x, y);
                            chessBoxEnd.Figure.DestroyFigure();
                            chessBoxStart.Figure = null;
                            chessBoxEnd.Figure = f;
                            if (isInChess(f.isWhite))
                            {
                                chessBoxStart.Figure = f;
                                f.BackToLastPosition();
                                figureToDestroy.BackToLastPosition();
                                chessBoxEnd.Figure = figureToDestroy;
                                throw new KingInChessExeption("You cannot move here! You will be in chess!");
                            }
                        }
                        else
                        {
                            throw new InvalidAttackExeption("Invalid movement! You cannot attack your figure!");
                        }
                    }
                    else
                    {
                        f.Move(x, y);
                        chessBoxStart.Figure = null;
                        chessBoxEnd.Figure = f;
                        if (isInChess(f.isWhite))
                        {
                            f.BackToLastPosition();
                            chessBoxStart.Figure = f;
                            chessBoxEnd.Figure = null;
                            throw new KingInChessExeption("You cannot move here! You will be in chess!");
                        }
                    }
                }
                else
                {
                    throw new PathBetweenBoxesNotFreeExeption("The path between the boxes is not free");
                }
            }
           
            ///if Move coordinates invalid figure.move -argument exeption 
        }

        public Figure figureOnBox(char x, int y)
        {
            return getChessBoxByCoordinates(x,y).Figure;
        }
  
        public bool PathBetweenBoxesFree(ChessBox start, ChessBox end)
        {
                if (start.Xcoord == end.Xcoord)
                 {

                     char sameX = start.Xcoord;
                    
                    if(start.Ycoord<end.Ycoord)
                    {
                        
                        for (int i = start.Ycoord+1; i <end.Ycoord ; i++)
                        {
                            
                            if(getChessBoxByCoordinates(sameX,i).isFigureOn())
                            {
                                return false;
                            }
                            
                        }
                        return true;
                    }
                    else if(start.Ycoord>end.Ycoord)
                    {
                        for (int i = end.Ycoord + 1; i < start.Ycoord; i++)
                        {
                            if (getChessBoxByCoordinates(sameX, i).isFigureOn())
                            {
                                return false;
                            }
                            
                        }
                        return true;
                    }
                }
                else if(start.Ycoord==end.Ycoord)
                {
                    int sameY = start.Ycoord;

                    if (start.Xcoord < end.Xcoord)
                    {
                        for (int i = start.Xcoord + 1; i < end.Xcoord; i++)
                        {
                            if (getChessBoxByCoordinates(Convert.ToChar(i), sameY).isFigureOn())
                            {
                                return false;
                            }
                            
                        }
                        return true;
                    }
                    else if (start.Xcoord > end.Xcoord)
                    {
                        for (int i = end.Xcoord + 1; i < start.Xcoord; i++)
                        {
                            if (getChessBoxByCoordinates(Convert.ToChar(i), sameY).isFigureOn())
                            {
                                return false;
                            }
                            
                        }
                        return true;
                    }
                }
                else if (((end.Xcoord > end.Ycoord) && (end.Ycoord > start.Ycoord)) && (((end.Xcoord - start.Xcoord) == (end.Ycoord - start.Ycoord))))
                {/// down right
                    
                    char indexX = Convert.ToChar(start.Xcoord + 1);
                    int indexY = start.Ycoord + 1;
                   while(indexY<end.Ycoord)
                   {
                       if(getChessBoxByCoordinates(indexX,indexY).isFigureOn())
                       {
                           return false;
                       }
                       indexX++;
                       indexY++;
                   }
                   return true;
                }
            else if (((end.Xcoord>start.Xcoord)&&(start.Ycoord>end.Ycoord))&&((end.Xcoord-start.Xcoord)==(start.Ycoord-end.Ycoord)))
                {/// up right
                    
                    char indexX = Convert.ToChar(start.Xcoord + 1);
                    int indexY = start.Ycoord - 1;
                    while (indexX < end.Xcoord)
                    {
                        if (getChessBoxByCoordinates(indexX, indexY).isFigureOn())
                        {
                            return false;
                        }
                        indexX++;
                        indexY--;
                    }
                    return true;
                }
                else if ((((start.Xcoord>end.Xcoord)&&(end.Ycoord>start.Ycoord)))&&((start.Xcoord - end.Xcoord) == (end.Ycoord - start.Ycoord)))
                {/// down left
                   
                    char indexX = Convert.ToChar(start.Xcoord - 1);
                    int indexY = start.Ycoord + 1;
                    while (indexY < end.Ycoord)
                    {
                        if (getChessBoxByCoordinates(indexX, indexY).isFigureOn())
                        {
                            return false;
                        }
                        indexX--;
                        indexY++;
                    }
                    return true;
                }
                else if ((((start.Xcoord > end.Xcoord) && (start.Ycoord > end.Ycoord))) && ((start.Xcoord - end.Xcoord) == (start.Ycoord - end.Ycoord)))
                {/// up left
                    
                    char indexX = Convert.ToChar(start.Xcoord - 1);
                    int indexY = start.Ycoord - 1;
         
                    while (indexY > end.Ycoord)
                    {
                        
                        if (getChessBoxByCoordinates(indexX, indexY).isFigureOn())
                        {
                            return false;
                        }
                        indexX--;
                        indexY--;
                    }
                    return true;
                }
                
                return true;
                  
                    
                   
            
            
        }
        public void placeFigure(Figure f)
        {//PRIVATE!!
            //convert the coordinates for the matrix
            int x = f.Xpositon - 'A';
            int y = f.Ypositon - 1;
            this.chessBoard[y, x].Figure = f;

        }

        public override string ToString()
        {
            StringBuilder chessB= new StringBuilder(); 

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessB.Append(chessBoard[row, col] + " ");
                    //if (chessBoard[row, col].IsWhite)
                    //{
                    //    chessB.Append("W ");
                    //}
                    //else
                    //{
                    //    chessB.Append("b ");
                    //}
                  
               
                }
                chessB.Append("\n");
            }
            return chessB.ToString();
        }
        private void MovePawn(Figure f, char X, int Y)
         {
             var chessBoxStart = this.getChessBoxByCoordinates(f.Xpositon, f.Ypositon);
             var chessBoxEnd = this.getChessBoxByCoordinates(X, Y);
             if (PathBetweenBoxesFree(chessBoxStart, chessBoxEnd))
             {
                 if((chessBoxStart.Xcoord-chessBoxEnd.Xcoord!=0))
                 {//check if the pawn is trying to capture a figure
                     if(chessBoxEnd.isFigureOn())
                     {
                         if (chessBoxEnd.Figure.isWhite != f.isWhite)
                         {
                             f.Move(X, Y);
                             Figure FigureToKill=chessBoxEnd.Figure;
                             chessBoxEnd.deleteFigure();
                             chessBoxStart.Figure = null;
                             chessBoxEnd.Figure = f;
                             if (isInChess(f.isWhite))
                             {
                                 chessBoxStart.Figure = chessBoxEnd.Figure;
                                 chessBoxEnd.Figure.BackToLastPosition();
                                 FigureToKill.BackToLastPosition();
                                 chessBoxEnd.Figure = FigureToKill;
                                 throw new KingInChessExeption("You cannot move here! You will be in chess!");
                             }
                         }
                         else
                         {
                             throw new InvalidAttackExeption("You cannot capture your own figure!");
                         }
                     }
                     else if (getChessBoxByCoordinates(chessBoxEnd.Xcoord,chessBoxEnd.Ycoord-1).isFigureOn()&&getChessBoxByCoordinates(chessBoxEnd.Xcoord, chessBoxEnd.Ycoord - 1).Figure.getFigureType()=="Pawn")
                     {//checking for "En Passant"
                         ChessBox thePawnToBeCaptured = this.getChessBoxByCoordinates(chessBoxEnd.Xcoord, chessBoxEnd.Ycoord - 1);
                         Pawn EndPostionFigure =(Pawn)this.getChessBoxByCoordinates(chessBoxEnd.Xcoord, chessBoxEnd.Ycoord - 1).Figure;
                         if((f.isWhite!=EndPostionFigure.isWhite)&&(EndPostionFigure.lastMoveWasTwoSquares))
                         {
                             f.Move(X, Y);
                             //Figure FigureToKill = chessBoxEnd.Figure;
                             thePawnToBeCaptured.deleteFigure();
                             chessBoxStart.Figure = null;
                             chessBoxEnd.Figure = f;
                             if (isInChess(f.isWhite))
                             {
                                 chessBoxStart.Figure = chessBoxEnd.Figure;
                                 chessBoxEnd.Figure.BackToLastPosition();

                                 EndPostionFigure.pawnReborn();
                                 getChessBoxByCoordinates(EndPostionFigure.Xpositon, EndPostionFigure.Ypositon).Figure = EndPostionFigure;
                                 chessBoxEnd.Figure=null;
                                 //chessBoxEnd.Figure = FigureToKill;
                                 throw new KingInChessExeption("You cannot move here! You will be in chess!");
                             }
                         }
                         else
                         {
                             throw new InvalidFigureMovementExeption("Invalid pawn coordinates!");
                         }

                     }
                     else if(getChessBoxByCoordinates(chessBoxEnd.Xcoord,chessBoxEnd.Ycoord+1).isFigureOn()&&getChessBoxByCoordinates(chessBoxEnd.Xcoord, chessBoxEnd.Ycoord + 1).Figure.getFigureType()=="Pawn")
                     {//checking for "En Passant" 2
                         ChessBox thePawnToBeCaptured = this.getChessBoxByCoordinates(chessBoxEnd.Xcoord, chessBoxEnd.Ycoord + 1);
                         Pawn EndPostionFigure = (Pawn)this.getChessBoxByCoordinates(chessBoxEnd.Xcoord, chessBoxEnd.Ycoord + 1).Figure;
                         if ((f.isWhite != EndPostionFigure.isWhite) && (EndPostionFigure.lastMoveWasTwoSquares))
                         {
                             f.Move(X, Y);
                             //Figure FigureToKill = chessBoxEnd.Figure;
                             thePawnToBeCaptured.deleteFigure();
                             chessBoxStart.Figure = null;
                             chessBoxEnd.Figure = f;
                             if (isInChess(f.isWhite))
                             {
                                 chessBoxStart.Figure = chessBoxEnd.Figure;
                                 chessBoxEnd.Figure.BackToLastPosition();

                                 EndPostionFigure.pawnReborn();
                                 getChessBoxByCoordinates(EndPostionFigure.Xpositon, EndPostionFigure.Ypositon).Figure = EndPostionFigure;
                                 chessBoxEnd.Figure = null;
                                 //chessBoxEnd.Figure = FigureToKill;
                                 throw new KingInChessExeption("You cannot move here! You will be in chess!");
                             }
                         }
                         else
                         {
                             throw new InvalidFigureMovementExeption("Invalid pawn coordinates!");
                         }
                     }
                     else
                     {
                         throw new InvalidFigureMovementExeption("Invalid pawn coordinates!");
                     }

                 }
                 else
                 {
                     if (!chessBoxEnd.isFigureOn())
                     {
                         f.Move(X, Y);
                         chessBoxStart.Figure = null;
                         chessBoxEnd.Figure = f;
                         if (isInChess(f.isWhite))
                         {
                             chessBoxStart.Figure = chessBoxEnd.Figure;
                             chessBoxEnd.Figure.BackToLastPosition();
                             chessBoxEnd.Figure = null;
                             throw new KingInChessExeption("You cannot move here! You will be in chess!");
                         } 
                     }
                     else
                     {
                         throw new InvalidAttackExeption("Pawn cannot capture figure on this coordiantes!");
                     }
                 }
             }
             else
             {
                 throw new PathBetweenBoxesNotFreeExeption("The path between the boxes is not free");
             }

         }
        public ChessBox getChessBoxByCoordinates(char a, int y)
        {
            int xCord = a - 'A';
            int yCord = y - 1;
            
            return this.chessBoard[yCord, xCord];
        }
        private bool isInChess(bool IswhiteKing)
        {
            ChessBox kingSBox = getKingChessBox(IswhiteKing);
            int[] xChange={-1,1,0,0};
            int[] yChange = { 0, 0, 1, -1 };
            for (int i = 0; i < 4; i++)//check rook and queen
            {
                char x = kingSBox.Xcoord;
                int y = kingSBox.Ycoord;
                x = Convert.ToChar(x + xChange[i]);
                y = y + yChange[i];
                while (areValidChessBoxCoordinates(x,y))
                {
                    ChessBox boxToCheck = getChessBoxByCoordinates(x, y);
                    if (boxToCheck.isFigureOn())
                    {
                        if (boxToCheck.Figure.isWhite!=IswhiteKing)
                        {
                            if (boxToCheck.Figure.getFigureType().Equals("Rook")||(boxToCheck.Figure.getFigureType().Equals("Queen")))
                            {
                                return true;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    x = Convert.ToChar(x + xChange[i]);
                    y = y + yChange[i];
                }
            }
            //check knight 
            int[] xKnightMovment= { 1, 1, -1, -1, 2, -2, 2, -2 }; 
            int[] YKnightMovment= { 2, -2, 2, -2, 1, 1, -1, -1 };
           
            for (int i = 0; i < 8; i++)
            {
                char xCord = kingSBox.Xcoord;
                int yCord = kingSBox.Ycoord;
                xCord = Convert.ToChar(xCord + xKnightMovment[i]);
                yCord = yCord + YKnightMovment[i];

                if (areValidChessBoxCoordinates(xCord,yCord))
                {
                    ChessBox chessBoxToCheck = getChessBoxByCoordinates(xCord, yCord);
             
                    if ((chessBoxToCheck.isFigureOn()) && (chessBoxToCheck.Figure.isWhite != IswhiteKing))
                    {
                        if (chessBoxToCheck.Figure.getFigureType().Equals("Knight"))
                        {
                            return true;
                        }
                    }
                }
            }
            int[] xBishopMovment = { 1, 1, -1, -1 };
            int[] yBishopMovment = {-1, 1, -1, 1};
            ///check Bishop
            for (int i = 0; i < 4; i++)
            {
                char xBishopCheck = kingSBox.Xcoord;
                int yBishopCheck = kingSBox.Ycoord;
                xBishopCheck = Convert.ToChar(xBishopCheck + xBishopMovment[i]);
                yBishopCheck = yBishopCheck + yBishopMovment[i];
                while (areValidChessBoxCoordinates(xBishopCheck,yBishopCheck))
                {
                   
                    
                    ChessBox boxToCheck = getChessBoxByCoordinates(xBishopCheck, yBishopCheck);
                    if (boxToCheck.isFigureOn())
                    {
                        if (boxToCheck.Figure.isWhite != IswhiteKing)
                        {
                            if (boxToCheck.Figure.getFigureType().Equals("Bishop") || (boxToCheck.Figure.getFigureType().Equals("Queen")))
                            {
                                return true;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    xBishopCheck = Convert.ToChar(xBishopCheck + xBishopMovment[i]);
                    yBishopCheck = yBishopCheck + yBishopMovment[i];
                    
                }
            }
            ///check King
            int[] xKingMovment = { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] yKingMovment = { 1, 0, -1, 1, -1, -1, 0, 1 };
            for (int i = 0; i < 8; i++)
            {
                 char xKingCheck = kingSBox.Xcoord;
                 int yKingCheck = kingSBox.Ycoord;
                 xKingCheck = Convert.ToChar(xKingCheck + xKingMovment[i]);
                 yKingCheck = yKingCheck + yKingMovment[i];
                 if (areValidChessBoxCoordinates(xKingCheck,yKingCheck))
                 {
                     ChessBox boxToCheck = getChessBoxByCoordinates(xKingCheck, yKingCheck);
                     if (boxToCheck.isFigureOn())
                     {
                         if (boxToCheck.Figure.getFigureType().Equals("King")&&(boxToCheck.Figure.isWhite!=IswhiteKing))
                         {
                             return true;
                         }
                     }

                 }

            }
            ///check Pawn
             char xPawnCheck = kingSBox.Xcoord;
            int yPawnCheck = kingSBox.Ycoord;
            if (IswhiteKing)
            {
                if (areValidChessBoxCoordinates(Convert.ToChar(xPawnCheck-1),yPawnCheck-1))
                {
                    ChessBox boxToCheck = getChessBoxByCoordinates(Convert.ToChar(xPawnCheck-1),yPawnCheck-1);
                    if ((boxToCheck.isFigureOn())&&((boxToCheck.Figure.isWhite!=IswhiteKing)&&(boxToCheck.Figure.getFigureType().Equals("Pawn"))))
                    {
                        return true;
                    }
                }
                if (areValidChessBoxCoordinates(Convert.ToChar(xPawnCheck + 1), yPawnCheck - 1))
                {
                    ChessBox boxToCheck = getChessBoxByCoordinates(Convert.ToChar(xPawnCheck + 1), yPawnCheck - 1);
                    if ((boxToCheck.isFigureOn())&&((boxToCheck.Figure.isWhite != IswhiteKing) && (boxToCheck.Figure.getFigureType().Equals("Pawn"))))
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (areValidChessBoxCoordinates(Convert.ToChar(xPawnCheck + 1), yPawnCheck + 1))
                {
                    ChessBox boxToCheck = getChessBoxByCoordinates(Convert.ToChar(xPawnCheck + 1), yPawnCheck + 1);
                    if ((boxToCheck.isFigureOn())&&((boxToCheck.Figure.isWhite != IswhiteKing) && (boxToCheck.Figure.getFigureType().Equals("Pawn"))))
                    {
                        return true;
                    }
                }
                if (areValidChessBoxCoordinates(Convert.ToChar(xPawnCheck - 1), yPawnCheck + 1))
                {
                    ChessBox boxToCheck = getChessBoxByCoordinates(Convert.ToChar(xPawnCheck - 1), yPawnCheck + 1);
                    if ((boxToCheck.isFigureOn())&&((boxToCheck.Figure.isWhite != IswhiteKing) && (boxToCheck.Figure.getFigureType().Equals("Pawn"))))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private bool areValidChessBoxCoordinates(char x,int y)
        {
            if ((x<'A')||(x>'H')||(y<1)||(y>8))
            {
                return false;
            }
            return true;
        }
        private ChessBox getKingChessBox(bool isWhite)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((chessBoard[i,j].isFigureOn())&&(chessBoard[i,j].Figure.getFigureType().Equals("King")&&(chessBoard[i,j].Figure.isWhite==isWhite)))
                    {
                     return chessBoard[i,j];
                    }
                }
            }
            throw new InvalidProgramException("The king was not found!");
        }

    }
}

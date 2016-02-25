using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;
using Chess.Figures;

namespace Chess
{
    public class ChessBoard
    {
        private ChessBox[,] chessBoard;

        public ChessBoard()
        {
            chessBoard = new ChessBox[8, 8];

            //Fill The Board with Boxes;
            bool isWhite = true;
            int arrArgX = 0;
            for (int i = 1; (i < 9); i++)
            {
                int arrArgY = 0;

                for (char a = 'A'; a < 'I'; a++)
                {
                    chessBoard[arrArgX, arrArgY] = new ChessBox(a, i, isWhite);
                    if(a!='A')
                    {
                        isWhite = !isWhite;
                    }
                    
                    arrArgY++;
                }
                arrArgX++;
                
            }

          //inTheMatrix 
          //X->0-'A' ,1-->'B'..
          //Y->0-1, 1-2..
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
            f.Move(x, y);
            ///if Move coordinates invalid figure.move -argument exeption 
            chessBoxStart.Figure = null;
            var chessBoxEnd = this.getChessBoxByCoordinates(x, y);
            chessBoxEnd.Figure = f;






        }
        public Figure figureOnBox(char x, int y)
        {
            return getChessBoxByCoordinates(x,y).Figure;
        }
  
        public bool PathBetweenBoxesFree(ChessBox start, ChessBox end)
        {
                if(start.Figure.Xpositon==end.Figure.Xpositon)
                {
                    
                    char sameX=start.Figure.Xpositon;
                    
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
                else if(start.Figure.Ypositon==end.Figure.Ypositon)
                {
                    int sameY = start.Figure.Ypositon;

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
                    Console.WriteLine("agd");
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
                    Console.WriteLine("ssss");
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
                    Console.WriteLine("ASD");
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
                    Console.WriteLine("ddd");
                    char indexX = Convert.ToChar(start.Xcoord - 1);
                    int indexY = start.Ycoord - 1;
                    while (indexY < end.Ycoord)
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
                Console.WriteLine("BAH");
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
                    
                  
               
                }
                chessB.Append("\n");
            }
            return chessB.ToString();
        }
  
        public ChessBox getChessBoxByCoordinates(char a, int y)
        {
            int xCord = a - 'A';
            int yCord = y - 1;
            
            return this.chessBoard[yCord, xCord];
        }

    }
}

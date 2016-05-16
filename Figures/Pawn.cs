using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Exeptions;

namespace Chess.Figures
{
    public class Pawn : Figure
    {
        private bool isMoved = false;
        public bool lastMoveWasTwoSquares = false;
        private char xBeforeKilled;
        private int yBeforeKilled;
        public Pawn(char x, int y, bool isWhite):base(x, y, isWhite)
        {

        }
        public override void Move(char x, int y)
        {
           char currentX = this.Xpositon;
           int currentY = this.Ypositon;
            if (!this.FigureChangePosition(x, y))
            {
                throw new InvalidFigureMovementExeption("You should move the pawn to a diffrent positon");            
            }
            if(this.isWhite)
            {
                
                if(this.isMoved)
                {
                    if((x==this.Xpositon)&&(y==this.Ypositon-1)||((x==this.Xpositon+1)&&(y==this.Ypositon-1)||((x==this.Xpositon-1)&&(y==this.Ypositon-1))))
                    {
                        this.Xpositon = x;
                        this.Ypositon = y;
                    }
                    else
                    {
                        throw new InvalidFigureMovementExeption("Invalid pawn coordinates");
                    }

                }
                else
                {
                    if ((((x == this.Xpositon) && (y == this.Ypositon - 1)) || (x == this.Xpositon) && (y == this.Ypositon -2))||((x==this.Xpositon+1)&&(y==this.Ypositon-1)||((x==this.Xpositon-1)&&(y==this.Ypositon-1))))
                    {
                        this.Xpositon = x;
                        this.Ypositon = y;
                    }
                    else
                    {
                        throw new InvalidFigureMovementExeption("Invalid pawn coordinates");
                    }
                }

            }
            else
            {
                if (this.isMoved)
                {
                    if ((x == this.Xpositon) && (y == this.Ypositon + 1)||((x == this.Xpositon+1) && (y == this.Ypositon + 1))||((x == this.Xpositon-1) && (y == this.Ypositon + 1)))
                    {
                        this.Xpositon = x;
                        this.Ypositon = y;
                    }
                    else
                    {
                        throw new InvalidFigureMovementExeption("Invalid pawn coordinates");
                    }

                }
                else
                {
                    if ((((x == this.Xpositon) && (y == this.Ypositon + 1)) || (x == this.Xpositon) && (y == this.Ypositon + 2))||((x == this.Xpositon+1) && (y == this.Ypositon + 1))||((x == this.Xpositon-1) && (y == this.Ypositon + 1)))
                    {
                        this.Xpositon = x;
                        this.Ypositon = y;
                    }
                    else
                    {
                        throw new InvalidFigureMovementExeption("Invalid pawn coordinates");
                    }
                }

            }
            this.isMoved = true;
            
            if((currentY-y==2)||(currentY-y==-2))
            {
                this.lastMoveWasTwoSquares = true;
            }
            else
            {
                this.lastMoveWasTwoSquares = false;
            }
            SaveLastPosition(currentX, currentY);
            xBeforeKilled = Xpositon;
            yBeforeKilled = Ypositon;
        }

        public override void BackToLastPosition()
        {
            base.BackToLastPosition();
            if (lastMoveWasTwoSquares)
            {
                lastMoveWasTwoSquares = false;
                isMoved = false;
            }
        }
        public void pawnReborn()
        {
            this.Xpositon=xBeforeKilled;
            this.Ypositon=yBeforeKilled;
        }
      
    }
}

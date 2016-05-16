using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Exeptions;
namespace Chess.Figures
{
    public class King : Figure
    {
        public bool isMoved = false;
        private bool wasLastRocade = false;
         public King(char x, int y,bool isWhite):base(x,y,isWhite)
        {

        }
        public override void Move(char x, int y)
        {
            char currentX = Xpositon;
            int currentY = Ypositon;
            bool isRokade = false;
            if((this.Xpositon-x==2)||(this.Xpositon-x==-2))
            {
                isRokade=true;
            }
            if (!this.FigureChangePosition(x, y))
            {
                throw new InvalidFigureMovementExeption("You should move the King to a diffrent positon");
            }
            if (isRokade)
            {
                if((!this.isMoved)&&(this.Ypositon==y)&&(this.Xpositon-x==2 ||(this.Xpositon-x==-2)))
                {
                   
                    this.Xpositon = x;
                    this.Ypositon = y;
                    wasLastRocade = true;
                    
                }
                else
                {
                    throw new InvalidFigureMovementExeption("Invalid king coordinates!");
                }

            }
            else
            {

                int[] xCoordinates = { 1, 1, 1, 0, 0, -1, -1, -1 };
                int[] yCoordinates = { -1, 0, 1, 1, -1, -1, 0, 1 };
                bool moved = false;
                for (int i = 0; i < xCoordinates.Length; i++)
                {
                    if ((this.Xpositon + xCoordinates[i] == x) && (this.Ypositon + yCoordinates[i] == y))
                    {
                        moved = true;
                        this.Xpositon = x;
                        this.Ypositon = y;
                        wasLastRocade = false;
                        break;
                    }
                }
                if (!moved)
                {
                    throw new InvalidFigureMovementExeption("Invalid king coordinates!");
                }
            }
            this.isMoved = true;
            SaveLastPosition(currentX, currentY);
        }
        public override void BackToLastPosition()
        {
            if (wasLastRocade)
            {
                isMoved = false;
            }
            base.BackToLastPosition();
        }
    }
}

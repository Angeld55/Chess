using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Exeptions;

namespace Chess.Figures
{
    public class Bishop:Figure
    {
        public Bishop(char x, int y, bool isWhite): base(x, y, isWhite)
        {

        }
        public override void Move(char x, int y)
        {
            if (!this.FigureChangePosition(x,y))
            {
             
                throw new InvalidFigureMovementExeption("You should move the bishop to a diffrent positon");
            }
            char currentX = Xpositon;
            int currentY = Ypositon;
            int xDiff = this.Xpositon - x;
            int yDiff = this.Ypositon - y;
            if (xDiff<0)
            {
                xDiff = xDiff * -1;
            }
            if (yDiff < 0)
            {
                yDiff = yDiff * -1; 
            }    
            if(xDiff==yDiff)
            {
                this.Xpositon = x;
                this.Ypositon = y;
            }
            else
            {
                throw new InvalidFigureMovementExeption("Invalid bishop coordinates");
            }
            SaveLastPosition(currentX, currentY);
            
        }
    }
}

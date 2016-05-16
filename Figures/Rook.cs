using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Exeptions;
namespace Chess.Figures
{
    public class Rook : Figure
    {
        public bool isMoved = false;
        public Rook(char x, int y, bool isWhite):base(x, y, isWhite)
        {

        }
        public override void Move(char x, int y)
        {
            if (!this.FigureChangePosition(x, y))
            {
                throw new InvalidFigureMovementExeption("You should move the rook to a diffrent positon");
            }
            char currentX = this.Xpositon;
            int currentY = this.Ypositon;
            if (x==this.Xpositon)
            {
                this.Ypositon = y;
            }
            else if (y==this.Ypositon)
            {
                this.Xpositon = x;
            }
            else
            {
                throw new InvalidFigureMovementExeption("Invalid rook coordinates!");
            }
            isMoved = true;
            SaveLastPosition(currentX, currentY);
        }
    }
}

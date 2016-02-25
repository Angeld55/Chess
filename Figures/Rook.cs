using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Figures
{
    public class Rook : Figure
    {
        public Rook(char x, int y, bool isWhite):base(x, y, isWhite)
        {

        }
        public override void Move(char x, int y)
        {
            if (!this.FigureChangePosition(x, y))
            {
                throw new ArgumentException("You should move to a diffrent positon");
            }
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
                throw new ArgumentException("Invalid rook coordinates!");
            }

        }
    }
}

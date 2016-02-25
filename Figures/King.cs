using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Figures
{
    public class King : Figure
    {
         public King(char x, int y,bool isWhite):base(x,y,isWhite)
        {

        }
        public override void Move(char x, int y)
        {
            if (!this.FigureChangePosition(x, y))
            {
                throw new ArgumentException("You should move to a diffrent positon");
            }

            int[] xCoordinates = { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] yCoordinates = { -1, 0, 1, 1, -1, -1, 0, 1 };
            bool moved = false;
            for (int i = 0; i < xCoordinates.Length; i++)
            {
                if ((this.Xpositon+xCoordinates[i]==x)&&(this.Ypositon+yCoordinates[i]==y))
                {
                    moved = true;
                    this.Xpositon = x;
                    this.Ypositon = y;
                    break;
                }
            }
            if(!moved)
            {
                throw new ArgumentException("Invalid king coordinates!");
            }
        }
    }
}

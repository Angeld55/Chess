using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Figures
{
    public class Pawn : Figure
    {
        private bool isMoved = false;

        public Pawn(char x, int y, bool isWhite):base(x, y, isWhite)
        {

        }
        public override void Move(char x, int y)
        {
            if (!this.FigureChangePosition(x, y))
            {
                throw new ArgumentException("You should move to a diffrent positon");
            }
            
            if(this.isWhite)
            {
                if(this.isMoved)
                {
                    if((x==this.Xpositon)&&(y==this.Ypositon-1))
                    {
                        this.Xpositon = x;
                        this.Ypositon = y;
                    }
                    else if (true)
                    {
                        // Check if there is a figure on this place
                    }
                    else
                    {
                        throw new ArgumentException("Invalid pawn coordinates");
                    }

                }
                else
                {
                    if (((x == this.Xpositon) && (y == this.Ypositon - 1)) || (x == this.Xpositon) && (y == this.Ypositon -2))
                    {
                        this.Xpositon = x;
                        this.Ypositon = y;
                    }
                    else if (true)
                    {
                        // Check if there is a figure on this place
                    }
                    else
                    {
                        throw new ArgumentException("Invalid queen coordinates");
                    }
                }

            }
            else
            {
                if (this.isMoved)
                {
                    if ((x == this.Xpositon) && (y == this.Ypositon + 1))
                    {
                        this.Xpositon = x;
                        this.Ypositon = y;
                    }
                    else if (true)
                    {
                        // Check if there is a figure on this place
                    }
                    else
                    {
                        throw new ArgumentException("Invalid pawn coordinates");
                    }

                }
                else
                {
                    if (((x == this.Xpositon) && (y == this.Ypositon + 1)) || (x == this.Xpositon) && (y == this.Ypositon + 2))
                    {
                        this.Xpositon = x;
                        this.Ypositon = y;
                    }
                    else if (true)
                    {
                        // Check if there is a figure on this place
                    }
                    else
                    {
                        throw new ArgumentException("Invalid queen coordinates");
                    }
                }

            }

        }
    }
}

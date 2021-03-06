﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Exeptions;
namespace Chess.Figures
{
    public class Knight : Figure
    {
        public Knight(char x, int y, bool isWhite): base(x, y, isWhite)
        {

        }
        public override void Move(char x, int y)
        {

            if (!this.FigureChangePosition(x, y))
            {
                throw new InvalidFigureMovementExeption("You should move the knight to a diffrent positon");
            }
            char currentX = Xpositon;
            int currentY = Ypositon;
            int[] xMovment = { 1, 1, -1, -1, 2, -2, 2, -2 }; 
            int[] YMovment = { 2, -2, 2, -2, 1, 1, -1, -1 };
            bool movmentPossible = false;
            for (int i = 0; i < 8; i++)
            {
                if((this.Xpositon+xMovment[i]==x)&&(this.Ypositon+YMovment[i]==y))
                {
                    movmentPossible = true;
                    break;
                }
            }
            if (movmentPossible)
            {
                this.Xpositon = x;
                this.Ypositon = y;
            }
            else
            {
                throw new InvalidFigureMovementExeption("Invalid knight coordinates!");
            }
            SaveLastPosition(currentX, currentY);
        }
    }
}

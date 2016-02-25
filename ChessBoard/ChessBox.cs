using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Figures;


namespace Chess.Figures
{
    public class ChessBox
    {
        private char Xcoordinate;
        private int Ycoordinate;
        private bool isWhite;
        private Figure figure;
        public ChessBox(char X,int Y,bool iswhite)
        {
            this.Xcoord = X;
            this.Ycoord = Y;
            this.isWhite = iswhite;
          
        }
        public ChessBox(char X, int Y, bool iswhite,Figure FIgure)
        {
            this.Xcoord = X;
            this.Ycoord = Y;
            this.isWhite = iswhite;
            this.Figure = FIgure;
        }
        public Figure Figure 
        {
            get
            {
                if(this.figure==null)
                {
                    throw new ArgumentException("There is no figure on this box!");
                }
                return this.figure;
            }
            set { this.figure = value; }
        }
        public char Xcoord
        {
            get { return this.Xcoordinate; } 
            set
            {
                if((value<'A')||(value>'H'))
                {
                    
                    throw new ArgumentException("Invalid ChessBox coordinates");
                }
                this.Xcoordinate = value;
            }
            
        }
        public int Ycoord
        {
            get { return this.Ycoordinate; }
            set
            {
                if ((value < 1) || (value > 8))
                {
                    
                    throw new ArgumentException("Invalid ChessBox coordinates {0}");
                }
                this.Ycoordinate = value;
            }

        }
        public void deleteFigure()
        {
            this.Figure = null;
        }
        public bool isFigureOn()
        {
            if(this.figure==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override string ToString()
        {
           if(this.figure==null)
           {
               return this.Xcoord.ToString() + this.Ycoord;
           }
           else
           {
               return this.Figure.ToString();
           }
        }

    }
}

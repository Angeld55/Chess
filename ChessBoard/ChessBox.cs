using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Figures;
using Chess.Exeptions;


namespace Chess
{
    public class ChessBox
    {
        private char Xcoordinate;
        private int Ycoordinate;
        private bool isWhite;
        private Figure figure;
        private Figure oldFigure;
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
                    throw new ChessBoxExeption("There is no figure on this box!");
                }
                return this.figure;
            }
            set { this.figure = value; }
        }

        public bool IsWhite
        {
            get
            {
                return isWhite;
            }
            private set { this.isWhite = value; }
        }
        public char Xcoord
        {
            get { return this.Xcoordinate; } 
            set
            {
                if((value<'A')||(value>'H'))
                {

                    throw new ChessBoxExeption("Invalid ChessBox coordinates");
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
                    throw new ChessBoxExeption("Invalid ChessBox coordinates");
                }
                this.Ycoordinate = value;
            }

        }
        public void deleteFigure()
        {
            this.oldFigure=this.Figure;
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

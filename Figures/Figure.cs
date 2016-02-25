using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Figures
{
    public abstract class Figure
    {
        private char Xposition;
        private int Yposition;
        public bool isWhite;
        protected bool inPlay;
        
        
        public Figure(char x, int y,bool isWhite)
        {
            this.Xpositon = x;
            this.Ypositon = y;
            this.isWhite = isWhite;
            inPlay = true;
        }
        public char Xpositon
        {
            get{return Xposition;}
            
            protected set
                {
                    if ((value<'A')||(value>'H'))
                     {
                         string error = "Invalid X coordinate for " + this.getFigureType();
                         throw new ArgumentOutOfRangeException(error);
                     }
                    this.Xposition=value;
                }
        }
        
        public int Ypositon
        {
            get { return Yposition; }

           protected set
            {
                if ((value < 1) || (value > 8))
                {
                    string error = "Invalid Y coordinate for "+this.getFigureType();
                    throw new ArgumentOutOfRangeException(error);
                }
                this.Yposition = value;
            }
        }
        public bool FigureChangePosition(int x,int y)
        {
            if((x == this.Xpositon)&&(y==this.Ypositon))
            {
                return false;
            }
            return true;
        }
        public virtual void Move(char x , int y)
        {

        }

        public string getFigureType()
        {
            string type = this.GetType().ToString();
            int lastDot = type.LastIndexOf('.');
            StringBuilder TYPE = new StringBuilder();
            for (int i = lastDot+1; i < type.Length; i++)
            {
                TYPE.Append(type[i]);
            }
            return TYPE.ToString();

        }
        public override string ToString()
        {
            string x = this.GetType().ToString();
            return x[14].ToString()+" ";
        }

    }
}

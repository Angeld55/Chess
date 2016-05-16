using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Exeptions
{
    class InvalidFigureMovementExeption:Exception
    {
        public InvalidFigureMovementExeption(string msg):base(msg)
        {

        }
    }
}

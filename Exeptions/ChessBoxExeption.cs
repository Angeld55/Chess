using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Exeptions
{
    class ChessBoxExeption:Exception
    {
        public ChessBoxExeption(string msg):base(msg)
        {

        }
    }
}

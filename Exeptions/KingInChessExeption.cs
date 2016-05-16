using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Exeptions
{
    class KingInChessExeption:Exception
    {
        public KingInChessExeption(string msg): base(msg)
        {

        }
    }
}

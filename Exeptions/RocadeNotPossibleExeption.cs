using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Exeptions
{
    class RocadeNotPossibleExeption: Exception
    {
        public RocadeNotPossibleExeption(string msg)
            : base(msg)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Exeptions
{
    class InvalidAttackExeption:Exception
    {
        public InvalidAttackExeption(string msg)
            : base(msg)
        {

        }
    }
}

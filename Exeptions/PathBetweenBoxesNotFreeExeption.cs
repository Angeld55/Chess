﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Exeptions
{
    class PathBetweenBoxesNotFreeExeption:Exception
    {
        public PathBetweenBoxesNotFreeExeption(string msg)
            : base(msg)
        {

        }
    }
}

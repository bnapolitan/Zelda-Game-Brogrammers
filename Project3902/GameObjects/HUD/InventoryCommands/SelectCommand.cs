﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class SelectCommand : ICommand
    {
        public void Execute()
        {
            PauseScreen.Instance.SelectItem();
        }
    }
}

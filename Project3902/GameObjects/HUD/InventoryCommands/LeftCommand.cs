﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LeftCommand : ICommand
    {
        public void Execute()
        {
            PauseScreen.Instance.MoveSelectorLeft();
        }
    }
}
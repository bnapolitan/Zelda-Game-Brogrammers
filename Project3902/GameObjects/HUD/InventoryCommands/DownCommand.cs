using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class DownCommand : ICommand
    {
        public void Execute()
        {
            PauseScreen.Instance.MoveSelectorDown();
        }
    }
}

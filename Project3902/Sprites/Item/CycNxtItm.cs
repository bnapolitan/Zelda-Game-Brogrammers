using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class CycNxtItm: ICommand
    {
        private Sprint2 game;

        public CycNxtItm(Sprint2 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.cycNxtItm();
        }
    }
}

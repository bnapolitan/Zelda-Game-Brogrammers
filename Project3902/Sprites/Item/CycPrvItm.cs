using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class CycPrvItm : ICommand
    {
        private Sprint2 game;

        public CycPrvItm(Sprint2 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.cycPrvItm();
        }
    }
}

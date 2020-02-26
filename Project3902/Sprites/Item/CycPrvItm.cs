using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class CycPrvItm : ICommand
    {
        private FinalGame game;

        public CycPrvItm(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.cycPrvItm();
        }
    }
}

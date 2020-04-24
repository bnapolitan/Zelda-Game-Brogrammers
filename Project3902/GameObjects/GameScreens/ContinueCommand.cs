using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class ContinueCommand : ICommand
    {
        FinalGame game;
        public ContinueCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {

            game.Continue = true;
            game.GameStart();
            return;
            
        }
    }
}

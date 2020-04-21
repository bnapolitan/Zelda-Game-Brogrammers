using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class PauseGameCommand : ICommand
    {
        private FinalGame game;
        public PauseGameCommand(FinalGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.PauseGame();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class TotalPauseGameCommand : ICommand
    {
        private readonly FinalGame game;
        public TotalPauseGameCommand(FinalGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.TotalPauseGame();
        }
    }
}

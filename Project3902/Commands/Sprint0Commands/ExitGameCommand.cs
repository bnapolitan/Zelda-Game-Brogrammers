using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class ExitGameCommand : ICommand
    {
        private Sprint2 game;

        public ExitGameCommand(Sprint2 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}

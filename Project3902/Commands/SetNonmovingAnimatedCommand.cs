using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class SetNonmovingAnimatedCommand : ICommand
    {
        private Sprint0 game;

        public SetNonmovingAnimatedCommand(Sprint0 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetNonmovingAnimatedSprite();
        }
    }
}

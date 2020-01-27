using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class SetMovingAnimatedCommand : ICommand
    {
        private Sprint0 game;

        public SetMovingAnimatedCommand(Sprint0 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.SetMovingAnimatedSprite();
        }
    }
}

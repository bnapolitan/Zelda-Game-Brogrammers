using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class SetSpriteMouseCommand : ICommand
    {
        private Rectangle topLeft = new Rectangle(0, 0, 400, 240);
        private Rectangle topRight = new Rectangle(400, 0, 400, 240);
        private Rectangle bottomLeft = new Rectangle(0, 240, 400, 240);
        private Rectangle bottomRight = new Rectangle(400, 240, 400, 240);

        private Sprint0 game;

        public SetSpriteMouseCommand(Sprint0 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            MouseState state = Mouse.GetState();
            Point mousePos = new Point(state.X, state.Y);

            if (topLeft.Contains(mousePos))
                new SetNonmovingNonanimatedCommand(game).Execute();
            else if (topRight.Contains(mousePos))
                new SetNonmovingAnimatedCommand(game).Execute();
            else if (bottomLeft.Contains(mousePos))
                new SetMovingNonanimatedCommand(game).Execute();
            else if (bottomRight.Contains(mousePos))
                new SetMovingAnimatedCommand(game).Execute();
        }
    }
}

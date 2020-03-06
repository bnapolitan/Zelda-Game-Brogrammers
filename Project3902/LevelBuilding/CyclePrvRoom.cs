using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class CyclePrvRoom : ICommand
    {
        private FinalGame game;

        public CyclePrvRoom(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CycleRoomLast();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class CycleNextRoom : ICommand
    {
        private FinalGame game;

        public CycleNextRoom(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CycleRoomNext();
        }
    }
}

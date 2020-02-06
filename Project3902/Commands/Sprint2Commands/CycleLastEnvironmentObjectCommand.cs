using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class CycleLastEnvironmentObjectCommand : ICommand
    {
        private Sprint2 game;

        public CycleLastEnvironmentObjectCommand(Sprint2 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CycleEnvironmentLast();
        }
    }
}

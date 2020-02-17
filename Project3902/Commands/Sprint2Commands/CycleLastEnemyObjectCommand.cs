using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.Commands.Sprint2Commands
{
    class CycleLastEnemyObjectCommand :ICommand
    {
        private Sprint2 game;

        public CycleLastEnemyObjectCommand(Sprint2 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CycleEnemyLast();
        }
    }
}

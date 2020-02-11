using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.Commands.Sprint2Commands
{
    class CycleNextEnemyObjectCommand: ICommand
    {
        private Sprint2 game;

        public CycleNextEnemyObjectCommand(Sprint2 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CycleEnemyNext();
        }
    }
}

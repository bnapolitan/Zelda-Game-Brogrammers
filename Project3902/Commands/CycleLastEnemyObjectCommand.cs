using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.Commands.Sprint2Commands
{
    class CycleLastEnemyObjectCommand :ICommand
    {
        private FinalGame game;

        public CycleLastEnemyObjectCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CycleEnemyLast();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class CycleLastEnvironmentObjectCommand : ICommand
    {
        private FinalGame game;

        public CycleLastEnvironmentObjectCommand(FinalGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.CycleEnvironmentLast();
        }
    }
}

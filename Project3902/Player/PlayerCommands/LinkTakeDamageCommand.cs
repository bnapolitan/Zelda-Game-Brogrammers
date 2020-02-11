using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkTakeDamageCommand : ICommand
    {
        private ILink link;
        private Sprint2 game;

        public LinkTakeDamageCommand(ILink link, Sprint2 game)
        {
            this.link = link;
            this.game = game;
        }

        public void Execute()
        {
            game.Link = new DamagedLink(link, game);
        }
    }
}

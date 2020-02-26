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
        private FinalGame game;

        public LinkTakeDamageCommand(ILink link, FinalGame game)
        {
            this.link = link;
            this.game = game;
        }

        public void Execute()
        {
            link.TakeDamage(1);
            game.Link = new DamagedLink(link, game);
        }
    }
}

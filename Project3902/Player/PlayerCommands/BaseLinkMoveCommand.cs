using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    abstract class BaseLinkMoveCommand : ICommand
    {
        protected Link link;

        public BaseLinkMoveCommand(Link link)
        {
            this.link = link;
        }

        public abstract void Execute();
    }
}

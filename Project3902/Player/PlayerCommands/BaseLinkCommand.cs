using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    abstract class BaseLinkCommand : ICommand
    {
        protected Link link;

        public BaseLinkCommand(Link link)
        {
            this.link = link;
        }

        public abstract void Execute();
    }
}

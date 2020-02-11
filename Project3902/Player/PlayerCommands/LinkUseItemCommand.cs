using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkUseItemCommand : BaseLinkCommand
    {
        public LinkUseItemCommand(Link link)
            : base(link) { }

        public override void Execute()
        {
            link.UseItem();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkAttackCommand : BaseLinkCommand
    {
        public LinkAttackCommand(Link link)
            : base(link) { }

        public override void Execute()
        {
            link.Attack();
        }
    }
}
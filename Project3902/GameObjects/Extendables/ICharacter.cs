﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    interface ICharacter : IGameObject, ICollidable
    {
        float Health { get; set; }
    }
}

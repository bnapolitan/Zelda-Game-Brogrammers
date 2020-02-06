using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    interface ICharacter : IGameObject, IUpdatable, IDrawable, ICollideable
    {
        float Health { get; set; }
    }
}

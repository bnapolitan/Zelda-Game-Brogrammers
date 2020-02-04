using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    interface IGameObject : IUpdatable, IDrawable
    {
        Vector2 Position { get; set; }

        ISprite Sprite { get; set; }

        bool Active { get; set; }

    }
}

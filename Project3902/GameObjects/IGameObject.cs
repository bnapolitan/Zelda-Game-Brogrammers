using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects
{
    interface IGameObject
    {
        Vector2 Position { get; set; }

        ISprite Sprite { get; set; }

        void Activate();

        void Deactivate();
    }
}

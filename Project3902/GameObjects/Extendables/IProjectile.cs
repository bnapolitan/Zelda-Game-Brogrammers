using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    interface IProjectile : IGameObject, ICollideable
    {
        // Not sure if Direction and Speed should be interface members
        Vector2 Direction { get; set; }
        float Speed { get; set; }

        void Launch(Vector2 position, Vector2 direction);
    }
}

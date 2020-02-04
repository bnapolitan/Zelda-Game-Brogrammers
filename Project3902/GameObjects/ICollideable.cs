using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects
{
    interface ICollideable
    {
        Rectangle hitbox { get; set; }

        void OnCollide();
    }
}

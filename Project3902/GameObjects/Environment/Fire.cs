using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.Environment
{
    class Fire : FixedGameObject, IInteractiveEnvironmentObject
    {

        public Fire(Vector2 position)
            : base(position) { }

        public Rectangle hitbox { get; set; }

        public void OnCollide()
        {
        }
    }
}

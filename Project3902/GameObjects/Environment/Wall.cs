using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.Environment
{
    class Wall : FixedGameObject, IInteractiveEnvironmentObject
    {

        public Wall(Vector2 position)
            : base(position) { }

        public Rectangle hitbox { get; set; }
        public Rectangle Collider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void OnCollide()
        {
        }
    }
}

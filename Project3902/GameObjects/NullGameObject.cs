using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class NullGameObject : IGameObject
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }

        public NullGameObject(Vector2? position = null)
        {
            Position = position ?? Vector2.Zero;
            Sprite = new NullSprite();
        }

        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            
        }
    }
}

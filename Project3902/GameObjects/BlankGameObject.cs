using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects
{
    class BlankGameObject: IGameObject, ICollidable
    {
        public Vector2 Position { get; set; }

        public ISprite Sprite { get; set; }

        public bool Active { get; set; }

        public Collider Collider { get; set; }

        public BlankGameObject(Vector2 pos)
        {
            Position = pos;

        }
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Collider.Draw(spriteBatch);
        }

        public void OnCollide(Collider other)
        {

        }
    }
}

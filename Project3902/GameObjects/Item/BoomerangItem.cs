using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class BoomerangItem : IItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }

        public BoomerangItem(Vector2 pos)
        {
            Position = pos;
            Active = true;
        }
        public void TakeDamage()
        {

        }
        public void Attack()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
                Sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void OnCollide(Collider other)
        {
        }
    }
}

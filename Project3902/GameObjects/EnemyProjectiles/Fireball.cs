using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class Fireball : BasePlayerProjectile
    {
        private Vector2 position;
        public new Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                if (Collider != null)
                    Collider.AlignHitbox();
            }
        }

        private float distance = 500;
        private Vector2 relPos = new Vector2(0, 0);

        public Fireball(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Sprite = WeaponFactory.Instance.CreateFireballSprite(this);
            position = pos;
            Direction = initDirection;
            Speed = moveSpeed;
            Active = true;
        }

        public override void OnCollide(Collider other)
        {
            
        }
        public new void Draw(SpriteBatch spriteBatch)
        {
            if (!Active)
            {
                return;
            }
            Collider.Draw(spriteBatch);
            Sprite.Draw(spriteBatch);

        }

        public new void Update(GameTime gameTime)
        {
            if (!Active)
            {
                return;
            }

            Position += Direction * Speed;
            relPos += Direction * Speed;
            if (relPos.Length() >= distance)
            {
                Active = false;
            }
            Sprite.Update(gameTime);
        }

        public new void Launch(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
            Active = true;
        }




    }
}
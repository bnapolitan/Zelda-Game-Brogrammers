using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.Item
{
    class Bomb : IItem, IProjectile
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }
        public int Damage { get; } = 1;
        public bool IsExploding { get; set; } = false;
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }

        private int timeUntilExplosion = 120;

        public Bomb(Vector2 pos)
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

            if(timeUntilExplosion <= 0 && timeUntilExplosion > -30)
            {

            }
        }

        public void Update(GameTime gameTime)
        {
            timeUntilExplosion--;
            if(timeUntilExplosion == 0)
            {
                this.Launch(Position, new Vector2(1, 0));
                this.Active = false;
                this.IsExploding = true;
                SoundHandler.Instance.PlaySoundEffect("Bomb Blow");
            }
            if(timeUntilExplosion == -2)
            {
                this.IsExploding = false;
            }
        }

        public void OnCollide(Collider other)
        {
        }

        public void Launch(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;

            Collider.AlignHitbox();
        }
    }
}

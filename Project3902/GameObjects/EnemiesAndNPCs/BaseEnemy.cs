using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    abstract class BaseEnemy : IEnemy
    {
        public float Health { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }

        public abstract void Attack();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
            Collider.Draw(spriteBatch);
        }

        public abstract void OnCollide(Collider other);

        public abstract void TakeDamage();

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            Collider.Update(gameTime);
        }
    }
}

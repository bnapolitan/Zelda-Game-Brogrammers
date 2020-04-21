using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902.GameObjects.EnemyProjectiles
{
    class Fireball : IProjectile
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public Collider Collider { get; set; }

        public float Damage { get; set; } = 1f;
        public float distance = 470;
        private Vector2 relPos = new Vector2(0, 0);

        public Fireball(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Direction = initDirection;
            Speed = moveSpeed;
            Active = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active)
            {
                return;
            }

            Sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            if (!Active)
            {
                return;
            }

            Position += Direction * Speed;
            relPos += Direction * Speed;
            if (relPos.Length() >= distance)
            {
                Deactivate();
            }
            Sprite.Update(gameTime);
            Collider.AlignHitbox();
        }

        public void Launch(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
            CollisionHandler.Instance.RemoveCollidable(this);
        }

        public void OnCollide(Collider other)
        {
            if (other.GameObject is IEnemy)
            {
                Deactivate();
            }
        }
    }
}
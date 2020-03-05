using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902.GameObjects.EnemyProjectiles
{
    class Boomerang : IProjectile
    {
        private Vector2 _position;
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                if(Collider != null)
                {
                    Collider.AlignHitbox();
                }
                
            }
        }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public Collider Collider { get; set; }

        private readonly float maxSpeed = 1000f;
        private readonly float minSpeed = 500f;
        private readonly float distance = 500;
        private Vector2 relPos = new Vector2(0, 0);
        private bool turned = false;

        public Boomerang(Vector2 pos, float moveSpeed, Vector2 initDirection)
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
            Collider.Draw(spriteBatch);
            Sprite.Draw(spriteBatch);
            
        }


        public void Update(GameTime gameTime)
        {
            if (!Active)
                return;

            Sprite.Update(gameTime);
            float distTraveled = relPos.Length();

            Speed = (distance - distTraveled) / distance * maxSpeed;
            if (Speed < minSpeed)
                Speed = minSpeed;

            if (distTraveled > distance)
            {
                Direction *= -1;
                turned = true;
            }

            if (turned && distTraveled <= 20f)
                Active = false;

            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            relPos += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Launch(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
            Active = true;
        }

        public void OnCollide(Collider other)
        {
            if (other.GameObject is IEnemy)
            {
                Direction *= -1;
            }
        }
    }
}

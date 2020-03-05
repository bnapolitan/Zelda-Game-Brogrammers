using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902.GameObjects.EnemyProjectiles
{
    class Boomerang : IProjectile
    {
        private readonly float maxDistance = 300f;
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
        private Vector2 startingPos;
        private bool turned = false;

        public Boomerang(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            startingPos = pos;
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
            //base.Update(gameTime);
            Sprite.Update(gameTime);
            Collider.AlignHitbox();

            if (!Active)
            {
                return;
            }

            float distTraveled = (Position - startingPos).Length();


            Speed = (maxDistance - distTraveled) / maxDistance * maxSpeed;

            if ((Speed < maxSpeed * .5f))
                Speed = maxSpeed * .5f;

            if ((distTraveled > maxDistance))
            {
                Position = startingPos + maxDistance * Direction;
                Direction *= -1;
                turned = true;
            }

            if (turned && distTraveled <= 20f)
                Active = false;

            if (Position == startingPos && (distTraveled > 0))
            {
                Active = false;
            }
            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Launch(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
            Active = true;
        }

        public void OnCollide(Collider other)
        {
            if (other.GameObject is Link || other.GameObject is IInteractiveEnvironmentObject || other.GameObject is IBackgroundEnvironmentObject)
            {
                if (!turned)
                {
                    Direction *= -1;
                    turned = true;
                    Position += (Direction * ((Speed / 30) + 3));
                }
            }
        }
    }
}

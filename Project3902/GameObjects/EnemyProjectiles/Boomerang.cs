using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.ObjectManagement;

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
        public float Damage { get; set; } = 1f;
        private readonly float maxSpeed = 1000f;
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
            if (Active == false)
            {
                CollisionHandler.Instance.RemoveCollidable(this);
            }
            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Launch(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
            Active = true;
        }

        public void Deactivate()
        {
            this.Active = false;
            CollisionHandler.Instance.RemoveCollidable(this);
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

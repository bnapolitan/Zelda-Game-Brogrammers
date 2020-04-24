using Microsoft.Xna.Framework;

namespace Project3902
{
    abstract class ProjectileLaunchingEnemy : BaseEnemy
    {
        public bool hasShot = false;
        public ProjectileLaunchingEnemy(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            MoveSpeed = moveSpeed;
            Direction = initDirection;
        }

        public abstract void DespawnProjectile();

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void OnCollide(Collider other)
        {
            base.OnCollide(other);
            if (hasShot && !Active)
            {
                DespawnProjectile();
            }
        }
    }
}

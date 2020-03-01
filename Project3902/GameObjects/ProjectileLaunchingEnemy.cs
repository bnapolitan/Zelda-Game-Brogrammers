using Microsoft.Xna.Framework;

namespace Project3902
{
    abstract class ProjectileLaunchingEnemy : BaseEnemy
    {
        public float MoveSpeed { get; set; }
        public Vector2 Direction { get; set; }

        public ProjectileLaunchingEnemy(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            MoveSpeed = moveSpeed;
            Direction = initDirection;
        }
    }
}

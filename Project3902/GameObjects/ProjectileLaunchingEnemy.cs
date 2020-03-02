using Microsoft.Xna.Framework;

namespace Project3902
{
    abstract class ProjectileLaunchingEnemy : BaseEnemy
    { 
        public ProjectileLaunchingEnemy(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            MoveSpeed = moveSpeed;
            Direction = initDirection;
        }
    }
}

using Microsoft.Xna.Framework;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class OldMan : BaseEnemy
    {

        public OldMan(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            MoveSpeed = moveSpeed;
            Direction = initDirection;
        }
        public override void TakeDamage()
        {

        }
        public override void Attack()
        {

        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

       
    }
}
using Microsoft.Xna.Framework;

namespace Project3902
{
    class SwordAttack : BasePlayerProjectile
    {
        public SwordAttack()
        {
            var rect = new Rectangle(0, 0, 64, 64);
            Collider = new Collider(this, rect);
        }

        public override void Launch(Vector2 position, Vector2 direction)
        {
            base.Launch(position, direction);
            Collider.AlignHitbox();
        }
    }
}

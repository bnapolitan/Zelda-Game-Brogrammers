using Microsoft.Xna.Framework;

namespace Project3902
{
    class SwordAttack : BasePlayerProjectile
    {
        public SwordAttack()
        {
            var rect = new Rectangle(4, 4, 48, 48);
            Collider = new Collider(this, rect);
        }

        public override void Launch(Vector2 position, Vector2 direction)
        {
            base.Launch(position, direction);
            Collider.AlignHitbox();
        }
    }
}

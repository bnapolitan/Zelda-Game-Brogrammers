using Microsoft.Xna.Framework;

namespace Project3902
{
    interface IProjectile : IGameObject, ICollidable
    {
        Vector2 Direction { get; set; }
        float Speed { get; set; }

        void Launch(Vector2 position, Vector2 direction);
    }
}

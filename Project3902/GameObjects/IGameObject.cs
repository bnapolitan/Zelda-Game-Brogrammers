using Microsoft.Xna.Framework;

namespace Project3902
{
    public interface IGameObject : IUpdatable, IDrawable
    {
        Vector2 Position { get; set; }

        ISprite Sprite { get; set; }

        bool Active { get; set; }

    }
}

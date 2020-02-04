using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    public interface ISprite : IUpdatable, IDrawable
    {
        Vector2 Scale { get; set; }
        Texture2D Texture { get; set; }
        IGameObject GameObject { get; set; }
    }
}

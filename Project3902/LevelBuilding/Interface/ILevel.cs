using Microsoft.Xna.Framework;

namespace Project3902.LevelBuilding
{
    interface ILevel : IUpdatable, IDrawable
    {
        string LevelName { get; set; }
        LevelMap Map { get; set; }
        Vector2 ScrollDirection { get; set; }
        float ScrollSpeed { get; set; }
        bool Scrolling { get; set; }

        void LoadLevel();
        void OffsetGameObjects(Vector2 offset);
        void FreezeEnemies();
    }
}

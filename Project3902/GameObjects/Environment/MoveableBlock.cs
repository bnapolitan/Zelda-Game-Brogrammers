using Microsoft.Xna.Framework;

namespace Project3902.GameObjects.Environment
{
    class MoveableBlock : BaseEnvironment
    {
        public Vector2 Direction { get; set; }
        public int MaxFrames { get; set; }
        public bool HasMoved { get; set; } = false;
        public MoveableBlock(Vector2 position, Vector2 direction)
            : base(position) {
            Direction = direction;
            MaxFrames = 64;
        }

    }
}

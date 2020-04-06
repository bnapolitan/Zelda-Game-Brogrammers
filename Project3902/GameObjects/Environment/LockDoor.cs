using Microsoft.Xna.Framework;

namespace Project3902.GameObjects.Environment
{
    class LockDoor : BaseEnvironment
    {
        public int DirectionType { set; get; }
        public LockDoor(Vector2 position)
            : base(position) { }
    }
}

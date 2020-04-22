using Microsoft.Xna.Framework;
using Project3902.Configuration;
using Project3902.GameObjects.Item;

namespace Project3902.GameObjects.Environment
{
    class ExplodableWall : BaseEnvironment
    {
        private FinalGame game;
        private bool hasExploded = false;

        public ExplodableWall(Vector2 position, FinalGame game)
            : base(position) { this.game = game; }

        public override void OnCollide(Collider other)
        {
            if(other.GameObject is Bomb && (other.GameObject as Bomb).IsExploding && !hasExploded)
            {
                if(Position.X < RoomSwitchingThresholdConfiguration.LeftRoomThreshold)
                {
                    game.ExplodeWallLeft(this);
                }
                else if (Position.X > RoomSwitchingThresholdConfiguration.RightRoomThreshold)
                {
                    game.ExplodeWallRight(this);
                }
                else if (Position.Y < RoomSwitchingThresholdConfiguration.TopRoomThreshold)
                {
                    game.ExplodeWallTop(this);
                }
                else
                {
                    game.ExplodeWallBottom(this);
                }
                hasExploded = true;
                CollisionHandler.Instance.RemoveCollidable(this);
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using Project3902.GameObjects.Environment;
using System.Collections.Generic;

namespace Project3902.ObjectManagement
{
    internal class EnvironmentFactory : ISpriteFactory
    {
        private SpriteAtlas dungeonSpriteAtlas;
        private SpriteAtlas linkSpriteAtlas;
        private Vector2 environmentScale = new Vector2(4, 4);
        private FinalGame game;

        public static EnvironmentFactory Instance { get; } = new EnvironmentFactory();

        private EnvironmentFactory()
        {
        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
        }

        public void LoadAllTextures(ContentManager content)
        {
            dungeonSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("DungeonSpriteSheet"));
            linkSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("linkspritesheet"));
        }

        public static void RegisterEnvironmentForCollision(IInteractiveEnvironmentObject EnvironmentObject)
        {
            EnvironmentObject.Collider = new Collider(EnvironmentObject, new Rectangle(0, 0, 64, 64));
            CollisionHandler.Instance.RegisterCollidable(EnvironmentObject, Layer.Wall);
        }

        public static void RegisterDoorForCollision(IInteractiveEnvironmentObject door)
        {
            door.Collider = new Collider(door, new Rectangle(0, 0, 128, 128));
            CollisionHandler.Instance.RegisterCollidable(door, Layer.Wall);
        }


        public IDrawable CreateCoverScreen()
        {
            var createdObject = new HUDObject(new Vector2(0, 0));

            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(521, 11, 256, 176), new Vector2(4, 4));
            createdObject.Sprite = sprite;
            return createdObject;
        }


        public static void RegisterExplodableWallForCollision(IInteractiveEnvironmentObject door)
        {
            door.Collider = new Collider(door, new Rectangle(0, 0, 128, 128));
            CollisionHandler.Instance.RegisterCollidable(door, Layer.Wall, Layer.Projectile);
        }



        public IGameObject CreateStairs(Vector2 position)
        {
            var createdObject = new Stairs(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnvironmentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateLadderTile(Vector2 position)
        {
            var createdObject = new LadderTile(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1001, 45, 16, 16));
            createdObject.Sprite = sprite;
            RegisterEnvironmentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateGapTile(Vector2 position)
        {
            var createdObject = new GapTile(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(984, 28, 16, 16));
            createdObject.Sprite = sprite;
            RegisterEnvironmentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateFire(Vector2 position)
        {
            var createdObject = new Fire(position);
            var sprite = new FixedSprite(createdObject, linkSpriteAtlas, new Rectangle(191, 185, 16, 16));
            createdObject.Sprite = sprite;
            RegisterEnvironmentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBrickWallTile(Vector2 position)
        {
            var createdObject = new BrickTile(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(984, 45, 16, 16));
            createdObject.Sprite = sprite;
            RegisterEnvironmentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBombedOpeningTop(Vector2 position)
        {
            var createdObject = new BombedOpening(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(947, 11, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBombedOpeningBottom(Vector2 position)
        {
            var createdObject = new BombedOpening(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(947, 11, 32, 32), environmentScale)
            {
                Flip = SpriteEffects.FlipVertically
            };
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBombedOpeningLeft(Vector2 position)
        {
            var createdObject = new BombedOpening(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(947, 44, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBombedOpeningRight(Vector2 position)
        {
            var createdObject = new BombedOpening(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(947, 44, 32, 32), environmentScale)
            {
                Flip = SpriteEffects.FlipHorizontally
            };
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateRoomBorder(Vector2 position)
        {
            var createdObject = new RoomBorder(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(521, 11, 256, 176), environmentScale);
            createdObject.Sprite = sprite;
            return createdObject;
        }

        public IGameObject CreateFloorTile(Vector2 position)
        {
            var createdObject = new FloorTile(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(984, 11, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            return createdObject;
        }

        public IGameObject CreateFloorTileDirt(Vector2 position)
        {
            var createdObject = new FloorTile(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1001, 28, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            return createdObject;
        }

        public IGameObject CreateBlockingBrick(Vector2 position)
        {
            var createdObject = new BlockingBrick(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1001, 11, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnvironmentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateLeftStatue(Vector2 position)
        {
            var createdObject = new Statues(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(468, 75, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnvironmentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateRightStatue(Vector2 position)
        {
            var createdObject = new Statues(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(468, 91, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnvironmentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateEnemyCloudAppearance(Vector2 position)
        {
            var createdObject = new EnemyCloudAppearance(position);
            var sprite = new AnimatedSprite(createdObject, linkSpriteAtlas,
                new List<Rectangle> { new Rectangle(138, 185, 16, 16), new Rectangle(155, 185, 16, 16), new Rectangle(172, 185, 16, 16) },
                (float)0.25, environmentScale);
            //var sprite = new FixedSprite(createdObject, linkSpriteAtlas, new Rectangle(138, 185, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            return createdObject;
        }

        public IGameObject CreateLockDoorTop(Vector2 position)
        {
            var createdObject = new LockDoor(position)
            {
                DirectionType = 0
            };
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(881, 11, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateLockDoorBottom(Vector2 position)
        {
            var createdObject = new LockDoor(position)
            {
                DirectionType = 2
            };
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(881, 110, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateLockDoorLeft(Vector2 position)
        {
            var createdObject = new LockDoor(position)
            {
                DirectionType = 3
            };
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(881, 44, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateLockDoorRight(Vector2 position)
        {
            var createdObject = new LockDoor(position)
            {
                DirectionType = 1
            };
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(881, 77, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateOpenDoorTop(Vector2 position)
        {
            var createdObject = new OpenDoor(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(848, 11, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateOpenDoorBottom(Vector2 position)
        {
            var createdObject = new OpenDoor(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(848, 110, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateOpenDoorLeft(Vector2 position)
        {
            var createdObject = new OpenDoor(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(848, 44, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateOpenDoorRight(Vector2 position)
        {
            var createdObject = new OpenDoor(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(848, 77, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateShutDoorTop(Vector2 position)
        {
            var createdObject = new ShutDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(914, 11, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateShutDoorBottom(Vector2 position)
        {
            var createdObject = new ShutDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(914, 110, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateShutDoorLeft(Vector2 position)
        {
            var createdObject = new ShutDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(914, 44, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateShutDoorRight(Vector2 position)
        {
            var createdObject = new ShutDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(914, 77, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }
        public IGameObject CreateMoveableBlock(Vector2 position, Vector2 direction)
        {
            var createdObject = new MoveableBlock(position, direction);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1001, 11, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            createdObject.Collider = new Collider(createdObject, new Rectangle(0, 0, 64, 64));
            CollisionHandler.Instance.RegisterCollidable(createdObject, Layer.Wall);
            return createdObject;
        }

        public IGameObject CreateWallTop(Vector2 position)
        {
            var createdObject = new Wall(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 11, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateWallBottom(Vector2 position)
        {
            var createdObject = new Wall(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 110, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateWallLeft(Vector2 position)
        {
            var createdObject = new Wall(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 44, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateWallRight(Vector2 position)
        {
            var createdObject = new Wall(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 77, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterDoorForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateExplodableWallTop(Vector2 position)
        {
            var createdObject = new ExplodableWall(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 11, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterExplodableWallForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateExplodableWallBottom(Vector2 position)
        {
            var createdObject = new ExplodableWall(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 110, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterExplodableWallForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateExplodableWallLeft(Vector2 position)
        {
            var createdObject = new ExplodableWall(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 44, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterExplodableWallForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateExplodableWallRight(Vector2 position)
        {
            var createdObject = new ExplodableWall(position, game);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 77, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterExplodableWallForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBlackBackground(Vector2 position)
        {
            var createdObject = new FloorTile(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1000, 900, 64, 64), new Vector2(12, 7));
            createdObject.Sprite = sprite;
            return createdObject;
        }

        public IGameObject CreateBlackBars(Vector2 position)
        {
            var createdObject = new BlackBackground(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1000, 900, 64, 64), new Vector2(12, 15));
            createdObject.Sprite = sprite;
            return createdObject;
        }

        public IGameObject CreateWater(Vector2 position)
        {
            var createdObject = new BrickTile(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(785, 80, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnvironmentForCollision(createdObject);
            return createdObject;
        }



    }
}

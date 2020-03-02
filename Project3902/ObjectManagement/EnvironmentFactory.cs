﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using Project3902.GameObjects.Environment;
using System;
using System.Collections.Generic;

namespace Project3902.ObjectManagement
{
    internal class EnvironmentFactory : ISpriteFactory
    {
        private SpriteAtlas dungeonSpriteAtlas;
        private SpriteAtlas linkSpriteAtlas;
        private Vector2 environmentScale = new Vector2(4, 4);
        private SpriteAtlas dungeons2;

        public static EnvironmentFactory Instance { get; } = new EnvironmentFactory();

        private EnvironmentFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            dungeonSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("DungeonSpriteSheet"));
            dungeons2 = new SpriteAtlas(content.Load<Texture2D>("Dungeon_Enemies_2"));
            linkSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("linkspritesheet"));
        }

        public static void RegisterEnviromentForCollision(IInteractiveEnvironmentObject EnviromentObject)
        {
            // REPLACE: create colliders in individual Create...() methods below with correct sizes.
            // See CreateAquaGel for example.
            EnviromentObject.Collider = new Collider(EnviromentObject, new Rectangle(0, 0, 64, 64));
            CollisionHandler.Instance.RegisterCollidable(EnviromentObject, Layer.Enemy, Layer.Wall);
        }


        public IGameObject CreateStairs(Vector2 position)
        {
            var createdObject = new Stairs(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16));
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateLadderTile(Vector2 position)
        {
            var createdObject = new LadderTile(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1001, 45, 16, 16));
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateGapTile(Vector2 position)
        {
            var createdObject = new GapTile(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(984, 28, 16, 16));
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateFire(Vector2 position)
        {
            var createdObject = new Fire(position);
            var sprite = new FixedSprite(createdObject, linkSpriteAtlas, new Rectangle(191, 185, 16, 16));
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBrickTile(Vector2 position)
        {
            var createdObject = new BrickTile(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(984, 45, 16, 16));
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBombedOpeningTop(Vector2 position)
        {
            var createdObject = new BombedOpening(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(947, 11, 32, 32));
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBombedOpeningBottom(Vector2 position)
        {
            var createdObject = new BombedOpening(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(947, 11, 32, 32));
            sprite.Flip = SpriteEffects.FlipVertically;
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBombedOpeningLeft(Vector2 position)
        {
            var createdObject = new BombedOpening(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(947, 44, 32, 32));
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateBombedOpeningRight(Vector2 position)
        {
            var createdObject = new BombedOpening(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(947, 44, 32, 32));
            sprite.Flip = SpriteEffects.FlipHorizontally;
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
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

        public IGameObject CreateLeftStatue(Vector2 position)
        {
            var createdObject = new Statues(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(468, 75, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }



        public IGameObject CreateRightStatue(Vector2 position)
        {
            var createdObject = new Statues(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(468, 91, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }



        public IGameObject CreateEnemyCloudAppearance(Vector2 position)
        {
            var createdObject = new EnemyCloudAppearance(position);
            var sprite = new FixedSprite(createdObject, linkSpriteAtlas, new Rectangle(138, 185, 16, 16));
            createdObject.Sprite = sprite;
            return createdObject;
        }

        public IGameObject CreateLockDoorTop(Vector2 position)
        {
            var createdObject = new LockDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(881, 11, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateLockDoorBottom(Vector2 position)
        {
            var createdObject = new LockDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(881, 110, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }



        public IGameObject CreateLockDoorLeft(Vector2 position)
        {
            var createdObject = new LockDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(881, 44, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateLockDoorRight(Vector2 position)
        {
            var createdObject = new LockDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(881, 77, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateOpenDoorTop(Vector2 position)
        {
            var createdObject = new OpenDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(848, 11, 32, 32), environmentScale);
            createdObject.Sprite = sprite;

            return createdObject;
        }

        public IGameObject CreateOpenDoorBottom(Vector2 position)
        {
            var createdObject = new OpenDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(848, 110, 32, 32), environmentScale);
            createdObject.Sprite = sprite;

            return createdObject;
        }

        public IGameObject CreateOpenDoorLeft(Vector2 position)
        {
            var createdObject = new OpenDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(848, 44, 32, 32), environmentScale);
            createdObject.Sprite = sprite;

            return createdObject;
        }

        public IGameObject CreateOpenDoorRight(Vector2 position)
        {
            var createdObject = new OpenDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(848, 77, 32, 32), environmentScale);
            createdObject.Sprite = sprite;

            return createdObject;
        }

        public IGameObject CreateShutDoorTop(Vector2 position)
        {
            var createdObject = new ShutDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(914, 11, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateShutDoorBottom(Vector2 position)
        {
            var createdObject = new ShutDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(914, 110, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateShutDoorLeft(Vector2 position)
        {
            var createdObject = new ShutDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(914, 44, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateShutDoorRight(Vector2 position)
        {
            var createdObject = new ShutDoor(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(914, 77, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }
        public IGameObject CreateMoveableBlock(Vector2 position)
        {
            var createdObject = new MoveableBlock(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1001, 11, 16, 16), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateWallTop(Vector2 position)
        {
            var createdObject = new Wall(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 11, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateWallBottom(Vector2 position)
        {
            var createdObject = new Wall(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 110, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateWallLeft(Vector2 position)
        {
            var createdObject = new Wall(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 44, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }

        public IGameObject CreateWallRight(Vector2 position)
        {
            var createdObject = new Wall(position);
            var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(815, 77, 32, 32), environmentScale);
            createdObject.Sprite = sprite;
            RegisterEnviromentForCollision(createdObject);
            return createdObject;
        }


    }
}

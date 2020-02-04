using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.ObjectManagement
{
    class EnvironmentFactory
    {
        private SpriteAtlas dungeonSpriteAtlas;
		private SpriteAtlas linkSpriteAtlas;

		private static EnvironmentFactory instance = new EnvironmentFactory();

		public static EnvironmentFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private EnvironmentFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
        {
            dungeonSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("DungeonSpriteSheet"));
			linkSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("zeldaspritesheet"));
        }

		public IGameObject CreateStairs(Vector2 position)
		{
			var sprite =  new FixedSprite(dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16));
			var createdObject = new Stairs(sprite, position);
			sprite.GameObject = createdObject;
			return createdObject;
		}

		public IGameObject CreateLadderTile(Vector2 position)
		{
			var sprite = new FixedSprite(dungeonSpriteAtlas, new Rectangle(1001, 45, 16, 16));
			var createdObject = new LadderTile(sprite, position);
			sprite.GameObject = createdObject;
			return createdObject;
		}

		public IGameObject CreateGapTile(Vector2 position)
		{
			var sprite = new FixedSprite(dungeonSpriteAtlas, new Rectangle(984, 28, 16, 16));
			var createdObject = new GapTile(sprite, position);
			sprite.GameObject = createdObject;
			return createdObject;
		}

		public IGameObject CreateFire(Vector2 position)
		{
			var sprite = new FixedSprite(linkSpriteAtlas, new Rectangle(191, 185, 16, 16));
			var createdObject = new Fire(sprite, position);
			sprite.GameObject = createdObject;
			return createdObject;
		}

		public IGameObject CreateBrickTile(Vector2 position)
		{
			var sprite = new FixedSprite(dungeonSpriteAtlas, new Rectangle(984, 45, 16, 16));
			var createdObject = new BrickTile(sprite, position);
			sprite.GameObject = createdObject;
			return createdObject;
		}

		public IGameObject CreateBombedOpening(Vector2 position)
		{
			var sprite = new FixedSprite(dungeonSpriteAtlas, new Rectangle(947, 11, 32, 32));
			var createdObject = new BombedOpening(sprite, position);
			sprite.GameObject = createdObject;
			return createdObject;
		}

		public IGameObject CreateRoomBorder(Vector2 position)
		{
			var sprite = new FixedSprite(dungeonSpriteAtlas, new Rectangle(521, 11, 256, 176));
			var createdObject = new BombedOpening(sprite, position);
			sprite.GameObject = createdObject;
			return createdObject;
		}

		public IGameObject CreateFloorTile(Vector2 position)
		{
			var sprite = new FixedSprite(dungeonSpriteAtlas, new Rectangle(984, 11, 16, 16));
			var createdObject = new BombedOpening(sprite, position);
			sprite.GameObject = createdObject;
			return createdObject;
		}

		public IGameObject CreateEnemyCloudAppearance(Vector2 position)
		{
			var sprite = new FixedSprite(dungeonSpriteAtlas, new Rectangle(984, 11, 16, 16));
			var createdObject = new BombedOpening(sprite, position);
			sprite.GameObject = createdObject;
			return createdObject;
		}
	}
}

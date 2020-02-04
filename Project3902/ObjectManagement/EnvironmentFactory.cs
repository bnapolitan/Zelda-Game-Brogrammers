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
			linkSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("linkspritesheet"));
        }

		public IGameObject CreateStairs(Vector2 position)
		{
			var createdObject = new Stairs(position);
			var sprite =  new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateLadderTile(Vector2 position)
		{
			var createdObject = new LadderTile(position);
			var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateGapTile(Vector2 position)
		{
			var createdObject = new GapTile(position);
			var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateFire(Vector2 position)
		{
			var createdObject = new Fire(position);
			var sprite = new FixedSprite(createdObject, linkSpriteAtlas, new Rectangle(1035, 28, 16, 16));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBrickTile(Vector2 position)
		{
			var createdObject = new BrickTile(position);
			var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBombedOpening(Vector2 position)
		{
			var createdObject = new BombedOpening(position);
			var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateRoomBorder(Vector2 position)
		{
			var createdObject = new RoomBorder(position);
			var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateFloorTile(Vector2 position)
		{
			var createdObject = new FloorTile(position);
			var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateEnemyCloudAppearance(Vector2 position)
		{
			var createdObject = new EnemyCloudAppearance(position);
			var sprite = new FixedSprite(createdObject, dungeonSpriteAtlas, new Rectangle(1035, 28, 16, 16));
			createdObject.Sprite = sprite;
			return createdObject;
		}
	}
}

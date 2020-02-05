using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects.Enemies_and_NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.ObjectManagement
{
    class EnemyFactory
    {
		private SpriteAtlas dungeonSpriteAtlas;
		private SpriteAtlas overworldSpriteAtlas;

		private static EnemyFactory instance = new EnemyFactory();

		public static EnemyFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private EnemyFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			dungeonSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("DungeonSpriteSheet"));
			overworldSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("OverworldSpriteSheet"));
		}

		public IGameObject CreateAquaGel(Vector2 position)
		{
			var createdObject = new Gel(position);
			List<Rectangle> aquaGelSource = new List<Rectangle> { new Rectangle(1, 11, 8, 16), new Rectangle(10, 11, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, aquaGelSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBlueGel(Vector2 position)
		{
			var createdObject = new Gel(position);
			List<Rectangle> blueGelSource = new List<Rectangle> { new Rectangle(19, 11, 8, 16), new Rectangle(28, 11, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, blueGelSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateGreenGel(Vector2 position)
		{
			var createdObject = new Gel(position);
			List<Rectangle> greenGelSource = new List<Rectangle> { new Rectangle(37, 11, 8, 16), new Rectangle(46, 11, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, greenGelSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBrownGel(Vector2 position)
		{
			List<Rectangle> brownGelSource = new List<Rectangle> { new Rectangle(19, 28, 8, 16), new Rectangle(28, 28, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, brownGelSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBlackGel(Vector2 position)
		{
			var createdObject = new Gel(position);
			List<Rectangle> blackGelSource = new List<Rectangle> { new Rectangle(55, 28, 8, 16), new Rectangle(64, 28, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, blackGelSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateRedGoriya(Vector2 position)
		{
			var createdObject = new Goriya(position);
			List<Rectangle> redGoriyaSource = new List<Rectangle> { new Rectangle(222, 11, 16, 16), new Rectangle(239, 11, 16, 16), new Rectangle(256, 11, 16, 16), new Rectangle(273, 11, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, redGoriyaSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBlueGoriya(Vector2 position)
		{
			var createdObject = new Goriya(position);
			List<Rectangle> blueGoriyaSource = new List<Rectangle> { new Rectangle(222, 28, 16, 16), new Rectangle(239, 28, 16, 16), new Rectangle(256, 28, 16, 16), new Rectangle(273, 28, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, blueGoriyaSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBlueKeese(Vector2 position)
		{
			var createdObject = new Keese(position);
			List<Rectangle> blueKeeseSource = new List<Rectangle> { new Rectangle(183, 11, 16, 16), new Rectangle(200, 11, 16, 16)};
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, blueKeeseSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateRedKeese(Vector2 position)
		{
			var createdObject = new Keese(position);
			List<Rectangle> redKeeseSource = new List<Rectangle> { new Rectangle(183, 28, 16, 16), new Rectangle(200, 28, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, redKeeseSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateStalfos(Vector2 position)
		{
			var createdObject = new Stalfos(position);
			List<Rectangle> stalfosSource = new List<Rectangle> { new Rectangle(1, 59, 16, 16)};
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, stalfosSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateWallmaster(Vector2 position)
		{
			var createdObject = new Wallmaster(position);
			List<Rectangle> wallmasterSource = new List<Rectangle> { new Rectangle(393, 11, 16, 16), new Rectangle(409, 11, 16, 16)};
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, wallmasterSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateGreenZol(Vector2 position)
		{
			var createdObject = new Gel(position);
			List<Rectangle> greenZolSource = new List<Rectangle> { new Rectangle(77, 11, 8, 16), new Rectangle(93, 11, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, greenZolSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBlackZol(Vector2 position)
		{
			var createdObject = new Gel(position);
			List<Rectangle> blackZolSource = new List<Rectangle> { new Rectangle(94, 11, 8, 16), new Rectangle(110, 11, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, blackZolSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBrownZol(Vector2 position)
		{
			var createdObject = new Gel(position);
			List<Rectangle> brownZolSource = new List<Rectangle> { new Rectangle(77, 28, 8, 16), new Rectangle(93, 28, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, brownZolSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateRope(Vector2 position)
		{
			var createdObject = new Wallmaster(position);
			List<Rectangle> ropeSource = new List<Rectangle> { new Rectangle(126, 59, 16, 16), new Rectangle(143, 59, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, wallmasterSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}
	}
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects.Enemies_and_NPCs;
using Project3902.GameObjects.Enemies_and_NPCs.Interfaces;
using Project3902.Sprites.EnemySprites;
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
		private SpriteAtlas dungeons2;

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
			dungeonSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("DungeonEnemies"));
			dungeons2 = new SpriteAtlas(content.Load<Texture2D>("Dungeon_Enemies_2"));
		}

		public IGameObject CreateAquaGel(Vector2 position)
		{
			var createdObject = new Gel(position, 2, new Vector2(1,0));
			List<Rectangle> aquaGelSource = new List<Rectangle> { new Rectangle(403, 183, 10, 10), new Rectangle(403, 213, 10, 10) };
			var sprite = new GelSprite(createdObject, dungeons2, aquaGelSource, 0.5f, new Vector2(6,6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBlueGel(Vector2 position)
		{
			var createdObject = new Gel(position, 2, new Vector2(1, 0));
			List<Rectangle> blueGelSource = new List<Rectangle> { new Rectangle(19, 11, 8, 16), new Rectangle(28, 11, 8, 16) };
			var sprite = new GelSprite(createdObject, dungeonSpriteAtlas, blueGelSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateGreenGel(Vector2 position)
		{
			var createdObject = new Gel(position, 2, new Vector2(1, 0));
			List<Rectangle> greenGelSource = new List<Rectangle> { new Rectangle(37, 11, 8, 16), new Rectangle(46, 11, 8, 16) };
			var sprite = new GelSprite(createdObject, dungeonSpriteAtlas, greenGelSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBrownGel(Vector2 position)
		{
			var createdObject = new Gel(position, 2, new Vector2(1, 0));
			List<Rectangle> brownGelSource = new List<Rectangle> { new Rectangle(19, 28, 8, 16), new Rectangle(28, 28, 8, 16) };
			var sprite = new GelSprite(createdObject, dungeonSpriteAtlas, brownGelSource, 0.5f,new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBlackGel(Vector2 position)
		{
			var createdObject = new Gel(position, 2, new Vector2(1, 0));
			List<Rectangle> blackGelSource = new List<Rectangle> { new Rectangle(423, 183, 10, 10), new Rectangle(423, 213, 10, 10) };
			var sprite = new GelSprite(createdObject, dungeons2, blackGelSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateRedGoriya(Vector2 position)
		{
			var createdObject = new Goriya(position, 2, new Vector2(1, 0));
			List<Rectangle> leftGoriyaSource = new List<Rectangle> { new Rectangle(30, 60, 15, 15), new Rectangle(30, 90, 15, 15) };
			List<Rectangle> rightGoriyaSource = new List<Rectangle> { new Rectangle(90, 60, 15, 15), new Rectangle(90, 90, 15, 15) };
			List<Rectangle> upGoriyaSource = new List<Rectangle> { new Rectangle(60, 60, 15, 15), new Rectangle(60, 90, 15, 15) };
			List<Rectangle> downGoriyaSource = new List<Rectangle> { new Rectangle(0, 60, 15, 15), new Rectangle(0, 90, 15, 15) };
			createdObject.Sprite = new GoriyaSprite(createdObject, dungeons2, rightGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.rightFacingGoriya = new RopeSprite(createdObject, dungeons2, rightGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.leftFacingGoriya = new RopeSprite(createdObject, dungeons2, leftGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.upFacingGoriya = new RopeSprite(createdObject, dungeons2, upGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.downFacingGoriya = new RopeSprite(createdObject, dungeons2, downGoriyaSource, 0.5f, new Vector2(6, 6));
			return createdObject;
		}

		public IGameObject CreateBlueGoriya(Vector2 position)
		{
			var createdObject = new Goriya(position, 2, new Vector2(1, 0));
			List<Rectangle> leftGoriyaSource = new List<Rectangle> { new Rectangle(150, 60, 15, 15), new Rectangle(150, 90, 15, 15) };
			List<Rectangle> rightGoriyaSource = new List<Rectangle> { new Rectangle(210, 60, 15, 15), new Rectangle(210, 90, 15, 15) };
			List<Rectangle> upGoriyaSource = new List<Rectangle> { new Rectangle(180, 60, 15, 15), new Rectangle(180, 90, 15, 15) };
			List<Rectangle> downGoriyaSource = new List<Rectangle> { new Rectangle(120, 60, 15, 15), new Rectangle(120, 90, 15, 15) };
			createdObject.Sprite = new GoriyaSprite(createdObject, dungeons2, rightGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.rightFacingGoriya = new RopeSprite(createdObject, dungeons2, rightGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.leftFacingGoriya = new RopeSprite(createdObject, dungeons2, leftGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.upFacingGoriya = new RopeSprite(createdObject, dungeons2, upGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.downFacingGoriya = new RopeSprite(createdObject, dungeons2, downGoriyaSource, 0.5f, new Vector2(6, 6));
			return createdObject;
		}

		public IGameObject CreateBlueKeese(Vector2 position)
		{
			var createdObject = new Keese(position, 2, new Vector2(1, 0));
			List<Rectangle> blueKeeseSource = new List<Rectangle> { new Rectangle(234, 268, 18, 18), new Rectangle(259, 268, 18, 18)};
			var sprite = new KeeseSprite(createdObject, dungeons2, blueKeeseSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateRedKeese(Vector2 position)
		{
			var createdObject = new Keese(position, 2, new Vector2(1,0));
			List<Rectangle> redKeeseSource = new List<Rectangle> { new Rectangle(279, 268, 18, 18), new Rectangle(304, 268, 18, 18) };
			var sprite = new KeeseSprite(createdObject, dungeons2, redKeeseSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateStalfos(Vector2 position)
		{
			var createdObject = new Stalfos(position, 2, new Vector2(0,1));
			List<Rectangle> stalfosSource = new List<Rectangle> { new Rectangle(418, 119, 18, 18), new Rectangle(418, 149, 18, 18) };
			var sprite = new StalfosSprite(createdObject, dungeons2, stalfosSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateWallmaster(Vector2 position)
		{
			var createdObject = new Wallmaster(position, 2, new Vector2(1, 0));
			List<Rectangle> leftWallmasterSource = new List<Rectangle> { new Rectangle(239, 0, 18, 18), new Rectangle(239, 29, 18, 18) };
			List<Rectangle> rightWallmasterSource = new List<Rectangle> { new Rectangle(269, 0, 18, 18), new Rectangle(269, 29, 18, 18) };
			createdObject.Sprite = new WallmasterSprite(createdObject, dungeons2, rightWallmasterSource, 0.5f, new Vector2(6, 6));
			createdObject.rightFacingWallmaster = new WallmasterSprite(createdObject, dungeons2, rightWallmasterSource, 0.5f, new Vector2(6, 6));
			createdObject.leftFacingWallmaster = new WallmasterSprite(createdObject, dungeons2, leftWallmasterSource, 0.5f, new Vector2(6, 6));
			return createdObject;
		}

		public IGameObject CreateGreenZol(Vector2 position)
		{
			var createdObject = new Zol(position, 2, new Vector2(1, 0));
			List<Rectangle> greenZolSource = new List<Rectangle> { new Rectangle(380, 180, 16, 16), new Rectangle(380, 210, 16, 16) };
			var sprite = new ZolSprite(createdObject, dungeons2, greenZolSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateGrayZol(Vector2 position)
		{
			var createdObject = new Zol(position, 2, new Vector2(1, 0));
			List<Rectangle> grayZolSource = new List<Rectangle> { new Rectangle(360, 180, 16, 16), new Rectangle(360, 210, 16, 16) };
			var sprite = new ZolSprite(createdObject, dungeons2, grayZolSource, 0.5f,  new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBrownZol(Vector2 position)
		{
			var createdObject = new Zol(position, 2, new Vector2(1, 0));
			List<Rectangle> brownZolSource = new List<Rectangle> { new Rectangle(77, 28, 16, 16), new Rectangle(94, 28, 16, 16) };
			var sprite = new ZolSprite(createdObject, dungeonSpriteAtlas, brownZolSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateRope(Vector2 position)
		{
			var createdObject = new Rope(position, 2, new Vector2(1, 0));
			List<Rectangle> leftRopeSource = new List<Rectangle> { new Rectangle(0, 298, 18, 18), new Rectangle(0, 328, 18, 18) };
			List<Rectangle> rightRopeSource = new List<Rectangle> { new Rectangle(29, 298, 18, 18), new Rectangle(29, 328, 18, 18) };
			createdObject.Sprite = new RopeSprite(createdObject, dungeons2, rightRopeSource, 0.5f, new Vector2(6, 6));
			createdObject.rightFacingRope = new RopeSprite(createdObject, dungeons2, rightRopeSource, 0.5f, new Vector2(6, 6));
			createdObject.leftFacingRope = new RopeSprite(createdObject, dungeons2, leftRopeSource, 0.5f, new Vector2(6, 6));
			return createdObject;
		}
	}
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects.Enemies_and_NPCs;
using Project3902.GameObjects.Enemies_and_NPCs.Interfaces;
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
		private SpriteAtlas NPCSpriteAtlas;
		private SpriteAtlas BossSpriteAtlas;

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
			NPCSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("ZeldaNPCSpriteSheet"));
			BossSpriteAtlas = new SpriteAtlas(content.Load<Texture2D>("ZeldaBossSprites"));
		}

		public IGameObject CreateAquaGel(Vector2 position)
		{
			var createdObject = new Gel(position, 2, new Vector2(1,0));
			List<Rectangle> aquaGelSource = new List<Rectangle> { new Rectangle(403, 183, 10, 10), new Rectangle(403, 213, 10, 10) };
			var sprite = new AnimatedSprite(createdObject, dungeons2, aquaGelSource, 0.5f, new Vector2(6,6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBlueGel(Vector2 position)
		{
			var createdObject = new Gel(position, 2, new Vector2(1, 0));
			List<Rectangle> blueGelSource = new List<Rectangle> { new Rectangle(19, 11, 8, 16), new Rectangle(28, 11, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, blueGelSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateGreenGel(Vector2 position)
		{
			var createdObject = new Gel(position, 2, new Vector2(1, 0));
			List<Rectangle> greenGelSource = new List<Rectangle> { new Rectangle(37, 11, 8, 16), new Rectangle(46, 11, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, greenGelSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBrownGel(Vector2 position)
		{
			var createdObject = new Gel(position, 2, new Vector2(1, 0));
			List<Rectangle> brownGelSource = new List<Rectangle> { new Rectangle(19, 28, 8, 16), new Rectangle(28, 28, 8, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, brownGelSource, 0.5f,new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBlackGel(Vector2 position)
		{
			var createdObject = new Gel(position, 2, new Vector2(1, 0));
			List<Rectangle> blackGelSource = new List<Rectangle> { new Rectangle(423, 183, 10, 10), new Rectangle(423, 213, 10, 10) };
			var sprite = new AnimatedSprite(createdObject, dungeons2, blackGelSource, 0.5f, new Vector2(6, 6));
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
			createdObject.Sprite = new AnimatedSprite(createdObject, dungeons2, rightGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.rightFacingGoriya = new AnimatedSprite(createdObject, dungeons2, rightGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.leftFacingGoriya = new AnimatedSprite(createdObject, dungeons2, leftGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.upFacingGoriya = new AnimatedSprite(createdObject, dungeons2, upGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.downFacingGoriya = new AnimatedSprite(createdObject, dungeons2, downGoriyaSource, 0.5f, new Vector2(6, 6));
			return createdObject;
		}

		public IGameObject CreateBlueGoriya(Vector2 position)
		{
			var createdObject = new Goriya(position, 2, new Vector2(1, 0));
			List<Rectangle> leftGoriyaSource = new List<Rectangle> { new Rectangle(150, 60, 15, 15), new Rectangle(150, 90, 15, 15) };
			List<Rectangle> rightGoriyaSource = new List<Rectangle> { new Rectangle(210, 60, 15, 15), new Rectangle(210, 90, 15, 15) };
			List<Rectangle> upGoriyaSource = new List<Rectangle> { new Rectangle(180, 60, 15, 15), new Rectangle(180, 90, 15, 15) };
			List<Rectangle> downGoriyaSource = new List<Rectangle> { new Rectangle(120, 60, 15, 15), new Rectangle(120, 90, 15, 15) };
			createdObject.Sprite = new AnimatedSprite(createdObject, dungeons2, rightGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.rightFacingGoriya = new AnimatedSprite(createdObject, dungeons2, rightGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.leftFacingGoriya = new AnimatedSprite(createdObject, dungeons2, leftGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.upFacingGoriya = new AnimatedSprite(createdObject, dungeons2, upGoriyaSource, 0.5f, new Vector2(6, 6));
			createdObject.downFacingGoriya = new AnimatedSprite(createdObject, dungeons2, downGoriyaSource, 0.5f, new Vector2(6, 6));
			return createdObject;
		}

		public IGameObject CreateBlueKeese(Vector2 position)
		{
			var createdObject = new Keese(position, 2, new Vector2(1, 0));
			List<Rectangle> blueKeeseSource = new List<Rectangle> { new Rectangle(234, 268, 18, 18), new Rectangle(259, 268, 18, 18)};
			var sprite = new AnimatedSprite(createdObject, dungeons2, blueKeeseSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateRedKeese(Vector2 position)
		{
			var createdObject = new Keese(position, 2, new Vector2(1,0));
			List<Rectangle> redKeeseSource = new List<Rectangle> { new Rectangle(279, 268, 18, 18), new Rectangle(304, 268, 18, 18) };
			var sprite = new AnimatedSprite(createdObject, dungeons2, redKeeseSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateStalfos(Vector2 position)
		{
			var createdObject = new Stalfos(position, 2, new Vector2(0,1));
			List<Rectangle> stalfosSource = new List<Rectangle> { new Rectangle(418, 119, 18, 18), new Rectangle(418, 149, 18, 18) };
			var sprite = new AnimatedSprite(createdObject, dungeons2, stalfosSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateWallmaster(Vector2 position)
		{
			var createdObject = new Wallmaster(position, 2, new Vector2(1, 0));
			List<Rectangle> leftWallmasterSource = new List<Rectangle> { new Rectangle(239, 0, 18, 18), new Rectangle(239, 29, 18, 18) };
			List<Rectangle> rightWallmasterSource = new List<Rectangle> { new Rectangle(269, 0, 18, 18), new Rectangle(269, 29, 18, 18) };
			createdObject.Sprite = new AnimatedSprite(createdObject, dungeons2, rightWallmasterSource, 0.5f, new Vector2(6, 6));
			createdObject.rightFacingWallmaster = new AnimatedSprite(createdObject, dungeons2, rightWallmasterSource, 0.5f, new Vector2(6, 6));
			createdObject.leftFacingWallmaster = new AnimatedSprite(createdObject, dungeons2, leftWallmasterSource, 0.5f, new Vector2(6, 6));
			return createdObject;
		}

		public IGameObject CreateGreenZol(Vector2 position)
		{
			var createdObject = new Zol(position, 2, new Vector2(1, 0));
			List<Rectangle> greenZolSource = new List<Rectangle> { new Rectangle(380, 180, 16, 16), new Rectangle(380, 210, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeons2, greenZolSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateGrayZol(Vector2 position)
		{
			var createdObject = new Zol(position, 2, new Vector2(1, 0));
			List<Rectangle> grayZolSource = new List<Rectangle> { new Rectangle(360, 180, 16, 16), new Rectangle(360, 210, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeons2, grayZolSource, 0.5f,  new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBrownZol(Vector2 position)
		{
			var createdObject = new Zol(position, 2, new Vector2(1, 0));
			List<Rectangle> brownZolSource = new List<Rectangle> { new Rectangle(77, 28, 16, 16), new Rectangle(94, 28, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, dungeonSpriteAtlas, brownZolSource, 0.5f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateRope(Vector2 position)
		{
			var createdObject = new Rope(position, 2, new Vector2(1, 0));
			List<Rectangle> leftRopeSource = new List<Rectangle> { new Rectangle(0, 298, 18, 18), new Rectangle(0, 328, 18, 18) };
			List<Rectangle> rightRopeSource = new List<Rectangle> { new Rectangle(29, 298, 18, 18), new Rectangle(29, 328, 18, 18) };
			createdObject.Sprite = new AnimatedSprite(createdObject, dungeons2, rightRopeSource, 0.5f, new Vector2(6, 6));
			createdObject.rightFacingRope = new AnimatedSprite(createdObject, dungeons2, rightRopeSource, 0.5f, new Vector2(6, 6));
			createdObject.leftFacingRope = new AnimatedSprite(createdObject, dungeons2, leftRopeSource, 0.5f, new Vector2(6, 6));
			return createdObject;
		}

		public IGameObject createDongo(Vector2 position)
		{
			var createdObject = new Dodongo(position, 2, new Vector2(1, 0));
			List<Rectangle> DodongoSource = new List<Rectangle> { new Rectangle(1, 58, 16, 14), new Rectangle(18, 58, 16, 14), new Rectangle(35, 58, 16, 14), new Rectangle(52, 58, 16, 14), new Rectangle(69, 58, 30, 14), new Rectangle(102, 58, 30, 14), new Rectangle(135, 58, 30, 14) };
			var sprite = new AnimatedSprite(createdObject, BossSpriteAtlas, DodongoSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject createFlame(Vector2 position)
		{
			var createdObject = new Flame(position, 2, new Vector2(1, 0));
			List<Rectangle> FlameSource = new List<Rectangle> { new Rectangle(52, 11, 15, 16) };
			var sprite = new AnimatedSprite(createdObject, NPCSpriteAtlas, FlameSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject createOldMan(Vector2 position)
		{
			var createdObject = new OldMan(position, 2, new Vector2(1, 0));
			List<Rectangle> OldManSource = new List<Rectangle> { new Rectangle(1, 11, 16, 16), new Rectangle(18, 11, 16, 16), new Rectangle(35, 11, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, NPCSpriteAtlas, OldManSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject createGreenMerchant(Vector2 position)
		{
			var createdObject = new Merchant(position, 2, new Vector2(1, 0));
			List<Rectangle> MerchantSource = new List<Rectangle> { new Rectangle(109, 11, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, NPCSpriteAtlas, MerchantSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;

		}

		public IGameObject createWhiteMerchant(Vector2 position)
		{
			var createdObject = new Merchant(position, 2, new Vector2(1, 0));
			List<Rectangle> MerchantSource = new List<Rectangle> { new Rectangle(126, 11, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, NPCSpriteAtlas, MerchantSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;

		}

		public IGameObject createRedMerchant(Vector2 position)
		{
			var createdObject = new Merchant(position, 2, new Vector2(1, 0));
			List<Rectangle> MerchantSource = new List<Rectangle> { new Rectangle(143, 11, 16, 16) };
			var sprite = new AnimatedSprite(createdObject, NPCSpriteAtlas, MerchantSource, 3);
			createdObject.Sprite = sprite;
			return createdObject;

		}

		/********* SPRITES **********/

		public ISprite CreateAquamentusSprite(IGameObject gameObject)
		{
			List<Rectangle> AquamentusSource = new List<Rectangle> { new Rectangle(1, 11, 24, 30), new Rectangle(26, 11, 24, 30), new Rectangle(51, 11, 24, 30), new Rectangle(76, 11, 24, 30) };
			var sprite = new AnimatedSprite(gameObject, BossSpriteAtlas, AquamentusSource, 0.5f, new Vector2(5, 5));
			return sprite;
		}
	}
}

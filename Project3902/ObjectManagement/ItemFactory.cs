using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
	class ItemFactory
	{
		private SpriteAtlas HeartSprite;
		private SpriteAtlas RupeeSprite;
		private SpriteAtlas FairySprite;
		private SpriteAtlas FixSprite;

		private static ItemFactory instance = new ItemFactory();

		public static ItemFactory Instance
		{
			get
			{
				return instance;
			}
		}

		private ItemFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			HeartSprite = new SpriteAtlas(content.Load<Texture2D>("item/Heart"));
			RupeeSprite = new SpriteAtlas(content.Load<Texture2D>("item/Rupees"));
			FairySprite = new SpriteAtlas(content.Load<Texture2D>("item/Fairy"));
			FixSprite = new SpriteAtlas(content.Load<Texture2D>("Items"));
		}

		public IGameObject CreateHeart(Vector2 position)
		{
			var createdObject = new Heart(position, 0, new Vector2(1, 0));
			List<Rectangle> HeartSource = new List<Rectangle> { new Rectangle(0, 0, 15, 15), new Rectangle(15, 0, 15, 15) };
			var sprite = new AnimatedSprite(createdObject, HeartSprite, HeartSource, .3f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateRupee(Vector2 position)
		{
			var createdObject = new Rupee(position, 0, new Vector2(1, 0));
			List<Rectangle> RupeeSource = new List<Rectangle> { new Rectangle(0, 0, 30, 30), new Rectangle(30, 0, 30, 30) };
			var sprite = new AnimatedSprite(createdObject, RupeeSprite, RupeeSource, .4f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}
		public IGameObject Create1Rupee(Vector2 position)
		{
			var createdObject = new Rupee(position, 0, new Vector2(1, 0));
			List<Rectangle> RupeeSource = new List<Rectangle> { new Rectangle(0, 0, 30, 30) };
			var sprite = new AnimatedSprite(createdObject, RupeeSprite, RupeeSource, .4f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateFairy(Vector2 position)
		{
			var createdObject = new Fairy(position, 2, new Vector2(1, 0));
			List<Rectangle> FairySource = new List<Rectangle> { new Rectangle(0, 0, 10, 18), new Rectangle(10, 0, 10, 18) };
			var sprite = new AnimatedSprite(createdObject, FairySprite, FairySource, .4f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateWatch(Vector2 position)
		{
			var createdObject = new Watch(position, 0, new Vector2(1, 0));
			List<Rectangle> WatchSource = new List<Rectangle> { new Rectangle(35, 0, 15, 18) };
			var sprite = new AnimatedSprite(createdObject, FixSprite, WatchSource, .4f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateBow(Vector2 position)
		{
			var createdObject = new Bow(position, 0, new Vector2(1, 0));
			List<Rectangle> BowSource = new List<Rectangle> { new Rectangle(155, 0, 15, 18) };
			var sprite = new AnimatedSprite(createdObject, FixSprite, BowSource, .4f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateKey(Vector2 position)
		{
			var createdObject = new Key(position, 0, new Vector2(1, 0));
			List<Rectangle> KeySource = new List<Rectangle> { new Rectangle(171, 0, 6, 18) };
			var sprite = new AnimatedSprite(createdObject, FixSprite, KeySource, .4f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

		public IGameObject CreateArrow(Vector2 position)
		{
			var createdObject = new Arrow(position, 0, new Vector2(1, 0));
			List<Rectangle> ArrowSource = new List<Rectangle> { new Rectangle(223, 0, 8, 18) };
			var sprite = new AnimatedSprite(createdObject, FixSprite, ArrowSource, .4f, new Vector2(6, 6));
			createdObject.Sprite = sprite;
			return createdObject;
		}

	}
}
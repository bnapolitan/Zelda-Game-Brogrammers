using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using System.Collections.Generic;

namespace Project3902
{
	class ItemFactory
	{
		private SpriteAtlas HeartSprite;
		private SpriteAtlas RupeeSprite;
		private SpriteAtlas FairySprite;
		private SpriteAtlas FixSprite;

        public static ItemFactory Instance { get; } = new ItemFactory();

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

		public static void RegisterItemForCollision(IItem ItemObject)
		{

			ItemObject.Collider = new Collider(ItemObject, new Rectangle(0, 0, 30, 30));
			CollisionHandler.Instance.RegisterCollidable(ItemObject, Layer.Pickup);
		}

		public IGameObject CreateHeart(Vector2 position)
		{
			var createdObject = new Heart(position);
			List<Rectangle> HeartSource = new List<Rectangle> { new Rectangle(0, 0, 15, 15), new Rectangle(15, 0, 15, 15) };
			var sprite = new AnimatedSprite(createdObject, HeartSprite, HeartSource, .3f, new Vector2(3.5f, 3.5f));
			createdObject.Sprite = sprite;
			RegisterItemForCollision(createdObject);
			return createdObject;
		}

		public IGameObject CreateRupee(Vector2 position)
		{
			var createdObject = new Rupee(position);
			List<Rectangle> RupeeSource = new List<Rectangle> { new Rectangle(0, 0, 30, 30), new Rectangle(30, 0, 30, 30) };
			var sprite = new AnimatedSprite(createdObject, RupeeSprite, RupeeSource, .4f, new Vector2(2,2));
			createdObject.Sprite = sprite;
			RegisterItemForCollision(createdObject);
			return createdObject;
		}
		public IGameObject Create1Rupee(Vector2 position)
		{
			var createdObject = new Rupee(position);
			List<Rectangle> RupeeSource = new List<Rectangle> { new Rectangle(0, 0, 30, 30) };
			var sprite = new AnimatedSprite(createdObject, RupeeSprite, RupeeSource, .4f, new Vector2(2,2));
			createdObject.Sprite = sprite;
			RegisterItemForCollision(createdObject);
			return createdObject;
		}

		public IGameObject CreateFairy(Vector2 position)
		{
			var createdObject = new Fairy(position, 2, new Vector2(1, 0));
			List<Rectangle> FairySource = new List<Rectangle> { new Rectangle(0, 0, 10, 18), new Rectangle(10, 0, 10, 18) };
			var sprite = new AnimatedSprite(createdObject, FairySprite, FairySource, .4f, new Vector2(3, 3));
			createdObject.Sprite = sprite;
			createdObject.Collider = new Collider(createdObject, new Rectangle(10, 0, 30, 30));
			CollisionHandler.Instance.RegisterCollidable(createdObject, Layer.Pickup);
			return createdObject;
		}

		public IGameObject CreateWatch(Vector2 position)
		{
			var createdObject = new Watch(position);
			List<Rectangle> WatchSource = new List<Rectangle> { new Rectangle(137, 0, 48, 61) };
			var sprite = new AnimatedSprite(createdObject, FixSprite, WatchSource, .4f, new Vector2(1,1));
			createdObject.Sprite = sprite;
			RegisterItemForCollision(createdObject);
			return createdObject;
		}

		public IGameObject CreateBow(Vector2 position)
		{
			var createdObject = new Bow(position);
			List<Rectangle> BowSource = new List<Rectangle> { new Rectangle(594, 0, 34, 61) };
			var sprite = new AnimatedSprite(createdObject, FixSprite, BowSource, .4f, new Vector2(1, 1));
			createdObject.Sprite = sprite;
			RegisterItemForCollision(createdObject);
			return createdObject;
		}

		public IGameObject CreateKey(Vector2 position)
		{
			var createdObject = new Key(position);
			List<Rectangle> KeySource = new List<Rectangle> { new Rectangle(647, 0, 23, 61) };
			var sprite = new AnimatedSprite(createdObject, FixSprite, KeySource, .4f, new Vector2(1, 1));
			createdObject.Sprite = sprite;
			RegisterItemForCollision(createdObject);
			return createdObject;
		}

		public IGameObject CreateSword(Vector2 position)
		{
			var createdObject = new Sword(position);
			List<Rectangle> SwordSource = new List<Rectangle> { new Rectangle(468, 0, 30, 61) };
			var sprite = new AnimatedSprite(createdObject, FixSprite, SwordSource, .4f, new Vector2(1, 1));
			createdObject.Sprite = sprite;
			RegisterItemForCollision(createdObject);
			return createdObject;
		}

		public IGameObject CreateRing(Vector2 position)
		{
			var createdObject = new Ring(position);
			List<Rectangle> RingSource = new List<Rectangle> { new Rectangle(771, 0, 48, 61) };
			var sprite = new AnimatedSprite(createdObject, FixSprite, RingSource, .4f, new Vector2(1, 1));
			createdObject.Sprite = sprite;
			RegisterItemForCollision(createdObject);
			return createdObject;
		}

		public IGameObject CreateArrow(Vector2 position)
		{
			var createdObject = new Arrow(position);
			List<Rectangle> ArrowSource = new List<Rectangle> { new Rectangle(848, 0, 22, 61) };
			var sprite = new AnimatedSprite(createdObject, FixSprite, ArrowSource, .4f, new Vector2(1, 1));
			createdObject.Sprite = sprite;
			RegisterItemForCollision(createdObject);
			return createdObject;
		}

	}
}
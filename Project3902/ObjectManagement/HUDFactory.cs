using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Project3902
{
    class HUDFactory : ISpriteFactory
    {
        private SpriteAtlas HUDSprites;
        public static HUDFactory Instance { get; } = new HUDFactory();
        private FinalGame game;
        public int HUDHeight = 96;
        private int HUDWidth;
        private Vector2 HUDScale = new Vector2(3, 3);
        public void LoadAllTextures(ContentManager content)
        {
            HUDSprites = new SpriteAtlas(content.Load<Texture2D>("ZeldaHUDSprites"));
        }

        private HUDFactory()
        {
        }

        public void registerGame(FinalGame game)
        {
            this.game = game;
            HUDWidth = game.graphics.PreferredBackBufferWidth;
        }

        public IGameObject createLifeWord()
        {
            var gameObject = new HUDObject(new Vector2(700,10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(441, 26, 44, 9),HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public List<IGameObject> createLevelMap()
        {
            Vector2[] positions = { new Vector2(28, 80), new Vector2(46, 80), new Vector2(64, 80),
                new Vector2(46, 68),
                new Vector2(28, 56), new Vector2(46, 56), new Vector2(64, 56),
                new Vector2(46, 44), new Vector2(28, 44), new Vector2(10, 44), new Vector2(64, 44), new Vector2(82, 44),
                new Vector2(46, 32), new Vector2(82, 32), new Vector2(100, 32),
                new Vector2(46, 20), new Vector2(28, 20) };
            var levelList = new List<IGameObject>();
            for (int i = 0; i < positions.Length; i++)
            {
                levelList.Add(new HUDObject(positions[i]));
                levelList[i].Sprite = new FixedSprite(levelList[i], HUDSprites, new Rectangle(129, 35, 16, 10), new Vector2(1, 1));
            }


            //var gameObject = new HUDObject(new Vector2(10, 80));

            //var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(129, 35, 20, 10), new Vector2(1, 1));
            //gameObject.Sprite = sprite;

            return levelList;
        }

        public IGameObject createABox()
        {
            var gameObject = new HUDObject(new Vector2(300, 0));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(404, 26, 20, 32), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createBBox()
        {
            var gameObject = new HUDObject(new Vector2(380, 0));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(380, 26, 20, 32), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createCoinCountIcon()
        {
            var gameObject = new HUDObject(new Vector2(500, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(345, 26, 34, 9), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createKeyCountIcon()
        {
            var gameObject = new HUDObject(new Vector2(500, 64));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(345, 42, 34, 9), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createOrbCountIcon()
        {
            var gameObject = new HUDObject(new Vector2(500, 37));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(345, 51, 34, 9), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createEmptyHeart()
        {
            var gameObject = new HUDObject(new Vector2(700, 50));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(627, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createHalfHeart()
        {
            var gameObject = new HUDObject(new Vector2(700, 50));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(636, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createFullHeart()
        {
            var gameObject = new HUDObject(new Vector2(700, 50));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(645, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createXCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(519, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createZeroCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(528, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createOneCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(537, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createTwoCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(546, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createThreeCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(555, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createFourCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(564, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createFiveCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(573, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createSixCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(582, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createSevenCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(591, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createEightCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(600, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createNineCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(609, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createLevelWord()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(584, 1, 55, 7), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }


    }
}

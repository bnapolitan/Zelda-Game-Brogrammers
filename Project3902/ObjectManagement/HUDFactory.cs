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
        private int numX;
        private Vector2 HUDScale = new Vector2(3, 3);
        public void LoadAllTextures(ContentManager content)
        {
            HUDSprites = new SpriteAtlas(content.Load<Texture2D>("ZeldaHUDSprites"));
        }

        private HUDFactory()
        {
            numX = 0;
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
            Vector2[] positions = { new Vector2(139, 82), new Vector2(157, 82), new Vector2(175, 82),
                new Vector2(157, 70),
                new Vector2(139, 58), new Vector2(157, 58), new Vector2(175, 58),
                new Vector2(157, 46), new Vector2(139, 46), new Vector2(121, 46), new Vector2(175, 46), new Vector2(193, 46),
                new Vector2(157, 34), new Vector2(193, 34), new Vector2(211, 34),
                new Vector2(157, 22), new Vector2(139, 22) };
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
            var gameObject = new HUDObject(new Vector2(500, 5));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(345, 26, 34, 9), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createKeyCountIcon()
        {
            var gameObject = new HUDObject(new Vector2(500, 34));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(345, 42, 34, 9), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createOrbCountIcon()
        {
            var gameObject = new HUDObject(new Vector2(500, 66));
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
            var gameObject = new HUDObject(new Vector2(527, 8));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(519, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;

            if(numX > 0)
            {
                var tempPos = gameObject.Position;
                tempPos.Y += ((numX) * 29);
                gameObject.Position = tempPos;
                
            }
            numX++;
            return gameObject;
        }

        public IGameObject createZeroCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(528, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createOneCharacter()
        {
            var gameObject = new HUDObject(new Vector2(244, 0));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(537, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createTwoCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(546, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createThreeCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(555, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createFourCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(564, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createFiveCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(573, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createSixCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(582, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createSevenCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(591, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createEightCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(600, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createNineCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(609, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createLevelWord()
        {
            var gameObject = new HUDObject(new Vector2(100, 0));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(584, 1, 55, 7), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createMapBlock()
        {
            var gameObject = new HUDObject(new Vector2(0, 0));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(672, 112, 7, 4), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createMapBlip()
        {
            var gameObject = new HUDObject(new Vector2(160, HUDHeight - 2));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(519, 126, 3, 3), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createPauseMapSection()
        {
            var gameObject = new HUDObject(new Vector2());
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(258,112,255,87), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject createPauseInventorySection()
        {
            var gameObject = new HUDObject(new Vector2(160, HUDHeight - 2));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(1,29,255,69), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public List<IGameObject> createDungeonMap()
        {
            return null;
        }

        public List<IGameObject> createNumberList()
        {
            var list = new List<IGameObject>();
            list.Add(createZeroCharacter());
            list.Add(createOneCharacter());
            list.Add(createTwoCharacter());
            list.Add(createThreeCharacter());
            list.Add(createFourCharacter());
            list.Add(createFiveCharacter());
            list.Add(createSixCharacter());
            list.Add(createSevenCharacter());
            list.Add(createEightCharacter());
            list.Add(createNineCharacter());
            return list;
        }


    }
}

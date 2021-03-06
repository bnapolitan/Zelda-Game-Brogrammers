﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Project3902
{
    class HUDFactory : ISpriteFactory
    {
        private SpriteAtlas HUDSprites;
        private SpriteAtlas ItemSprite;
        private SpriteAtlas IntroScreen;
        public static HUDFactory Instance { get; } = new HUDFactory();
        private FinalGame game;
        public int HUDHeight = 96;
        private Vector2 PauseScale = new Vector2(4, 4);
        private int HUDWidth;
        private int numX;
        public Vector2 HUDScale = new Vector2(3, 3);
        public void LoadAllTextures(ContentManager content)
        {
            IntroScreen = new SpriteAtlas(content.Load<Texture2D>("IntroScreen"));
            HUDSprites = new SpriteAtlas(content.Load<Texture2D>("ZeldaHUDSprites"));
            ItemSprite = new SpriteAtlas(content.Load<Texture2D>("ZeldaItems"));
        }

        private HUDFactory()
        {
            numX = 0;
        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
            HUDWidth = game.graphics.PreferredBackBufferWidth;

        }

        public void resetNumx()
        {
            numX = 0;
        }
        public IGameObject CreateScreen() {
            var gameObject = new HUDObject(new Vector2(30, 0));
            var sprite = new FixedSprite(gameObject, IntroScreen, new Rectangle(0, 0, 320, 280), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateLifeWord()
        {
            var gameObject = new HUDObject(new Vector2(700, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(441, 26, 44, 9), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public List<IGameObject> CreateLevelMap()
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




            return levelList;
        }

        public IGameObject CreateABox()
        {
            var gameObject = new HUDObject(new Vector2(300, 0));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(404, 26, 20, 32), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateBBox()
        {
            var gameObject = new HUDObject(new Vector2(380, 0));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(380, 26, 20, 32), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateCoinCountIcon()
        {
            var gameObject = new HUDObject(new Vector2(500, 5));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(345, 26, 34, 9), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateKeyCountIcon()
        {
            var gameObject = new HUDObject(new Vector2(500, 34));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(345, 42, 34, 9), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateOrbCountIcon()
        {
            var gameObject = new HUDObject(new Vector2(500, 66));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(345, 51, 34, 9), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateEmptyHeart()
        {
            var gameObject = new HUDObject(new Vector2(700, 50));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(627, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateHalfHeart()
        {
            var gameObject = new HUDObject(new Vector2(700, 50));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(636, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateFullHeart()
        {
            var gameObject = new HUDObject(new Vector2(700, 50));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(645, 117, 7, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateXCharacter()
        {
            var gameObject = new HUDObject(new Vector2(527, 8));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(519, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;

            if (numX > 0)
            {
                var tempPos = gameObject.Position;
                tempPos.Y += ((numX) * 29);
                gameObject.Position = tempPos;

            }
            numX++;
            return gameObject;
        }

        public IGameObject CreateZeroCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(528, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateOneCharacter()
        {
            var gameObject = new HUDObject(new Vector2(244, 0));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(537, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateTwoCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(546, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateThreeCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(555, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateFourCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(564, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateFiveCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(573, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateSixCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(582, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateSevenCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(591, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateEightCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(600, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateNineCharacter()
        {
            var gameObject = new HUDObject(new Vector2(100, 10));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(609, 117, 8, 8), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateLevelWord()
        {
            var gameObject = new HUDObject(new Vector2(100, 0));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(584, 1, 55, 7), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateMapBlock()
        {
            var gameObject = new HUDObject(new Vector2(0, 0));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(672, 112, 7, 4), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateMapBlip()
        {
            var gameObject = new HUDObject(new Vector2(160, HUDHeight - 2));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(519, 126, 3, 3), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateTriforceMapBlip()
        {
            var gameObject = new HUDObject(new Vector2(216, 39));
            List<Rectangle> BlipSource = new List<Rectangle> { new Rectangle(537, 126, 3, 3), new Rectangle(546, 126, 3, 3) };
            var sprite = new AnimatedSprite(gameObject, HUDSprites, BlipSource, .3f, HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreatePauseMapSection()
        {
            var gameObject = new HUDObject(new Vector2(0, (69 * PauseScale.Y) + HUDHeight));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(258, 112, 255, 87), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreatePauseInventorySection()
        {
            var gameObject = new HUDObject(new Vector2(0, HUDHeight));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(1, 29, 255, 69), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateBlackInventoryBox()
        {
            var gameObject = new HUDObject(new Vector2(520, 210));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(168, 118, 83, 35), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateTopInventoryBlackBar()
        {
            var gameObject = new HUDObject(new Vector2(510, 110));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(168, 118, 89, 20), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateItemBlackBox()
        {
            var gameObject = new HUDObject(new Vector2(190, 465));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(168, 118, 10, 20), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateCompassBlackBox()
        {
            var gameObject = new HUDObject(new Vector2(170, 625));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(168, 118, 19, 19), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateLowerPauseBorder()
        {
            var gameObject = new HUDObject(new Vector2(0, 700));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(1, 11, 256, 19), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateSidePauseBorder()
        {
            var gameObject = new HUDObject(new Vector2(1000, HUDHeight));
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(249, 11, 8, 80), new Vector2(5,20));
            gameObject.Sprite = sprite;
            return gameObject;
        }
        

        public IDrawable createTextSection(SpriteFont font, string text)
        {
            var sprite = new SimpleText(text, new Vector2(HUDWidth / 2, HUDHeight / 2), new Color(255, 255, 255), font, true);
            return sprite;
        }

        public IDrawable createExitText(SpriteFont font, string text)
        {
            var sprite = new SimpleText(text, new Vector2(HUDWidth / 2, HUDHeight / 2+100), new Color(255, 255, 255), font, true);
            return sprite;
        }


        public List<IGameObject> CreateNumberList()
        {
            var list = new List<IGameObject>
            {
                CreateZeroCharacter(),
                CreateOneCharacter(),
                CreateTwoCharacter(),
                CreateThreeCharacter(),
                CreateFourCharacter(),
                CreateFiveCharacter(),
                CreateSixCharacter(),
                CreateSevenCharacter(),
                CreateEightCharacter(),
                CreateNineCharacter()
            };
            return list;
        }

        public IGameObject CreateHUDBoomerang(Vector2 position)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(584, 137,8, 15), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateHUDSword(Vector2 position)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(555, 137, 8, 16), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateHUDCandle(Vector2 position)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(653, 137, 8, 16), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;

        }

        public IGameObject CreateHUDBomb(Vector2 position)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(604, 137, 8, 16), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateHUDArrow(Vector2 position)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(615, 137, 8, 16), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateHUDBow(Vector2 position)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(633, 137, 8, 16), HUDScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreatePauseCompass(Vector2 position)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(612, 158, 15, 14), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreatePauseMap(Vector2 position)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(601, 156, 8, 16), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateItemSelector(Vector2 position)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, ItemSprite, new Rectangle(64, 52, 13, 13), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateSolidMapBlock(Vector2 position)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle(360, 122, 8, 8), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }

        public IGameObject CreateMapRoomBlock(Vector2 position, int roomNum)
        {
            var gameObject = new HUDObject(position);
            var sprite = new FixedSprite(gameObject, HUDSprites, new Rectangle((519 + (9*roomNum)), 108, 8, 8), PauseScale);
            gameObject.Sprite = sprite;
            return gameObject;
        }
        public KeyboardController CreatePauseController(FinalGame game)
        {
            var controller = new KeyboardController();


            controller.RegisterCommand(Keys.Up, new UpCommand(), InputState.Pressed);
            controller.RegisterCommand(Keys.Down, new DownCommand(), InputState.Pressed);
            controller.RegisterCommand(Keys.Left, new LeftCommand(), InputState.Pressed);
            controller.RegisterCommand(Keys.Right, new RightCommand(), InputState.Pressed);
            controller.RegisterCommand(Keys.W, new UpCommand(), InputState.Pressed);
            controller.RegisterCommand(Keys.S, new DownCommand(), InputState.Pressed);
            controller.RegisterCommand(Keys.A, new LeftCommand(), InputState.Pressed);
            controller.RegisterCommand(Keys.D, new RightCommand(), InputState.Pressed);
            controller.RegisterCommand(Keys.G, new PauseGameCommand(game), InputState.Pressed);
            controller.RegisterCommand(Keys.H, new TotalPauseGameCommand(game), InputState.Pressed);
            controller.RegisterCommand(Keys.Z, new SelectCommand(), InputState.Pressed);
            controller.RegisterCommand(Keys.Escape, new ExitCommand(), InputState.Pressed);

            return controller;
        }

        public GamepadController CreatePauseGamepadController(FinalGame game)
        {
            var controller = new GamepadController();

            controller.RegisterCommand(Buttons.DPadUp, new UpCommand(),InputState.Pressed);
            controller.RegisterCommand(Buttons.DPadDown, new DownCommand(), InputState.Pressed);
            controller.RegisterCommand(Buttons.DPadLeft, new LeftCommand(), InputState.Pressed);
            controller.RegisterCommand(Buttons.DPadRight, new RightCommand(), InputState.Pressed);
            controller.RegisterCommand(Buttons.LeftThumbstickUp, new UpCommand(), InputState.Pressed);
            controller.RegisterCommand(Buttons.LeftThumbstickDown, new DownCommand(), InputState.Pressed);
            controller.RegisterCommand(Buttons.LeftThumbstickLeft, new LeftCommand(), InputState.Pressed);
            controller.RegisterCommand(Buttons.LeftThumbstickRight, new RightCommand(), InputState.Pressed);
            controller.RegisterCommand(Buttons.Start, new PauseGameCommand(game), InputState.Pressed);
            controller.RegisterCommand(Buttons.Back, new TotalPauseGameCommand(game), InputState.Pressed);
            controller.RegisterCommand(Buttons.A, new SelectCommand(), InputState.Pressed);


            return controller;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.Configuration;
using Project3902.GameObjects.Environment;
using Project3902.LevelBuilding;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;

/*
 * Team:
 * Dan Bellini
 * Huang Huang
 * Xueyang Li
 * Ben Napolitan
 * Austin Rogers
 * Suraj Suresh
*/

namespace Project3902
{
    class FinalGame : Game
    {
        private const int WindowWidth = 1024, WindowHeight = 672;
        public readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public ILink Link { get; set; }

        private ILevel currentLevel;
        private ILevel nextLevel;

        public bool IsPaused => isPaused;
        private bool isGameOver = false;
        public bool isRunning;

        public Vector2 roomSize = new Vector2(WindowWidth, WindowHeight);
        private float scrollTimer;
        private Vector2 lastScrollDirection;
        private Boolean isPaused = false;

        public List<IGameObject> HUDObjects;
        
        public MouseController LinkMouseController;
        public KeyboardController LinkKeyboardController;
        public GamepadController LinkGamepadController;
        public KeyboardController InventoryKeyboardController;
        public GamepadController InventoryGamepadController;
        KeyboardController soundController;

        public string CurrentRoom = "DungeonRoom0";

        public SpriteFont font;
        Vector2 linkPositionAfterRoomSwitch;
        public Boolean linkDeath = false;
        int drawingCounter = 0;
        private int drawingDone = 0;

        public FinalGame()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = (int)roomSize.X;
            graphics.PreferredBackBufferHeight = (int)roomSize.Y + HUDFactory.Instance.HUDHeight;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Credits");

            HUDFactory.Instance.LoadAllTextures(Content);
            HUDFactory.Instance.RegisterGame(this);
            HUDManager.Instance.RegisterGame(this);
            PauseScreen.Instance.RegisterGame(this);

            StartMenuState.Instance.RegisterGame(this);
            GameOverState.Instance.RegisterGame(this);

            HUDObjects = HUDManager.Instance.HUDElements;




            soundController = SoundHandler.Instance.RegisterSoundKeys();
            LinkKeyboardController = LinkFactory.Instance.CreateLinkController(this);
            LinkMouseController = LevelFactory.Instance.CreateLevelController(this);
            LinkGamepadController = LinkFactory.Instance.CreateLinkGamepadController(this);
            InventoryGamepadController = HUDFactory.Instance.CreatePauseGamepadController(this);
            InventoryKeyboardController = HUDFactory.Instance.CreatePauseController(this);


           

           


            ShapeSpriteFactory.Instance.CreateShapeTextures(GraphicsDevice);

            WeaponFactory.Instance.LoadAllTextures(Content);

            EnvironmentFactory.Instance.RegisterGame(this);
            EnvironmentFactory.Instance.LoadAllTextures(Content);

            ItemFactory.Instance.RegisterGame(this);
            ItemFactory.Instance.LoadAllTextures(Content);

            EnemyFactory.Instance.RegisterGame(this);
            EnemyFactory.Instance.LoadAllTextures(Content);

            SoundHandler.Instance.LoadAllSounds(Content);
            SoundHandler.Instance.UseDefaultSounds();
            SoundHandler.Instance.PlaySong("Intro");

            LevelManager.Instance.ResetLevels();
            currentLevel = LevelManager.Instance.GetLevel(CurrentRoom);

            LinkFactory.Instance.LoadAllTextures(Content);
            Link = LinkFactory.Instance.CreateLink(new Vector2(450, 500 + HUDFactory.Instance.HUDHeight), this);
            RegisterLinkCollision();
        }


        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (isRunning == false || isGameOver)
            {
                LinkMouseController.Update();
                LinkKeyboardController.Update();
                LinkGamepadController.Update();
                StartMenuState.Instance.Update(gameTime);
                return;
            }


            if(pauseCooldown != 5)
            {
                pauseCooldown++;
            }
            if (!isPaused)
            {
                currentLevel.Update(gameTime);
                if (nextLevel != null && nextLevel.Scrolling)
                    nextLevel.Update(gameTime);
            }
            base.Update(gameTime);

            if (!currentLevel.Scrolling)
            {

                    soundController.Update();
                Link.Update(gameTime);
                if (isPaused)
                {
                    InventoryKeyboardController.Update();
                    InventoryGamepadController.Update();
                    
                }
                else
                {
                    LinkMouseController.Update();
                    LinkKeyboardController.Update();
                    LinkGamepadController.Update();
                }
                    


            }
            else
            {
                scrollTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (scrollTimer <= 0)
                {
                    EndRoomSwitch();
                }
            }
            if (!isPaused)
            {
                HUDManager.Instance.Update();
                

                CollisionHandler.Instance.CheckCollisions();

                LevelManager.Instance.CheckSpecials();
                if (linkDeath)
                {
                    GameOver();
                    linkDeath = false;
                }
            }


            if (isPaused)
            {
                PauseScreen.Instance.Update();
            }

            if (drawingDone==1)
            {
                if(SoundHandler.Instance.SoundType==1)


                    SoundHandler.Instance.PlaySoundEffect("Old Man");
                drawingDone = 2;
            }
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            if (isGameOver)
            {

                GameOverState.Instance.Draw(spriteBatch);

                spriteBatch.End();
                return;
            }

            if (isRunning == false)
            {

                StartMenuState.Instance.Draw(spriteBatch);

                spriteBatch.End();
                return;
            }

            currentLevel.Draw(spriteBatch);
            if (nextLevel != null && nextLevel.Scrolling)
                nextLevel.Draw(spriteBatch);

            if (currentLevel.LevelName == "DungeonRoom9" && !currentLevel.Scrolling)
            {
                this.DrawText();
            }


            if (!currentLevel.Scrolling)
                Link.Draw(spriteBatch);

            HUDManager.Instance.Draw(spriteBatch);

            if (isPaused)
            {
                PauseScreen.Instance.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void RegisterLinkCollision()
        {
            CollisionHandler.Instance.RegisterCollidable(Link, Layer.Player, Layer.Enemy, Layer.Wall, Layer.Pickup, Layer.Projectile);
        }
        private int pauseCooldown = 5;
        public void PauseGame()
        {
            if(pauseCooldown == 5)
            {
                isPaused = !isPaused;
                pauseCooldown = 0;
            }
            
            
        }

        protected void RestartLevel()
        {
            CollisionHandler.Instance.Flush();
            SoundHandler.Instance.StopEffectInstance(true);

            currentLevel = LevelManager.Instance.GetLevel(CurrentRoom);

            RegisterLinkCollision();
        }





        private void StartRoomSwitch(Vector2 direction)
        {
            SoundHandler.Instance.StopEffectInstance(true);
            currentLevel.Scrolling = true;
            currentLevel.ScrollDirection = direction;
            CollisionHandler.Instance.Flush();

            lastScrollDirection = direction;

            nextLevel = LevelManager.Instance.GetLevelWithOffset(CurrentRoom, roomSize * -direction);
            nextLevel.Scrolling = true;
            nextLevel.ScrollDirection = direction;

            scrollTimer = (roomSize * direction).Length() / currentLevel.ScrollSpeed;
        }

        private void EndRoomSwitch()
        {
            Link.Position = linkPositionAfterRoomSwitch;
            currentLevel.Scrolling = false;

            currentLevel.OffsetGameObjects(roomSize * -lastScrollDirection);

            nextLevel.Scrolling = false;
            currentLevel = nextLevel;
            LevelManager.Instance.GetLevel(CurrentRoom);
            RegisterLinkCollision();
            nextLevel = null;
        }

        public void EnterRoomTop()
        {
            CurrentRoom = currentLevel.Map.Top;
            StartRoomSwitch(new Vector2(0, 1));
            linkPositionAfterRoomSwitch = new Vector2(LinkPositionConfiguration.LinkXPositionAfterRoomSwitchTop, LinkPositionConfiguration.LinkYPositionAfterRoomSwitchTop + HUDFactory.Instance.HUDHeight);
        }

        public void EnterRoomLeft()
        {
            CurrentRoom = currentLevel.Map.Left;
            StartRoomSwitch(new Vector2(1, 0));
            linkPositionAfterRoomSwitch = new Vector2(LinkPositionConfiguration.LinkXPositionAfterRoomSwitchLeft, LinkPositionConfiguration.LinkYPositionAfterRoomSwitchLeft + HUDFactory.Instance.HUDHeight);
        }

        public void EnterRoomRight()
        {
            CurrentRoom = currentLevel.Map.Right;
            StartRoomSwitch(new Vector2(-1, 0));
            linkPositionAfterRoomSwitch = new Vector2(LinkPositionConfiguration.LinkXPositionAfterRoomSwitchRight, LinkPositionConfiguration.LinkYPositionAfterRoomSwitchLeft + HUDFactory.Instance.HUDHeight);
        }

        public void EnterRoomBottom()
        {
            CurrentRoom = currentLevel.Map.Bottom;
            StartRoomSwitch(new Vector2(0, -1));
            linkPositionAfterRoomSwitch = new Vector2(LinkPositionConfiguration.LinkXPositionAfterRoomSwitchTop, LinkPositionConfiguration.LinkYPositionAfterRoomSwitchBottom + HUDFactory.Instance.HUDHeight);
        }

        public void ExplodeWallTop(IGameObject explodableWall)
        {
            (currentLevel as Level).interactiveEnvironmentObjects.Remove(explodableWall);
            (currentLevel as Level).interactiveEnvironmentObjects.Add(EnvironmentFactory.Instance.CreateBombedOpeningTop(explodableWall.Position));

            var adjacentLevel = LevelManager.Instance.levelDict[(currentLevel as Level).Map.Top];
            var adjacentExplodableWall = adjacentLevel.interactiveEnvironmentObjects.Find(wall => wall is ExplodableWall);
            adjacentLevel.interactiveEnvironmentObjects.Remove(adjacentExplodableWall);
            adjacentLevel.interactiveEnvironmentObjects.Add(EnvironmentFactory.Instance.CreateBombedOpeningBottom(adjacentExplodableWall.Position));
        }

        public void ExplodeWallLeft(IGameObject explodableWall)
        {
            (currentLevel as Level).interactiveEnvironmentObjects.Remove(explodableWall);
            (currentLevel as Level).interactiveEnvironmentObjects.Add(EnvironmentFactory.Instance.CreateBombedOpeningLeft(explodableWall.Position));

            var adjacentLevel = LevelManager.Instance.levelDict[(currentLevel as Level).Map.Left];
            var adjacentExplodableWall = adjacentLevel.interactiveEnvironmentObjects.Find(wall => wall is ExplodableWall);
            adjacentLevel.interactiveEnvironmentObjects.Remove(adjacentExplodableWall);
            adjacentLevel.interactiveEnvironmentObjects.Add(EnvironmentFactory.Instance.CreateBombedOpeningRight(adjacentExplodableWall.Position));
        }

        public void ExplodeWallRight(IGameObject explodableWall)
        {
            (currentLevel as Level).interactiveEnvironmentObjects.Remove(explodableWall);
            (currentLevel as Level).interactiveEnvironmentObjects.Add(EnvironmentFactory.Instance.CreateBombedOpeningRight(explodableWall.Position));

            var adjacentLevel = LevelManager.Instance.levelDict[(currentLevel as Level).Map.Right];
            var adjacentExplodableWall = adjacentLevel.interactiveEnvironmentObjects.Find(wall => wall is ExplodableWall);
            adjacentLevel.interactiveEnvironmentObjects.Remove(adjacentExplodableWall);
            adjacentLevel.interactiveEnvironmentObjects.Add(EnvironmentFactory.Instance.CreateBombedOpeningLeft(adjacentExplodableWall.Position));
        }

        public void ExplodeWallBottom(IGameObject explodableWall)
        {
            (currentLevel as Level).interactiveEnvironmentObjects.Remove(explodableWall);
            (currentLevel as Level).interactiveEnvironmentObjects.Add(EnvironmentFactory.Instance.CreateBombedOpeningBottom(explodableWall.Position));

            var adjacentLevel = LevelManager.Instance.levelDict[(currentLevel as Level).Map.Bottom];
            var adjacentExplodableWall = adjacentLevel.interactiveEnvironmentObjects.Find(wall => wall is ExplodableWall);
            adjacentLevel.interactiveEnvironmentObjects.Remove(adjacentExplodableWall);
            adjacentLevel.interactiveEnvironmentObjects.Add(EnvironmentFactory.Instance.CreateBombedOpeningTop(adjacentExplodableWall.Position));
        }

        public void MouseSwitchRoom(string room)
        {
            CurrentRoom = room;
            Link.Position = new Vector2(LinkPositionConfiguration.LinkXPositionAfterRoomSwitchTop, LinkPositionConfiguration.LinkYPositionAfterRoomSwitchTop + HUDFactory.Instance.HUDHeight);

            RestartLevel();
        }

        public void FreezeEnemies()
        {
            currentLevel.FreezeEnemies();
        }

        public void DrawText()
        {
            string words = TextConfiguration.OldManText;
            int textWritingDivisor = TextConfiguration.TextWritingDivisor;
            int characterPosition;
            int xPos;
            int yPos = TextConfiguration.TextYPosition;

            if (drawingCounter < words.Length * textWritingDivisor)
            {
                characterPosition = drawingCounter / textWritingDivisor;
                if (drawingCounter % textWritingDivisor == 0)
                {
                    SoundHandler.Instance.PlaySoundEffect("Heart");
                }
            }
            else
            {
                characterPosition = words.Length;
                if (drawingDone == 0)
                {
                    drawingDone = 1;
                }
            }
            drawingCounter++;

            for (int i = 0; i < characterPosition; i++)
            {
                if (i < TextConfiguration.FirstLineLength)
                {
                    xPos = i;
                }
                else
                {
                    xPos = i - TextConfiguration.SecondLineXOffset;
                    yPos = TextConfiguration.SecondLineYPosition;
                }
                spriteBatch.DrawString(font, words[i].ToString(), new Vector2(TextConfiguration.TextInitialXPosition + (xPos * TextConfiguration.XOffsetPerLetter), yPos), Color.White, 0f, new Vector2(0, 0), new Vector2(2, 2), SpriteEffects.None, 0f);
            }
        }
        public void GameOver()
        {
            isGameOver = true;
            isRunning = false;
            SoundHandler.Instance.StopEffectInstance(true);
            SoundHandler.Instance.PlaySoundEffect("Link Die", true);
            LevelManager.Instance.ResetLevels();
            CurrentRoom = "DungeonRoom0";
            RestartLevel();
            linkDeath = false;
        }


        public void GameStart()
        {
            isGameOver = false;
            isPaused = false;
            isRunning = true;

            linkDeath = false;
            Link.Health = Link.MaxHealth;
            SoundHandler.Instance.PlaySong("Dungeon");
        }
    }
}
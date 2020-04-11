using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.Configuration;
using Project3902.LevelBuilding;
using Project3902.ObjectManagement;
using System.Collections.Generic;
using System.Threading;

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
        public readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public ILink Link { get; set; }

        private ILevel currentLevel;
        private ILevel nextLevel;

        public Vector2 roomSize = new Vector2(1024, 672);
        private float scrollTimer;

        public List<IGameObject> HUDObjects;

        MouseController mouseController;
        KeyboardController keyboardController;

        public string CurrentRoom = "DungeonRoom0";

        private SpriteFont font;
        Vector2 linkPositionAfterRoomSwitch;
        int freezeEnemiesTime = 0;
        int drawingCounter = 0;

        public FinalGame()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = (int) roomSize.X;
            graphics.PreferredBackBufferHeight = (int) roomSize.Y + HUDFactory.Instance.HUDHeight;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Credits");

            HUDFactory.Instance.LoadAllTextures(Content);
            HUDFactory.Instance.registerGame(this);
            HUDManager.Instance.registerGame(this);
            HUDObjects = HUDManager.Instance.HUDElements;

            LinkFactory.Instance.LoadAllTextures(Content);
            Link = LinkFactory.Instance.CreateLink(new Vector2(450, 500 + HUDFactory.Instance.HUDHeight), this);
            RegisterLinkCollision();

            keyboardController = LinkFactory.Instance.CreateLinkController(this);
            mouseController = LevelFactory.Instance.CreateLevelController(this);

            ShapeSpriteFactory.Instance.CreateShapeTextures(GraphicsDevice);

            WeaponFactory.Instance.LoadAllTextures(Content);

            EnvironmentFactory.Instance.RegisterGame(this);
            EnvironmentFactory.Instance.LoadAllTextures(Content);

            ItemFactory.Instance.RegisterGame(this);
            ItemFactory.Instance.LoadAllTextures(Content);

            EnemyFactory.Instance.RegisterGame(this);
            EnemyFactory.Instance.LoadAllTextures(Content);

            SoundHandler.Instance.LoadAllSounds(Content);
            SoundHandler.Instance.PlaySong("Dungeon");

            currentLevel = new Level(CurrentRoom);
        }


        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            currentLevel.Update(gameTime);
            if (nextLevel != null)
                nextLevel.Update(gameTime);

            if (!currentLevel.Scrolling)
            {
                Link.Update(gameTime);
                mouseController.Update();
                keyboardController.Update();
            }
            else
            {
                scrollTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (scrollTimer <= 0)
                {
                    EndRoomSwitch();
                }
            }

            HUDManager.Instance.Update(gameTime);

            CollisionHandler.Instance.CheckCollisions();
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            currentLevel.Draw(spriteBatch);
            if (nextLevel != null)
                nextLevel.Draw(spriteBatch);

            if (currentLevel.LevelName == "DungeonRoom9" && !currentLevel.Scrolling)
                this.DrawText(gameTime);

            if (!currentLevel.Scrolling)
                Link.Draw(spriteBatch);

            HUDManager.Instance.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void RegisterLinkCollision()
        {
            CollisionHandler.Instance.RegisterCollidable(Link, Layer.Player, Layer.Enemy, Layer.Wall, Layer.Pickup, Layer.Projectile);
        }

        protected void RestartLevel()
        {
            CollisionHandler.Instance.Flush();
            CollisionHandler.Instance.CheckCollisions();
            SoundHandler.Instance.StopEffectInstance(true);

            currentLevel = new Level(CurrentRoom);

            RegisterLinkCollision();
        }

        public void ReloadOnDeath()
        {
            SoundHandler.Instance.StopEffectInstance(true);
            SoundHandler.Instance.PlaySoundEffect("Link Die", true);
            RestartLevel();
        }

        private void StartRoomSwitch(Vector2 direction)
        {
            currentLevel.Scrolling = true;
            currentLevel.ScrollDirection = direction;
            CollisionHandler.Instance.Flush();

            nextLevel = new Level(CurrentRoom, roomSize * -direction)
            {
                Scrolling = true,
                ScrollDirection = direction
            };

            scrollTimer = (roomSize * direction).Length() / currentLevel.ScrollSpeed;
        }

        private void EndRoomSwitch()
        {
            Link.Position = linkPositionAfterRoomSwitch;
            RegisterLinkCollision();

            currentLevel = new Level(CurrentRoom);
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

        public void DrawText(GameTime gameTime)
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
            }
            drawingCounter++;

            for (int i = 0; i < characterPosition; i++)
            {
                if(i < TextConfiguration.FirstLineLength)
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
    }
}

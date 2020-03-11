using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.LevelBuilding;
using Project3902.ObjectManagement;
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
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public ILink Link { get; set; }

        public List<IGameObject> interactiveEnvironmentObjects;
        public List<IGameObject> enemyObjects;
        public List<IGameObject> itemObjects;
        public int CurrentRoomNum = 1, TotalRoomNum=5;
        MouseController mouseController;
        KeyboardController keyboardController;
        public string CurrentRoom = "DungeonRoom1";
        public LevelMap levelMap;

        bool NextR, PreR;
        Vector2 linkPositionAfterRoomSwitch;
        bool isSwitchingLevels = false;

        public FinalGame()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 672;
            graphics.ApplyChanges();

            SetUpMouseController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var level = new LevelBuilder(this, CurrentRoom);

            LinkFactory.Instance.LoadAllTextures(Content);
            Link = LinkFactory.Instance.CreateLink(new Vector2(450, 500), this);
            CollisionHandler.Instance.RegisterCollidable(Link, Layer.Player, Layer.Enemy, Layer.Wall, Layer.Pickup, Layer.Projectile);

            keyboardController = LinkFactory.Instance.CreateLinkController(this);
            mouseController = LevelFactory.Instance.CreateLevelController(this);

            ShapeSpriteFactory.Instance.CreateShapeTextures(GraphicsDevice);

            WeaponFactory.Instance.LoadAllTextures(Content);

            EnvironmentFactory.Instance.RegisterGame(this);
            EnvironmentFactory.Instance.LoadAllTextures(Content);
            interactiveEnvironmentObjects = level.CreateInteractiveEnvironmentObjects();

            ItemFactory.Instance.LoadAllTextures(Content);
            itemObjects = level.CreateItemObjects();

            EnemyFactory.Instance.RegisterGame(this);
            EnemyFactory.Instance.LoadAllTextures(Content);
            enemyObjects = level.CreateEnemyObjects();

            levelMap = level.CreateAdjacentLevels();

            CollisionHandler.Instance.RegisterGame(this);
        }


        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            mouseController.Update();
            keyboardController.Update();

            if (isSwitchingLevels)
            {
                CollisionHandler.Instance.Flush();
                var level = new LevelBuilder(this, CurrentRoom);
                Link = LinkFactory.Instance.CreateLink(linkPositionAfterRoomSwitch, this);
                CollisionHandler.Instance.RegisterCollidable(Link, Layer.Player, Layer.Enemy, Layer.Wall, Layer.Pickup, Layer.Projectile);
                
                isSwitchingLevels = false;
                EnvironmentFactory.Instance.RegisterGame(this);
                interactiveEnvironmentObjects = level.CreateInteractiveEnvironmentObjects();
                
                itemObjects = level.CreateItemObjects();

                EnemyFactory.Instance.RegisterGame(this);
                enemyObjects = level.CreateEnemyObjects();

                levelMap = level.CreateAdjacentLevels();
            }

            foreach (IGameObject gameObject in interactiveEnvironmentObjects)
            {
                gameObject.Update(gameTime);
            }

            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Update(gameTime);
            }

            foreach (IGameObject gameObject in itemObjects)
            {
                gameObject.Update(gameTime);
            }


            base.Update(gameTime);

            Link.Update(gameTime);

            CollisionHandler.Instance.CheckCollisions();
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            foreach (IGameObject gameObject in interactiveEnvironmentObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            foreach (IGameObject gameObject in itemObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Draw(spriteBatch);
            }



            Link.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetUpMouseController()
        {
            mouseController = new MouseController();
            mouseController.RegisterCommand(MouseActions.Right, new CycleNextRoom(this), InputState.Pressed);
            mouseController.RegisterCommand(MouseActions.Left, new CyclePrvRoom(this), InputState.Pressed);
        }

        public void EnterRoomTop()
        {
            CurrentRoom = levelMap.Top;
            isSwitchingLevels = true;
            linkPositionAfterRoomSwitch = new Vector2(400, 500);
        }

        public void EnterRoomLeft()
        {
            CurrentRoom = levelMap.Left;
            isSwitchingLevels = true;
            linkPositionAfterRoomSwitch = new Vector2(840, 300);
        }

        public void EnterRoomRight()
        {
            CurrentRoom = levelMap.Right;
            isSwitchingLevels = true;
            linkPositionAfterRoomSwitch = new Vector2(125, 300);
        }

        public void EnterRoomBottom()
        {
            CurrentRoom = levelMap.Bottom;
            isSwitchingLevels = true;
            linkPositionAfterRoomSwitch = new Vector2(400, 150);
        }

        public void CycleRoomNext()
        {
            CurrentRoomNum = (CurrentRoomNum + 1) % TotalRoomNum;
            NextR = true;
        }

        public void CycleRoomLast()
        {
            PreR = true;
            if (CurrentRoomNum == 0)
            {
                CurrentRoomNum = TotalRoomNum - 1;
            }
            else
            {
                CurrentRoomNum--;
                
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        //public LevelFactory levelFactory = LevelFactory.Instance;
        //public List<string> RoomList = levelFactory.CreateRooms();
        public int CurrentRoomNum = 0, TotalRoomNum=5;
        MouseController mouseController;
        KeyboardController keyboardController;
        public string CurrentRoom = "DungeonRoom0";

        bool NextR,PreR = false;

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

            CurrentRoom = CurrentRoom.Substring(0, 11) + CurrentRoomNum;
            var level = new LevelBuilder(this,CurrentRoom );

            LinkFactory.Instance.LoadAllTextures(Content);
            Link = LinkFactory.Instance.CreateLink(new Vector2(256, 256), this);
            CollisionHandler.Instance.RegisterCollidable(Link, Layer.Player, Layer.Enemy, Layer.Wall, Layer.Pickup, Layer.Projectile);

            keyboardController = LinkFactory.Instance.CreateLinkController(this);
            mouseController = LevelFactory.Instance.CreateLevelController(this);

            ShapeSpriteFactory.Instance.CreateShapeTextures(GraphicsDevice);

            WeaponFactory.Instance.LoadAllTextures(Content);

            EnvironmentFactory.Instance.LoadAllTextures(Content);
            interactiveEnvironmentObjects = level.CreateInteractiveEnvironmentObjects();

            ItemFactory.Instance.LoadAllTextures(Content);
            itemObjects = level.CreateItemObjects();

            EnemyFactory.Instance.RegisterGame(this);
            EnemyFactory.Instance.LoadAllTextures(Content);
            enemyObjects = level.CreateEnemyObjects();

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

            if (NextR)
            {
                CurrentRoom = CurrentRoom.Substring(0, 11) + CurrentRoomNum;
                var level = new LevelBuilder(this, CurrentRoom);
                NextR = false;
                interactiveEnvironmentObjects = level.CreateInteractiveEnvironmentObjects();

                ItemFactory.Instance.LoadAllTextures(Content);
                itemObjects = level.CreateItemObjects();

                EnemyFactory.Instance.RegisterGame(this);
                EnemyFactory.Instance.LoadAllTextures(Content);
                enemyObjects = level.CreateEnemyObjects();
            }
            else if (PreR)
            {
                CurrentRoom = CurrentRoom.Substring(0, 11) + CurrentRoomNum;
                var level = new LevelBuilder(this, CurrentRoom);
                PreR = false;
                interactiveEnvironmentObjects = level.CreateInteractiveEnvironmentObjects();

                ItemFactory.Instance.LoadAllTextures(Content);
                itemObjects = level.CreateItemObjects();

                EnemyFactory.Instance.RegisterGame(this);
                EnemyFactory.Instance.LoadAllTextures(Content);
                enemyObjects = level.CreateEnemyObjects();
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

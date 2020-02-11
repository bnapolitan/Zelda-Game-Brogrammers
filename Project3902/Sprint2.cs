using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using Project3902.LevelBuilding.Sprint2Level;
using Project3902.ObjectManagement;
using Project3902.Commands.Sprint2Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3902.GameObjects.Enemies_and_NPCs.Interfaces;

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
    class Sprint2 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<IGameObject> enemyObjects;
        int currentEnemyObject;

        IController<MouseActions> mouseController;

        public Sprint2()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            // Set up keyboard controllers.
            SetUpMouseController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var level = new Sprint2Level();

            // Create player.
            // Create list of all items to be cycled through. Use a Factory class to create them.
            // Same for enemies.

            // Create environment.
            EnemyFactory.Instance.LoadAllTextures(Content);
            enemyObjects = level.CreateEnemyObjects();
            currentEnemyObject = 0;
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            mouseController.Update();
            enemyObjects[currentEnemyObject].Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Point filter keeps pixel art looking crisp.
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // All our drawing code goes here.
            // An IDrawable's Draw() method does not call spriteBatch.Begin() or spriteBatch.End().
            //Environment
            Console.WriteLine("A");
            enemyObjects[currentEnemyObject].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetUpMouseController()
        {
            mouseController = new MouseController();

            mouseController.RegisterCommand(MouseActions.Left, new CycleNextEnemyObjectCommand(this));
            mouseController.RegisterCommand(MouseActions.Right, new CycleLastEnemyObjectCommand(this));
        }

        public void CycleEnemyNext()
        {
            if (currentEnemyObject == enemyObjects.Count - 1)
            {
                currentEnemyObject = 0;
            }
            else
            {
                currentEnemyObject++;
            }
        }

        public void CycleEnemyLast()
        {
            if (currentEnemyObject == 0)
            {
                currentEnemyObject = enemyObjects.Count - 1;
            }
            else
            {
                currentEnemyObject--;
            }
        }

        public void CycleEnvironmentNext()
        {

        }

        public void CycleEnvironmentLast()
        {

        }
    }
}

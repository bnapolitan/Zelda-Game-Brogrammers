using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Sprint2()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            // Set up keyboard controllers.

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create player.
            // Create list of all items to be cycled through. Use a Factory class to create them.
            // Same for enemies.

            // Create environment.
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Point filter keeps pixel art looking crisp.
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // All our drawing code goes here.
            // An IDrawable's Draw() method does not call spriteBatch.Begin() or spriteBatch.End().

            spriteBatch.End();
        }
    }
}

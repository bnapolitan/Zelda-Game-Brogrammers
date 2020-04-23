using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3902.ObjectManagement;

namespace Project3902
{
    class GameOverState
    {
        private FinalGame game;
        public List<IDrawable> ScreenElements = new List<IDrawable>();
        private HUDFactory Factory = HUDFactory.Instance;
        public static GameOverState Instance { get; } = new GameOverState();
        private GameOverState()
        {
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IDrawable obj in ScreenElements)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
            createElements();
        }

        private void createElements()
        {

            ScreenElements.Add(Factory.createTextSection(game.font, "Game Over!\nPress X to restart\n"));
        }
    }
}

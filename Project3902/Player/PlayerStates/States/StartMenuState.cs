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
    class StartMenuState
    {
        private FinalGame game;
        public List<IDrawable> ScreenElements = new List<IDrawable>();
        private HUDFactory Factory = HUDFactory.Instance;
        public static StartMenuState Instance { get; } = new StartMenuState();
        private StartMenuState()
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
            //ScreenElements.Add(EnvironmentFactory.Instance.CreateCoverScreen());
            ScreenElements.Add(Factory.createTextSection(game.font, "Press Enter to start "));

        }
    }
}

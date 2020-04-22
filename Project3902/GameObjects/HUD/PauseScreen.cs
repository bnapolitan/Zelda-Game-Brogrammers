using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Project3902
{
    class PauseScreen
    {
        private FinalGame game;
        private Vector2 PauseScale = new Vector2(4, 4);
        public List<IGameObject> PauseScreenElements = new List<IGameObject>();
        private readonly HUDFactory Factory = HUDFactory.Instance;
        private List<IGameObject> aquiredItems = new List<IGameObject>();
        private int numItemsAquired = 0;
        private bool inPauseScreen;
        public static PauseScreen Instance { get; } = new PauseScreen();
        private PauseScreen()
        {
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IGameObject obj in PauseScreenElements)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
            CreatePauseElements();
        }

        public void CreatePauseElements()
        {
            PauseScreenElements.Add(Factory.CreatePauseInventorySection());
            PauseScreenElements.Add(Factory.CreatePauseMapSection());
            PauseScreenElements.Add(Factory.CreateBlackInventoryBox());
            PauseScreenElements.Add(Factory.CreateTopInventoryBlackBar());
            PauseScreenElements.Add(Factory.CreateItemBlackBox());
            PauseScreenElements.Add(Factory.CreateCompassBlackBox());
            var blackBox = Factory.CreateItemBlackBox();
            blackBox.Position = new Vector2(270, 210);
            PauseScreenElements.Add(blackBox);
            PauseScreenElements.Add(Factory.CreateHUDSword(CalculateNextInventoryPosition()));
            numItemsAquired++;
            
        }

        public void AddMapToPauseScreen()
        {
            var createdObject = ItemFactory.Instance.CreateMap(new Vector2(180,460));
            createdObject.Sprite.Scale = PauseScale;
            var createdPauseMap = new HUDObject(createdObject.Position);
            createdPauseMap.Sprite = createdObject.Sprite;
            PauseScreenElements.Add(createdPauseMap);

        }

        public void AddCompassToPauseScreen()
        {
            PauseScreenElements.Add(Factory.CreatePauseCompass(new Vector2(180, 620)));
        }


        public void addToAquiredItems(IGameObject item)
        {
            bool aquired = false;
           

                if (item is Bow)
                {
                    
                    foreach (IGameObject collected in aquiredItems)
                    {
                        if (collected is Bow)
                        {
                            aquired = true;
                        }
                        
                    }
                    if (aquired == false)
                    {
                        PauseScreenElements.Add(Factory.CreateHUDBow(CalculateNextInventoryPosition()));
                        numItemsAquired++;
                        
                    }
                }
                if (item is Arrow)
                {
                    
                    foreach (IGameObject collected in aquiredItems)
                    {
                        if (collected is Arrow)
                        {
                            aquired = true;
                        }
                        
                    }
                    if (aquired == false)
                    {
                        PauseScreenElements.Add(Factory.CreateHUDArrow(CalculateNextInventoryPosition()));
                        numItemsAquired++;
                        
                    }
                }
                if (item is Candle)
                {
                    foreach (IGameObject collected in aquiredItems)
                    {
                        if (collected is Candle)
                        {
                            aquired = true;
                        }
                       
                    }
                    if (aquired == false)
                    {
                        PauseScreenElements.Add(Factory.CreateHUDCandle(CalculateNextInventoryPosition()));
                        numItemsAquired++;
                        
                    }
                }
            if (item is BoomerangItem)
            {
                foreach (IGameObject collected in aquiredItems)
                {
                    if (collected is BoomerangItem)
                    {
                        aquired = true;
                    }

                }
                if (aquired == false)
                {
                    PauseScreenElements.Add(Factory.CreateHUDBoomerang(CalculateNextInventoryPosition()));
                    numItemsAquired++;

                }
            }
            aquiredItems.Add(item);
           
            
        }

        public Vector2 CalculateNextInventoryPosition()
        {
            Vector2 baseVector = new Vector2(525, 220);
            baseVector.X += (numItemsAquired % 4) * 100;
            baseVector.Y += (numItemsAquired / 4) * 75;
            return baseVector;
            
        }

        public void EnterInventoryScreenControl()
        {
            inPauseScreen = true;
        }

        public void ExitInventoryScreenControl()
        {
            inPauseScreen = false;
        }
    }
}

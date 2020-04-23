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
        private IGameObject SelectedItem;
        private readonly Vector2 SelectedItemPos = new Vector2(280, 220);
        public List<IGameObject> PauseScreenElements = new List<IGameObject>();
        private IGameObject ItemSelector;
        private readonly HUDFactory Factory = HUDFactory.Instance;
        private List<IGameObject> aquiredItems = new List<IGameObject>();
        private List<String> aquiredObjectKeys = new List<String>();
        private int numItemsAquired = 0;
        private int SelectorPos = 0;
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
            foreach (IGameObject obj in PauseScreenElements)
            {
                obj.Draw(spriteBatch);
            }
            if(ItemSelector != null)
            {
                ItemSelector.Draw(spriteBatch);
            }
            SelectedItem.Draw(spriteBatch);
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
            PauseScreenElements.Add(Factory.CreateLowerPauseBorder());
            PauseScreenElements.Add(Factory.CreateSidePauseBorder());
            var blackBox = Factory.CreateItemBlackBox();
            blackBox.Position = new Vector2(270, 210);
            PauseScreenElements.Add(blackBox);
            
            
            SelectedItem = Factory.CreateItemBlackBox();
            SelectedItem.Position = new Vector2(280, 210);

            
        }



        public void AddMapToPauseScreen()
        {
 
            PauseScreenElements.Add(Factory.CreatePauseMap(new Vector2(180, 460)));

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
                        aquiredItems.Add(item);
                        aquiredObjectKeys.Add("Bow");
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
                        aquiredItems.Add(item);
                        aquiredObjectKeys.Add("Arrow");
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
                        aquiredItems.Add(item);
                        aquiredObjectKeys.Add("Candle");
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
                    aquiredItems.Add(item);
                    aquiredObjectKeys.Add("Boomerang");
                    numItemsAquired++;

                }
            }
            if (item is BombPickup)
            {
                foreach (IGameObject collected in aquiredItems)
                {
                    if (collected is BombPickup)
                    {
                        aquired = true;
                    }

                }
                if (aquired == false)
                {
                    PauseScreenElements.Add(Factory.CreateHUDBomb(CalculateNextInventoryPosition()));
                    aquiredItems.Add(item);
                    aquiredObjectKeys.Add("Bomb");
                    numItemsAquired++;

                }
            }
            if(numItemsAquired == 1)
            {
                ItemSelector = Factory.CreateItemSelector(new Vector2(510, 220));
            }



        }

        public Vector2 CalculateNextInventoryPosition()
        {
            Vector2 baseVector = new Vector2(525, 220);
            baseVector.X += (numItemsAquired % 4) * 100;
            baseVector.Y += (numItemsAquired / 4) * 75;
            return baseVector;
            
        }

        public Vector2 CalculateItemSelectorPosition()
        {
            Vector2 baseVector = new Vector2(510, 220);
            baseVector.X += Math.Abs((SelectorPos % 4) * 100);
            baseVector.Y += Math.Abs(((SelectorPos / 4) % 2) * 75);
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

        public void MoveSelectorUp()
        {
            var temp = SelectorPos;
            temp -= 4;
            if (temp >= 0 && temp < numItemsAquired)
            {

                SelectorPos -= 4;
                ItemSelector.Position = CalculateItemSelectorPosition();
            }
        }

        public void MoveSelectorDown()
        {
            var temp = SelectorPos;
            temp += 4;
            if (temp >= 0 && temp < numItemsAquired)
            {

                SelectorPos += 4;
                ItemSelector.Position = CalculateItemSelectorPosition();
            }
        }

        public void MoveSelectorLeft()
        {
            var temp = SelectorPos;
            temp -= 1;
            if (temp >= 0 && temp < numItemsAquired)
            {

                SelectorPos -= 1;
                ItemSelector.Position = CalculateItemSelectorPosition();
            }
        }

        public void MoveSelectorRight()
        {
            var temp = SelectorPos;
            temp += 1;
            if (temp >= 0 && temp < numItemsAquired)
            {

                SelectorPos += 1;
                ItemSelector.Position = CalculateItemSelectorPosition();
            }
        }

        public void SelectItem()
        {
            
            var selectedItem = aquiredItems[SelectorPos];
            if(selectedItem is Sword)
            {
                SelectedItem = Factory.CreateHUDSword(SelectedItemPos);
                HUDManager.Instance.ChangeBItem(Factory.CreateHUDSword(SelectedItemPos), selectedItem);
            }
            if(selectedItem is BoomerangItem)
            {
                SelectedItem = Factory.CreateHUDBoomerang(SelectedItemPos);
                HUDManager.Instance.ChangeBItem(Factory.CreateHUDBoomerang(SelectedItemPos), selectedItem);
            }
            if(selectedItem is Arrow)
            {
                SelectedItem = Factory.CreateHUDArrow(SelectedItemPos);
                HUDManager.Instance.ChangeBItem(Factory.CreateHUDArrow(SelectedItemPos), selectedItem);
            }
            if(selectedItem is Candle)
            {
                SelectedItem = Factory.CreateHUDCandle(SelectedItemPos);
                HUDManager.Instance.ChangeBItem(Factory.CreateHUDCandle(SelectedItemPos), selectedItem);
            }
            if(selectedItem is Bow)
            {
                SelectedItem = Factory.CreateHUDBow(SelectedItemPos);
                HUDManager.Instance.ChangeBItem(Factory.CreateHUDBow(SelectedItemPos), selectedItem);
            }
            if(selectedItem is BombPickup)
            {
                SelectedItem = Factory.CreateHUDBomb(SelectedItemPos);
                HUDManager.Instance.ChangeBItem(Factory.CreateHUDBomb(SelectedItemPos), selectedItem);
            }
        }



    }
    
    
}

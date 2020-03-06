using Project3902.GameObjects;
using System.Collections.Generic;

namespace Project3902
{
    class CollisionHandler
    {
        
        public static CollisionHandler Instance { get; } = new CollisionHandler();
        private FinalGame game;
        private Dictionary<ICollidable, LayerMasksHolder> dict;

        private Dictionary<ICollidable, LayerMasksHolder> toAdd;

        private List<ICollidable> toDelete;

        private CollisionHandler() 
        {
            Flush();
        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
        }
        public void RegisterCollidable(ICollidable collidable, Layer mainLayer, params Layer[] masks)
        {
            var holder = new LayerMasksHolder(mainLayer, masks);
            toAdd.Add(collidable, holder);
        }

        public void RemoveCollidable(ICollidable collidable)
        {
            toDelete.Add(collidable);
            if (collidable is IEnemy)
            {
                game.enemyObjects.Remove(collidable as IGameObject);
            }
            if (collidable is IInteractiveEnvironmentObject)
            {
                game.interactiveEnvironmentObjects.Remove(collidable as IGameObject);
            }
            if (collidable is IItem)
            {
                game.itemObjects.Remove(collidable as IGameObject);
            }
        }

        public void CheckCollisions()
        {
            foreach (var collidable in toDelete)
                dict.Remove(collidable);
            toDelete = new List<ICollidable>();

            foreach (var collidable in toAdd)
                dict.Add(collidable.Key, collidable.Value);
            toAdd = new Dictionary<ICollidable, LayerMasksHolder>();

            foreach (ICollidable collider in dict.Keys)
            {
                foreach (ICollidable collidee in dict.Keys)
                {
                    if (dict[collider].Masks.Contains(dict[collidee].MainLayer))
                    {
                        if (collider.Collider.Intersects(collidee.Collider))
                        {
                            collider.OnCollide(collidee.Collider);
                        }
                    }
                }
            }
        }

        public void Flush()
        {
            dict = new Dictionary<ICollidable, LayerMasksHolder>();
            toAdd = new Dictionary<ICollidable, LayerMasksHolder>();
            toDelete = new List<ICollidable>();
        }
    }
}
